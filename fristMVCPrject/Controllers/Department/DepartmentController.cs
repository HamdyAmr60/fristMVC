using fristMVCBLL.repositories;
using fristMVCDAL.Models;
using Microsoft.AspNetCore.Mvc;


namespace fristMVCPL.Controllers.Departmentc
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            {
               var count = _departmentRepository.Add(department);
                if (count > 0) {
                    return Redirect(nameof(Index));
                }
            }
           
            return View(department);
        }

        //public IActionResult Delete(Department department)
        //{
        //    var count = _departmentRepository.Delete(department);
           
        //    return Redirect(nameof(Index));
        //}
    }

}
