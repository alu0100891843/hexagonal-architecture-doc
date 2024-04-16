﻿using System;
using System.Globalization;
using GtMotive.Generic.Microservice.Models.ValueObjects.Primitives;

namespace GtMotive.Generic.Microservice.Models.ValueObjects.Complex
{
    public class CapitalizeWordValueObject : StringValueObject
    {
        public CapitalizeWordValueObject(string value)
        : base(value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El valor no puede estar vacío o contener solo espacios en blanco.", nameof(value));
            }

            Value = CapitalizeWords(value);
        }

        private static string CapitalizeWords(string value)
        {
            var cultureInfo = new CultureInfo("es-ES", false);
            var textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(value.ToLower(cultureInfo));
        }
    }
}
