using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Logic;
using GtMotive.Estimate.Microservice.Host.Models.Vehicle;
using GtMotive.Estimate.Microservice.Host.Models.Vehicle.Mapper;
using GtMotive.Generic.Microservice.Utils.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleLogic vehicleLogic;

        public VehicleController(VehicleLogic logic)
        {
            vehicleLogic = logic;
        }

        [HttpGet("getAll")]
        public async Task<Collection<VehicleDto>> GetAll()
        {
            var vehicleList = await vehicleLogic.GetAll();
            return MapperUtils.MapList(vehicleList, VehicleDtoMapper.MapToDto);
        }

        [HttpPost("create")]
        public async Task<VehicleDto> Create([FromBody] VehicleDto vehicle)
        {
            var vehicleApi = VehicleDtoMapper.MapToApi(vehicle);
            var result = await vehicleLogic.Insert(vehicleApi);
            return VehicleDtoMapper.MapToDto(result);
        }
    }
}
