using IKEA.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        #region Index
        public IActionResult Index()
        {
            var Department = departmentService.GetDepartments();
            //return View(Department);
            return View(Department);
        } 
        #endregion
    }
}
