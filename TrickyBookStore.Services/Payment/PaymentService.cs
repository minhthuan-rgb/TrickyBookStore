using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Services.Enums;
using TrickyBookStore.Services.Models;
using TrickyBookStore.Services.PurchaseTransactions;

namespace TrickyBookStore.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        ICustomerService CustomerService { get; }
        IPurchaseTransactionService PurchaseTransactionService { get; }

        public PaymentService(ICustomerService customerService, 
            IPurchaseTransactionService purchaseTransactionService)
        {
            CustomerService = customerService;
            PurchaseTransactionService = purchaseTransactionService;
        }

        public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            double paymentAmount = 0;
            var customer = CustomerService.GetCustomerById(customerId);
            var purchaseTransactions = PurchaseTransactionService.GetPurchaseTransactions(customerId, fromDate, toDate);
            var subscriptions = CustomerService.GetCustomerSubscriptionsById(customerId);
            var books = PurchaseTransactionService.GetCustomerBooks(purchaseTransactions.Select(p => p.BookId).ToArray());
            if (subscriptions.Count > 0)
            {
                foreach (var subscription in subscriptions)
                    paymentAmount += subscription.PriceDetails["FixPrice"];
            }
            else
            {
                foreach (var book in books)
                    if (book.IsOld)
                        paymentAmount += (100 - (int)DiscountPercent.Free) * 1.0 / 100 * book.Price;
                    else paymentAmount += book.Price;
            }

            return paymentAmount;
        }

        public double GetPaymentAmount(long customerId, int year, int month)
        {
            double paymentAmount = 0;
            var customer = CustomerService.GetCustomerById(customerId);
            var subscriptions = CustomerService.GetCustomerSubscriptionsById(customerId);
            var purschaseTransactions = PurchaseTransactionService.GetPurchaseTransactions(customerId, year, month);
            var books = PurchaseTransactionService.GetCustomerBooks(purschaseTransactions.Select(p => p.BookId).ToArray());

            double oldBookDiscount = (double)DiscountPercent.Free;
            double newBookDiscount = (double)DiscountPercent.NoDiscount;

            IList<Counter> counters = new List<Counter>();
            foreach (var subscription in subscriptions)
            {
                paymentAmount += subscription.PriceDetails["FixPrice"];
                counters.Add(new Counter
                {
                    SubscriptionId = subscription.Id,
                    BookCategoryId = subscription.BookCategoryId,
                    NewBookCount = 0,
                });
            }

            Subscription currentSubscription = GetTopPrioritySubscription(subscriptions);

            if (currentSubscription != null)
                oldBookDiscount = currentSubscription.PriceDetails["OldBook"];
            var topOldBookDiscount = oldBookDiscount;

            foreach (var book in books)
            {
                if (subscriptions.FirstOrDefault(s => s.BookCategoryId == book.CategoryId) != null)
                {
                    currentSubscription = subscriptions.First(s => s.BookCategoryId == book.CategoryId);
                    oldBookDiscount = currentSubscription.PriceDetails["OldBook"];
                }
                else
                {
                    currentSubscription = GetTopPrioritySubscription(subscriptions);
                    oldBookDiscount = topOldBookDiscount;
                }

                if (currentSubscription != null)
                    newBookDiscount = currentSubscription.PriceDetails["NewBook"];

                if (book.IsOld)
                    paymentAmount += (100 - oldBookDiscount) / 100 * book.Price;
                else
                {
                    paymentAmount += (100 - newBookDiscount) / 100 * book.Price;
                    if (subscriptions.Count > 0 && ++counters.First(c => c.SubscriptionId == currentSubscription.Id).NewBookCount % 3 == 0)
                    {
                        subscriptions.Remove(currentSubscription);
                        if (subscriptions.Count == 0)
                            newBookDiscount = (double)DiscountPercent.NoDiscount;
                    }
                } 
            }

            return paymentAmount;
        }

        private Subscription GetTopPrioritySubscription(IList<Subscription> subscriptions)
        {
            var tempSubscriptions = subscriptions.Where(s => s.BookCategoryId == null);
            if (tempSubscriptions.Count() == 0)
                return null;

            Subscription topPrioritySubscription = tempSubscriptions.First();
            for (int i = 1; i < subscriptions.Count; i++)
                if (subscriptions[i].Priority < topPrioritySubscription.Priority)
                    topPrioritySubscription = subscriptions[i];
            return topPrioritySubscription;
        }
    }
}
