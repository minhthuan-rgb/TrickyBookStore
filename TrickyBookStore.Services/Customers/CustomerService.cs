using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services.Customers
{
    internal class CustomerService : ICustomerService
    {
        ISubscriptionService SubscriptionService { get; }

        public CustomerService(ISubscriptionService subscriptionService)
        {
            SubscriptionService = subscriptionService;
        }

        public Customer GetCustomerById(long id)
        {
            var customer = Store.Customers.Data.FirstOrDefault(c => c.Id.Equals(id));
            if (customer == null)
                throw new Exception("This Customer Not Exists!");
            return customer;
        }

        public IList<Subscription> GetCustomerSubscriptionsById(long id)
        {
            return SubscriptionService.GetSubscriptions(GetCustomerById(id).SubscriptionIds.ToArray());
        }
    }
}
