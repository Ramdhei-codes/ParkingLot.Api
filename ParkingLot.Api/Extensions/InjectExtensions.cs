using Microsoft.EntityFrameworkCore;
using ParkingLot.Infrastructure;

namespace ParkingLot.Api.Extensions
{
    public static class InjectExtensions
    {
        public static void Inject(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ParkingLotDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("connParkingDB"), b => b.MigrationsAssembly("ParkingLot.Api")));
        }
    }
}
