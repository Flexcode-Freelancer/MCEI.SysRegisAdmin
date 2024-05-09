#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using MCEI.SysRegisAdmin.EN.Membership___EN;
using Microsoft.EntityFrameworkCore;


#endregion


namespace MCEI.SysRegisAdmin.DAL.Membership___DAL
{
    public class MembershipDAL
    {
        #region METODO PARA CREAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(Membership memberships)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextBD())
            {
                bool membershipExists = await ExistMembership(memberships, dbContext);
                if (membershipExists == false)
                {
                    dbContext.Memberships.Add(memberships);
                    result = await dbContext.SaveChangesAsync(); // Await sirve para esperar a terminar todos los procesos para devolverlos todos juntos
                }
                else
                    throw new Exception("Membresia Ya Existente, Vuelve a Intentarlo Nuevamente.");
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Modificar Un Registro Existente De La Base De Datos
        public static async Task<int> UpdateAsync(Membership memberships)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                var membershipDB = await dbContext.Memberships.FirstOrDefaultAsync(m => m.Id == memberships.Id);
                if (membershipDB != null)
                {
                    bool membershipExists = await ExistMembership(memberships, dbContext);
                    if (membershipExists == false)
                    {
                        membershipDB.Name = memberships.Name;
                        membershipDB.LastName = memberships.LastName;
                        membershipDB.Dui = memberships.Dui;
                        membershipDB.DateOfBirth = memberships.DateOfBirth;
                        membershipDB.Age = memberships.Age;
                        membershipDB.Gender = memberships.Gender;
                        membershipDB.CivilStatus = memberships.CivilStatus;
                        membershipDB.Phone = memberships.Phone;
                        membershipDB.Address = memberships.Address;
                        membershipDB.IdProfessionOrStudy = memberships.IdProfessionOrStudy;
                        membershipDB.PlaceOfWorkOrStudy = memberships.PlaceOfWorkOrStudy;
                        membershipDB.ConversionDate = memberships.ConversionDate;
                        membershipDB.PlaceOfConversion = memberships.PlaceOfConversion;
                        membershipDB.WaterBaptism = memberships.WaterBaptism;
                        membershipDB.BaptismOfTheHolySpirit = memberships.BaptismOfTheHolySpirit;
                        membershipDB.PastorsName = memberships.PastorsName;
                        membershipDB.SupervisorsName = memberships.SupervisorsName;
                        membershipDB.LeadersName = memberships.LeadersName;
                        membershipDB.TimeToGather = memberships.TimeToGather;
                        membershipDB.Zone = memberships.Zone;
                        membershipDB.District = memberships.District;
                        membershipDB.Sector = memberships.Sector;
                        membershipDB.Cell = memberships.Cell;
                        membershipDB.Status = memberships.Status;
                        membershipDB.CommentsOrObservations = memberships.CommentsOrObservations;
                        membershipDB.DateCreated = memberships.DateCreated;
                        membershipDB.DateModification = memberships.DateModification;
                        membershipDB.ImageData = memberships.ImageData;

                        dbContext.Update(membershipDB);
                        result = await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Membresía ya existente, vuelve a intentarlo nuevamente.");
                    }
                }
                else
                {
                    throw new Exception("Membresía no encontrada para actualizar.");
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public static async Task<int> DeleteAsync(Membership memberships)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextBD())
            {
                // Obtiene el primer registro con el Id específico de memberships desde la base de datos.
                var membershipDB = await dbContext.Memberships.FirstOrDefaultAsync(m => m.Id == memberships.Id);
                // Validamos que membershipDB sea diferente de NULL
                if (membershipDB != null)
                {
                    dbContext.Memberships.Remove(membershipDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar La Lista De Registros
        public static async Task<List<Membership>> GetAllAsync()
        {
            var memberships = new List<Membership>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextBD())
            {
                memberships = await dbContext.Memberships.ToListAsync();
            }
            return memberships;
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo Para Mostrar Un Registro En Base A Su Id
        public static async Task<Membership> GetByIdAsync(Membership memberships)
        {
            var membershipDB = new Membership();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextBD())
            {
                membershipDB = await dbContext.Memberships.FirstOrDefaultAsync(m => m.Id == memberships.Id);
            }
            return membershipDB!; // Retornamos el Registro Encontrado
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS
        // Metodo Para Buscar Por Filtros
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros)
        internal static IQueryable<Membership> QuerySelect(IQueryable<Membership> query, Membership memberships)
        {
            // Por ID
            if (memberships.Id > 0)
                query = query.Where(m => m.Id == memberships.Id);

            // Por Su Profesion u Oficio
            if (memberships.IdProfessionOrStudy > 0)
                query = query.Where(m => m.IdProfessionOrStudy == memberships.IdProfessionOrStudy);

            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(memberships.Name))
                query = query.Where(m => m.Name.Contains(memberships.Name));

            // Por Apellido, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(memberships.LastName))
                query = query.Where(m => m.LastName.Contains(memberships.LastName));

            // Por Dui, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(memberships.Dui))
                query = query.Where(m => m.Dui.Contains(memberships.Dui));

            // Ordenamos de Manera Desendente
            query = query.OrderByDescending(c => c.Id).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para Buscar Registros Existentes
        public static async Task<List<Membership>> SearchAsync(Membership membership)
        {
            var memberships = new List<Membership>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextBD())
            {
                var select = dbContext.Memberships.AsQueryable();
                select = QuerySelect(select, membership);
                memberships = await select.ToListAsync();
            }
            return memberships;
        }
        #endregion

        #region METODO PARA INCLUIR A PROFESION U OFICIO
        // Metodo Que Incluye la Profesion u Oficio Para La Busqueda
        public static async Task<List<Membership>> SearchIncludeProfessionOrStudyAsync(Membership membership)
        {
            var memberships = new List<Membership>();
            using (var dbContext = new ContextBD())
            {
                var select = dbContext.Memberships.AsQueryable();
                select = QuerySelect(select, membership).Include(m => m.ProfessionOrStudy).AsQueryable();
                memberships = await select.ToListAsync();
            }
            return memberships;
        }
        #endregion

        #region METODO PARA VALIDAR UNICA EXISTENCIA DEL REGISTRO
        // Metodo Para Validar La Unica Existencia De Un Registro y No Haber Duplicidad
        private static async Task<bool> ExistMembership(Membership membership, ContextBD contextDB)
        {
            bool result = false;
            var memberships = await contextDB.Memberships.FirstOrDefaultAsync(m => m.Dui == membership.Dui && m.Id != membership.Id);
            if (memberships != null && memberships.Id > 0 && memberships.Dui == membership.Dui)
                result = true;
            return result;
        }
        #endregion
    }
}
