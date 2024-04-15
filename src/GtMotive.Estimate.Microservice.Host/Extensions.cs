using GtMotive.Estimate.Microservice.Api.Logic;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Extensions.Hosting
{
    public static class Extensions
    {
        public static void AddScopes(this IServiceCollection services)
        {
            services.AddScoped<VehicleLogic>();
            services.AddScoped<VehicleService>();

            services.AddScoped<ClientLogic>();
            services.AddScoped<ClientService>();

            services.AddScoped<RentLogic>();
            services.AddScoped<RentService>();

            services.AddSingleton<MongoService>();
        }
    }
}
