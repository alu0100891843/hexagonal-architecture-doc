using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Logic;
using GtMotive.Estimate.Microservice.Api.Models.Client.ValueObjects;
using GtMotive.Estimate.Microservice.Host.Models;
using GtMotive.Estimate.Microservice.Host.Models.Client.Mapper;
using GtMotive.Generic.Microservice.Utils.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientLogic clientLogic;

        public ClientController(ClientLogic logic)
        {
            clientLogic = logic;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<Collection<ClientDto>>> GetAll()
        {
            var clientList = await clientLogic.GetAll();
            return Ok(MapperUtils.MapList(clientList, ClientDtoMapper.MapToDto));
        }

        [HttpGet("getByNif")]
        public async Task<ActionResult<ClientDto>> GetByPlate([FromQuery] string nif)
        {
            if (string.IsNullOrEmpty(nif))
            {
                return BadRequest("La consulta no ha recibido el parámetro 'nif'");
            }

            var vehicle = await clientLogic.GetByNif(new NifValueObject(nif));
            return Ok(ClientDtoMapper.MapToDto(vehicle));
        }

        [HttpPost("create")]
        public async Task<ActionResult<ClientDto>> Create([FromBody] ClientDto client)
        {
            if (client == null)
            {
                return BadRequest("La consulta no ha recibido el parámetro 'client'");
            }

            var clientApi = ClientDtoMapper.MapToApi(client);
            var result = await clientLogic.Insert(clientApi);
            return Ok(ClientDtoMapper.MapToDto(result));
        }
    }
}
