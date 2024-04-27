#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations;
using MCEI.SysRegisAdmin.EN.Membership___EN;


#endregion

namespace MCEI.SysRegisAdmin.EN.ProfessionOrStudy___EN
{
    public class ProfessionOrStudy
    {
        #region ATRIBUTOS DE LA ENTIDAD
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        [Display(Name = "Nombre")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ/ ]+$", ErrorMessage = "El Nombre debe contener solo Letras")]
        public string Name { get; set; } = string.Empty;
        #endregion

        public List<Membership> Memberships { get; set; } = new List<Membership>(); //Propiedad de navegacion
    }
}
