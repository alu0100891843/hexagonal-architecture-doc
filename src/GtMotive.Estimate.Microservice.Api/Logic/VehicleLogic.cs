using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.Mapper;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Models.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl;
using GtMotive.Generic.Microservice.Domain;
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

        public async Task<Collection<VehicleApi>> GetAll()
        {
            try
            {
                var result = await vehicleService.GetAllAsync();
                return MapperUtils.MapList(result, VehicleDbMapper.MapToApi);
            }
            catch (DomainException)
            {
                throw new DomainException("Ha ocurrido un error al obtener el listado de vehículos");
            }
        }

        public async Task<VehicleApi> GetByPlate(PlateValueObject plate)
        {
            try
            {
                var result = await vehicleService.GetByPlateAsync(plate?.Value);
                return VehicleDbMapper.MapToApi(result);
            }
            catch (DomainException)
            {
                throw new DomainException("Ha ocurrido un error al obtener el vehículo por matrícula");
            }
        }

        public async Task<VehicleApi> Insert(VehicleApi vehicle)
        {
            try
            {
                await vehicleService.InsertAsync(VehicleDbMapper.MapToDb(vehicle));
                return vehicle;
            }
            catch (DomainException)
            {
                throw new DomainException("Ha ocurrido un error al crear el vehículo");
            }
        }
    }
}
