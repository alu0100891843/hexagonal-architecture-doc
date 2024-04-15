using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Models.ValueObjects.Primitives;

namespace GtMotive.Estimate.Microservice.Api.Models.Rent.Mapper
{
    public static class RentDbMapper
    {
        public static RentDb MapToDb(RentApi rentDb)
        {
            return rentDb == null
                ? null
                : new RentDb(
                rentDb.Id.Value,
                rentDb.VehicleId.Value,
                rentDb.ClientId.Value,
                rentDb.StartDate.Value,
                rentDb.FinishDate?.Value);
        }

        public static RentApi MapToApi(RentDb rentDb)
        {
            if (rentDb == null)
            {
                return null;
            }
            else
            {
                var finishDateVO = rentDb.FinishDate != null ? new DateValueObject((System.DateTime)rentDb.FinishDate) : null;
                return new RentApi(
                    new UuidValueObject(rentDb.Id),
                    new UuidValueObject(rentDb.VehicleId),
                    new UuidValueObject(rentDb.ClientId),
                    new DateValueObject(rentDb.StartDate),
                    finishDateVO);
            }
        }
    }
}
