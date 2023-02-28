using Microsoft.AspNetCore.Mvc;
using ParkingLot.Api.Extensions;
using ParkingLot.Api.Models;
using ParkingLot.Application.Services;
using ParkingLot.Infrastructure.Services;

namespace ParkingLot.Api.Controllers
{
    [ApiController]
    [Route("api/parkingLot")]
    public class ParkingLotController : ControllerBase
    {
        private readonly IRegisterVehicleService RegisterVehicleService;
        private readonly ICheckInService CheckInService;
        private readonly ICheckOutService CheckOutService;
        private readonly IPaymentTotal PaymentTotal;

        public ParkingLotController(IRegisterVehicleService registerVehicleService, ICheckInService checkInService, ICheckOutService checkOutService, IPaymentTotal paymentTotal)
        {
            RegisterVehicleService = registerVehicleService;
            CheckInService = checkInService;
            CheckOutService = checkOutService;
            PaymentTotal = paymentTotal;
        }

        [HttpPost]
        [Route("registerVehicle")]
        public async Task<IActionResult> RegisterVehicle([FromBody]RegisterVehicleModel vehicle)
        {
            return Created(nameof(RegisterVehicleService.RegisterVehicle),await RegisterVehicleService.RegisterVehicle(vehicle.Plate, vehicle.Brand, vehicle.VehicleType));
        }

        [HttpPost]
        [Route("checkIn")]
        public async Task<IActionResult> CheckIn([FromBody] CheckInModel checkIn)
        {
            return Ok(await CheckInService.CheckInAsync(checkIn.VehiclePlate));
        }

        [HttpPost]
        [Route("checkOut")]
        public async Task<IActionResult> CheckOut([FromBody] CheckInModel checkOut)
        {
            return Ok(await CheckOutService.CheckOutAsync(checkOut.VehiclePlate));
        }

        [HttpGet]
        [Route("totalPayments")]
        public async Task<IActionResult> TotalPayments([FromQuery] string? vehiclePlate)
        {
            return Ok(await PaymentTotal.TotalCarPayments(vehiclePlate));
        }
    }
}
