using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using TrickyBookStore.ConsoleApp.Injectors;
using TrickyBookStore.Services.DI_Services;
using TrickyBookStore.Services.Payment;

namespace TrickyBookStore.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddScoped<IPaymentInjector, PaymentInjector>()
                    .AddService()
                ).Build();

            var paymentInjector = host.Services.GetRequiredService<IPaymentInjector>();
            try
            {
                //var paymentAmount = paymentService.GetPaymentAmount(1, 2018, 1);

                var paymentAmount = paymentInjector.GetPaymentAmount(1, new DateTimeOffset(new DateTime(2018, 1, 1)), new DateTimeOffset(new DateTime(2019, 2, 28)));

                Console.WriteLine($"Payment Amount: {paymentAmount}$");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            host.Dispose();
        }
    }
}
