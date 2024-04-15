namespace GtMotive.Generic.Microservice.Models.ValueObjects.Primitives
{
    public class NumberValueObject
    {
        public NumberValueObject(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
