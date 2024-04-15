using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl
{
    public class RentService
    {
        public RentService(MongoService mongoService)
        {
            if (mongoService != null)
            {
                RentCollection = mongoService.RentCollection;
            }
        }

        private IMongoCollection<RentDb> RentCollection { get; }

        public async Task<IEnumerable<RentDb>> GetAllAsync()
        {
            return await RentCollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertAsync(RentDb rent)
        {
            await RentCollection.InsertOneAsync(rent);
        }

        public async Task EndRent(string clientId, string vehicleId)
        {
            var filter = Builders<RentDb>.Filter.Eq(r => r.ClientId, clientId) &
                         Builders<RentDb>.Filter.Eq(r => r.VehicleId, vehicleId) &
                         Builders<RentDb>.Filter.Eq(r => r.FinishDate, null);

            var update = Builders<RentDb>.Update.Set(r => r.FinishDate, DateTime.Now);
            await RentCollection.UpdateOneAsync(filter, update);
        }

        public async Task<bool> CheckVehicleIsAvailable(string vehicleId)
        {
            var count = await RentCollection.CountDocumentsAsync(r => r.VehicleId == vehicleId && r.FinishDate == null);
            return count == 0;
        }

        public async Task<bool> CheckClientCanRent(string clientId)
        {
            var count = await RentCollection.CountDocumentsAsync(r => r.ClientId == clientId && r.FinishDate == null);
            return count == 0;
        }
    }
}
