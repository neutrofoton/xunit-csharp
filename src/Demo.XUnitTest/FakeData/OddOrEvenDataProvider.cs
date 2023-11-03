using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.XUnitTest.FakeData
{
    public class OddOrEvenDataProvider
    {
        public static IEnumerable<object[]> Data
		{
			get
			{
				yield return new object[] { 1, true };
				yield return new object[] { 200, false };
			}
		}
    }
    
}