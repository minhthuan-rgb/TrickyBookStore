using System;
using System.Collections.Generic;
using TrickyBookStore.Models;

// KeepIt
namespace TrickyBookStore.Services.Payment
{
    public interface IPaymentService
    {
        double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate);

        double GetPaymentAmountWithinMonth(int year, int month, long customerId);

        IList<PurchaseTransaction> GetAllPurchaseTransactions();
    }
}
