using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment2.Services
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        

        protected BaseApiClient(IHttpClientFactory httpClientFactory,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            
            _httpClientFactory = httpClientFactory;
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
           
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body,
                    typeof(TResponse));

                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }
    }
}
