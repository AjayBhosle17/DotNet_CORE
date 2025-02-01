using _03_State_Management_Controller_To_View.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace _03_State_Management_Controller_To_View.Controllers
{
    public class CacheController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CacheController> _logger;

        public CacheController(IMemoryCache cache, ILogger<CacheController> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public IActionResult Index()
        {
            string Name = string.Empty;

            // Fetching Name from Cache
            if (_cache.TryGetValue("name", out string value))
            {
                Name = value;
                _logger.LogInformation("Name fetched from Cache");
            }
            else
            {
                Name = "Ajay Bhosle";
                _cache.Set("name", Name, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Set expiration
                });
                _logger.LogInformation("Name fetched from Database");
            }

            // Fetching Customers from Cache
            if (_cache.TryGetValue("customer", out List<Customer> customers))
            {
                ViewBag.Customers = customers;
                _logger.LogInformation("Customers fetched from Cache");
            }
            else
            {
                List<Customer> customers1 = new List<Customer>()
                {
                    new Customer() { Name = "Ajay Bhosle", Age = 23, Email = "ajaybhosle.comp@gmail.com" },
                    new Customer() { Name = "Vijay Bhosle", Age = 22, Email = "Vijay@gmail.com" }
                };

                _cache.Set("customer", customers1, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Set expiration
                });

                ViewBag.Customers = customers1;
                _logger.LogInformation("Customers fetched from Database");
            }

            return View((object)Name);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
