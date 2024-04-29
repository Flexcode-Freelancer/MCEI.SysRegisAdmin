#region REFERENCIAS
// Referencias Necesarias Para El Correcto Funcionamiento
using MCEI.SysRegisAdmin.BL.Membership___BL;
using MCEI.SysRegisAdmin.BL.ProfessionOrStudy___BL;
using MCEI.SysRegisAdmin.EN.Membership___EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



#endregion

namespace MCEI.SysRegisAdmin.WebApp.Controllers.Membership___Controller
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Desarrollador")]
    public class MembershipController : Controller
    {
        // Creamos Una Instancia Para Acceder a Los Metodos
        MembershipBL membershipBL = new MembershipBL();
        ProfessionOrStudyBL professionOrStudyBL = new ProfessionOrStudyBL();

        #region METODO PARA MOSTRAR INDEX
        // Accion Para Mostrar La Vista Index
        [Authorize(Roles = "Desarrollador")]
        public async Task<IActionResult> Index(Membership membership = null!)
        {
            if (membership == null)
                membership = new Membership();

            var memberships = await membershipBL.SearchIncludeProfessionOrStudyAsync(membership);
            var professionOrStudies = await professionOrStudyBL.GetAllAsync();

            ViewBag.ProfessionOrStudies = professionOrStudies;
            return View(memberships);
        }
        #endregion

        #region METODO PARA CREAR
        // Accion Para Mostrar La Vista De Crear
        [Authorize(Roles = "Desarrollador")]
        public async Task<IActionResult> Create()
        {
            ViewBag.ProfessionOrStudies = await professionOrStudyBL.GetAllAsync();
            ViewBag.Error = "";
            return View();
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [Authorize(Roles = "Desarrollador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Membership membership, IFormFile imagen)
        {
            try
            {
                // Mapeo de img a ArrayByte
                if (imagen != null && imagen.Length > 0)
                {
                    byte[] imagenData = null!;
                    using (var memoryStream = new MemoryStream())
                    {
                        await imagen.CopyToAsync(memoryStream);
                        imagenData = memoryStream.ToArray();
                    }

                    membership.ImageData = imagenData; // Asigna el array de bytes al campo de la imagen en tu modelo Membership
                }
                membership.DateCreated = DateTime.Now;
                membership.DateModification = DateTime.Now;
                int result = await membershipBL.CreateAsync(membership);
                TempData["SuccessMessageCreate"] = "Miembro Agregado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.ProfessionOrStudies = await professionOrStudyBL.GetAllAsync();
                return View(membership);
            }
        }

        #endregion
    }
}
