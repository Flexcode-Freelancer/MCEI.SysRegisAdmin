#region REFERENCIAS
// Referencias Necesarias Para El Correcto Funcionamiento
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace MCEI.SysRegisAdmin.WebApp.Controllers.Dashboard___Controller
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Desarrollador")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
