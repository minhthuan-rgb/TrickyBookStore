using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;

namespace TrickyBookStore.Services.PurchaseTransactions
{
    // KeepIt
    public interface IPurchaseTransactionService
    {
        IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate);

        IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, int year, int month);

        IList<Book> GetCustomerBooks(params long[] ids);
    }
}
