using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Demo.XUnitTest.Model
{
    [Collection("Customer")]
    public class SharedFixtureAccrossTest_CustomerAgeTest
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly CustomerFixture customerFixture;

        public SharedFixtureAccrossTest_CustomerAgeTest(ITestOutputHelper testOutputHelper, CustomerFixture customerFixture)
		{
            this.testOutputHelper = testOutputHelper;
			this.customerFixture = customerFixture;
		}

        [Fact]
        public void Age_Should_Be_GreatherThanEqual_30()
        {
            Assert.True(customerFixture.Cust.Age >= 30);

            int localRandom = new Random((int)DateTime.Now.Ticks).Next();
            this.testOutputHelper.WriteLine($"customerFixture random ={customerFixture.Random}");
            this.testOutputHelper.WriteLine($"Local random ={localRandom}");
        }
    }
}