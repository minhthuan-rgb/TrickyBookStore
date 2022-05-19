﻿using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Services.Customers;
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
            throw new NotImplementedException();
        }

        public double GetPaymentAmountWithinMonth(int year, int month, long customerId)
        {
            throw new NotImplementedException();
        }

        public IList<PurchaseTransaction> GetAllPurchaseTransactions()
        {
            return PurchaseTransactionService.GetAllPurchaseTransactions();
        }
    }
}
