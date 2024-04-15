using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl
{
    public class ClientService
    {
        public ClientService(MongoService mongoService)
        {
            if (mongoService != null)
            {
                ClientCollection = mongoService.ClientCollection;
            }
        }

        private IMongoCollection<ClientDb> ClientCollection { get; }

        public async Task<List<ClientDb>> GetAllAsync()
        {
            return await ClientCollection.Find(_ => true).ToListAsync();
        }

        public async Task<ClientDb> GetByNifAsync(string nif)
        {
            return await ClientCollection.Find(client => client.NIF == nif).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(ClientDb client)
        {
            await ClientCollection.InsertOneAsync(client);
        }
    }
}
