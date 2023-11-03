using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain.Model;

namespace Demo.XUnitTest.DataFeeder
{
    public class EmployeeFakeDataGenerator
    {
        public static List<Employee> GetEmployeeList()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "J.D@gmail.com",
                    Phone = "123-456-7890"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Mark Luther",
                    Email = "M.L@gmail.com",
                    Phone = "123-456-7890"
                }
            };
        }
        
    }
}