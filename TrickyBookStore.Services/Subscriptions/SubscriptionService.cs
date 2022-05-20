using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Subscriptions
{
    internal class SubscriptionService : ISubscriptionService
    {
        public IList<Subscription> GetSubscriptions(params int[] ids)
        {
            return Store.Subscriptions.Data.Where(s => ids.Contains(s.Id)).Select(s => s).ToList();
        }
    }
}
