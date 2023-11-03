using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain.Model;
using Demo.Domain.Service;
using Xunit;

namespace Demo.XUnitTest
{   
    public class AssertTest
	{
		[Fact]
		public void Assert_Int_Test()
		{
			int expected = 1;
			int actual = 1;

			Assert.Equal(expected, actual);
		}

        [Fact]
        public void Assert_Double_Test()
        {
            double expected = 1.72;
			double actual = 1.73;

            Assert.Equal(expected, actual, 1);
        }

        [Fact]
        public void Assert_String_Test()
        {
            Naming name = new Naming();
            string actual = name.MakeFullName("Neutro", "Foton");

            Assert.Contains("neutro", actual, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void Assert_String_Regex_Test()
        {
            Naming name = new Naming();
            string actual = name.MakeFullName("Neutro", "Foton");

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", actual);
        }

        [Fact]
        public void Assert_Collection_All_Test()
        {
            var calc = new Calculator();
            Assert.All(calc.FiboNumbers, x => Assert.NotEqual(0, x));
        }

        [Fact]
        public void Assert_Collection_Contain_Test()
        {
            var calc = new Calculator();
            Assert.Contains(13, calc.FiboNumbers);
        }

        [Trait("category","customer")]
        [Fact]
        public void Assert_Range_Test()
        {
            var cust = new Customer();
            Assert.InRange<int>(cust.Age, 25, 35);
        }

        [Trait("category", "customer")]
        [Fact]
        public void Assert_Exception_Test()
        {
            string? name = null;

            var cust = new Customer();
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()=>cust.GetOrder(name!));
            Assert.Equal("name should not be null", exception.ParamName);
        }

        [Trait("category", "customer")]
        [Fact]
        public void Assert_Type_Test()
        {
            var cust = CustomerFactory.CreateCustomer(200);

            Assert.IsAssignableFrom<Customer>(cust);
            Assert.IsType<LoyalCustomer>(cust);
        }
    }
}