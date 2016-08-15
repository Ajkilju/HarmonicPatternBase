using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FiboBase.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Patterns()
        {
            return View();
        }

        public IActionResult Reactions()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}