#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MCEI.SysRegisAdmin.EN.Privilege___EN;
using MCEI.SysRegisAdmin.EN.Membership___EN;


#endregion

namespace MCEI.SysRegisAdmin.EN.Server___EN
{
    public class Server
    {
        #region ATRIBUTOS DE LA ENTIDAD
        [Key]
        public int Id { get; set; }

        [ForeignKey("Membership")]
        [Required(ErrorMessage = "La Membresia es Requerida")]
        [Display(Name = "Membresia")]
        public int IdMembership { get; set; }

        [ForeignKey("Privilege")]
        [Required(ErrorMessage = "El Privilegio Es Requerido")]
        [Display(Name = "Privilegio")]
        public int IdPrivilege { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public byte Status { get; set; }

        [Display(Name = "Fecha de Creacion")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Fecha de Modificacion")]
        public DateTime DateModification { get; set; }
        #endregion

        public Privilege? Privilege { get; set; } // Propiedadd de Navegacion

        public Membership? Memberhsip { get; set; }// Propiedad de Navegacion
    }
}
