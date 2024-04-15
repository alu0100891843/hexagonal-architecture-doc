using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Domain.Models.ValueObjects.Primitives;

#nullable enable
namespace GtMotive.Estimate.Microservice.Api.Models.Rent
{
    public class RentApi
    {
        public RentApi(UuidValueObject id, UuidValueObject vehicle, UuidValueObject client, DateValueObject startDate, DateValueObject? finishDate)
        {
            Id = id;
            VehicleId = vehicle;
            ClientId = client;
            StartDate = startDate;
            FinishDate = finishDate;
        }

        public UuidValueObject Id { get; set; }

        public UuidValueObject VehicleId { get; set; }

        public UuidValueObject ClientId { get; set; }

        public DateValueObject StartDate { get; set; }

        public DateValueObject? FinishDate { get; set; }
    }
}
