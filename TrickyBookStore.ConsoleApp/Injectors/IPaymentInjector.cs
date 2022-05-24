using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyBookStore.ConsoleApp.Injectors
{
    public interface IPaymentInjector
    {
        double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate);

        double GetPaymentAmount(long customerId, int year, int month);
    }
}
