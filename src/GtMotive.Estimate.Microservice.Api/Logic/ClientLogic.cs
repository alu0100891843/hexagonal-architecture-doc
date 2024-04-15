using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Client;
using GtMotive.Estimate.Microservice.Api.Models.Client.Mapper;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl;
using GtMotive.Generic.Microservice.Utils.Mappers;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Api.Logic
{
    public class ClientLogic
    {
        private readonly ClientService clientService;

        public ClientLogic(ClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<Collection<ClientApi>> GetAll()
        {
            try
            {
                var result = await clientService.GetAllAsync();
                return MapperUtils.MapList(result, ClientDbMapper.MapToApi);
            }
            catch (MongoException)
            {
                throw new MongoException("Ha ocurrido un error al obtener los clientes");
            }
        }

        public async Task<ClientApi> Insert(ClientApi client)
        {
            try
            {
                await clientService.InsertAsync(ClientDbMapper.MapToDb(client));
                return client;
            }
            catch (MongoException)
            {
                throw new MongoException("Ha ocurrido un error al crear el cliente");
            }
        }
    }
}
