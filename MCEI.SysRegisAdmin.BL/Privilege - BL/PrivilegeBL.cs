#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using MCEI.SysRegisAdmin.EN.Privilege___EN;
using MCEI.SysRegisAdmin.DAL.Privilege___EN;

#endregion

namespace MCEI.SysRegisAdmin.BL.Privilege___BL
{
    public class PrivilegeBL
    {
        #region METODO PARA GUARDAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public async Task<int> CreateAsync(Privilege privilege)
        {
            return await PrivilegeDAL.CreateAsync(privilege);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Modificar Un Registro Existente En La Base De Datos
        public async Task<int> UpdateAsync(Privilege privilege)
        {
            return await PrivilegeDAL.UpdateAsync(privilege);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public async Task<int> DeleteAsync(Privilege privilege)
        {
            return await PrivilegeDAL.DeleteAsync(privilege);
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar Una Lista De Registro
        public async Task<List<Privilege>> GetAllAsync()
        {
            return await PrivilegeDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo Para Mostrar Un Registro Especifico Bajo Un Id
        public async Task<Privilege> GetByIdAsync(Privilege privilege)
        {
            return await PrivilegeDAL.GetByIdAsync(privilege);
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo Para Buscar Registros Existentes
        public async Task<List<Privilege>> SearchAsync(Privilege privilege)
        {
            return await PrivilegeDAL.SearchAsync(privilege);
        }
        #endregion
    }
}
