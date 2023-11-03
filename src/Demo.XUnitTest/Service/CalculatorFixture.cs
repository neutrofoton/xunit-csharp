using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain.Model;
using Demo.Domain.Service;

namespace Demo.XUnitTest.Service
{
    public class CalculatorFixture : IDisposable
	{
      
        public Calculator Calc => new Calculator();
        public int Random = new Random((int)DateTime.Now.Ticks).Next();      
        public void Dispose()
        {
        }
    }

}