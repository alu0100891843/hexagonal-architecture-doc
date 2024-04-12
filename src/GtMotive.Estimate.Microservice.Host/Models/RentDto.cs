using System;

namespace GtMotive.Estimate.Microservice.Api.Models.Host
{
    public class RentDto
    {
        public RentDto(string id, VehicleDto vehicle, ClientDto client, DateTimeOffset startDate, DateTimeOffset returnDate)
        {
            Id = id;
            Vehicle = vehicle;
            Client = client;
            StartDate = startDate;
            ReturnDate = returnDate;
        }

        public string Id { get; set; }

        public VehicleDto Vehicle { get; set; }

        public ClientDto Client { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset ReturnDate { get; set; }
    }
}
