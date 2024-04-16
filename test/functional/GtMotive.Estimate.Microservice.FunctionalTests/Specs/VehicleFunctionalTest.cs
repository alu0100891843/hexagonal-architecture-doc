using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using GtMotive.Estimate.Microservice.Host.Controllers;
using GtMotive.Estimate.Microservice.Host.Models.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    public class VehicleFunctionalTest : FunctionalTestBase
    {
        public VehicleFunctionalTest(CompositionRootTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task GetAll()
        {
            await Fixture.UsingRepository<VehicleController>(async service =>
            {
                var result = await service.GetAll();

                if (result.Result is OkObjectResult okObjectResult)
                {
                    var vehicles = okObjectResult.Value as Collection<VehicleDto>;

                    Assert.NotNull(vehicles);

                    Assert.NotEmpty(vehicles);
                }
                else
                {
                    throw new InvalidOperationException("La llamada no ha sido correcta");
                }
            });
        }
    }
}
