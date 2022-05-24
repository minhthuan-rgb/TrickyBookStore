using Microsoft.Extensions.DependencyInjection;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Services.Payment;
using TrickyBookStore.Services.PurchaseTransactions;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services.DI_Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPurchaseTransactionService, PurchaseTransactionService>();
            services.AddScoped<IBookService, BookService>();
        }
    }
}
