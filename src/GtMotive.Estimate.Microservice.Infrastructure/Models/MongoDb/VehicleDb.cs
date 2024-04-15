using System;
using GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb.Parent;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb
{
    public class VehicleDb : MongoEntity
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

        internal static void ConfigureRestrictions(IMongoCollection<VehicleDb> vehicleCollection)
        {
            var plateIndexKeys = Builders<VehicleDb>.IndexKeys.Ascending(x => x.Plate);
            var plateIndexOptions = new CreateIndexOptions { Unique = true };
            var plateIndexModel = new CreateIndexModel<VehicleDb>(plateIndexKeys, plateIndexOptions);
            vehicleCollection.Indexes.CreateOne(plateIndexModel);
        }
    }
}
