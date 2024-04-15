using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    public class ClientDb
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
    }
}
