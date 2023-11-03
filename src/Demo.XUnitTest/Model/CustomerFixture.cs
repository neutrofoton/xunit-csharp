using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain.Model;

namespace Demo.XUnitTest.Model
{
    public class CustomerFixture
	{
		public Customer Cust => new Customer();
        public int Random = new Random((int)DateTime.Now.Ticks).Next();

    }
}