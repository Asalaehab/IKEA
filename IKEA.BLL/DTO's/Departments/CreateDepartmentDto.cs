using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO_s.Departments
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage ="Code is Required")]
        public string Code { get; set; } = null!;

        public DateOnly CreationDate { get; set; }

        public string? Description { get; set; }
    }
}
