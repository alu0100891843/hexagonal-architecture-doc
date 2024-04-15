using System;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    public class OldVehicleDb : VehicleDb
    {
        public OldVehicleDb(string id, string brand, string model, string plate, DateTime manufacturedDate, double price)
            : base(id, brand, model, plate, manufacturedDate)
        {
            Price = price;
        }

        public double Price { get; set; }

        internal static void ConfigureRestrictions(IMongoCollection<OldVehicleDb> vehicleCollection)
        {
            var plateIndexKeys = Builders<OldVehicleDb>.IndexKeys.Ascending(x => x.Plate);
            var plateIndexOptions = new CreateIndexOptions { Unique = true };
            var plateIndexModel = new CreateIndexModel<OldVehicleDb>(plateIndexKeys, plateIndexOptions);
            vehicleCollection.Indexes.CreateOne(plateIndexModel);
        }
    }
}
