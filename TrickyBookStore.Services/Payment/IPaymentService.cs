using System;
using System.Collections.Generic;
using TrickyBookStore.Models;

// KeepIt
namespace TrickyBookStore.Services.Payment
{
    public interface IPaymentService
    {
        double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate);

        double GetPaymentAmount(long customerId, int year, int month);
    }
}
