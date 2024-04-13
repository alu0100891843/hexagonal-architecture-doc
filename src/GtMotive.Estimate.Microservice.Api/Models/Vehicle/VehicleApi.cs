using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Domain.Models.Vehicle
{
    public class VehicleApi
    {
        public VehicleApi(UuidValueObject id, StringValueObject brand, StringValueObject model, PlateValueObject plate, ManufacturedDateValueObject manufacturedDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Plate = plate;
            ManufacturedDate = manufacturedDate;
        }

        public UuidValueObject Id { get; set; }

        public StringValueObject Brand { get; set; }

        public StringValueObject Model { get; set; }

        public PlateValueObject Plate { get; set; }

        public ManufacturedDateValueObject ManufacturedDate { get; set; }
    }
}
