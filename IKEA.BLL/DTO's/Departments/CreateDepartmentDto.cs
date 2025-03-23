using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO_s.Departments
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateOnly CreationDate { get; set; }

        public string? Description { get; set; }
    }
}
