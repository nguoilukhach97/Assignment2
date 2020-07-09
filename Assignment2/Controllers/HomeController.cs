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
        public async Task<IActionResult> Index(string keyword,int pageIndex=1,int pageSize=5)
        {
            var data = await _studentAPI.GetAllPaging(keyword,pageIndex,pageSize);
            ViewBag.keyword = keyword;
            return View(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateRequest request, string Commune, string District, string Province)
        {
            if (!ModelState.IsValid)
                return View();
            request.Address = request.Address + $", {Commune}, {District}, {Province}";
            var result = await _studentAPI.Create(request);

            return View(request);
        }
        
    }
}
