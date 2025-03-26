using IKEA.BLL.DTO_s.Departments;
using IKEA.BLL.DTO_s.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeesServices
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeDTO> GetALLEmployees();

        EmployeeDetailsDTO? GetEmployeeById(int id);

        int CreateEmployee(CreatedEmployeeDTO EmployeeDto);

        int UpdateEmployee(UpdatedEmployeeDTO EmployeeDto);

        bool DeletedEmployee(int id);
    }
}
