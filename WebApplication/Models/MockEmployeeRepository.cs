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
                new Employee() {Id=1, Name = "John", Department = Dept.HR, Email = "john@gmail.com"},
                new Employee() {Id=2, Name = "Steve", Department = Dept.IT, Email = "steve@gmail.com"},
                new Employee() {Id=3, Name = "Mary", Department = Dept.Payroll, Email = "mary@gmail.com"},
            };
            
            
        }
        
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(employee => employee.Id == Id);
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            
            return employee;
        }

        public Employee RemoveEmployee(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
    }
}