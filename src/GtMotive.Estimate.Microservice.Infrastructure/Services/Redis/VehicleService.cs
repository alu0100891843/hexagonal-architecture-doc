using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using Redis.OM;
using Redis.OM.Searching;

namespace GtMotive.Estimate.Microservice.Infrastructure.Services.Redis
{
    public class VehicleService
    {
        private readonly RedisCollection<VehicleRd> vehicleContext;

        public VehicleService(RedisConnectionProvider redisCnn)
        {
            if (redisCnn == null)
            {
                throw new ArgumentNullException(nameof(redisCnn));
            }

            redisCnn.Connection.CreateIndex(typeof(VehicleRd));
            vehicleContext = redisCnn.RedisCollection<VehicleRd>() as RedisCollection<VehicleRd>;
        }

        public async Task<List<VehicleRd>> GetAll()
        {
            return await vehicleContext.ToListAsync() as List<VehicleRd>;
        }

        public async Task<VehicleRd> Create(VehicleRd vehicle)
        {
            /* TODONOW: COMPROBACIONES DE INTEGRIDAD DE LOS ID DE VEHICLE Y RENT
                  ACCIONES COLATERALES PARA EL BORRADO
            */
            await vehicleContext.InsertAsync(vehicle);
            return vehicle;
        }
    }
}
