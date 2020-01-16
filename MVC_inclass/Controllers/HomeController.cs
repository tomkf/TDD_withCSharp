using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_inclass.Models;
using MVC_inclass.Repositories;
using MVC_inclass.Interfaces;


namespace MVC_inclass.Controllers
{
    public class HomeController : Controller
    {

       //dependency injection
        private IProductRepository _repo;


        public HomeController(IProductRepository productRepo)
        {
            _repo = productRepo;
        }


        public IActionResult Index()
        {

            var products = _repo.ProductList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Details(int id)
        {
            return View(_repo.GetProduct(id));
        }


    }
}
