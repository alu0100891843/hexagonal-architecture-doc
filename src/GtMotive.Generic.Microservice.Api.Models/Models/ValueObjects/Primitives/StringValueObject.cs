namespace GtMotive.Generic.Microservice.Models.ValueObjects.Primitives
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
