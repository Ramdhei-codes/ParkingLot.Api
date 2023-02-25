using ParkingLot.Domain.Payment.Entities;

namespace ParkingLot.Domain.Stay.Entities
{
    public class Stay
    {
        public Guid? StayId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string? VehiclePlate { get; set; }
        public Vehicle.Entities.Vehicle? Vehicle { get; set; }
        public Payment.Entities.Payment? Payment { get; set; }
    }
}
