using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Subscriptions
{
    internal class SubscriptionService : ISubscriptionService
    {
        public IList<Subscription> GetSubscriptions(params int[] ids)
        {
            return (IList<Subscription>)Store.Subscriptions.Data;
        }
    }
}
