using fristMVCBLL.repositories;
using Microsoft.AspNetCore.Mvc;

namespace fristMVCPL.Controllers.Employee
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var allemployees = _employeeRepository.GetAll();
            return View(allemployees);
        }
    }
}
