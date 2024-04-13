using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Models.Vehicle;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Api.Models.Vehicle.Mapper
{
    public static class VehicleRdMapper
    {
        public static VehicleRd MapToRd(VehicleApi vehicleApi)
        {
            return vehicleApi == null
                ? null
                : new VehicleRd(
                vehicleApi.Id.Value,
                vehicleApi.Brand.Value,
                vehicleApi.Model.Value,
                vehicleApi.Plate.Value,
                vehicleApi.ManufacturedDate.Value);
        }

        public static VehicleApi MapToApi(VehicleRd vehicleRd)
        {
            return vehicleRd == null
                ? null
                : new VehicleApi(
                new UuidValueObject(vehicleRd.Id),
                new StringValueObject(vehicleRd.Brand),
                new StringValueObject(vehicleRd.Model),
                new PlateValueObject(vehicleRd.Plate),
                new ManufacturedDateValueObject(vehicleRd.ManufacturedDate));
        }
    }
}
