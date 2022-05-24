using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Services.Payment;

namespace TrickyBookStore.ConsoleApp.Injectors
{
    public class PaymentInjector : IPaymentInjector
    {
        IPaymentService PaymentService { get; }
        public PaymentInjector(IPaymentService paymentService)
        {
            PaymentService = paymentService;
        }

        public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            return PaymentService.GetPaymentAmount(customerId, fromDate, toDate);
        }

        public double GetPaymentAmount(long customerId, int year, int month)
        {
            return PaymentService.GetPaymentAmount(customerId, year, month);
        }
    }
}
