using ParkingLot.Domain.Shared;
using ParkingLot.Domain.Stay.Entities;
using ParkingLot.Domain.Vehicle.Entities;

namespace ParkingLot.Application.Services.Impl
{
    public class CheckInService : ICheckInService
    {
        private readonly IRepository<Stay> StayRepository;

        public CheckInService(IRepository<Stay> stayRepository, IRepository<Vehicle> vehicleRepository)
        {
            StayRepository = stayRepository;
        }

        public async Task<Stay> CheckInAsync(string? vehiclePlate)
        {
            Stay checkIn = new Stay
            {
                CheckInTime = DateTime.Now,
                VehiclePlate = vehiclePlate
            };

            await StayRepository.InsertAsync(checkIn);
            await StayRepository.SaveChangesAsync();

            return checkIn;
        }
    }
}
