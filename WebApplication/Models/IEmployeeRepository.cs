using System.Collections;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public interface IEmployeeRepository
    {
        Employee Get(int Id);

        Employee Add(Employee employee);

        Employee Delete(int Id);

        IEnumerable<Employee> GetAllEmployees();

        Employee Update(Employee employee);
    }
}