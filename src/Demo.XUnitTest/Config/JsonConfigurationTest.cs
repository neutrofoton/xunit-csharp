using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit.Abstractions;

namespace Demo.XUnitTest.Config
{
    public class JsonConfigurationTest
    {
        private ITestOutputHelper output;

        public JsonConfigurationTest(ITestOutputHelper output){
            this.output=output;
        }

        [Fact]
        public void Get_DbConnection_Test()
        {
            DbConfigurationReader configReader = new DbConfigurationReader();
            var configuration = configReader.GetDbConfiguration(AppContext.BaseDirectory);

            configuration
                .Should().NotBeNull("Configuration object cannot be null");

            if(configuration!=null){

                configuration.ConnectionString
                    .Should().NotBeNull("Connection string cannot be null.");

                configuration.ConnectionString
                    .Should().NotBeSameAs(String.Empty, "Connection cannot be an empty string");

                output.WriteLine($"Connection string is: {configuration.ConnectionString}");
            }
        }
    }
}