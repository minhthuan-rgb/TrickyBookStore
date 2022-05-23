using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Services.Enums;

namespace TrickyBookStore.Services.Models
{
    public class Discount
    {
        public double OldBookPercent { get; set; }
        public double NewBookPercent { get; set; }

        public Discount()
        {
            OldBookPercent = (double)DiscountPercent.Free;
            NewBookPercent = (double)DiscountPercent.NoDiscount;
        }
    }
}
