using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Store
{
    public static class BookCategories
    {
        public static readonly IEnumerable<BookCategory> Data = new List<BookCategory>
        {
            new BookCategory { Id = 1, Title = "Mystery" },
            new BookCategory { Id = 2, Title = "Thriller" },
            new BookCategory { Id = 3, Title = "Horror" },
            new BookCategory { Id = 4, Title = "Historical" },
            new BookCategory { Id = 5, Title = "Romance" },
            new BookCategory { Id = 6, Title = "Science Fiction" },
            new BookCategory { Id = 7, Title = "Fantasy" },
        };
    }
}
