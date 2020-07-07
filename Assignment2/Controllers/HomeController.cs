using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2.App.Public;
using Assignment2.Data.EF;
using Assignment2.App;
using Assignment2.App.Manages;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManageStudentService _service;
        public HomeController(IManageStudentService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(StudentCreateRequest request)
        {
            _service.Create(request);
            return View();
        }
        public IActionResult test()
        {
            
            return View();
        }
    }
}
