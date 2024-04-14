using GtMotive.Estimate.Microservice.Api.Models.Client.ValueObjects;
using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;

namespace GtMotive.Estimate.Microservice.Api.Models.Client.Mapper
{
    public static class ClientRdMapper
    {
        public static ClientApi MapToApi(ClientRd clientRd)
        {
            return clientRd == null
                ? null
                : new ClientApi(
                new UuidValueObject(clientRd.Id),
                new CapitalizeWordValueObject(clientRd.Name),
                new CapitalizeWordValueObject(clientRd.LastName),
                new NifValueObject(clientRd.NIF));
        }

        public static ClientRd MapToRd(ClientApi clientApi)
        {
            return clientApi == null
                ? null
                : new ClientRd(
                clientApi.Id?.Value.ToString(),
                clientApi.Name?.Value,
                clientApi.LastName?.Value,
                clientApi.NIF?.Value);
        }
    }
}
