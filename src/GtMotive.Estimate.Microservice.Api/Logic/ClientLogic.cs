using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Client;
using GtMotive.Estimate.Microservice.Api.Models.Client.Mapper;
using GtMotive.Estimate.Microservice.Infrastructure.Services.Redis.Impl;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Utils.Mappers;

namespace GtMotive.Estimate.Microservice.Api.Logic
{
    public class ClientLogic
    {
        private readonly ClientService clientService;

        public ClientLogic(ClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<ClientApi> Create(ClientApi client)
        {
            if (client == null)
            {
                throw new ArgumentException("La información del vehículo está vacía");
            }

            var result = await clientService.Create(ClientRdMapper.MapToRd(client));
            return ClientRdMapper.MapToApi(result);
        }

        public async Task Delete(string id)
        {
            UuidValueObject uuid = new(id);
            await clientService.Delete(uuid.Value);
        }

        public async Task<Collection<ClientApi>> GetAll()
        {
            var result = await clientService.GetAll();
            return MapperUtils.MapList(result, ClientRdMapper.MapToApi);
        }
    }
}
