using System.Text.Json.Serialization;

namespace ParkingLot.Domain.Payment.Entities
{
    public class Payment
    {
        public Guid? PaymentId { get; set; }
        public double? Amount { get; set; }
        public Guid? StayId { get; set; }
        [JsonIgnore]
        public Stay.Entities.Stay? Stay { get; set; }
    }
}
