using IKEA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Persistance.Repositiories.Departments
{
    //GetAll GetById
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool WithNoTracking = true);
        Department? GetById(int id);
        int Add(Department department);
        int Update(Department department);
        int Remove(Department department);
    }
}
