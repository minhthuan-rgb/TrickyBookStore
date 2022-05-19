using System;
using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Books
{
    internal class BookService : IBookService
    {
        public IList<Book> GetBooks(params long[] ids)
        {
            return (IList<Book>)Store.Books.Data;
        }
    }
}
