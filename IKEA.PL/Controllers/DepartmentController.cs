using IKEA.BLL.DTO_s.Departments;
using IKEA.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        #region Services - DI
        private readonly IDepartmentService departmentService;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment environment;


        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> _logger, IWebHostEnvironment environment)
        {
            this.departmentService = departmentService;
            logger = _logger;
            this.environment = environment;
        } 
        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var Department = departmentService.GetDepartments();
            //return View(Department);
            return View(Department);
        } 
        #endregion

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

        #region Update
        [HttpGet]//Request Get:/Department/Edit/10
        public IActionResult Edit(int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }
            var department = departmentService.GetDepartmentById(id.Value);

            if(department is null)
            {
                return NotFound();
            }
            var MappedDepartment = new UpdatedDepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                CreationDate=department.CreationDate,
                Description=department.Description
                
            };
            return View(MappedDepartment);
        }


        [HttpPost]
        public IActionResult Edit(UpdatedDepartmentDto updatedDepartmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedDepartmentDto);
            }

            //var department=

            var Message = string.Empty;
            try
            {
                var Result = departmentService.UpdateDepartment(updatedDepartmentDto);

                if(Result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Message = "Department is not updated";
                }
            }
            catch(Exception ex)
            {
                //1.log Exception
                logger.LogError(ex,ex.Message);

                //2.set Message

                Message = environment.IsDevelopment() ? ex.Message : "An Error has been Occured during Update";
            }
            ModelState.AddModelError(string.Empty, Message);
            return View(updatedDepartmentDto);
        }
        #endregion


        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Message = string.Empty;

            try
            {
                var IsDeleted=departmentService.DeletedDeparement(id);

                if (IsDeleted)
                    return RedirectToAction(nameof(Index));

                Message = "Department is Not Deleted";

            }
            catch (Exception ex)
            {
                //1.log Exception

                logger.LogError(ex, ex.Message);

                Message = environment.IsDevelopment() ? ex.Message : "An Error has been ocuurued during delete";
                throw;
            }
            ModelState.AddModelError(string.Empty,Message);
            return View(nameof(Delete), new {id=id});
        }
        #endregion
    }
}
