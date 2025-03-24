using IKEA.BLL.DTO_s.Departments;
using IKEA.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment environment;

   
        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> _logger, IWebHostEnvironment environment)
        {
            this.departmentService = departmentService;
            logger = _logger;
            this.environment = environment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Department = departmentService.GetDepartments();
            //return View(Department);
            return View(Department);
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto createDepartmentDto)
        {
            //server side validation

            if (!ModelState.IsValid)

                return View(createDepartmentDto);

            var Message = string.Empty;


            try
            {
                var Result = departmentService.CreateDepartment(createDepartmentDto);
                if (Result > 0)

                    return RedirectToAction(nameof(Index));
                else
                {
                    // prepare the message
                    Message = "Department is not created";

                    ModelState.AddModelError(string.Empty, Message);
                    return View(createDepartmentDto);

                }
            }
            catch (Exception ex)
            {
                //1.log exception Kestral
                logger.LogError(ex, ex.Message);

                //2.set default message user
                if (environment.IsDevelopment())
                {
                    Message = ex.Message;
                    ModelState.AddModelError(string.Empty, Message);
                    return View(createDepartmentDto);
                }
                else
                {
                    Message = "An Error Effect At the Creation Operatot";
                    ModelState.AddModelError(string.Empty, Message);
                    return View(createDepartmentDto);
                }

            }

        }
        #endregion


        #region Details Button
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = departmentService.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }
        #endregion
    }
}
