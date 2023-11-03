using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Domain.Model
{
    public class Customer
	{
		public string Name => "Me";
		public int Age => 30;

		public int GetOrder(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name should not be null");

			return new Random().Next(10,100);
		}
	}

	public class LoyalCustomer : Customer
	{

	}

	public class CustomerFactory
	{
		public static Customer CreateCustomer(int order)
		{
			if (order > 100)
				return new LoyalCustomer();

			return new Customer();
		}
	}
}