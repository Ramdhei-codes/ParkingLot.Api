using ParkingLot.Domain.Stay.Entities;

namespace ParkingLot.Application.Services
{
    public interface ICheckInService
    {
        Task<Stay> CheckInAsync(string? vehiclePlate);
    }
}
