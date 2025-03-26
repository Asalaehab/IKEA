using IKEA.BLL.DTO_s.Departments;
using IKEA.BLL.Services.Departments;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Repositiories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.DepartmentsServices
{
    public class DepartmentServices:IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            var Deparments = departmentRepository.GetAll().Select(dept => new DepartmentDTO()
            {
                Id = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                CreationDate = dept.CreationDate
            });
            return Deparments;
            //var Deparments = departmentRepository.GetAll();
            //List<DepartmentDTO> departmentDTOs = new List<DepartmentDTO>();

            //foreach (var dept in Deparments)
            //{
            //    DepartmentDTO departmentDTO = new DepartmentDTO
            //    {
            //        Id=dept.Id,
            //        Name=dept.Name,
            //        Code=dept.Code,
            //        CreationDate=dept.CreationDate
            //    };
            //    departmentDTOs.Add(departmentDTO);
            //}
            //return departmentDTOs;
        }


        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var Department = departmentRepository.GetById(id);
            if (Department is not null)
                return new DepartmentDetailsDto()
                {
                    Id=Department.Id,
                    Name=Department.Name,
                    Code=Department.Code,
                    CreationDate=Department.CreationDate,
                    IsDeleted=Department.IsDeleted,
                    LastModifiedOn=Department.LastModifiedOn,
                    LastModifiedBy=Department.LastModifiedBy,
                    createdBy=Department.createdBy,
                    CreatedOn=Department.CreatedOn
                };
            else
                return null;
        }



        public int CreateDepartment(CreateDepartmentDto departmentDto)
        {
            var CreatedDepartment = new Department()
            {
                Code=departmentDto.Code,
                Name=departmentDto.Name,
                Description=departmentDto.Description,
                CreationDate=departmentDto.CreationDate,
                createdBy=1,
                LastModifiedBy=1,
                LastModifiedOn=DateTime.Now
            };
            return departmentRepository.Add(CreatedDepartment);
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var UpdatedDepartment = new Department()
            {
                Id = departmentDto.Id,
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now
            };
            return departmentRepository.Update(UpdatedDepartment);
        }

        public bool DeletedDeparement(int id)
        {
            var department = departmentRepository.GetById(id);
            int Result = 0;
            if (department is not null)

                Result = departmentRepository.Remove(department);
            if (Result > 0)
                return true;
            else
                return false;
        }

    }
}
