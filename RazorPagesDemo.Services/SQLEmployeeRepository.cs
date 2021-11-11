using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesDemo.Services
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee Add(Employee newEmployee)
        {
            _context.Database.ExecuteSqlRaw("spInsertEmployee {0}, {1}, {2}, {3}",
                                    newEmployee.Name,
                                    newEmployee.Email,
                                    newEmployee.PhotoPath,
                                    newEmployee.Department);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = _context.Employees;

            if (dept.HasValue)
            {
                query = query.Where(e => e.Department == dept.Value);
            }

            return query.GroupBy(e => e.Department)
                .Select(g => new DeptHeadCount()
                {
                    Department = g.Key.Value,
                    Count = g.Count()
                }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees
                .FromSqlRaw<Employee>("SELECT * FROM Employees")
                .ToList();
        }

        public Employee GetEmployee(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);
            
            return _context.Employees.FromSqlRaw<Employee>("spGetEmployeeById @Id", parameter)
                                     .ToList()
                                     .FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _context.Employees;
            }

            return _context.Employees.Where(e => e.Name.Contains(searchTerm) ||
                                            e.Email.Contains(searchTerm));
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = _context.Employees.Attach(updatedEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedEmployee;
        }
    }
}
