using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Books
{
    internal class BookService : IBookService
    {
        public IList<Book> GetBooks(params long[] ids)
        {
            return Store.Books.Data.Where(b => ids.Contains(b.Id)).Select(b => b).ToList();
        }
    }
}
