﻿#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using Microsoft.EntityFrameworkCore;
using MCEI.SysRegisAdmin.EN.User___EN;
using MCEI.SysRegisAdmin.EN.Role___EN;
using MCEI.SysRegisAdmin.EN.ProfessionOrStudy___EN;
using MCEI.SysRegisAdmin.EN.Membership___EN;
using MCEI.SysRegisAdmin.EN.Privilege___EN;
using MCEI.SysRegisAdmin.EN.Server___EN;
using MCEI.SysRegisAdmin.EN.HistoryServer___EN;


#endregion

namespace MCEI.SysRegisAdmin.DAL
{
    public class ContextBD : DbContext
    {
        #region REFERENCIAS DE TABLAS DE LA BD
        //Coleccion que hace referencia a la tabla de la base de datos
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ProfessionOrStudy> ProfessionOrStudys { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<HistoryServer> HistoryServers { get; set; }
        #endregion

        // Metodo de Conexion a la Base de Datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=;Database=;Trusted_Connection=True;TrustServerCertificate=True"); // String de Conexion
        }
    }
}
