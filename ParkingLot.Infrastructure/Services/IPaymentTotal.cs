namespace ParkingLot.Infrastructure.Services
{
    public interface IPaymentTotal
    {
        Task<double?> TotalCarPayments(string? vehiclePlate);
    }
}
