 
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Persistance.Repositiories.Departments
{
    public class DepartmentRepository :IDepartmentRepository
    {
        //Service
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department; 
        }

        //Get All
        public IEnumerable<Department>GetAll(bool WithTracking=false)
        {
            if (WithTracking)
                return _dbContext.Departments.ToList();
            else
                return _dbContext.Departments.AsNoTracking().ToList();
        }

        //Update
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        //Delete
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }
        //Insert
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }
    }
}
