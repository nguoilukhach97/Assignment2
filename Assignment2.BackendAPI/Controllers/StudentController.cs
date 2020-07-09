using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.App.Manages;
using Assignment2.App.Repository;
using Assignment2.App.ViewModels;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            var data = await _service.GetAllStudent(pageIndex,pageSize);
            return Ok(data);
        }

        [HttpGet("student-search")]
        public async Task<IActionResult> SearchStudent(string keyword, int pageIndex, int pageSize)
        {
            var dataStudent = await _service.GetAllPaging(keyword,pageIndex, pageSize);
            return Ok(dataStudent);
        }


        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetById(int studentId)
        {
            var student = await _service.GetById(studentId);
            if (student == null)
                return BadRequest("Cannot find Student");
            return Ok(student);
        }
        [HttpPost("create-student")]
        public async Task<IActionResult> Create([FromBody]StudentCreateRequest request)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await _service.Create(request);
            if (result<=0)
                return BadRequest(result);

            return Ok();
        }
        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] StudentCreateRequest request)
        //{
        //    var result = await _service.Update(request);
        //    if (result == 0)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();
        //}

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> Delete(int studentId)
        {
            var result = await _service.Delete(studentId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        
    }
}
