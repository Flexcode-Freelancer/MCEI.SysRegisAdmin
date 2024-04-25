#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using MCEI.SysRegisAdmin.DAL.ProfessionOrStudy___DAL;
using MCEI.SysRegisAdmin.EN.ProfessionOrStudy___EN;


#endregion

namespace MCEI.SysRegisAdmin.BL.ProfessionOrStudy___BL
{
    public class ProfessionOrStudyBL
    {
        #region METODO PARA CREAR
        // Metodo para Guardar Un Nuevo Registro
        public async Task<int> CreateAsync(ProfessionOrStudy professionOrStudy)
        {
            return await ProfessionOrStudyDAL.CreateAsync(professionOrStudy);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para Modificar Un Registro Existente
        public async Task<int> UpdateAsync(ProfessionOrStudy professionOrStudy)
        {
            return await ProfessionOrStudyDAL.UpdateAsync(professionOrStudy);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente
        public async Task<int> DeleteAsync(ProfessionOrStudy professionOrStudy)
        {
            return await ProfessionOrStudyDAL.DeleteAsync(professionOrStudy);
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar Una Lista De Registros
        public async Task<List<ProfessionOrStudy>> GetAllAsync()
        {
            return await ProfessionOrStudyDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo Para Mostrar Un Registro Especifico Bajo Un Id
        public async Task<ProfessionOrStudy> GetByIdAsync(ProfessionOrStudy professionOrStudy)
        {
            return await ProfessionOrStudyDAL.GetByIdAsync(professionOrStudy);
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo Para Buscar Registros Existentes
        public async Task<List<ProfessionOrStudy>> SearchAsync(ProfessionOrStudy professionOrStudy)
        {
            return await ProfessionOrStudyDAL.SearchAsync(professionOrStudy);
        }
        #endregion
    }
}
