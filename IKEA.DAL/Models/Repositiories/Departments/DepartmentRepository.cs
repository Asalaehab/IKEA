using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Repositiories._Generics;
using IKEA.DAL.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Repositiories.Departments
{
    public class DepartmentRepository :GenericRepository<Department>,IDepartmentRepository
    {
        
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext context):base(context)
        {
            _dbContext = context;
        }
    }
}
