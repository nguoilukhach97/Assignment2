using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Assignment2.Data.EF;
using Assignment2.App;
using Assignment2.App.Manages;
using Assignment2.Services;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentAPI _studentAPI;
        public HomeController(IStudentAPI studentAPI)
        {
            _studentAPI = studentAPI;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(StudentCreateRequest request)
        {
           
            return View();
        }
        
    }
}
