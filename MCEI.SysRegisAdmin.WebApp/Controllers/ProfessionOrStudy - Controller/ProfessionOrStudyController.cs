#region REFERENCIAS
// Referencias Necesarias Para El Correcto Funcionamiento
using MCEI.SysRegisAdmin.BL.ProfessionOrStudy___BL;
using MCEI.SysRegisAdmin.EN.ProfessionOrStudy___EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace MCEI.SysRegisAdmin.WebApp.Controllers.ProfessionOrStudy___Controller
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Desarrollador")]
    public class ProfessionOrStudyController : Controller
    {
        // Creamos Una Instancia Para Acceder a Los Metodos
        ProfessionOrStudyBL professionOrStudyBL = new ProfessionOrStudyBL();

        #region METODO PARA MOSTRAR INDEX
        // Accion Para Mostrar La Vista Index
        [Authorize(Roles = "Desarrollador")]
        public async Task<IActionResult> Index(ProfessionOrStudy professionOrStudy = null!)
        {
            if (professionOrStudy == null)
                professionOrStudy = new ProfessionOrStudy();

            var professionOrStudys = await professionOrStudyBL.SearchAsync(professionOrStudy);
            return View(professionOrStudys);
        }
        #endregion

        #region METODO PARA CREAR
        // Accion Para Mostrar La Vista De Crear
        [Authorize(Roles = "Desarrollador")]
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [Authorize(Roles = "Desarrollador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessionOrStudy professionOrStudy)
        {
            try
            {
                int result = await professionOrStudyBL.CreateAsync(professionOrStudy);
                TempData["SuccessMessageCreate"] = "Profesion u Oficio Agregado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Accion Que Muestra La Vista De Modificar
        [Authorize(Roles = "Desarrollador")]
        public async Task<IActionResult> Edit(int id)
        {
            var professionOrStudy = await professionOrStudyBL.GetByIdAsync(new ProfessionOrStudy { Id = id });
            ViewBag.Error = "";
            return View(professionOrStudy);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [Authorize(Roles = "Desarrollador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProfessionOrStudy professionOrStudy)
        {
            try
            {
                int result = await professionOrStudyBL.UpdateAsync(professionOrStudy);
                TempData["SuccessMessageUpdate"] = "Profesion u Oficio Modificado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(professionOrStudy);
            }
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Accion Que Muestra La Vista De Eliminar
        [Authorize(Roles = "Desarrollador")]
        public async Task<IActionResult> Delete(int id)
        {
            var professionOrStudy = await professionOrStudyBL.GetByIdAsync(new ProfessionOrStudy { Id = id });
            ViewBag.Error = "";
            return View(professionOrStudy);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [Authorize(Roles = "Desarrollador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ProfessionOrStudy professionOrStudy)
        {
            try
            {
                int result = await professionOrStudyBL.DeleteAsync(professionOrStudy);
                TempData["SuccessMessageDelete"] = "Profesion u Oficio Eliminada Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(professionOrStudy);
            }
        }
        #endregion

        #region METODO PARA MOSTRAR DETALLES
        // Accion Que Muestra El Detalle De Un Registro
        [Authorize(Roles = "Desarrollador")]
        public async Task<IActionResult> Details(int id)
        {
            var professionOrStudy = await professionOrStudyBL.GetByIdAsync(new ProfessionOrStudy { Id = id }); //Convertimos para mostrar muy bien
            return View(professionOrStudy); // Retornamos los Detalles a La Vista
        }
        #endregion
    }
}
