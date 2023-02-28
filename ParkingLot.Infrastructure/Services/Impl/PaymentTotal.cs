using Microsoft.EntityFrameworkCore;
using ParkingLot.Infrastructure.Database;

namespace ParkingLot.Infrastructure.Services.Impl
{
    public class PaymentTotal : IPaymentTotal
    {
        private readonly ParkingLotDbContext context;

        public PaymentTotal(ParkingLotDbContext context)
        {
            this.context = context;
        }
        public Task<double?> TotalCarPayments(string? vehiclePlate)
        {
            Task<double?> totalPayment =
                (from stays in context.Stays
                 join payments in context.Payments!
                 on stays.StayId equals payments.StayId
                 where stays.VehiclePlate == vehiclePlate
                 select payments.Amount).SumAsync();

            return totalPayment;
        }
    }
}
