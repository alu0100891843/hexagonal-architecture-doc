using System;

namespace GtMotive.Estimate.Microservice.Host.Models.Rent
{
    public class RentDto
    {
        public RentDto(string id, string vehicleId, string clientId, DateTime startDate, DateTime? finishDate)
        {
            Id = id;
            VehicleId = vehicleId;
            ClientId = clientId;
            StartDate = startDate;
            FinishDate = finishDate;
        }

        public string Id { get; set; }

        public string VehicleId { get; set; }

        public string ClientId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? FinishDate { get; set; }
    }
}
