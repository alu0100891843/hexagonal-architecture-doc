using System;
using Redis.OM.Modeling;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Rent" })]
    public class RentRd
    {
        public RentRd(string id, string vehicleId, string clientId, DateTimeOffset startDate, DateTimeOffset finishDate)
        {
            Id = id;
            VehicleId = vehicleId;
            ClientId = clientId;
            StartDate = startDate;
            FinishDate = finishDate;
        }

        [RedisIdField]
        [Indexed]
        public string Id { get; set; }

        [Indexed]
        public string VehicleId { get; set; }

        [Indexed]
        public string ClientId { get; set; }

        [Indexed]
        public DateTimeOffset StartDate { get; set; }

        [Indexed]
        public DateTimeOffset FinishDate { get; set; }
    }
}
