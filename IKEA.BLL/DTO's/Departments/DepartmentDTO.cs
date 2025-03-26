﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO_s.Departments
{
   public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        // public string? Description { get; set; }

        [Display(Name="Date Of Creation")]
        public DateOnly CreationDate { get; set; }
    }
}
