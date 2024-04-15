using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Infrastructure;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl
{
    public class VehicleService
    {
        public VehicleService(MongoService mongoService)
        {
            if (mongoService != null)
            {
                VehicleCollection = mongoService.VehicleCollection;
            }
        }

        private IMongoCollection<VehicleDb> VehicleCollection { get; }

        public async Task<List<VehicleDb>> GetAllAsync()
        {
            return await VehicleCollection.Find(_ => true).ToListAsync();
        }

        public async Task<VehicleDb> GetByPlateAsync(string plate)
        {
            return await VehicleCollection.Find(vehicle => vehicle.Plate == plate).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(VehicleDb vehicle)
        {
            await VehicleCollection.InsertOneAsync(vehicle);
        }
    }
}
