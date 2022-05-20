using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyBookStore.Services.Models
{
    public class Counter
    {
        public int SubscriptionId { get; set; }
        public int? BookCategoryId { get; set; }
        public int NewBookCount { get; set; }
    }
}
