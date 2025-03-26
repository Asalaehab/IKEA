using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Models.Repositiories._Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Repositiories.Employees
{
    public interface IEmployeeRepository : IGeneircRepository<Employee>
    {

    }
}
