﻿using IKEA.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Employees
{
    public class Employee :ModelBaseClass
    {
        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        public string Address { get; set; } = null!;

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }
}
