#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funiconamiento
using MCEI.SysRegisAdmin.DAL.Membership___DAL;
using MCEI.SysRegisAdmin.EN.Membership___EN;


#endregion

namespace MCEI.SysRegisAdmin.BL.Membership___BL
{
    public class MembershipBL
    {
        #region METODO PARA CREAR
        // Metodo Para Guardar Un Nuevo Registro
        public async Task<int> CreateAsync(Membership membership)
        {
            return await MembershipDAL.CreateAsync(membership);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Guardar Un Nuevo Registro
        public async Task<int> UpdateAsync(Membership membership)
        {
            return await MembershipDAL.UpdateAsync(membership);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public async Task<int> DeleteAsync(Membership membership)
        {
            return await MembershipDAL.DeleteAsync(membership);
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar Una Lista De Registros
        public async Task<List<Membership>> GetAllAsync()
        {
            return await MembershipDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo Para Mostrar Un Registro Especifico Bajo Un Id
        public async Task<Membership> GetByIdAsync(Membership membership)
        {
            return await MembershipDAL.GetByIdAsync(membership);
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo Para Buscar Registros Existentes
        public async Task<List<Membership>> SearchAsync(Membership membership)
        {
            return await MembershipDAL.SearchAsync(membership);
        }
        #endregion

        #region METODO PARA INCLUIR A PROFESION U OFICIO
        public async Task<List<Membership>> SearchIncludeProfessionOrStudyAsync(Membership membership)
        {
            return await MembershipDAL.SearchIncludeProfessionOrStudyAsync(membership);
        }
        #endregion
    }
}
