using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Repository.Config;
using Microsoft.Extensions.Configuration;

namespace Demo.XUnitTest.Config
{
    public class DbConfigurationReader 
    {
        public IConfigurationRoot GetConfigurationRoot(string basePath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
        
        public DbConfiguration? GetDbConfiguration(string basePath)
        {
            var iConfigRoot = GetConfigurationRoot(basePath);

            return iConfigRoot
                .GetSection("DbConfiguration")
                .Get<DbConfiguration>();

        }
    }
}