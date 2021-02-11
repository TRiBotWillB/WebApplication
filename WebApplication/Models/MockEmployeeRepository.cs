using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id=1, Name = "John", Department = "HR", Email = "john@gmail.com"},
                new Employee() {Id=2, Name = "Steve", Department = "IT", Email = "steve@gmail.com"},
                new Employee() {Id=3, Name = "Mary", Department = "IT", Email = "mary@gmail.com"},
            };
            
            
        }
        
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(employee => employee.Id == Id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
    }
}