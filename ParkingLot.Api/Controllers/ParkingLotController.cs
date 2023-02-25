using Microsoft.AspNetCore.Mvc;
using ParkingLot.Api.Models;
using ParkingLot.Application.Services;

namespace ParkingLot.Api.Controllers
{
    [ApiController]
    [Route("api/parkingLot")]
    public class ParkingLotController : ControllerBase
    {
        IRegisterVehicleService RegisterVehicleService { get; set; }

        public ParkingLotController(IRegisterVehicleService registerVehicleService)
        {
            RegisterVehicleService = registerVehicleService;
        }

        [HttpPost]
        [Route("registerVehicle")]
        public async Task<IActionResult> RegisterVehicle([FromBody]RegisterVehicleModel vehicle)
        {
            return Ok(await RegisterVehicleService.RegisterVehicle(vehicle.Plate, vehicle.Brand, vehicle.VehicleType));
        }
    }
}
