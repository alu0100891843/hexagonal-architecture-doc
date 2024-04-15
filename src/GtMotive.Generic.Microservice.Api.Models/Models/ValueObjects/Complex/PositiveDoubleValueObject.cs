using GtMotive.Generic.Microservice.Domain;

namespace GtMotive.Generic.Microservice.Models.ValueObjects.Primitives
{
    public class PositiveDoubleValueObject : DoubleValueObject
    {
        public PositiveDoubleValueObject(double value)
            : base(value)
        {
            Validate(value);
        }

        private static void Validate(double value)
        {
            if (value < 0)
            {
                throw new DomainException("El número flotante es menor que 0");
            }
        }
    }
}
