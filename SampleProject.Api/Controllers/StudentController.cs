using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Model;
using SampleProject.Repository.Interfaces;

namespace SampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentRepository _repository;



        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAllStudent()
        {
            var response = await _repository.GetAllStudent();

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        // [HttpGet("{Id}")]
        [HttpGet("Select/{Id}")]
        public async Task<ActionResult> GetStudent(string Id)
        {
            var response = await _repository.GetStudent(Id);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult> AddStudent([FromBody] Student student)
        {

            var response = await _repository.AddStudent(student);

            if (response.Success)
            {
                return StatusCode(StatusCodes.Status201Created, response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult> UpdateStudent([FromBody] Student student)
        {

            var response = await _repository.UpdateStudent(student);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete("DeleteStudent/{Id}")]
        public async Task<ActionResult> DeleteStudent(string Id)
        {

            var response = await _repository.DeleteStudent(Id);


            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }  
}
