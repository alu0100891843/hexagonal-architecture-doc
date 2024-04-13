using System;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle
{
    public class ManufacturedDateValueObject : DateValueObject
    {
        public ManufacturedDateValueObject(DateTime value)
            : base(value)
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("La fecha de fabricación no puede ser futura.", nameof(value));
            }

            var fiveYearsAgo = DateTime.Now.AddYears(-5);

            if (value < fiveYearsAgo)
            {
                throw new ArgumentException("Han pasado más de 5 años desde la fecha de fabricación de este vehículo");
            }
        }
    }
}
