#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// References Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations;
using MCEI.SysRegisAdmin.EN.User___EN;



#endregion

namespace MCEI.SysRegisAdmin.EN.Role___EN
{
    public class Role
    {
        #region ATRIBUTOS DE LA ENTIDAD
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [Display(Name = "Nombre")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ/ ]+$", ErrorMessage = "El Nombre debe contener solo Letras")]
        public string Name { get; set; } = string.Empty;
        #endregion

        public List<User>? Users { get; set; } // propiedad de navegación
    }
}
