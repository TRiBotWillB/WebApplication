using System.Collections;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);

        Employee AddEmployee(Employee employee);

        Employee RemoveEmployee(int Id);

        IEnumerable<Employee> GetAllEmployees();
    }
}