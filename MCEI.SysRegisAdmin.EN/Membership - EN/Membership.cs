#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MCEI.SysRegisAdmin.EN.ProfessionOrStudy___EN;
using MCEI.SysRegisAdmin.EN.Server___EN;
using MCEI.SysRegisAdmin.EN.HistoryServer___EN;


#endregion


namespace MCEI.SysRegisAdmin.EN.Membership___EN
{
    public class Membership
    {
        #region Atributos de la Entidad
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre Es Requerido")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombres")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Debe contener solo Letras")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Apellido Es Requerido")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Apellidos")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Debe contener solo Letras")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Dui Es Requerido")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        [Display(Name = "Dui")]
        public string Dui { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Fecha De Nacimiento Es Requerida")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "Por favor, introduce una fecha válida")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Required(ErrorMessage = "La Edad Es Requerida")]
        [StringLength(3, ErrorMessage = "Maximo 3 caracteres")]
        [Display(Name = "Edad")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "La edad debe contener solo números")]
        public string Age { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Genero Es Requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        [Display(Name = "Genero")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Debe contener solo Letras")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Estado Civil Es Requerido")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        [Display(Name = "Estado Civil")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ/ ]+$", ErrorMessage = "Debe contener solo Letras")]
        public string CivilStatus { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Telefono Es Requerido")]
        [StringLength(9, ErrorMessage = "Maximo 9 caracteres")]
        [Display(Name = "Telefono")]
        [RegularExpression("^[0-9-]+$", ErrorMessage = "El Telefono debe contener solo números")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Direccion Es Requerida")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        [Display(Name = "Direccion de Residencia")]
        public string Address { get; set; } = string.Empty;

        [ForeignKey("ProfessionOrStudy")]
        [Required(ErrorMessage = "Profesion u Oficio Es Requerido")]
        [Display(Name = "Profesion u Oficio")]
        public int IdProfessionOrStudy { get; set; }

        [Required(ErrorMessage = "Lugar De Trabajo u Oficio Es Requerido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        [Display(Name = "Lugar De Trabajo o Estudio")]
        public string PlaceOfWorkOrStudy { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefono Del Trabajo u Oficio Es Requerido")]
        [StringLength(9, ErrorMessage = "Maximo 9 caracteres")]
        [Display(Name = "Telefono De Trabajo o Estudio")]
        [RegularExpression("^[0-9-]+$", ErrorMessage = "El Telefono de trabajo o estudio debe contener solo números")]
        public string WorkOrStudyPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fecha De Conversion Es Requerido")]
        [Display(Name = "Fecha De Conversion")]
        [DataType(DataType.Date, ErrorMessage = "Por favor, introduce una fecha válida")]
        public DateTime ConversionDate { get; set; } = DateTime.MinValue;

        [Required(ErrorMessage = "Lugar De Conversion Es Requerido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        [Display(Name = "Lugar De Conversion")]
        public string PlaceOfConversion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bautismo En Agua Es Requerido")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        [Display(Name = "Bautizmo En Agua")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ, ]+$", ErrorMessage = "Debe contener solo Letras")]
        public string WaterBaptism { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bautizmo Del Espiritu Santo Es Requerido")]
        [StringLength(2, ErrorMessage = "Maximo 2 caracteres")]
        [Display(Name = "Bautizmo Por El Espiritu Santo")]
        public string BaptismOfTheHolySpirit { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nombre Del Pastor Es Requerido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        [Display(Name = "Nombre Del Pastor")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Debe contener solo Letras")]
        public string PastorsName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Nombre Del Supervisor Es Requerido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        [Display(Name = "Nombre Del Supervisor")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Debe contener solo Letras")]
        public string SupervisorsName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Nombre Del Lider Es Requerido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        [Display(Name = "Nombre Del Lider Lider")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Debe contener solo Letras")]
        public string LeadersName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Tiempo De Asistir Es Requerido")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Tiempo de Asistir")]
        public string TimeToGather { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Zona Es Requerida")]
        [StringLength(1, ErrorMessage = "Maximo 1 caracteres")]
        [Display(Name = "Zona")]
        public string Zone { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Distrito Es Requerido")]
        [StringLength(1, ErrorMessage = "Maximo 1 caracteres")]
        [Display(Name = "Distrito")]
        public string District { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Sector Es Requerido")]
        [StringLength(1, ErrorMessage = "Maximo 1 caracteres")]
        [Display(Name = "Sector")]
        public string Sector { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Celula Es Requerida")]
        [StringLength(1, ErrorMessage = "Maximo 1 caracteres")]
        [Display(Name = "Celula")]
        public string Cell { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Estatus Es Requerido")]
        [Display(Name = "Estatus")]
        public byte Status { get; set; } 

        [Required(ErrorMessage = "Los Comentarios u Observaciones Son Requeridas")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        [Display(Name = "Comentarios u Observaciones")]
        public string CommentsOrObservations { get; set; } = string.Empty;

        [Display(Name = "Fecha de Creacion")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Fecha de Modificacion")]
        public DateTime DateModification { get; set; }

        [Display(Name = "Fotografia")]
        public byte[]? ImageData { get; set; }

        #endregion

        public ProfessionOrStudy? ProfessionOrStudy { get; set; } //propiedad de navegación

        public List<Server> Servers { get; set; } = new List<Server>(); // Propiedad de navegacion

        public List<HistoryServer> HistoryServers { get; set; } = new List<HistoryServer>(); // Propiedad de navegacion
    }

    public enum Membership_Status
    {
        ACTIVO = 1, INACTIVO = 2
    }
}
