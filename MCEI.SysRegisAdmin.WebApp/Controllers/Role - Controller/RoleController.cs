#region REFERENCIAS
using Microsoft.AspNetCore.Http;
// Referencias Necesarias Para El Correcto Funcionamiento
using Microsoft.AspNetCore.Mvc;
using MCEI.SysRegisAdmin.BL.Role___BL;
using MCEI.SysRegisAdmin.EN.Role___EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;



#endregion

namespace MCEI.SysRegisAdmin.WebApp.Controllers.Role___Controller
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Desarrollador")]
    public class RoleController : Controller
    {
        // Instancia De La Clase Logica De Negocio
        RoleBL roleBL = new RoleBL();

        #region METODO PARA INDEX
        // Metodo Para Mostrar La Vista Index
        public async Task<IActionResult> Index(Role role = null!)
        {
            if (role == null)
                role = new Role();
            if (role.Top_Aux == 0)
                role.Top_Aux = 10; // setear el número de registros a mostrar
            else if (role.Top_Aux == -1)
                role.Top_Aux = 0;

            var roles = await roleBL.SearchAsync(role);
            ViewBag.Top = role.Top_Aux;

            return View(roles);
        }
        #endregion

        #region METODO PARA GUARDAR
        // Metodo Para Mostrar La Vista Guardar
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // Metodo Que Recibe y Envia a La Base De Datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            try
            {
                int result = await roleBL.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(role);
            }
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Mostrar La Vista De Modificar
        public async Task<IActionResult> Edit(int id)
        {
            var role = await roleBL.GetByIdAsync(new Role { Id = id });
            ViewBag.Error = "";
            return View(role);
        }

        // Metodo Que Recibe y Envia a La Base De Datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Role role)
        {
            try
            {
                int result = await roleBL.UpdateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(role);
            }
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Mostrar La Vista De Eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var role = await roleBL.GetByIdAsync(new Role { Id = id });
            ViewBag.Error = "";
            return View(role);
        }

        // Metodo Que Recibe y Envia a La Base De Datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Role role)
        {
            try
            {
                int result = await roleBL.DeleteAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(role);
            }
        }
        #endregion

        #region METODO PARA DETALLES
        // Metodo que Muestra La Vista De Detalles
        public async Task<IActionResult> Details(int id)
        {
            var role = await roleBL.GetByIdAsync(new Role { Id = id });
            return View(role);
        }
        #endregion

    }
}