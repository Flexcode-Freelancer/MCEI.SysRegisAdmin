#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using MCEI.SysRegisAdmin.EN.Privilege___EN;
using Microsoft.EntityFrameworkCore;


#endregion

namespace MCEI.SysRegisAdmin.DAL.Privilege___EN
{
    public class PrivilegeDAL
    {
        #region METODO PARA CREAR
        // Metodo Para Crear Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(Privilege privilege)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                bool privilegeExists = await ExistPrivilege(privilege, dbContext);
                if (privilegeExists == false)
                {
                    dbContext.Priviliges.Add(privilege);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Privilegio Ya Existente");
            }
            return result;
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Modificar Un Registro Existente En La Base De Datos
        public static async Task<int> UpdateAsync(Privilege privilege)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                var privilegeDB = await dbContext.Priviliges.FirstOrDefaultAsync(c => c.Id == privilege.Id);
                if (privilegeDB != null)
                {
                    bool privilegeExist = await ExistPrivilege(privilege, dbContext);
                    if (privilegeExist == false)
                    {
                        privilegeDB.Name = privilege.Name;

                        dbContext.Update(privilegeDB);
                        result = await dbContext.SaveChangesAsync();
                    }
                    else
                        throw new Exception("Privilegio Ya Existente");
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public static async Task<int> DeleteAsync(Privilege privilege)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                var privilegeDB = await dbContext.Priviliges.FirstOrDefaultAsync(c => c.Id == privilege.Id);
                if (privilegeDB != null)
                {
                    dbContext.Priviliges.Remove(privilegeDB);
                    result = await dbContext.SaveChangesAsync();
                }
                return result;
            }
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar La Lista De Registros
        public static async Task<List<Privilege>> GetAllAsync()
        {
            var privileges = new List<Privilege>();
            using (var dbContext = new ContextBD())
            {
                privileges = await dbContext.Priviliges.ToListAsync();
            }
            return privileges;
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo Para Mostrar Un Registro En Base A Su Id
        public static async Task<Privilege> GetByIdAsync(Privilege privilege)
        {
            var privilegeDB = new Privilege();
            using (var dbContext = new ContextBD())
            {
                privilegeDB = await dbContext.Priviliges.FirstOrDefaultAsync(c => c.Id == privilege.Id);
            }
            return privilegeDB!;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS
        // Metodo Para Buscar Por Filtros
        internal static IQueryable<Privilege> QuerySelect(IQueryable<Privilege> query, Privilege privilege)
        {
            // Por ID
            if (privilege.Id > 0)
                query = query.Where(c => c.Id == privilege.Id);

            // Por Nombre
            if (!string.IsNullOrWhiteSpace(privilege.Name))
                query = query.Where(c => c.Name.Contains(privilege.Name));

            // Ordenamos de Manera Desendente
            query = query.OrderByDescending(c => c.Id).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo Para Buscar Registros Existentes
        public static async Task<List<Privilege>> SearchAsync(Privilege privilege)
        {
            var privilegee = new List<Privilege>();
            using (var dbContext = new ContextBD())
            {
                var select = dbContext.Priviliges.AsQueryable();
                select = QuerySelect(select, privilege);
                privilegee = await select.ToListAsync();
            }
            return privilegee;
        }
        #endregion

        #region METODO PARA VALIDAR UNICA EXISTENCIA
        // Metodo Para Validar La Unica Existencia De Un Registro y No Haber Duplicidad
        private static async Task<bool> ExistPrivilege(Privilege privilege, ContextBD dbContext)
        {
            bool result = false;
            var privileges = await dbContext.Priviliges.FirstOrDefaultAsync(p => p.Name == privilege.Name && p.Id != privilege.Id);
            if (privileges != null && privileges.Id > 0 && privileges.Name == privilege.Name)
                result = true;

            return result;
        }
        #endregion
    }
}
