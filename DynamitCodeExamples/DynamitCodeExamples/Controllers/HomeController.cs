using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamitCodeExamples.ViewModels;

namespace DynamitCodeExamples.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            QuestionOneViewModel vm = new QuestionOneViewModel();
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
