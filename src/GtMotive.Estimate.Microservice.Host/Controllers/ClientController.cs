using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Logic;
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
        public async Task<Collection<ClientDto>> GetAll()
        {
            var clientList = await clientLogic.GetAll();
            return MapperUtils.MapList(clientList, ClientDtoMapper.MapToDto);
        }

        [HttpPost("create")]
        public async Task<ClientDto> Create([FromBody] ClientDto client)
        {
            var clientApi = ClientDtoMapper.MapToApi(client);
            var result = await clientLogic.Create(clientApi);
            return ClientDtoMapper.MapToDto(result);
        }

        [HttpDelete("delete")]
        public async Task Delete([FromQuery] string id)
        {
            await clientLogic.Delete(id);
        }
    }
}
