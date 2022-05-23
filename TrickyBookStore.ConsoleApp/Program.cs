using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using TrickyBookStore.Services.DI_Services;
using TrickyBookStore.Services.Payment;

namespace TrickyBookStore.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = (IHost)Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddScoped<IPaymentService, PaymentService>()
                            .AddService()
                ).Build();

            var paymentService = host.Services.GetService<IPaymentService>();

            //var paymentAmount = paymentService.GetPaymentAmount(1, 2018, 1);

            var paymentAmount = paymentService.GetPaymentAmount(1, new DateTimeOffset(new DateTime(2018, 1, 1)), new DateTimeOffset(new DateTime(2019, 2, 28)));

            Console.WriteLine($"Payment Amount: {paymentAmount}");

            host.Dispose();
        }
    }
}
