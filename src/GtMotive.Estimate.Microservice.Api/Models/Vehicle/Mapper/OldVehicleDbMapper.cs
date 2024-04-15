using GtMotive.Estimate.Microservice.Api.Models.Vehicle;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Api.Models.OldVehicle.Mapper
{
    public static class OldVehicleDbMapper
    {
        public static OldVehicleDb MapToDb(OldVehicleApi oldVehicleApi)
        {
            return oldVehicleApi == null
                ? null
                : new OldVehicleDb(
                oldVehicleApi.Id.Value,
                oldVehicleApi.Brand.Value,
                oldVehicleApi.Model.Value,
                oldVehicleApi.Plate.Value,
                oldVehicleApi.ManufacturedDate.Value,
                oldVehicleApi.Price.Value);
        }

        public static OldVehicleApi MapToApi(OldVehicleDb oldVehicleDb)
        {
            return oldVehicleDb == null
                ? null
                : new OldVehicleApi(
                new UuidValueObject(oldVehicleDb.Id),
                new CapitalizeWordValueObject(oldVehicleDb.Brand),
                new CapitalizeWordValueObject(oldVehicleDb.Model),
                new PlateValueObject(oldVehicleDb.Plate),
                new DateValueObject(oldVehicleDb.ManufacturedDate),
                new PositiveDoubleValueObject(oldVehicleDb.Price));
        }
    }
}
