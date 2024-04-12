using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Logic;
using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
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
        public async Task<List<VehicleRd>> GetAll()
        {
            return await vehicleLogic.GetAll();
        }

        [HttpPost("create")]
        public async Task<VehicleRd> Create([FromBody] VehicleRd vehicle)
        {
            return await vehicleLogic.Create(vehicle);
        }
    }
}
