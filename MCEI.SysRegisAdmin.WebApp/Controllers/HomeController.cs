using MCEI.SysRegisAdmin.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MCEI.SysRegisAdmin.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
