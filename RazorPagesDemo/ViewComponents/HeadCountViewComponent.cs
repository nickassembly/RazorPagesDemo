using Microsoft.AspNetCore.Mvc;
using RazorPagesDemo.Models;
using RazorPagesDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesDemo.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HeadCountViewComponent(IEmployeeRepository repository)
        {
            _employeeRepository = repository;
        }

        public IViewComponentResult Invoke(Dept? department = null)
        {
            var result = _employeeRepository.EmployeeCountByDept(department);
            return View(result);
        }

    }
}
