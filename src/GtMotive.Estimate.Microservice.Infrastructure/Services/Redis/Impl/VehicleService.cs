using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.Services.Redis.Impl.Parent;

namespace GtMotive.Estimate.Microservice.Infrastructure.Services.Redis.Impl
{
    public class VehicleService : RedisService
    {
        public VehicleService(RedisContext redisContext)
            : base(redisContext)
        {
        }

        public async Task<List<VehicleRd>> GetAll()
        {
            return await RedisContext.VehicleContext.ToListAsync() as List<VehicleRd>;
        }

        public async Task<VehicleRd> Create(VehicleRd vehicle)
        {
            /* TODONOW: COMPROBACIONES DE INTEGRIDAD DE LOS ID DE VEHICLE Y RENT
                  ACCIONES COLATERALES PARA EL BORRADO
            */
            await RedisContext.VehicleContext.InsertAsync(vehicle);
            return vehicle;
        }
    }
}
