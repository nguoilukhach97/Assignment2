using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Assignment2.Data.EF;
using Assignment2.App;
using Assignment2.App.Manages;
using Assignment2.Services;
using Microsoft.Extensions.Configuration;
using DocumentFormat.OpenXml.Bibliography;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentAPI _studentAPI;
        private readonly IConfiguration _configuration;
        public HomeController(IStudentAPI studentAPI,IConfiguration configuration)
        {
            _studentAPI = studentAPI;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string keyword,int pageIndex=1,int pageSize=3,int sort=0)
        {
            var data = await _studentAPI.GetAllPaging(keyword,pageIndex,pageSize,sort);
            
            ViewBag.keyword = keyword;
            return View(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(StudentUpdateRequest request, string Commune, string District, string Province)
        {
            if (!ModelState.IsValid)
                return View("/Home/Error");
            request.Address = request.Address + $", {Commune}, {District}, {Province}";
            if (request.Id==0)
            {
                var stCreate = new StudentCreateRequest()
                {
                    IdAddress = request.IdAddress,
                    Name = request.Name,
                    Address=request.Address,
                    PhoneNumber= request.PhoneNumber,
                    YearOfBirth = request.YearOfBirth
                };
                var result = await _studentAPI.Create(stCreate);
            }
            else
            {
                var result = await _studentAPI.Update(request);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int studentId)
        {
            var result = await _studentAPI.Delete(studentId);
            
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<JsonResult> GetStudent(int id,int idAddress)
        {
            var data = await _studentAPI.GetStudent(id);
            var adress = await _studentAPI.GetIdAddress(idAddress);
            var request = new GetInfoUpdateRequest() { 
                Student = data,
                Address = adress
            };
            return new  JsonResult(request);
        }

        [HttpGet]
        public async Task<JsonResult> GetProvince()
        {
            var data = await _studentAPI.GetProvine();
            return new JsonResult(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetDistrict(int id)
        {
            var data = await _studentAPI.GetDistrict(id);
            return new JsonResult(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetCommune(int id)
        {
            var data = await _studentAPI.GetCommune(id);
            return new JsonResult(data);
        }
      
    }
}
