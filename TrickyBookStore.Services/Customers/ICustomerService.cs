using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Subscriptions;

// KeepIt
namespace TrickyBookStore.Services.Customers
{
    public interface ICustomerService
    {
        Customer GetCustomerById(long id);

        IList<Subscription> GetCustomerSubscriptionsById(long id);
    }
}
