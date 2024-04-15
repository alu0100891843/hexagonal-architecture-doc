using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;

namespace GtMotive.Estimate.Microservice.Domain.Models.Vehicle
{
    public class VehicleApi
    {
        public VehicleApi(UuidValueObject id, CapitalizeWordValueObject brand, CapitalizeWordValueObject model, PlateValueObject plate, ManufacturedDateValueObject manufacturedDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Plate = plate;
            ManufacturedDate = manufacturedDate;
        }

        protected VehicleApi()
        {
        }

        public UuidValueObject Id { get; set; }

        public CapitalizeWordValueObject Brand { get; set; }

        public CapitalizeWordValueObject Model { get; set; }

        public PlateValueObject Plate { get; set; }

        public ManufacturedDateValueObject ManufacturedDate { get; set; }
    }
}
