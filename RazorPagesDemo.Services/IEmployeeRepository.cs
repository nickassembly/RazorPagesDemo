using RazorPagesDemo.Models;
using System.Collections.Generic;

namespace RazorPagesDemo.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee updatedEmployee);
    }
}
