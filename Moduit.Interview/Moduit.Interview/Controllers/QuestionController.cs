using Microsoft.AspNetCore.Mvc;
using Moduit.Interview.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using JsonFlatten;
using Newtonsoft.Json;

namespace Moduit.Interview.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        const string url1 = "https://screening.moduit.id/backend/question/one";
        const string url2 = "https://screening.moduit.id/backend/question/two";
        const string url3 = "https://screening.moduit.id/backend/question/three";

        Question1ViewModel data = new Question1ViewModel();
        List<Question2ViewModel> data2 = new List<Question2ViewModel>();
        IQueryable<Question2ViewModel> data3 = null;

        [Route("api/question/GetQuestion1")]
        [HttpGet]
        public Question1ViewModel GetQueSstion1()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url1);

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<Question1ViewModel>().Result;  
            }
            return data;
        }


        [Route("api/question/GetQuestion2")]
        [HttpGet]
        public IQueryable<Question2ViewModel> GetQueSstion2()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url2);

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                data2 = response.Content.ReadAsAsync<List<Question2ViewModel>>().Result;
            }
            var test = data2.Where(x => x.description.Contains("Ergonomic") || x.title.Contains("Ergonomic") || (x.tags?.Contains("Sports") ?? false)).OrderByDescending(x => x.id).Take(3).Reverse().ToList().AsQueryable();
            return test;
        }

        [Route("api/question/GetQuestion3")]
        [HttpGet]
        public IQueryable<Question2ViewModel> GetQueSstion3()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url3);

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                data3 = response.Content.ReadAsAsync<List<Question2ViewModel>>().Result.AsQueryable();
            }

            foreach (var item in data3)
            {

            }


            return data3;
        }

    }
}
