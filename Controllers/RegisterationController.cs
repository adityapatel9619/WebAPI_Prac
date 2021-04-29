using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Prac.Controllers
{
    public class RegisterationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
