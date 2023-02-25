using ParkingLot.Domain.Shared;
using ParkingLot.Domain.Vehicle.Entities;
using ParkingLot.Domain.Vehicle.Enums;

namespace ParkingLot.Application.Services.Impl
{
    public class RegisterVehicleService : IRegisterVehicleService
    {
        private readonly IRepository<Vehicle> VehicleRepository;

        public RegisterVehicleService(IRepository<Vehicle> vehicleRepository)
        {
            VehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> RegisterVehicle(string? plate, string? brand, VehicleType? type)
        {
            Vehicle vehicle = new Vehicle
            {
                Plate = plate,
                Brand = brand,
                VehicleType = type
            };
            await VehicleRepository.InsertAsync(vehicle);
            await VehicleRepository.SaveChangesAsync();

            return vehicle;
        }
    }
}
