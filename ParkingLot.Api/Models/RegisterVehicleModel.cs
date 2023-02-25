using ParkingLot.Domain.Vehicle.Enums;

namespace ParkingLot.Api.Models
{
    public class RegisterVehicleModel
    {
        public string? Plate { get; set; }
        public string? Brand { get; set; }
        public VehicleType? VehicleType { get; set; }
    }
}
