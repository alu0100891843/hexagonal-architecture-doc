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
    public class OldVehicleController : ControllerBase
    {
        private readonly OldVehicleLogic oldVehicleLogic;

        public OldVehicleController(OldVehicleLogic logic)
        {
            oldVehicleLogic = logic;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<Collection<OldVehicleDto>>> GetAll()
        {
            var oldVehicleList = await oldVehicleLogic.GetAll();
            return Ok(MapperUtils.MapList(oldVehicleList, OldVehicleDtoMapper.MapToDto));
        }
    }
}
