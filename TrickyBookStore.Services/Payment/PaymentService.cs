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
            var subscriptions = CustomerService.GetCustomerSubscriptionsById(customerId);
            if (fromDate.Month == toDate.Month && fromDate.Year == toDate.Year)
            {
                var purchaseTransactions = PurchaseTransactionService
                                            .GetPurchaseTransactions(customerId, fromDate, toDate);
                return GetPaymentAmount(customerId, purchaseTransactions);
            }    
            else
            {
                double paymentAmount = 0;
                paymentAmount += GetPaymentAmountFirstMonth(customerId, fromDate);
                paymentAmount += GetPaymentAmountLastMonth(customerId, toDate);

                if (fromDate.Year == toDate.Year)
                    for (int i = fromDate.Month + 1; i < toDate.Month; i++)
                        paymentAmount += GetPaymentAmountWithinMonth(customerId, toDate.Year, i);
                else
                {
                    paymentAmount += GetPaymentAmountFirstYear(customerId, fromDate);
                    paymentAmount += GetPaymentAmountLastYear(customerId, toDate);
                    
                    for (int i = fromDate.Year + 1; i < toDate.Year; i++)
                        for (int j = 1; j <= 12; j++)
                            paymentAmount += GetPaymentAmountWithinMonth(customerId, i, j);
                }
                return paymentAmount;
            }
        }

        public double GetPaymentAmount(long customerId, int year, int month)
        {
            
            var purchaseTransactionsWithinMonth = PurchaseTransactionService.GetPurchaseTransactions(customerId, year, month);

            return GetPaymentAmount(customerId, purchaseTransactionsWithinMonth);
        }

        private double GetPaymentAmount(long customerId, IList<PurchaseTransaction> purchaseTransactions)
        {
            double paymentAmount = 0;
            var subscriptions = CustomerService.GetCustomerSubscriptionsById(customerId);
            var books = PurchaseTransactionService.GetPurchasedBooks(purchaseTransactions.Select(p => p.BookId).ToArray());

            IList<Counter> counters = new List<Counter>();
            foreach (var subscription in subscriptions)
            {
                paymentAmount += subscription.PriceDetails["FixPrice"];
                counters.Add(new Counter
                {
                    SubscriptionId = subscription.Id,
                    NewBookCount = 0,
                });
            }
            var bookDiscount = new Discount();
            Subscription currentSubscription = GetTopPrioritySubscription(subscriptions);

            if (currentSubscription != null)
                bookDiscount.OldBookPercent = currentSubscription.PriceDetails["OldBook"];
            var topOldBookDiscount = bookDiscount.OldBookPercent;

            foreach (var book in books)
            {
                if (subscriptions.FirstOrDefault(s => s.BookCategoryId == book.CategoryId) != null)
                {
                    currentSubscription = subscriptions.First(s => s.BookCategoryId == book.CategoryId);
                    bookDiscount.OldBookPercent = currentSubscription.PriceDetails["OldBook"];
                }
                else
                {
                    currentSubscription = GetTopPrioritySubscription(subscriptions);
                    bookDiscount.OldBookPercent = topOldBookDiscount;
                }

                if (currentSubscription != null)
                    bookDiscount.NewBookPercent = currentSubscription.PriceDetails["NewBook"];

                if (book.IsOld)
                    paymentAmount += (100 - bookDiscount.OldBookPercent) / 100 * book.Price;
                else
                {
                    paymentAmount += (100 - bookDiscount.NewBookPercent) / 100 * book.Price;
                    if (subscriptions.Count > 0 && ++counters.First(c => c.SubscriptionId == currentSubscription.Id).NewBookCount == 3)
                    {
                        subscriptions.Remove(currentSubscription);
                        if (subscriptions.Count == 0)
                            bookDiscount.NewBookPercent = (double)DiscountPercent.NoDiscount;
                    }
                }
            }

            return paymentAmount;
        }

        private double GetPaymentAmountFirstMonth(long customerId, DateTimeOffset fromDate)
        {
            var purchaseTransactionsFirstMonth = PurchaseTransactionService 
                                                    .GetPurchaseTransactions(customerId, fromDate,
                                                                                new DateTimeOffset(new DateTime(fromDate.Year, fromDate.Month, 1).AddMonths(1).AddDays(-1)));
            return GetPaymentAmount(customerId, purchaseTransactionsFirstMonth);
        }

        private double GetPaymentAmountLastMonth(long customerId, DateTimeOffset toDate)
        {
            var purchaseTransactionsLastMonth = PurchaseTransactionService
                                                    .GetPurchaseTransactions(customerId, new DateTimeOffset(new DateTime(toDate.Year, toDate.Month, 1)), toDate);
            return GetPaymentAmount(customerId, purchaseTransactionsLastMonth);
        }

        private double GetPaymentAmountFirstYear(long customerId, DateTimeOffset fromDate)
        {
            double paymentAmount = 0;
            for (int i = fromDate.Month + 1; i <= 12; i++)
            {
                paymentAmount += GetPaymentAmountWithinMonth(customerId, fromDate.Year, i);
            }
            return paymentAmount;
        }

        private double GetPaymentAmountLastYear(long customerId, DateTimeOffset toDate)
        {
            double paymentAmount = 0;
            for (int i = 1; i < toDate.Month; i++)
            {
                paymentAmount += GetPaymentAmountWithinMonth(customerId, toDate.Year, i);
            }
            return paymentAmount;
        }

        private double GetPaymentAmountWithinMonth(long customerId, int year, int month)
        {
            var purchaseTransactionsWithinMonth = PurchaseTransactionService
                                                                .GetPurchaseTransactions(customerId, new DateTimeOffset(new DateTime(year, month, 1)),
                                                                                            new DateTimeOffset(new DateTime(year, month, 1).AddMonths(1).AddDays(-1)));
            return GetPaymentAmount(customerId, purchaseTransactionsWithinMonth);
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
