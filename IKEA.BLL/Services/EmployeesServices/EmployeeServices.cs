using IKEA.BLL.DTO_s.Employees;
using IKEA.DAL.Models.Repositiories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeesServices
{
    public class EmployeeServices:IEmployeeServices
    {
        private readonly EmployeeRepository repository;

        public EmployeeServices(EmployeeRepository repository)
        {
            this.repository = repository;
        }

        public int CreateEmployee(CreatedEmployeeDTO EmployeeDto)
        {
            throw new NotImplementedException();
        }

        public bool DeletedEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDTO> GetALLEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeDetailsDTO? GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(UpdatedEmployeeDTO EmployeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
