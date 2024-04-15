using System;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    public class VehicleDb
    {
        public VehicleDb(string id, string brand, string model, string plate, DateTime manufacturedDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Plate = plate;
            ManufacturedDate = manufacturedDate;
        }

        [BsonId]
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Plate { get; set; }

        public DateTime ManufacturedDate { get; set; }
    }
}
