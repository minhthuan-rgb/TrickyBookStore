using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Enums;

namespace TrickyBookStore.Services.Store
{
    public static class Subscriptions
    {
        public static readonly IEnumerable<Subscription> Data = new List<Subscription>
        {
            new Subscription { Id = 1, SubscriptionType = SubscriptionTypes.Free, Priority = (int)SubscriptionPriority.Free,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.Free },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.Free },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.NoDiscount },
                }
            },
            new Subscription { Id = 2, SubscriptionType = SubscriptionTypes.Paid, Priority = (int)SubscriptionPriority.Paid,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.Paid },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.Paid },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.Paid },
                }
            },
            new Subscription { Id = 3, SubscriptionType = SubscriptionTypes.Premium, Priority = (int)SubscriptionPriority.Premium,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.Premium },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.FreeOfCharge },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.Premium },
                }
            },
            new Subscription { Id = 4, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.CategoryAddicted },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.FreeOfCharge },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.CategoryAddicted },
                },
                BookCategoryId = 1
            },
            new Subscription { Id = 5, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.CategoryAddicted },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.FreeOfCharge },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.CategoryAddicted },
                },
                BookCategoryId = 2
            },
            new Subscription { Id = 6, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.CategoryAddicted },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.FreeOfCharge },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.CategoryAddicted },
                },
                BookCategoryId = 3
            },
            new Subscription { Id = 7, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.CategoryAddicted },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.FreeOfCharge },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.CategoryAddicted },
                },
                BookCategoryId = 4
            },
             new Subscription { Id = 8, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.CategoryAddicted },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.FreeOfCharge },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.CategoryAddicted },
                },
                BookCategoryId = 5
            },
              new Subscription { Id = 9, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.CategoryAddicted },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.FreeOfCharge },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.CategoryAddicted },
                },
                BookCategoryId = 6
            },
               new Subscription { Id = 10, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = (int)SubscriptionPriority.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>
                {
                    { PriceDetailKey.FixPrice, SubscriptionPrice.CategoryAddicted },
                    { PriceDetailKey.OldBook, (double)DiscountPercent.FreeOfCharge },
                    { PriceDetailKey.NewBook, (double)DiscountPercent.CategoryAddicted },
                },
                BookCategoryId = 7
            }
        };
    }
}
