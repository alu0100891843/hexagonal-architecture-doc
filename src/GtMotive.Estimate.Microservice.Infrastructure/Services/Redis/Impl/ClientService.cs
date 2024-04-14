using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.Services.Redis.Impl.Parent;
using Redis.OM;

namespace GtMotive.Estimate.Microservice.Infrastructure.Services.Redis.Impl
{
    public class ClientService : RedisService
    {
        public ClientService(RedisContext redisContext)
            : base(redisContext)
        {
        }

        public async Task<List<ClientRd>> GetAll()
        {
            return await RedisContext.ClientContext.ToListAsync() as List<ClientRd>;
        }

        public async Task<ClientRd> Create(ClientRd vehicle)
        {
            await RedisContext.ClientContext.InsertAsync(vehicle);
            return vehicle;
        }

        public async Task Delete(string id)
        {
            // TODONOW: BORRAR ALQUILERES RELACIONADOS SI LOS HUBIERA
            await RedisContext.RedisCnn.Connection.UnlinkAsync($"Client:{id}");
        }
    }
}
