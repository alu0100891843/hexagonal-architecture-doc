using Redis.OM.Modeling;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Client" })]
    public class ClientRd
    {
        public ClientRd(string id, string name, string lastName, string nif)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            NIF = nif;
        }

        [RedisIdField]
        [Indexed]
        public string Id { get; set; }

        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public string LastName { get; set; }

        [Searchable]
        public string NIF { get; set; }
    }
}
