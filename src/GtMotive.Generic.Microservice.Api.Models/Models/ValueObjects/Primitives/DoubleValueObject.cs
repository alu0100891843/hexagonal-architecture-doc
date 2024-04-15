namespace GtMotive.Generic.Microservice.Models.ValueObjects.Primitives
{
    public class DoubleValueObject
    {
        public DoubleValueObject(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }
}
