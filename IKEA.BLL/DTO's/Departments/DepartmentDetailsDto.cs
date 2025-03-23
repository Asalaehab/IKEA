using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO_s.Departments
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }


        #region Adminstrator
        public bool IsDeleted { get; set; } //Soft Deleted
        public int createdBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }


        #endregion

        #region Department
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }

        #endregion
    }
}
