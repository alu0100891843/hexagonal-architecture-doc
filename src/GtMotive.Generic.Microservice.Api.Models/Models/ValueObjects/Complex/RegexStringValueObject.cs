using System;
using System.Text.RegularExpressions;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Primitives;

namespace GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex
{
    public abstract class RegexStringValueObject : StringValueObject
    {
        protected RegexStringValueObject(string value, string name, string pattern)
            : base(value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El valor de" + name + "no puede estar vacío.", nameof(value));
            }

            Regex regex = new(pattern);

            if (!regex.IsMatch(value))
            {
                throw new ArgumentException("El formato de " + name + " no es correcto.", nameof(value));
            }
        }
    }
}
