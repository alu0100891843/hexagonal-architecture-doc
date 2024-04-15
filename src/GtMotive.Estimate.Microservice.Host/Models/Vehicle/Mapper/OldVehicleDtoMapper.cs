using GtMotive.Estimate.Microservice.Api.Models.Vehicle;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Host.Models.Vehicle.Mapper
{
    public static class OldVehicleDtoMapper
    {
        public static OldVehicleDto MapToDto(OldVehicleApi oldVehicleApi)
        {
            return oldVehicleApi == null
                ? null
                : new OldVehicleDto(
                oldVehicleApi.Id.Value,
                oldVehicleApi.Brand.Value,
                oldVehicleApi.Model.Value,
                oldVehicleApi.Plate.Value,
                oldVehicleApi.ManufacturedDate.Value,
                oldVehicleApi.Price.Value);
        }

        public static OldVehicleApi MapToApi(OldVehicleDto oldVehicleDto)
        {
            return oldVehicleDto == null
                ? null
                : new OldVehicleApi(
                new UuidValueObject(oldVehicleDto.Id ?? UuidValueObject.GenerateUUID()),
                new CapitalizeWordValueObject(oldVehicleDto.Brand),
                new CapitalizeWordValueObject(oldVehicleDto.Model),
                new PlateValueObject(oldVehicleDto.Plate),
                new ManufacturedDateValueObject(oldVehicleDto.ManufacturedDate),
                new PositiveDoubleValueObject(oldVehicleDto.Price));
        }
    }
}
