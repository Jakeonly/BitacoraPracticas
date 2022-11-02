using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Operations.DataAccess.Contexts;
using Visionamos.Operations.DataAccess.Models;
using Visionamos.Operations.DataAccess.Models.Homologation;
using Visionamos.Operations.DataAccess.ViewModels.Homologation;
using Visionamos.Operations.DataReads.Mappers.Homologation;
using Visionamos.Operations.DataReads.Utilidades;

namespace Visionamos.Operations.DataReads.Homologation
{
    /// <summary>
    /// Source File:   TipoCuenta.cs                                             
    /// Description:   Clase contiene las consultas de TipoCuenta
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class AccountType
    {
        #region Internals
        public OperationsModels<HomologationContext> dbContext;
        #endregion

        #region Constructor
        public AccountType(OperationsModels<HomologationContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<HomologationContext>();
            }
        }
        #endregion

        #region Methods
        public async Task<NotificacionRespuesta<List<AccountTypeGrid_UI>>> GetAll()
        {
            NotificacionRespuesta<List<AccountTypeGrid_UI>> response = new NotificacionRespuesta<List<AccountTypeGrid_UI>>();

            try
            {
                var context = dbContext.obtenerContexto();
                List<TBL_TACCOUNT_TYPE> list = (List<TBL_TACCOUNT_TYPE>)await dbContext.ObtenerTodosAsync<TBL_TACCOUNT_TYPE>();
                var result = list.Select(x => x.Map()).ToList();
                response.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<List<TBL_TACCOUNT_TYPE>> GetAllAsync()
        {
            try
            {
                IEnumerable<TBL_TACCOUNT_TYPE> list = await dbContext.ObtenerTodosAsync<TBL_TACCOUNT_TYPE>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
