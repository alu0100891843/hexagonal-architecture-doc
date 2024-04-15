using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        public MongoService(IOptions<MongoDbSettings> options)
        {
            MongoClient = new MongoClient(options.Value.ConnectionString);

            Db = MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);

            VehicleCollection = Db.GetCollection<VehicleDb>("vehicles");
            ClientCollection = Db.GetCollection<ClientDb>("clients");
            RentCollection = Db.GetCollection<RentDb>("rents");
        }

        public MongoClient MongoClient { get; }

        public IMongoDatabase Db { get; }

        public IMongoCollection<VehicleDb> VehicleCollection { get; }

        public IMongoCollection<ClientDb> ClientCollection { get; }

        public IMongoCollection<RentDb> RentCollection { get; }
    }
}
