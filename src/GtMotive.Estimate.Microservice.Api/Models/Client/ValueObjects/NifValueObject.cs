using System;
using System.Text.RegularExpressions;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Api.Models.Client.ValueObjects
{
    public class NifValueObject : StringValueObject
    {
        public NifValueObject(string value)
            : base(value)
        {
            Validate(Value);
        }

        private static void Validate(string value)
        {
            if (!ValidarDNI(value) && !ValidarNIE(value) && !ValidarPassport(value))
            {
                throw new ArgumentException("El NIF, NIE o Pasaporte no es válido");
            }
        }

        private static bool ValidarDNI(string value)
        {
            Regex regex = new(@"^\d{8}[A-Z]$");
            return regex.IsMatch(value);
        }

        private static bool ValidarNIE(string value)
        {
            Regex regex = new("/^[XYZ]\\d{7}[A-Z]$/");
            return regex.IsMatch(value);
        }

        private static bool ValidarPassport(string value)
        {
            Regex regex = new("/^[A-Z0-9<]{6,}$/i");
            return regex.IsMatch(value);
        }
    }
}
