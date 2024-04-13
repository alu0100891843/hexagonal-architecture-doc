using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.Mapper;
using GtMotive.Estimate.Microservice.Domain.Models.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.Services.Redis.Impl;
using GtMotive.Generic.Microservice.Utils.Mappers;

namespace GtMotive.Estimate.Microservice.Api.Logic
{
    public class VehicleLogic
    {
        private readonly VehicleService vehicleService;

        public VehicleLogic(VehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        public async Task<VehicleApi> Create(VehicleApi vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentException("La información del vehículo está vacía");
            }

            var result = await vehicleService.Create(VehicleRdMapper.MapToRd(vehicle));
            return VehicleRdMapper.MapToApi(result);
        }

        public async Task<Collection<VehicleApi>> GetAll()
        {
            var result = await vehicleService.GetAll();
            return MapperUtils.MapList(result, VehicleRdMapper.MapToApi);
        }
    }
}
