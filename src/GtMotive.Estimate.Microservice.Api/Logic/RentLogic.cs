using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Client.ValueObjects;
using GtMotive.Estimate.Microservice.Api.Models.Rent;
using GtMotive.Estimate.Microservice.Api.Models.Rent.Mapper;
using GtMotive.Estimate.Microservice.Api.Models.Vehicle.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl;
using GtMotive.Generic.Microservice.Domain;
using GtMotive.Generic.Microservice.Models.ValueObjects.Complex;
using GtMotive.Generic.Microservice.Models.ValueObjects.Primitives;
using GtMotive.Generic.Microservice.Utils.Mappers;

namespace GtMotive.Estimate.Microservice.Api.Logic
{
    public class RentLogic
    {
        private readonly RentService rentService;
        private readonly ClientService clientService;
        private readonly VehicleService vehicleService;

        public RentLogic(VehicleService vehicleService, ClientService clientService, RentService rentService)
        {
            this.rentService = rentService;
            this.clientService = clientService;
            this.vehicleService = vehicleService;
        }

        public async Task<Collection<RentApi>> GetAll()
        {
            try
            {
                var result = await rentService.GetAllAsync();
                return MapperUtils.MapList(result, RentDbMapper.MapToApi);
            }
            catch (DomainException)
            {
                throw new DomainException("Ha ocurrido un error al obtener los alquileres");
            }
        }

        public async Task<RentApi> Create(PlateValueObject plate, NifValueObject nif)
        {
            try
            {
                var vehicle = await vehicleService.GetByPlateAsync(plate?.Value);
                var client = await clientService.GetByNifAsync(nif?.Value);

                CheckIfClientAndVehicleExists(client, vehicle);
                await CheckIfRentIsPossible(client.Id, vehicle.Id);

                var newRent = new RentApi(new UuidValueObject(UuidValueObject.GenerateUUID()), new UuidValueObject(vehicle.Id), new UuidValueObject(client.Id), new DateValueObject(DateTime.Now), null);
                await rentService.InsertAsync(RentDbMapper.MapToDb(newRent));

                return newRent;
            }
            catch (DomainException)
            {
                throw new DomainException("Ha ocurrido un error al crear el alquiler");
            }
        }

        public async Task EndRent(PlateValueObject plate, NifValueObject nif)
        {
            try
            {
                var vehicle = await vehicleService.GetByPlateAsync(plate?.Value);
                var client = await clientService.GetByNifAsync(nif?.Value);
                CheckIfClientAndVehicleExists(client, vehicle);

                await rentService.EndRent(client.Id, vehicle.Id);
            }
            catch (DomainException)
            {
                throw new DomainException("Ha ocurrido un error al finalizar el alquiler");
            }
        }

        private static void CheckIfClientAndVehicleExists(ClientDb client, VehicleDb vehicle)
        {
            if (client == null)
            {
                throw new InvalidOperationException("No existe el cliente al que se hace referencia en la operación");
            }

            if (vehicle == null)
            {
                throw new InvalidOperationException("No existe el vehículo al que se hace referencia en la operación");
            }
        }

        private async Task CheckIfRentIsPossible(string clientId, string vehicleId)
        {
            var vehicleIsAvailable = await rentService.CheckVehicleIsAvailable(vehicleId);
            var clientCanRent = await rentService.CheckClientCanRent(clientId);

            if (!vehicleIsAvailable)
            {
                throw new InvalidOperationException("El vehículo no se encuentra disponible en este momento");
            }

            if (!clientCanRent)
            {
                throw new InvalidOperationException("El cliente no puede realizar un alquiler en este momento");
            }
        }
    }
}
