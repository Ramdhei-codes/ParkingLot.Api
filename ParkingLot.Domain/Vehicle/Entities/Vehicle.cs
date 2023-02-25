using ParkingLot.Domain.Vehicle.Enums;

namespace ParkingLot.Domain.Vehicle.Entities
{
    public class Vehicle
    {
        public string? Plate { get; set; }
        public string? Brand { get; set; }
        public VehicleType? VehicleType { get; set; }
        public IEnumerable<Stay.Entities.Stay>? Stays { get; set; }
    }
}
