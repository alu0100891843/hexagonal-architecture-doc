using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Logic;
using GtMotive.Estimate.Microservice.Api.Models.Client.ValueObjects;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Host.Models.Rent;
using GtMotive.Estimate.Microservice.Host.Models.Rent.Mapper;
using GtMotive.Estimate.Microservice.Host.Models.Rent.Request;
using GtMotive.Generic.Microservice.Utils.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly RentLogic rentLogic;

        public RentController(RentLogic logic)
        {
            rentLogic = logic;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<Collection<RentDto>>> GetAll()
        {
            var rentList = await rentLogic.GetAll();
            return Ok(MapperUtils.MapList(rentList, RentDtoMapper.MapToDto));
        }

        [HttpPost("create")]
        public async Task<ActionResult<RentDto>> Create([FromBody] RqRentInfo rqRentInfo)
        {
            if (rqRentInfo == null)
            {
                return BadRequest("La petición no se ha hecho correctamente");
            }

            var result = await rentLogic.Create(new PlateValueObject(rqRentInfo.Plate), new NifValueObject(rqRentInfo.NIF));
            return Ok(RentDtoMapper.MapToDto(result));
        }

        [HttpPut("endRent")]
        public async Task<ActionResult> EndRent([FromBody] RqRentInfo rqRentInfo)
        {
            if (rqRentInfo == null)
            {
                return BadRequest("La petición no se ha hecho correctamente");
            }

            await rentLogic.EndRent(new PlateValueObject(rqRentInfo.Plate), new NifValueObject(rqRentInfo.NIF));
            return Ok();
        }
    }
}
