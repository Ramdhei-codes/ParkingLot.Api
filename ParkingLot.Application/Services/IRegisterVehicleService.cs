using ParkingLot.Domain.Vehicle.Entities;
using ParkingLot.Domain.Vehicle.Enums;

namespace ParkingLot.Application.Services
{
    public interface IRegisterVehicleService
    {
        Task<Vehicle> RegisterVehicle(string? plate, string? brand, VehicleType? type);
    }
}
