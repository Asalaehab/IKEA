using IKEA.BLL.DTO_s.Departments;
using IKEA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        //Services
        //DTO ==>Data Transfer Object

        //Get All By Id
        IEnumerable<DepartmentDTO> GetDepartments();

        DepartmentDetailsDto? GetDepartmentById(int id);

        int CreateDepartment(CreateDepartmentDto departmentDto);

        int UpdateDepartment(UpdatedDepartmentDto departmentDto);

        bool DeletedDeparement(int id);
    }
}
