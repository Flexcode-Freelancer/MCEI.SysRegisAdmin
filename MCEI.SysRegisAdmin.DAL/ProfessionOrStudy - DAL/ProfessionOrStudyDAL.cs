#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Corrrecto Funcionamiento
using MCEI.SysRegisAdmin.EN.ProfessionOrStudy___EN;
using Microsoft.EntityFrameworkCore;



#endregion

namespace MCEI.SysRegisAdmin.DAL.ProfessionOrStudy___DAL
{
    public class ProfessionOrStudyDAL
    {
        #region METODO PARA CREAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(ProfessionOrStudy professionOrStudys)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                bool professionOrStudyExists = await ExistProfessionOrStudy(professionOrStudys, dbContext);
                if (professionOrStudyExists == false)
                {
                    dbContext.ProfessionOrStudys.Add(professionOrStudys);
                    result = await dbContext.SaveChangesAsync(); // Await sirve para esperar a terminar todos los procesos para devolverlos todos juntos
                }
                else
                    throw new Exception("Profesion u Oficio Ya Existente");
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Modificar Un Registro Existente En La Base De Datos
        public static async Task<int> UpdateAsync(ProfessionOrStudy professionOrStudys)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                // Obtiene el primer registro con el Id específico de ProfessionOrStudys desde la base de datos.
                var professionOrStudyDB = await dbContext.ProfessionOrStudys.FirstOrDefaultAsync(c => c.Id == professionOrStudys.Id);
                // Validamos que professionOrStudyDB sea diferente de NULL
                if (professionOrStudyDB != null)
                {
                    bool professionOrStudyExists = await ExistProfessionOrStudy(professionOrStudys, dbContext);
                    if (professionOrStudyExists == false)
                    {
                        professionOrStudyDB.Name = professionOrStudys.Name;

                        dbContext.Update(professionOrStudyDB);
                        result = await dbContext.SaveChangesAsync();
                    }
                    else
                        throw new Exception("Profesion u Oficio Ya Existente");
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public static async Task<int> DeleteAsync(ProfessionOrStudy professionOrStudys)
        {
            int result = 0;
            using (var dbContext = new ContextBD())
            {
                // Obtiene el primer registro con el Id específico de ProfessionOrStudys desde la base de datos.
                var professionOrStudyDB = await dbContext.ProfessionOrStudys.FirstOrDefaultAsync(c => c.Id == professionOrStudys.Id);
                // Validamos que professionOrStudyDB sea diferente de NULL
                if (professionOrStudyDB != null)
                {
                    dbContext.ProfessionOrStudys.Remove(professionOrStudyDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar La Lista De Registros
        public static async Task<List<ProfessionOrStudy>> GetAllAsync()
        {
            var professionOrStudies = new List<ProfessionOrStudy>();
            using (var dbContext = new ContextBD())
            {
                professionOrStudies = await dbContext.ProfessionOrStudys.ToListAsync();
            }
            return professionOrStudies;
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo Para Mostrar Un Registro En Base A Su Id
        public static async Task<ProfessionOrStudy> GetByIdAsync(ProfessionOrStudy professionOrStudys)
        {
            var professionOrStudyDB = new ProfessionOrStudy();
            using (var dbContext = new ContextBD())
            {
                professionOrStudyDB = await dbContext.ProfessionOrStudys.FirstOrDefaultAsync(c => c.Id == professionOrStudys.Id);
            }
            return professionOrStudyDB!; // Retornamos el Registro Encontrado
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS (Por Nombre)
        // Metodo Para Buscar Por Filtros
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros)
        internal static IQueryable<ProfessionOrStudy> QuerySelect(IQueryable<ProfessionOrStudy> query, ProfessionOrStudy professionOrStudys)
        {
            // Por ID
            if (professionOrStudys.Id > 0)
                query = query.Where(c => c.Id == professionOrStudys.Id);

            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(professionOrStudys.Name))
                query = query.Where(c => c.Name.Contains(professionOrStudys.Name));

            // Ordenamos de Manera Desendente
            query = query.OrderByDescending(c => c.Id).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para Buscar Registros Existentes
        public static async Task<List<ProfessionOrStudy>> SearchAsync(ProfessionOrStudy professionOrStudys)
        {
            var proffesionOrStudy = new List<ProfessionOrStudy>();
            using (var dbContext = new ContextBD())
            {
                var select = dbContext.ProfessionOrStudys.AsQueryable();
                select = QuerySelect(select, professionOrStudys);
                proffesionOrStudy = await select.ToListAsync();
            }
            return proffesionOrStudy;
        }
        #endregion

        #region METODO PARA VALIDAR UNICA EXISTENCIA DEL REGISTRO
        // Metodo Para Validar La Unica Existencia De Un Registro y No Haber Duplicidads
        private static async Task<bool> ExistProfessionOrStudy(ProfessionOrStudy professionOrStudy, ContextBD dbContext)
        {
            bool result = false;
            var professionOrStudys = await dbContext.ProfessionOrStudys.FirstOrDefaultAsync(p => p.Name == professionOrStudy.Name && p.Id != professionOrStudy.Id);
            if (professionOrStudys != null && professionOrStudys.Id > 0 && professionOrStudys.Name == professionOrStudy.Name)
                result = true;

            return result;
        }
        #endregion
    }
}
