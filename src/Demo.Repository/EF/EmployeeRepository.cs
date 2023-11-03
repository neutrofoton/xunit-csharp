using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Demo.Domain.Model;


namespace Demo.Repository.EF
{
    public class EmployeeRepository : EFRepository, IEmployeeRepository
    {
        public EmployeeRepository(EFContext efContext):base(efContext){

        }

        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            return await EFContext.Employees.ToListAsync();
        }

        public bool AddEmployee(Employee employee)
        {
            if (EFContext.Employees == null)
                return false;

            if(EFContext.Employees.Any(x=> x.Id==employee.Id)) 
                return false; 

            EFContext.Employees.Add(employee);
            EFContext.SaveChanges();
            return true;
        }

        public bool DeleteEmployee(Employee employee)
        {
            if (EFContext.Employees == null)
                return false;

            if (!EFContext.Employees.Any(x => x.Id == employee.Id)) { return false; }

            EFContext.Employees.Remove(employee);
            EFContext.SaveChanges();
            return true;
        }

        public Employee? GetEmployeeById(int id)
        {
            if (EFContext.Employees == null)
                return null;

            return EFContext.Employees.FirstOrDefault(x => x.Id == id);
        }

        public IList<Employee> GetEmployees()
        {
            if (EFContext.Employees == null)
                return new List<Employee>();

            return EFContext.Employees.ToList();
        }

        public bool UpdateEmployee(Employee employee)
        {
            if (EFContext.Employees == null)
                return false;

            if (!EFContext.Employees.Any(x => x.Id == employee.Id)) { return false; }

            EFContext.Employees.Update(employee);
            EFContext.SaveChanges();
            return true;
        }
    }
}