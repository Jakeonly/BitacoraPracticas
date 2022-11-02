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
    /// Source File:   SubtipoCuenta.cs                                             
    /// Description:   Clase contiene las consultas de SubtipoCuenta
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class AccountSubtype
    {
        #region Internals
        public OperationsModels<HomologationContext> dbContext;
        #endregion

        #region Constructor
        public AccountSubtype(OperationsModels<HomologationContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<HomologationContext>();
            }
        }
        #endregion

        #region Methods
        public async Task<NotificacionRespuesta<List<AccountSubtypeGrid_UI>>> GetAll(string typeBusiness)
        {
            NotificacionRespuesta<List<AccountSubtypeGrid_UI>> response = new NotificacionRespuesta<List<AccountSubtypeGrid_UI>>();

            try
            {
                var context = dbContext.obtenerContexto();
                List<TBL_TACCOUNT_SUBTYPE> list = (List<TBL_TACCOUNT_SUBTYPE>)await dbContext.ObtenerTodosAsync<TBL_TACCOUNT_SUBTYPE>();
                AccountType accountType = new AccountType();
                List<TBL_TACCOUNT_TYPE> listAccountType = await accountType.GetAllAsync();
                var type = listAccountType.Select(x => x.Map()).Where(x => x.ACT_CSWITCH_TYPE == typeBusiness).ToList();
                var resultType = type.Select(x => x.ACT_COPEN_BANKING_TYPE);
                var result = list.Select(x => x.Map()).Where(x => x.AST_COPEN_BANKING_TYPEPARENT == resultType.First()).ToList();
                response.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<List<AccountSubtypeGrid_UI>>> GetAllSub()
        {
            NotificacionRespuesta<List<AccountSubtypeGrid_UI>> response = new NotificacionRespuesta<List<AccountSubtypeGrid_UI>>();

            try
            {
                var context = dbContext.obtenerContexto();
                List<TBL_TACCOUNT_SUBTYPE> listSubtype = (List<TBL_TACCOUNT_SUBTYPE>)await dbContext.ObtenerTodosAsync<TBL_TACCOUNT_SUBTYPE>();
                AccountType accountType = new AccountType();
                List<TBL_TACCOUNT_TYPE> listAccountType = await accountType.GetAllAsync();
                var result = listSubtype.Join(listAccountType, 
                    ls => ls.AST_COPEN_BANKING_TYPEPARENT, 
                    la => la.ACT_COPEN_BANKING_TYPE,
                    (ls, la) => new AccountSubtypeGrid_UI 
                    {
                        AST_GID = ls.AST_GID.ToString(),
                        AST_CDESCRIPTION = ls.AST_CDESCRIPTION,
                        AST_BACTIVE = ls.AST_BACTIVE,
                        AST_COPEN_BANKING_TYPE = ls.AST_COPEN_BANKING_TYPE,
                        AST_COPEN_BANKING_TYPEPARENT = ls.AST_COPEN_BANKING_TYPEPARENT,
                        AST_CPORTAL_TYPE = ls.AST_CPORTAL_TYPE,
                        AST_CSWITCH_TYPE = ls.AST_CSWITCH_TYPE,
                        AST_COPEN_BANKING_NAME = la.ACT_CSWITCH_TYPE
                    }).ToList();
                response.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<List<TBL_TACCOUNT_SUBTYPE>> GetAllAsync()
        {
            try
            {
                IEnumerable<TBL_TACCOUNT_SUBTYPE> list = await dbContext.ObtenerTodosAsync<TBL_TACCOUNT_SUBTYPE>();
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
