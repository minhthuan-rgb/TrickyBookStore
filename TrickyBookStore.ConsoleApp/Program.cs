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

            var logger = host.Services
                .GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            var paymentService = host.Services.GetService<IPaymentService>();
            var res = paymentService.GetAllPurchaseTransactions();
            
            logger.LogDebug("All Done!");

            Console.WriteLine("Hello World!");
        }
    }
}
