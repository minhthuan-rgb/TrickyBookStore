using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Store
{
    public static class Customers
    {
        public static readonly IEnumerable<Customer> Data = new List<Customer>
        {
            new Customer{ Id = 1, Name = "Phạm Minh Thuận", SubscriptionIds = new List<int> { 1 } },
            new Customer{ Id = 2, Name = "Phạm Minh Thành", SubscriptionIds = new List<int> { } },
            new Customer{ Id = 3, Name = "Phạm Minh Thiện", SubscriptionIds = new List<int> { 3 } },
            new Customer{ Id = 4, Name = "Phạm Nguyễn Phương Thảo", SubscriptionIds = new List<int> { 6 } },
            new Customer{ Id = 5, Name = "Phạm Nguyễn Minh Thư", SubscriptionIds = new List<int> { 1, 5, 4 } },
            new Customer{ Id = 6, Name = "Phạm Đức Thịnh", SubscriptionIds = new List<int> { 1, 3, 5, 4 } },
            new Customer{ Id = 7, Name = "Phạm Minh Thông", SubscriptionIds = new List<int> { 4 } },
        };
    }
}
