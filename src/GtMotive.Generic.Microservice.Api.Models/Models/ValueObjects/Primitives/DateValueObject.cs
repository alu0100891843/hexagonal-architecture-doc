﻿using System;

namespace GtMotive.Generic.Microservice.Models.ValueObjects.Primitives
{
    public class DateValueObject
    {
        public DateValueObject(DateTime value)
        {
            Value = value;
        }

        public DateTime Value { get; set; }
    }
}
