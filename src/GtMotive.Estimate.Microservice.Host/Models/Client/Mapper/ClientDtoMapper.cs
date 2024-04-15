using GtMotive.Estimate.Microservice.Api.Models.Client;
using GtMotive.Estimate.Microservice.Api.Models.Client.ValueObjects;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;

namespace GtMotive.Estimate.Microservice.Host.Models.Client.Mapper
{
    public static class ClientDtoMapper
    {
        public static ClientDto MapToDto(ClientApi clientApi)
        {
            return clientApi == null
                ? null
                : new ClientDto(
                clientApi.Id?.Value.ToString(),
                clientApi.Name?.Value,
                clientApi.LastName?.Value,
                clientApi.NIF?.Value);
        }

        public static ClientApi MapToApi(ClientDto clientDto)
        {
            return clientDto == null
            ? null
            : new ClientApi(
                new UuidValueObject(clientDto.Id ?? UuidValueObject.GenerateUUID()),
                new CapitalizeWordValueObject(clientDto.Name),
                new CapitalizeWordValueObject(clientDto.LastName),
                new NifValueObject(clientDto.NIF));
        }
    }
}
