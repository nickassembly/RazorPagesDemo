using RazorPagesDemo.Models;
using System.Collections.Generic;

namespace RazorPagesDemo.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pargimtech.com", PhotoPath="mary.png" },
                new Employee() {Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com", PhotoPath="john.png" },
                new Employee() {Id = 3, Name = "Sara", Department = Dept.IT, Email = "sara@pragimtech.com", PhotoPath= "sara.png"},
                new Employee() {Id = 4, Name = "David", Department = Dept.Payroll, Email = "david@pragimetch.com", PhotoPath= "noimage.jpg"}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
    }
}
