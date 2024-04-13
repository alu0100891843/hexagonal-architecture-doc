using System;

namespace GtMotive.Estimate.Microservice.Host.Models.Vehicle
{
    public class VehicleDto
    {
        public VehicleDto(string id, string brand, string model, string plate, DateTime manufacturedDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Plate = plate;
            ManufacturedDate = manufacturedDate;
        }

        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Plate { get; set; }

        public DateTime ManufacturedDate { get; set; }
    }
}
