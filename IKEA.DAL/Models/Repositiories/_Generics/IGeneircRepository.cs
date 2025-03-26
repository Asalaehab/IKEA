using IKEA.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Repositiories._Generics
{
    public interface IGeneircRepository<T> where T : ModelBaseClass
    {
        IEnumerable<T> GetAll(bool WithNoTracking = true);
        T? GetById(int id);
        int Add(T item);
        int Update(T item);
        int Remove(T item);
    }
}
