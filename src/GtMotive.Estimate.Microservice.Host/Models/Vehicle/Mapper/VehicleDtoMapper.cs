using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Models.Vehicle;
using GtMotive.Estimate.Microservice.Host.Models.Vehicle;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Host.Models.Vehicle.Mapper
{
    public static class VehicleDtoMapper
    {
        public static VehicleDto MapToDto(VehicleApi vehicleApi)
        {
            return vehicleApi == null
                ? null
                : new VehicleDto(
                vehicleApi.Id?.Value?.ToString(),
                vehicleApi.Brand?.Value,
                vehicleApi.Model?.Value,
                vehicleApi.Plate?.Value,
                vehicleApi.ManufacturedDate.Value);
        }

        public static VehicleApi MapToApi(VehicleDto vehicleDto)
        {
            return vehicleDto == null
                ? null
                : new VehicleApi(
                new UuidValueObject(vehicleDto.Id ?? UuidValueObject.GenerateUUID()),
                new StringValueObject(vehicleDto.Brand),
                new StringValueObject(vehicleDto.Model),
                new PlateValueObject(vehicleDto.Plate),
                new ManufacturedDateValueObject(vehicleDto.ManufacturedDate));
        }
    }
}
