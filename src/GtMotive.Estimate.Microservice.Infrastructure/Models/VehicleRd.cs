using System;
using Redis.OM.Modeling;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Vehicle" })]
    public class VehicleRd
    {
        public VehicleRd(string id, string brand, string model, string plate, DateTime manufacturedDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Plate = plate;
            ManufacturedDate = manufacturedDate;
        }

        [RedisIdField]
        [Indexed]
        public string Id { get; set; }

        [Searchable]
        public string Brand { get; set; }

        [Searchable]
        public string Model { get; set; }

        [Searchable]
        public string Plate { get; set; }

        [Searchable]
        public DateTime ManufacturedDate { get; set; }
    }
}
