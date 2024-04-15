using System;
using GtMotive.Generic.Microservice.Domain;
using GtMotive.Generic.Microservice.Models.ValueObjects.Primitives;

namespace GtMotive.Generic.Microservice.Models.ValueObjects.Complex
{
    public class UuidValueObject : StringValueObject
    {
        public UuidValueObject(string value)
            : base(value)
        {
            if (!Guid.TryParse(value, out _))
            {
                throw new DomainException("La cadena de caracteres no es un UUID válido");
            }
        }

        public static string GenerateUUID() => Guid.NewGuid().ToString();
    }
}
