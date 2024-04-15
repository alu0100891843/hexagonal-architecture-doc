using System;
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
                OldVehicleCollection = mongoService.OldVehicleCollection;
            }
        }

        private IMongoCollection<VehicleDb> VehicleCollection { get; }

        private IMongoCollection<OldVehicleDb> OldVehicleCollection { get; }

        public async Task EvalOldVehicles()
        {
            var fiveYearsAgo = DateTime.Now.AddYears(-5);
            var filter = Builders<VehicleDb>.Filter.Lt(v => v.ManufacturedDate, fiveYearsAgo);
            var oldVehicles = await VehicleCollection.Find(filter).ToListAsync();

            foreach (var vehicle in oldVehicles)
            {
                await MoveVehicleToOldAsync(vehicle);
            }

            Console.WriteLine("Old vehicles moved to OldVehicleDb.");
        }

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

        private async Task MoveVehicleToOldAsync(VehicleDb vehicle)
        {
            var oldVehicle = new OldVehicleDb(vehicle.Id, vehicle.Brand, vehicle.Model, vehicle.Plate, vehicle.ManufacturedDate, 0);
            await OldVehicleCollection.InsertOneAsync(oldVehicle);
            await VehicleCollection.DeleteOneAsync(v => v.Id == vehicle.Id);
        }
    }
}
