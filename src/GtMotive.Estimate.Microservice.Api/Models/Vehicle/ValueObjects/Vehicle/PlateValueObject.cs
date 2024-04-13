using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;

namespace GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle
{
    public class PlateValueObject : RegexStringValueObject
    {
        public PlateValueObject(string value)
            : base(value, "la matrícula", @"^\d{4}[A-Z]{3}$")
        {
        }
    }
}
