using System;

namespace GtMotive.Estimate.Microservice.Host.Models.Vehicle
{
    public class OldVehicleDto : VehicleDto
    {
        public OldVehicleDto(string id, string brand, string model, string plate, DateTime manufacturedDate, double price)
            : base(id, brand, model, plate, manufacturedDate)
        {
            Price = price;
        }

        public double Price { get; set; }
    }
}
