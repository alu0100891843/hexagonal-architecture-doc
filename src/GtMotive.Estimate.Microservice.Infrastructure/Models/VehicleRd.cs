using System;
using Redis.OM.Modeling;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    [Document(StorageType = StorageType.Json, IndexName = "vehiclerd-idx", Prefixes = new[] { "Vehicle" })]
    public class VehicleRd
    {
        public VehicleRd(string id, string brand, string model, string plate, DateTimeOffset? manufacturedDate)
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
        public DateTimeOffset? ManufacturedDate { get; set; }
    }
}
