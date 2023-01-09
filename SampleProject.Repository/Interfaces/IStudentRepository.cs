using SampleProject.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository.Interfaces
{
   public interface IStudentRepository
    {
       
        Task<BaseResponse> GetAllStudent();

        Task<BaseResponse> GetStudent(string Id);

        Task<BaseResponse> AddStudent(Student student);

        Task<BaseResponse> DeleteStudent(string Id);

        Task<BaseResponse> UpdateStudent(Student student);
    }
}
