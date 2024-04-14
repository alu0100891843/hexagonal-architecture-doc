namespace GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Primitives
{
    public class StringValueObject
    {
        public StringValueObject(string value)
        {
            Value = value;
        }

        public string Value { get; protected set; }
    }
}
