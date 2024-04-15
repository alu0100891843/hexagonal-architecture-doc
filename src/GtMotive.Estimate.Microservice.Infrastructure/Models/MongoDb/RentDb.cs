using System;
using GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb.Parent;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb
{
    public class RentDb : MongoEntity
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
