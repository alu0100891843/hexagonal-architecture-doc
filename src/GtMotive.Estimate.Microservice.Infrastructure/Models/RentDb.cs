using System;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    public class RentDb
    {
        public RentDb(string id, string vehicleId, string clientId, DateTime startDate, DateTime? finishDate)
        {
            Id = id;
            VehicleId = vehicleId;
            ClientId = clientId;
            StartDate = startDate;
            FinishDate = finishDate;
        }

        [BsonId]
        public string Id { get; set; }

        public string VehicleId { get; set; }

        public string ClientId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? FinishDate { get; set; }
    }
}
