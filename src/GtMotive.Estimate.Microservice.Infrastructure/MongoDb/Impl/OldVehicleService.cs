using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl
{
    public class OldVehicleService
    {
        public OldVehicleService(MongoService mongoService)
        {
            if (mongoService != null)
            {
                OldVehicleCollection = mongoService.OldVehicleCollection;
            }
        }

        private IMongoCollection<OldVehicleDb> OldVehicleCollection { get; }

        public async Task<List<OldVehicleDb>> GetAllAsync()
        {
            return await OldVehicleCollection.Find(_ => true).ToListAsync();
        }
    }
}
