using System;
using GtMotive.Estimate.Microservice.Host.Models.Vehicle;

namespace GtMotive.Estimate.Microservice.Host.Models.Rent
{
    public class RentDto
    {
        public RentDto(string id, VehicleDto vehicle, ClientDto client, DateTime startDate, DateTime returnDate)
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

        public DateTime StartDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
