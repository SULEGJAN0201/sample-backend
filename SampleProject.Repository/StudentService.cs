using Dapper;
using SampleProject.Model;
using SampleProject.Repository.Interfaces;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository
{
    public class StudentService : IStudentRepository
    {

        private readonly string _connectionString;
        public StudentService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<BaseResponse> GetStudent(string Id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    para.Add("@Id", Id);
                    var results = await connection.QueryAsync<Student>("[getStudentDetails]", para, commandType: CommandType.StoredProcedure);

                    return new BaseResponseService().GetSuccessResponse(results);
                }
            }

            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }

        public async Task<BaseResponse> GetAllStudent()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var results = await connection.QueryAsync<Student>("[getAllStudentDetails]", commandType: CommandType.StoredProcedure);

                    return new BaseResponseService().GetSuccessResponse(results);
                }
            }

            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }

        public async Task<BaseResponse> AddStudent(Student student)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@Id", student.Id);
                    para.Add("@Fname", student.Fname);
                    para.Add("@Lname", student.Lname);
                    para.Add("@DOB", student.DOB);
                    para.Add("@Address", student.Address);



                    var results = await connection.QueryAsync<Student>("AddNewStudentStoredProcedure", para, commandType: CommandType.StoredProcedure);
                    Console.WriteLine("\n" + results + "\n");
                    return new BaseResponseService().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }


        public async Task<BaseResponse> DeleteStudent(string Id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@Id", Id);


                    var results = await connection.QueryAsync<Student>("DeleteStudent", para, commandType: CommandType.StoredProcedure);
                    return new BaseResponseService().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }

        public async Task<BaseResponse> UpdateStudent(Student student)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@Id", student.Id);
                    para.Add("@Fname", student.Fname);
                    para.Add("@Lname", student.Lname);
                    para.Add("@DOB", student.DOB);
                    para.Add("@Address", student.Address);



                    var results = await connection.QueryAsync<Student>("UpdateStudent", para, commandType: CommandType.StoredProcedure);
                    Console.WriteLine("\n" + results + "\n");
                    return new BaseResponseService().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseService().GetErrorResponse(ex);
            }
        }




    }
}