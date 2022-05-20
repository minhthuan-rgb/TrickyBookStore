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
            using IHost host = (IHost)Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddLogging()
                    .AddScoped<IPaymentService, PaymentService>()
                    .AddService()
                ).Build();

            var paymentService = host.Services.GetService<IPaymentService>();

            var res = paymentService.GetPaymentAmount(1, 2018, 1);

            Console.WriteLine($"Result: {res}");
        }
    }
}
