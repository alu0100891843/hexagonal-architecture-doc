using System;

namespace GtMotive.Estimate.Microservice.Api.Models.Infrastructure
{
    public class OldVehicleDb : VehicleDb
    {
        public OldVehicleDb(string id, string brand, string model, string plate, DateTime manufacturedDate, double price)
            : base(id, brand, model, plate, manufacturedDate)
        {
            Price = price;
        }

        public double Price { get; set; }
    }
}
