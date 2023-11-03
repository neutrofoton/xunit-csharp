using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.XUnitTest.Model
{
    [CollectionDefinition("Customer")]
	public class CustomerFixtureCollection : ICollectionFixture<CustomerFixture>
	{
		
	}
}