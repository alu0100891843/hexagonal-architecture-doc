using System;
using System.Threading;
using GtMotive.Estimate.Microservice.Api.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Host.Utils.Schedulers
{
    public static class MoveOldVehiclesScheduler
    {
        public static void Start(IServiceProvider serviceProvider)
        {
            var thread = new Thread(() =>
            {
                using var serviceScope = serviceProvider.CreateScope();
                var services = serviceScope.ServiceProvider;
                var scheduler = services.GetRequiredService<VehicleLogic>();
                var executionTime = DateTime.Today.AddHours(0).AddMinutes(0);

                TimeSpan timeLeft;
                if (DateTime.Now > executionTime)
                {
                    executionTime = executionTime.AddDays(1);
                    timeLeft = executionTime - DateTime.Now;
                }
                else
                {
                    timeLeft = executionTime - DateTime.Now;
                }

                using var timer = new Timer(
                    async callback =>
                    {
                        await scheduler.DeleteOldVehicles();
                    },
                    null,
                    timeLeft,
                    TimeSpan.FromHours(24));

                Thread.Sleep(timeLeft);
            });

            thread.Start();
        }
    }
}
