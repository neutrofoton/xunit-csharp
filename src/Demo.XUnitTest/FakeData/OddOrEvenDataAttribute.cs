using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Demo.XUnitTest.FakeData
{
    public class OddOrEvenDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1, true };
            yield return new object[] { 200, false };
        }
    }
}