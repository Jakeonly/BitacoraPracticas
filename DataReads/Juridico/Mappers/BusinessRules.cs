using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Operations.Common.Logger;
using Visionamos.Operations.DataAccess.Contexts;
using Visionamos.Operations.DataAccess.Models;
using Visionamos.Operations.DataAccess.Models.Ecgts;
using Visionamos.Operations.DataAccess.Models.Homologation;
using Visionamos.Operations.DataAccess.Models.Products;
using Visionamos.Operations.DataAccess.Recursos;
using Visionamos.Operations.DataAccess.ViewModels.Products;
using Visionamos.Operations.DataReads.ECGTS;
using Visionamos.Operations.DataReads.Homologation;
using Visionamos.Operations.DataReads.Mappers.Products;
using Visionamos.Operations.DataReads.Utilidades;

namespace Visionamos.Operations.DataReads.Products
{
    /// <summary>
    /// Source File:   BusinessRules.cs                                             
    /// Description:   Clase contiene las consultas de BusinessRules
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class BusinessRules
    {
        #region Internals
        public OperationsModels<ProductContext> dbContext;
        private static readonly ILogger _log = new Logger<BusinessRules>();
        #endregion

        #region Contructor
        public BusinessRules(OperationsModels<ProductContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<ProductContext>();
            }
        }

        public static ILogger Log
        {
            [DebuggerStepThrough]
            get { return _log; }
        }
        #endregion

        #region Methods
        public async Task<NotificacionRespuesta<List<BusinessRulesGrid_UI>>> GetAll(string entity)
        {
            NotificacionRespuesta<List<BusinessRulesGrid_UI>> response = new NotificacionRespuesta<List<BusinessRulesGrid_UI>>();
            
            try
            {
                var context = dbContext.obtenerContexto();
                List<TBL_TBUSINESS_RULES> listBusiness = (List<TBL_TBUSINESS_RULES>)await dbContext.ObtenerTodosAsync<TBL_TBUSINESS_RULES>();
                
                AccountType accountType = new AccountType();
                AccountSubtype accountSubtype = new AccountSubtype();
                Commerce commerce = new Commerce();
               
                List<TBL_TACCOUNT_TYPE> listAccountType = await accountType.GetAllAsync();
                List<TBL_TACCOUNT_SUBTYPE> listAccountSubtype = await accountSubtype.GetAllAsync();
                List<commerce> listCommerce = await commerce.ObtenerListaOrdenadaAsync();
                
                var result = listBusiness.Join(listAccountType,
                    l => l.BSR_CPRODUCT_TYPE,
                    la => la.ACT_CSWITCH_TYPE,
                    (l, la) => new { l, la }).Join(listAccountSubtype,
                        lb => lb.l.BSR_CPRODUCT_SUBTYPE,
                        las => las.AST_CSWITCH_TYPE,
                        (lb, las) => new { lb, las }).Join(listCommerce,
                            lbs => lbs.lb.l.BSR_CENTITY_CODE,
                            lc => lc.CODE,
                            (lbs, lc) => new BusinessRulesGrid_UI
                            {
                                GuidBusinessRules = lbs.lb.l.BSR_GGUID.ToString(),
                                CodeEntity = lbs.lb.l.BSR_CENTITY_CODE,
                                NameEntity = lc.NAME,
                                CodeTypeBusiness = lbs.lb.l.BSR_CPRODUCT_TYPE,
                                NameTypeBusiness = lbs.lb.la.ACT_CDESCRIPTION,
                                CodeSubtypeBusiness = lbs.lb.l.BSR_CPRODUCT_SUBTYPE,
                                NameSubtypeBusiness = lbs.las.AST_CDESCRIPTION,
                                BallowsPayment = lbs.lb.l.BSR_BALLOWS_PAYMENT,
                                BallowsOthersValues = lbs.lb.l.BSR_BALLOWS_OTHERS_VALUES,
                                BallowsLessMinimum = lbs.lb.l.BSR_BALLOWS_LESS_MINIMUM,
                                BallowsMoreMaximum = lbs.lb.l.BSR_BALLOWS_MORE_MAXIMUM,
                                BallowsDebits = lbs.lb.l.BSR_BALLOWS_DEBITS,
                                BallowsCredits = lbs.lb.l.BSR_BALLOWS_CREDITS,
                                InitialValue = lbs.lb.l.BSR_NINITIAL_VALUE.ToString()
                            }).Where(x => x.CodeEntity == entity).ToList();
                response.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<BusinessRulesGrid_UI>> Create(BusinessRulesGrid_UI model, string entity)
        {
            NotificacionRespuesta<BusinessRulesGrid_UI> response = new NotificacionRespuesta<BusinessRulesGrid_UI>();
           
            try
            {
                bool countProduct = dbContext.ObtenerTodos<TBL_TBUSINESS_RULES>().Any(x => x.BSR_CPRODUCT_TYPE == model.CodeTypeBusiness && x.BSR_CPRODUCT_SUBTYPE == model.CodeSubtypeBusiness && x.BSR_CENTITY_CODE == entity);
                
                if (!countProduct)
                {
                    var context = dbContext.obtenerContexto();
                    var record = context.Set<TBL_TBUSINESS_RULES>().Add(model.Map()); 
                    await context.SaveChangesAsync();
                    var list = await GetAll(entity); 
                    model = list.Respuesta.FirstOrDefault(x => x.GuidBusinessRules == record.BSR_GGUID.ToString());
                    response.AsignarRespuesta(model);
                }
                else
                {
                    throw new Exception(message: RscGlobalMessages.BusinessRulesCreate);
                }
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<BusinessRulesGrid_UI>> Update(BusinessRulesGrid_UI model)
        {
            NotificacionRespuesta<BusinessRulesGrid_UI> response = new NotificacionRespuesta<BusinessRulesGrid_UI>();

            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TBUSINESS_RULES>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<bool>> Eliminar(BusinessRulesGrid_UI model)
        {
            NotificacionRespuesta<bool> response = new NotificacionRespuesta<bool>();

            try
            {
                dbContext.Eliminar<TBL_TBUSINESS_RULES>(model.Map());
                await dbContext.GuardarCambiosAsync();
                response.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }
        #endregion
    }
}
