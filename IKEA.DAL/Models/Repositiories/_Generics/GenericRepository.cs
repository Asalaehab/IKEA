using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Repositiories._Generics
{
    public class GenericRepository<T> : IGeneircRepository<T> where T :ModelBaseClass
    {
        //Service
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public T? GetById(int id)
        {
            var item = _dbContext.Set<T>().Find(id);
            return item;
        }

        //Get All
        public IEnumerable<T> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbContext.Set<T>().ToList();
            else
                return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        //Update
        public int Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            return _dbContext.SaveChanges();
        }

        //Delete
        public int Remove(T item)
        {
            _dbContext.Set<T>().Remove(item);
            return _dbContext.SaveChanges();
        }
        //Insert
        public int Add(T item)
        {
            item.IsDeleted = true;
            _dbContext.Set<T>().Add(item);
            return _dbContext.SaveChanges();
        }
    }
}
