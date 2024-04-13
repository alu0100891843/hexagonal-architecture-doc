using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.Services.Redis.Impl;

namespace GtMotive.Estimate.Microservice.Api.Logic
{
    public class VehicleLogic
    {
        private readonly VehicleService vehicleService;

        public VehicleLogic(VehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        public async Task<VehicleRd> Create(VehicleRd vehicle)
        {
            return await vehicleService.Create(vehicle);
        }

        public async Task<List<VehicleRd>> GetAll()
        {
            return await vehicleService.GetAll();
        }
    }
}
