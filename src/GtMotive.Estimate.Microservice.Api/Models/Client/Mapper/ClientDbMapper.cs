using GtMotive.Estimate.Microservice.Api.Models.Client.ValueObjects;
using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;

namespace GtMotive.Estimate.Microservice.Api.Models.Client.Mapper
{
    public static class ClientDbMapper
    {
        public static ClientApi MapToApi(ClientDb clientDb)
        {
            return clientDb == null
                ? null
                : new ClientApi(
                new UuidValueObject(clientDb.Id),
                new CapitalizeWordValueObject(clientDb.Name),
                new CapitalizeWordValueObject(clientDb.LastName),
                new NifValueObject(clientDb.NIF));
        }

        public static ClientDb MapToDb(ClientApi clientApi)
        {
            return clientApi == null
                ? null
                : new ClientDb(
                clientApi.Id?.Value,
                clientApi.Name?.Value,
                clientApi.LastName?.Value,
                clientApi.NIF?.Value);
        }
    }
}
