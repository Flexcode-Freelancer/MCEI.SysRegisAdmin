#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using MCEI.SysRegisAdmin.EN.Role___EN;
using Microsoft.EntityFrameworkCore;


#endregion

namespace MCEI.SysRegisAdmin.DAL.Role___DAL
{
    public class RoleDAL
    {
        #region METODO PARA GUARDAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(Role role)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                dbContext.Role.Add(role);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Modificar Un Registro Existente En La Base De Datos
        public static async Task<int> UpdateAsync(Role role)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                var roleDb = await dbContext.Role.FirstOrDefaultAsync(r => r.Id == role.Id);
                if (roleDb != null)
                {
                    roleDb.Name = role.Name;
                    dbContext.Role.Update(roleDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public static async Task<int> DeleteAsync(Role role)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                var roleDb = await dbContext.Role.FirstOrDefaultAsync(r => r.Id == role.Id);
                if (roleDb != null)
                {
                    dbContext.Role.Remove(roleDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MOSTRAR TODOS
        // Metodo Para Listar y Mostrar Todos Los Resultados
        public static async Task<List<Role>> GetAllAsync()
        {
            var roles = new List<Role>();
            using (var dbContext = new ContextBD())
            {
                roles = await dbContext.Role.ToListAsync();
            }
            return roles;
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo Para Obtener Un Registro Por Su Id
        public static async Task<Role> GetByIdAsync(Role role)
        {
            var roleDb = new Role();
            using (var dbContext = new ContextBD())
            {
                roleDb = await dbContext.Role.FirstOrDefaultAsync(r => r.Id == role.Id);
            }
            return roleDb!;
        }
        #endregion

        #region METODO PARA FILTRAR BUSQUEDA
        // Metodo Para Filtrar La Busqueda Por Parametros
        internal static IQueryable<Role> QuerySelect(IQueryable<Role> query, Role role)
        {
            if (role.Id > 0)
                query = query.Where(r => r.Id == role.Id);

            if (!string.IsNullOrWhiteSpace(role.Name))
                query = query.Where(r => r.Name.Contains(role.Name));

            query = query.OrderByDescending(r => r.Id);

            if (role.Top_Aux > 0)
                query = query.Take(role.Top_Aux).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo Para Buscar Registros Existentes En La Base De Datos
        public static async Task<List<Role>> SearchAsync(Role role)
        {
            var roles = new List<Role>();
            using (var dbContext = new ContextBD())
            {
                var select = dbContext.Role.AsQueryable();
                select = QuerySelect(select, role);
                roles = await select.ToListAsync();
            }
            return roles;
        }
        #endregion
    }
}
