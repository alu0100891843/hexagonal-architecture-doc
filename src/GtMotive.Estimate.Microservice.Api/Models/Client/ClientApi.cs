using GtMotive.Estimate.Microservice.Api.Models.Client.ValueObjects;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;

namespace GtMotive.Estimate.Microservice.Api.Models.Client
{
    public class ClientApi
    {
        public ClientApi(UuidValueObject id, CapitalizeWordValueObject name, CapitalizeWordValueObject lastName, NifValueObject nif)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            NIF = nif;
        }

        public UuidValueObject Id { get; set; }

        public CapitalizeWordValueObject Name { get; set; }

        public CapitalizeWordValueObject LastName { get; set; }

        public NifValueObject NIF { get; set; }
    }
}
