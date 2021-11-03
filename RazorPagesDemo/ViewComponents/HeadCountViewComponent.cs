using Microsoft.AspNetCore.Mvc;
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

        public IViewComponentResult Invoke()
        {
            var result = _employeeRepository.EmployeeCountByDept();
            return View(result);
        }

    }
}
