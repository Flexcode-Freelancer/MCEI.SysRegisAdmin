#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCEI.SysRegisAdmin.EN.Membership___EN;

// Referencias Necesarias Para El Correcto Funcionamiento
using MCEI.SysRegisAdmin.EN.Server___EN;
using MCEI.SysRegisAdmin.EN.User___EN;
using Microsoft.EntityFrameworkCore;


#endregion

namespace MCEI.SysRegisAdmin.DAL.Server___DAL
{
    public class ServerDAL
    {
        #region METDO PARA CREAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(Server server)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                bool serverExists = await ExistServer(server, dbContext);
                if (serverExists == false)
                {
                    dbContext.Servers.Add(server);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Servidor Ya Existente, Vuelve a Intentarlo");
            }
            return result;
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Modificar Un Registro Existente En La Base De Datos
        public static async Task<int> UpdateAsync(Server server)
        {
            int result = 0;
            using(var dbContext = new ContextBD())
            {
                var serverDB = await dbContext.Servers.FirstOrDefaultAsync(s => s.Id == server.Id);
                if (serverDB != null)
                {
                    bool serverExists = await ExistServer(server, dbContext);
                    if(serverExists == false)
                    {
                        serverDB.IdMembership = server.IdMembership;
                        serverDB.IdPrivilege = server.IdPrivilege;
                        serverDB.Status = server.Status;
                        serverDB.DateCreated = server.DateCreated;
                        serverDB.DateModification = server.DateModification;

                        dbContext.Update(serverDB);
                        result = await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Servidor Ya Existente, Vuelve a Intentarlo");
                    }
                }
                else
                {
                    throw new Exception("Servidor No Encontrado Para Actualizar");
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public static async Task<int> DeleteAsync(Server server)
        {
            int result = 0;
            using( var dbContext = new ContextBD())
            {
                var serverDB = await dbContext.Servers.FirstOrDefaultAsync(s => s.Id == server.Id);
                if( serverDB != null )
                {
                    dbContext.Servers.Remove(serverDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar La Lista De Registros
        public static async Task<List<Server>> GetAllAsync()
        {
            var servers = new List<Server>();
            using ( var dbContext = new ContextBD())
            {
                servers = await dbContext.Servers.ToListAsync();
            }
            return servers;
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo Para Mostrar Un Registro En Base A Su Id
        public static async Task<Server> GetByIdAsync(Server server)
        {
            var serversDB = new Server();
            using( var dbContext = new ContextBD())
            {
                serversDB = await dbContext.Servers.FirstOrDefaultAsync(s => s.Id == server.Id);
            }
            return serversDB!;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS
        // Metodo Para Buscar Por Filtros
        internal static IQueryable<Server> QuerySelect(IQueryable<Server> query, Server server)
        {
            // Por Id
            if (server.Id > 0)
                query = query.Where(m => m.Id == server.Id);

            // Por Miembro
            if (server.IdMembership > 0)
                query = query.Where(m => m.IdMembership == server.IdMembership);

            // Por Su Privilegio
            if (server.IdPrivilege > 0)
                query = query.Where(m => m.IdPrivilege == server.IdPrivilege);

            if (server.Status > 0)
                query = query.Where(m => m.Status == server.Status);

            // Ordenamos de Manera Desendente
            query = query.OrderByDescending(c => c.Id).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo Para Buscar Registros Existentes
        public static async Task<List<Server>> SearchAsync(Server server)
        {
            var servers = new List<Server>();
            using( var dbContext = new ContextBD())
            {
                var select = dbContext.Servers.AsQueryable();
                select = QuerySelect(select, server);
                servers = await select.ToListAsync();
            }
            return servers;
        }
        #endregion

        #region METODOS PARA INCLUIR LAS LLAVES FORANEAS
        // Metodo Que Incluye El Miembro Para La Busqueda
        public static async Task<List<Server>> SearchIncludeMembershipAsync(Server server)
        {
            var servers = new List<Server>();
            using(var dbContext = new ContextBD())
            {
                var select = dbContext.Servers.AsQueryable();
                select = QuerySelect(select, server).Include(m => m.Memberhsip).AsQueryable();
                servers = await select.ToListAsync();
            }
            return servers;
        }

        // Metodo Que Incluye El Privilegio Para La Busqueda
        public static async Task<List<Server>> SearchIncludePrivilegeAsync(Server server)
        {
            var servers = new List<Server>();
            using (var dbContext = new ContextBD())
            {
                var select = dbContext.Servers.AsQueryable();
                select = QuerySelect(select, server).Include(m => m.Privilege).AsQueryable();
                servers = await select.ToListAsync();
            }
            return servers;
        }
        #endregion

        #region METODO PARA VALIDAR UNICA EXISTENCIA DEL REGISTRO
        // Metodo Para Validar La Unica Existencia De Un Registro y No Haber Duplicidad
        private static async Task<bool> ExistServer(Server server, ContextBD contextBD)
        {
            bool result = false;
            var servers = await contextBD.Servers.FirstOrDefaultAsync(s => s.IdMembership == server.IdMembership && s.Id != server.Id);
            if(servers != null && servers.Id > 0 && servers.IdMembership == server.IdMembership)
                result = true;
            return result;
        }
        #endregion
    }
}
