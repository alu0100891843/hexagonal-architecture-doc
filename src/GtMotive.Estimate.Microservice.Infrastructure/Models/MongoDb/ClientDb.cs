using GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb.Parent;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb
{
    public class ClientDb : MongoEntity
    {
        public ClientDb(string id, string name, string lastName, string nif)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            NIF = nif;
        }

        [BsonId]
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string NIF { get; set; }

        internal static void ConfigureRestrictions(IMongoCollection<ClientDb> clientCollection)
        {
            var nifIndexKeys = Builders<ClientDb>.IndexKeys.Ascending(x => x.NIF);
            var nifIndexOptions = new CreateIndexOptions { Unique = true };
            var nifIndexModel = new CreateIndexModel<ClientDb>(nifIndexKeys, nifIndexOptions);
            clientCollection.Indexes.CreateOne(nifIndexModel);
        }
    }
}
