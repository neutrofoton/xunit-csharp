using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Demo.XUnitTest.Model
{
    [Collection("Customer")]
    public class SharedFixtureAccrossTest_CustomerNameTest
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly CustomerFixture customerFixture;

		public SharedFixtureAccrossTest_CustomerNameTest(ITestOutputHelper testOutputHelper, CustomerFixture customerFixture)
		{
			this.testOutputHelper = testOutputHelper;
            this.customerFixture = customerFixture;
		}

		[Fact]
		public void Customer_Name_Should_Not_Null()
		{
			Assert.NotNull(customerFixture.Cust.Name);

            int localRandom = new Random((int)DateTime.Now.Ticks).Next();
            this.testOutputHelper.WriteLine($"customerFixture random ={customerFixture.Random}");
            this.testOutputHelper.WriteLine($"Local random ={localRandom}");
        }
    }
}