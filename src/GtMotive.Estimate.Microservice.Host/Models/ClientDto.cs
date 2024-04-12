namespace GtMotive.Estimate.Microservice.Api.Models.Host
{
    public class ClientDto
    {
        public ClientDto(string id, string name, string lastName, string nif)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            NIF = nif;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string NIF { get; set; }
    }
}
