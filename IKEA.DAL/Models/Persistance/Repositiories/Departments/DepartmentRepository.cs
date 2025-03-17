using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Persistance.Repositiories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        //Service
        private readonly ApplicationDbContext dbContext;
        public DepartmentRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IEnumerable<Department> GetAll()
        {
            return dbContext.Departments.ToList();
        }

        public int Add(Department department)
        {
            throw new NotImplementedException();
        }

        public int Delete(Department department)
        {
            throw new NotImplementedException();
        }

        public Department? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
