using System;
using System.Net.Http;
using System.Net.Http.Headers;
namespace GameStarz.Models
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient{get;set;}
        
        public static void InitializedClient(string ApiKey)
        {
            ApiClient=new HttpClient();
            ApiClient.BaseAddress=new Uri("https://api-v3.igdb.com/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
           
            ApiClient.DefaultRequestHeaders.Add("user-key",ApiKey);

            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
      
    }
}