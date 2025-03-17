using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models
{
   public class ModelBaseClass
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } //Soft Deleted
        public int createdBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LastModifiedOn { get; set; }


    }
}
