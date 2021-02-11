using System.Collections;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);

        IEnumerable<Employee> GetAllEmployees();
    }
}