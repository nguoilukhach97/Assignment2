using Assignment2.App.DTOs;
using Assignment2.App.Manages;
using Assignment2.App.ViewModels;
using Assignment2.App.Common;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment2.Services
{
    public class StudentAPI : BaseApiClient, IStudentAPI
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        
        public StudentAPI(IHttpClientFactory httpClient,  IConfiguration configuration)
            : base(httpClient, configuration)
        {
            _httpClientFactory = httpClient;
            _configuration = configuration;
        }


        public async Task<PagedViewModel<StudentViewModel>> GetAllPaging(string keyword,int pageIndex, int pageSize)
        {
            var data = await GetAsync<PagedViewModel<StudentViewModel>>(
                $"/api/student/student-search?keyword={keyword}&pageIndex={pageIndex}" +
                $"&pageSize={pageSize}");

            return data;
        }
        [HttpPost]
        public async Task<int> Create(StudentCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json,Encoding.UTF8,"application/json");

            var response = await client.PostAsync($"/api/student/create-student",httpContent);

            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<int>(result);

            return JsonConvert.DeserializeObject<int>(result);
        }


    }
}
