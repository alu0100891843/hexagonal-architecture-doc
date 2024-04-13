using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using Redis.OM;
using Redis.OM.Searching;
using System;

namespace GtMotive.Estimate.Microservice.Infrastructure.Services.Redis
{
    public class RedisContext
    {
        public RedisContext(RedisConnectionProvider redisCnn)
        {
            if (redisCnn == null)
            {
                throw new ArgumentNullException(nameof(redisCnn));
            }

            redisCnn.Connection.CreateIndex(typeof(VehicleRd));
            VehicleContext = redisCnn.RedisCollection<VehicleRd>() as RedisCollection<VehicleRd>;

            redisCnn.Connection.CreateIndex(typeof(RentRd));
            RentContext = redisCnn.RedisCollection<RentRd>() as RedisCollection<RentRd>;

            redisCnn.Connection.CreateIndex(typeof(ClientRd));
            ClientContext = redisCnn.RedisCollection<ClientRd>() as RedisCollection<ClientRd>;
        }

        public RedisCollection<VehicleRd> VehicleContext { get; }

        public RedisCollection<RentRd> RentContext { get; }

        public RedisCollection<ClientRd> ClientContext { get; }
    }
}
