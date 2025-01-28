using _01_MVC_Core_Introduction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _01_MVC_Core_Introduction.ViewComponents
{
    public class FakeUsersViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Users> users = new List<Users>();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users");

            HttpResponseMessage response = client.GetAsync(" ").Result;

            string result = response.Content.ReadAsStringAsync().Result;

            users = JsonSerializer.Deserialize<List<Users>>(result);


            return View("FakeUsers", users);
        }
    }
}
