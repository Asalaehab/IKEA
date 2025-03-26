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


    }
}
