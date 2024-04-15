using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.OldVehicle.Mapper;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl;
using GtMotive.Generic.Microservice.Domain;
using GtMotive.Generic.Microservice.Utils.Mappers;

namespace GtMotive.Estimate.Microservice.Api.Logic
{
    public class OldVehicleLogic
    {
        private readonly OldVehicleService oldVehicleService;

        public OldVehicleLogic(OldVehicleService oldVehicleService)
        {
            this.oldVehicleService = oldVehicleService;
        }

        public async Task<Collection<OldVehicleApi>> GetAll()
        {
            try
            {
                var result = await oldVehicleService.GetAllAsync();
                return MapperUtils.MapList(result, OldVehicleDbMapper.MapToApi);
            }
            catch (DomainException)
            {
                throw new DomainException("Ha ocurrido un error al obtener el listado de vehículos antiguos");
            }
        }
    }
}
