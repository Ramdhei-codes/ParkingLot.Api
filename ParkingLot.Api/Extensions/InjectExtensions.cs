using Microsoft.EntityFrameworkCore;
using ParkingLot.Application.Services;
using ParkingLot.Application.Services.Impl;
using ParkingLot.Domain.Shared;
using ParkingLot.Infrastructure.Database;
using ParkingLot.Infrastructure.Shared;

namespace ParkingLot.Api.Extensions
{
    public static class InjectExtensions
    {
        public static void Inject(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IRegisterVehicleService, RegisterVehicleService>();
            builder.Services.AddDbContext<ParkingLotDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("connParkingDB")));
        }
    }
}
