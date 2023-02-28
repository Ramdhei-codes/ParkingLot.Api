using ParkingLot.Domain.Payment.Entities;
using ParkingLot.Domain.Shared;
using ParkingLot.Domain.Stay.Entities;

namespace ParkingLot.Application.Services.Impl
{
    public class CheckOutService : ICheckOutService
    {
        private readonly IRepository<Stay> StayRepository;
        private readonly IRepository<Payment> PaymentRepository;

        public CheckOutService(IRepository<Stay> stayRepository, IRepository<Payment> paymentRepository)
        {
            StayRepository = stayRepository;
            PaymentRepository = paymentRepository;
        }

        public async Task<Stay> CheckOutAsync(string? vehiclePlate)
        {
            Stay currentStay = (await StayRepository.GetByFilterAsync(stay => stay.VehiclePlate! == vehiclePlate && stay.CheckOutTime == null)).FirstOrDefault()!;

            currentStay.CheckOutTime = DateTime.Now;

            await GeneratePayment(currentStay);

            await StayRepository.UpdateAsync(currentStay);
            await StayRepository.SaveChangesAsync();

            return currentStay;
        }
        public double CalculateStayPrice(DateTime? checkInDate, DateTime? checkOutDate)
        {
            TimeSpan? stayTime = checkOutDate - checkInDate;

            double totalStayPrice = stayTime!.Value.TotalMinutes * 0.5;

            return totalStayPrice;
        }

        public async Task GeneratePayment(Stay? stay)
        {
            double stayPrice = CalculateStayPrice(stay!.CheckInTime, stay!.CheckOutTime);

            Payment payment = new Payment
            {
                Amount = stayPrice,
                StayId = stay.StayId
            };

            await PaymentRepository.InsertAsync(payment);
            await PaymentRepository.SaveChangesAsync();
        }
    }
}
