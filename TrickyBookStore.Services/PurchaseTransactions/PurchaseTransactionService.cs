using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;

namespace TrickyBookStore.Services.PurchaseTransactions
{
    internal class PurchaseTransactionService : IPurchaseTransactionService
    {
        IBookService BookService { get; }

        public PurchaseTransactionService(IBookService bookService)
        {
            BookService = bookService;
        }

        public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            return Store.PurchaseTransactions.Data.Where(p => p.CustomerId.Equals(customerId) && 
                                                                                            p.CreatedDate >= fromDate &&
                                                                                            p.CreatedDate <= toDate).Select(p => p).ToList();
        }

        public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, int year, int month)
        {
            return (IList<PurchaseTransaction>)Store.PurchaseTransactions.Data.Where(p => p.CustomerId.Equals(customerId) &&
                                                                                            p.CreatedDate.Month.Equals(month) &&
                                                                                            p.CreatedDate.Year.Equals(year)).ToList();
        }

        public IList<Book> GetCustomerBooks (params long[] ids)
        {
            return BookService.GetBooks(ids);
        }
    }
}
