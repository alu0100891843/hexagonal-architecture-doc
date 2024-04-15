using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.Mapper;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Models.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Utils.Mappers;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Api.Logic
{
    public class VehicleLogic
    {
        private readonly VehicleService vehicleService;

        public VehicleLogic(VehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        public async Task<Collection<VehicleApi>> GetAll()
        {
            try
            {
                var result = await vehicleService.GetAllAsync();
                return MapperUtils.MapList(result, VehicleDbMapper.MapToApi);
            }
            catch (MongoException)
            {
                throw new MongoException("Ha ocurrido un error al obtener los clientes");
            }
        }

        public async Task<VehicleApi> GetByPlate(PlateValueObject plate)
        {
            var result = await vehicleService.GetByPlateAsync(plate?.Value);
            return VehicleDbMapper.MapToApi(result);
        }

        public async Task<VehicleApi> Insert(VehicleApi vehicle)
        {
            try
            {
                await vehicleService.InsertAsync(VehicleDbMapper.MapToDb(vehicle));
                return vehicle;
            }
            catch (MongoException)
            {
                throw new MongoException("Ha ocurrido un error al crear el vehículo");
            }
        }
    }
}
