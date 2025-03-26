using IKEA.DAL.Common;
using IKEA.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Data.Configrations.EmployeeConfigration
{
    class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("varchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");
            builder.Property(E => E.Gender).HasConversion
                (
                    (gender) => gender.ToString(),//store in database as string
                    (gender) =>(Gender) Enum.Parse(typeof(Gender),gender)//store in model as gender
                );

            builder.Property(E => E.EmployeeType).HasConversion
                (
                    (employeetype) => employeetype.ToString(),
                    (employeetype) => (EmployeeType) Enum.Parse(typeof(EmployeeType),employeetype)
                
                );

            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property(E => E.LastModifiedOn).HasComputedColumnSql("GetDate()");
        }
    }
}
