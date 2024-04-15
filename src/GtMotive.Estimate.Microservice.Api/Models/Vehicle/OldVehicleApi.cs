using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Models.Vehicle;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Api.Models.Vehicle
{
    public class OldVehicleApi : VehicleApi
    {
        public OldVehicleApi(UuidValueObject id, CapitalizeWordValueObject brand, CapitalizeWordValueObject model, PlateValueObject plate, DateValueObject manufacturedDate, PositiveDoubleValueObject price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Plate = plate;
            ManufacturedDate = manufacturedDate;
            Price = price;
        }

#pragma warning disable CA1061 // No ocultar métodos de clases base
        public new DateValueObject ManufacturedDate { get; set; }
#pragma warning restore CA1061 // No ocultar métodos de clases base

        public PositiveDoubleValueObject Price { get; set; }
    }
}
