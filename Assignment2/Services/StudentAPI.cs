using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment2.Services
{
    public class StudentAPI : IStudentAPI
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;

        //public StudentAPI(IHttpClientFactory httpClient, IHttpContextAccessor accessor,IConfiguration configuration)
        //    : base(httpClient,accessor,configuration)
        //{
            
        //}

        
    }
}
