using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Store
{
    public static class Books
    {
        public static readonly IEnumerable<Book> Data = new List<Book>
        {
            new Book { Id = 1, Title = "And Then There Were None", CategoryId = 1, IsOld = true, Price = 34 },
            new Book { Id = 2, Title = "Into the Dark", CategoryId = 2, IsOld = true, Price = 25 },
            new Book { Id = 3, Title = "The Loop", CategoryId = 3, IsOld = true, Price = 20 },
            new Book { Id = 4, Title = "What Is History?", CategoryId = 4, IsOld = true, Price = 16 },
            new Book { Id = 5, Title = "Harvest Home", CategoryId = 3, IsOld = true, Price = 9.99 },
            new Book { Id = 6, Title = "The Big Sleep", CategoryId = 1, IsOld = false, Price = 70 },
            new Book { Id = 7, Title = "The Murders at Fleat House", CategoryId = 2, IsOld = false, Price = 69 },
            new Book { Id = 8, Title = "The Other Black Girl", CategoryId = 3, IsOld = false, Price = 55 },
            new Book { Id = 9, Title = "1491", CategoryId = 4, IsOld = false, Price = 88 },
            new Book { Id = 10, Title = "Out Of Her Depth", CategoryId = 2, IsOld = false, Price = 76 },
            new Book { Id = 11, Title = "Perfect People", CategoryId = 2, IsOld = false, Price = 85 },
            new Book { Id = 12, Title = "Gone Girl", CategoryId = 1, IsOld = false, Price = 74 },
            new Book { Id = 13, Title = "The Melting", CategoryId = 2, IsOld = false, Price = 65 },
            new Book { Id = 14, Title = "The Auctioneer", CategoryId = 3, IsOld = false, Price = 45 },
            new Book { Id = 15, Title = "The Postman Always Rings Twice", CategoryId = 1, IsOld = false, Price = 33 },
            new Book { Id = 16, Title = "In Cold Blood", CategoryId = 1, IsOld = false, Price = 81 },
            new Book { Id = 17, Title = "Precolonial Black Africa", CategoryId = 4, IsOld = false, Price = 42 },
            new Book { Id = 18, Title = "Stalin's Englishman: The Lives of Guy Burgess", CategoryId = 2, IsOld = false, Price = 82 },

            new Book { Id = 19, Title = "Beautiful World, Where Are You", CategoryId = 5, IsOld = true, Price = 25 },
            new Book { Id = 20, Title = "Sea of Tranquillity", CategoryId = 6, IsOld = true, Price = 69 },
            new Book { Id = 21, Title = "The Fifth Season", CategoryId = 7, IsOld = true, Price = 74 },
            new Book { Id = 22, Title = "The Proposal", CategoryId = 5, IsOld = true, Price = 20 },
            new Book { Id = 23, Title = "Classic Science Fiction Stories", CategoryId = 6, IsOld = true, Price = 55 },
            new Book { Id = 24, Title = "The Fellowship Of The Ring", CategoryId = 7, IsOld = true, Price = 65 },
            new Book { Id = 25, Title = "Seven Days in June", CategoryId = 5, IsOld = true, Price = 16 },
            new Book { Id = 26, Title = "Weaponized", CategoryId = 6, IsOld = true, Price = 88 },
            new Book { Id = 27, Title = "A Wizard Of Earthsea", CategoryId = 7, IsOld = true, Price = 45 },
            new Book { Id = 28, Title = "The Guns of August", CategoryId = 4, IsOld = true, Price = 34 },
            new Book { Id = 29, Title = "The Hating Game", CategoryId = 5, IsOld = true, Price = 9.99 },
            new Book { Id = 30, Title = "The Kaiju Preservation Society", CategoryId = 6, IsOld = true, Price = 76 },
            new Book { Id = 31, Title = "The Grace of Kings", CategoryId = 7, IsOld = true, Price = 34 },
            new Book { Id = 32, Title = "The Hunger", CategoryId = 3, IsOld = false, Price = 85 },
            new Book { Id = 33, Title = "Parallel Lives", CategoryId = 4, IsOld = false, Price = 33 },
            new Book { Id = 34, Title = "Vision In White", CategoryId = 5, IsOld = false, Price = 70 },
            new Book { Id = 35, Title = "Eyes of the Void", CategoryId = 6, IsOld = false, Price = 85 },
            new Book { Id = 36, Title = "Who Fears Death", CategoryId = 7, IsOld = false, Price = 33 },
        };
    }
}
