using GtMotive.Estimate.Microservice.Api.Models.Client.ValueObjects;
using GtMotive.Generic.Microservice.Domain;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Specs
{
    public class ValueObjectsUnitTest
    {
        [Fact]
        public void TestNifValueObjectOkValue()
        {
            var value = "12345678A";
            var nif = new NifValueObject(value);

            Assert.Equal(value, nif.Value);
        }

        // Creating a new instance of NifValueObject with a value that is one character shorter than the minimum length for a Passport should raise an ArgumentException.
        [Fact]
        public void TestNifValueObjectInvalidValue()
        {
            var value = "123456";

            Assert.Throws<DomainException>(() => new NifValueObject(value));
        }
    }
}
