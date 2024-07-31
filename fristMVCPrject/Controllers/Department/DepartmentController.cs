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
        [ValidateAntiForgeryToken]
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

        public IActionResult Delete(Department department)
        {
          var count =    _departmentRepository.Delete(department);

            if (count > 0)
            {
                TempData["SuccessMessage"] = "Department Deleted successfully.";
                var AllDepartments = _departmentRepository.GetAll();

                return Redirect("/Department");
            }
            else
            {
                TempData["ErrorMessage"] = "no such a department";
                // var error = "no such a Department";
                return Redirect("/Department");
            }

            
        }


        public IActionResult Details(int? id) 
        {
            if(id is not null)
            {
                var DepartmentDetails = _departmentRepository.Get(id);

                if (DepartmentDetails == null)
                {
                    return NotFound();
                }
                return View(DepartmentDetails);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            
            var UpdatedDepartment = _departmentRepository.Get(id);
            return View(UpdatedDepartment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Department updated successfully.";
                _departmentRepository.Update(department);
                return Redirect("/Department");
            }
            else {
                TempData["ErrorMessage"] = "not updated";
                return View(department);
            } 
        }
    }

}
