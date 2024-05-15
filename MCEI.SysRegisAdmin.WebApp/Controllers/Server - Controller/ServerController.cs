#region REFERENCIAS
// Referencias Necesarias Para El Correcto Funcionamiento
using MCEI.SysRegisAdmin.BL.Membership___BL;
using MCEI.SysRegisAdmin.BL.Privilege___BL;
using MCEI.SysRegisAdmin.BL.Server___BL;
using MCEI.SysRegisAdmin.EN.Server___EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


#endregion

namespace MCEI.SysRegisAdmin.WebApp.Controllers.Server___Controller
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Desarrollador")]
    public class ServerController : Controller
    {
        // Creamos Una Instancia Para Acceder a Los Metodos
        ServerBL serverBL = new ServerBL();
        MembershipBL membershipBL = new MembershipBL();
        PrivilegeBL privilegeBL = new PrivilegeBL();

        #region METODO PARA MOSTRAR INDEX
        // Accion Para Mostrar La Vista Index
        [Authorize(Roles = "Desarrollador")]
        public async Task<IActionResult> Index(Server server = null!)
        {
            if (server == null)
                server = new Server();

            var serversWithMemberships = await serverBL.SearchIncludeMembershipAsync(server);
            var serversWithPrivileges = await serverBL.SearchIncludePrivilegeAsync(server);
            var allServers = serversWithMemberships.Union(serversWithPrivileges).ToList();
            var privileges = await privilegeBL.GetAllAsync();

            ViewBag.Privileges = privileges;
            return View(allServers);
        }

        #endregion
    }
}
