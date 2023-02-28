using ParkingLot.Domain.Payment.Entities;
using ParkingLot.Domain.Stay.Entities;

namespace ParkingLot.Application.Services
{
    public interface ICheckOutService
    {
        Task<Stay> CheckOutAsync(string? vehiclePlate);

        Task GeneratePayment(Stay? stay);

        double CalculateStayPrice(DateTime? checkInDate, DateTime? checkOutDate);
    }
}
