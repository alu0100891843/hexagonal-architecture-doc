using GtMotive.Estimate.Microservice.Api.Models.Rent;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Host.Models.Rent.Mapper
{
    public static class RentDtoMapper
    {
        public static RentDto MapToDto(RentApi rentApi)
        {
            return rentApi == null
                ? null
                : new RentDto(
                    rentApi.Id.Value,
                    rentApi.VehicleId.Value,
                    rentApi.ClientId.Value,
                    rentApi.StartDate.Value,
                    rentApi.FinishDate?.Value);
        }

        public static RentApi MapToApi(RentDto rentDto)
        {
            if (rentDto == null)
            {
                return null;
            }
            else
            {
                var finishDateVO = rentDto.FinishDate != null ? new DateValueObject((System.DateTime)rentDto.FinishDate) : null;
                return new RentApi(
                        new UuidValueObject(rentDto.Id),
                        new UuidValueObject(rentDto.VehicleId),
                        new UuidValueObject(rentDto.ClientId),
                        new DateValueObject(rentDto.StartDate),
                        finishDateVO);
            }
        }
    }
}
