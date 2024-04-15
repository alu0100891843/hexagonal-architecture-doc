using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Logic;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
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
        public async Task<ActionResult<Collection<VehicleDto>>> GetAll()
        {
            var vehicleList = await vehicleLogic.GetAll();
            return Ok(MapperUtils.MapList(vehicleList, VehicleDtoMapper.MapToDto));
        }

        [HttpGet("getByPlate")]
        public async Task<ActionResult<VehicleDto>> GetByPlate([FromQuery] string plate)
        {
            if (string.IsNullOrEmpty(plate))
            {
                return BadRequest("La consulta no ha recibido el parámetro 'plate'");
            }

            var vehicle = await vehicleLogic.GetByPlate(new PlateValueObject(plate));
            return Ok(VehicleDtoMapper.MapToDto(vehicle));
        }

        [HttpPost("create")]
        public async Task<ActionResult<VehicleDto>> Create([FromBody] VehicleDto vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("La consulta no ha recibido el parámetro 'vehicle'");
            }

            var vehicleApi = VehicleDtoMapper.MapToApi(vehicle);
            var result = await vehicleLogic.Insert(vehicleApi);
            return Ok(VehicleDtoMapper.MapToDto(result));
        }
    }
}
