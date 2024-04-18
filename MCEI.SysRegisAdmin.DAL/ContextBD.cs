#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using Microsoft.EntityFrameworkCore;
using MCEI.SysRegisAdmin.EN.User___EN;
using MCEI.SysRegisAdmin.EN.Role___EN;


#endregion

namespace MCEI.SysRegisAdmin.DAL
{
    public class ContextBD : DbContext
    {
        #region REFERENCIAS DE TABLAS DE LA BD
        //Coleccion que hace referencia a la tabla de la base de datos
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        #endregion

        // Metodo de Conexion a la Base de Datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@""); // String de Conexion
        }
    }
}
