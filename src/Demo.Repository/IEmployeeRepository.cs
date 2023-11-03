using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain.Model;

namespace Demo.Repository
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetEmployeesAsync();

        Employee? GetEmployeeById(int id);
        bool AddEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
    }

}