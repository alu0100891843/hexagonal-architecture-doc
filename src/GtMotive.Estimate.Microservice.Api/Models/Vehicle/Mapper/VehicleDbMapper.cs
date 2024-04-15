using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Models.Vehicle;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;

namespace GtMotive.Estimate.Microservice.Api.Models.Vehicle.Mapper
{
    public static class VehicleDbMapper
    {
        public static VehicleDb MapToDb(VehicleApi vehicleApi)
        {
            return vehicleApi == null
                ? null
                : new VehicleDb(
                vehicleApi.Id.Value,
                vehicleApi.Brand.Value,
                vehicleApi.Model.Value,
                vehicleApi.Plate.Value,
                vehicleApi.ManufacturedDate.Value);
        }

        public static VehicleApi MapToApi(VehicleDb vehicleDb)
        {
            return vehicleDb == null
                ? null
                : new VehicleApi(
                new UuidValueObject(vehicleDb.Id),
                new CapitalizeWordValueObject(vehicleDb.Brand),
                new CapitalizeWordValueObject(vehicleDb.Model),
                new PlateValueObject(vehicleDb.Plate),
                new ManufacturedDateValueObject(vehicleDb.ManufacturedDate));
        }
    }
}
