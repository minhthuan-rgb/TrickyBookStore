using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Enums;

namespace TrickyBookStore.Services.Store
{
    public static class Subscriptions
    {
        public static readonly IEnumerable<Subscription> Data = new List<Subscription>
        {
            new Subscription { Id = 2, SubscriptionType = SubscriptionTypes.Free, Priority = (int)SubscriptionPriority.Free,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", SubscriptionPrice.Free }
                }
            },
            new Subscription { Id = 1, SubscriptionType = SubscriptionTypes.Paid, Priority = (int)SubscriptionPriority.Paid,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", SubscriptionPrice.Paid },
                }
            },
            new Subscription { Id = 3, SubscriptionType = SubscriptionTypes.Premium, Priority = (int)SubscriptionPriority.Premium,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrcie", SubscriptionPrice.Premium }
                }
            },
            new Subscription { Id = 4, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", SubscriptionPrice.CategoryAddicted }
                },
                BookCategoryId = 1
            },
            new Subscription { Id = 5, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", SubscriptionPrice.CategoryAddicted },
                },
                BookCategoryId = 2
            },
            new Subscription { Id = 6, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", SubscriptionPrice.CategoryAddicted },
                },
                BookCategoryId = 3
            },
            new Subscription { Id = 7, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", SubscriptionPrice.CategoryAddicted }
                },
                BookCategoryId = 4
            },
             new Subscription { Id = 8, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", SubscriptionPrice.CategoryAddicted }
                },
                BookCategoryId = 5
            },
              new Subscription { Id = 9, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", SubscriptionPrice.CategoryAddicted }
                },
                BookCategoryId = 6
            },
               new Subscription { Id = 10, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", SubscriptionPrice.CategoryAddicted }
                },
                BookCategoryId = 7
            }
        };
    }
}
