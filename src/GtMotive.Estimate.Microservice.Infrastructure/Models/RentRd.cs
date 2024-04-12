using System;
using Redis.OM.Modeling;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Rent" })]
    public class RentRd
    {
        public RentRd(string id, string vehicle, string client, DateTimeOffset startDate, DateTimeOffset finishDate)
        {
            Id = id;
            Vehicle = vehicle;
            Client = client;
            StartDate = startDate;
            FinishDate = finishDate;
        }

        [RedisIdField]
        [Indexed]
        public string Id { get; set; }

        [Indexed]
        public string Vehicle { get; set; }

        [Indexed(CascadeDepth = 1)]
        public string Client { get; set; }

        [Indexed]
        public DateTimeOffset StartDate { get; set; }

        [Indexed]
        public DateTimeOffset FinishDate { get; set; }
    }
}
