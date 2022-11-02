using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
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
    public class FeaturesRules
    {
        #region Internals
        public OperationsModels<ProductContext> dbContext;
        #endregion

        #region Constructor
        public FeaturesRules(OperationsModels<ProductContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<ProductContext>();
            }
        }
        #endregion

        #region Methods
        public async Task<NotificacionRespuesta<List<FeaturesRulesGrid_UI>>> GetAll()
        {
            NotificacionRespuesta<List<FeaturesRulesGrid_UI>> response = new NotificacionRespuesta<List<FeaturesRulesGrid_UI>>();

            try
            {
                var context = dbContext.obtenerContexto().Set<TBL_TFEATURES_RULES>();
                List<TBL_TFEATURES_RULES> listFeature = (List<TBL_TFEATURES_RULES>)await dbContext.ObtenerTodosAsync<TBL_TFEATURES_RULES>();
                
                Commerce clsCommerce = new Commerce();
                AccountType clsAccount = new AccountType();
                AccountSubtype clsSubAccount = new AccountSubtype();

                List<commerce> commerces = await clsCommerce.ObtenerListaOrdenadaAsync();
                List<TBL_TACCOUNT_TYPE> accounts = await clsAccount.GetAllAsync();
                List<TBL_TACCOUNT_SUBTYPE> subtype = await clsSubAccount.GetAllAsync();

                var result = listFeature.Join(commerces,
                    l => l.FTR_CENTITY_CODE,
                    com => com.CODE, (l, c) => new {l, c}).Join(accounts,
                        lf => lf.l.FTR_CPRODUCT_TYPE,
                        a => a.ACT_CSWITCH_TYPE,
                        (lf, a) => new {lf, a}).Join(subtype,
                            lfe => lfe.lf.l.FTR_CPRODUCT_SUBTYPE,
                            s => s.AST_CSWITCH_TYPE,
                            (lfe, s) => new FeaturesRulesGrid_UI
                            {
                                Guid = lfe.lf.l.FTR_GGUID.ToString(),
                                EntityCode = lfe.lf.l.FTR_CENTITY_CODE,
                                EntityName = lfe.lf.c.NAME,
                                ProductType = lfe.lf.l.FTR_CPRODUCT_TYPE,
                                ProductSubType = lfe.lf.l.FTR_CPRODUCT_SUBTYPE,
                                ProductTypeTxt = lfe.a.ACT_CDESCRIPTION,
                                ProductSubTypeTxt = s.AST_CDESCRIPTION,
                                AllowsQr = lfe.lf.l.FTR_BALLOWS_QR,
                                AllowsCp = lfe.lf.l.FTR_BALLOWS_CP,
                                AllowsMovements = lfe.lf.l.FTR_BALLOWS_MOVEMENTS_QUERY,
                                AllowsDetails = lfe.lf.l.FTR_BALLOWS_OBLIGATION_DETAILS,
                                AllowViewBalance = lfe.lf.l.FTR_BALLOWS_VIEW_AVAILABLE_BALANCE,
                                AllowViewDueDate = lfe.lf.l.FTR_BALLOWS_VIEW_DUE_DATE,
                                AllowViewLedBalance = lfe.lf.l.FTR_BALLOWS_VIEW_LED_BALANCE,
                                AllowViewMinimumPay = lfe.lf.l.FTR_BALLOWS_VIEW_MINIMUM_PAYMENT,
                                AllowViewTotalPayment = lfe.lf.l.FTR_BALLOWS_VIEW_TOTAL_PAYMENT
                            }).ToList();                        
                response.AsignarRespuesta(result);

            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<FeaturesRulesGrid_UI>> Update(FeaturesRulesGrid_UI model)
        {
            NotificacionRespuesta<FeaturesRulesGrid_UI> response = new NotificacionRespuesta<FeaturesRulesGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TFEATURES_RULES>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        public async Task<NotificacionRespuesta<FeaturesRulesGrid_UI>> Create(FeaturesRulesGrid_UI model)
        {
            NotificacionRespuesta<FeaturesRulesGrid_UI> response = new NotificacionRespuesta<FeaturesRulesGrid_UI>();
            try
            {
                if (ValidateCreate(model.ProductType, model.ProductSubType, model.EntityCode))
                {
                    var context = dbContext.obtenerContexto();
                    var record = context.Set<TBL_TFEATURES_RULES>().Add(model.Map());
                    await context.SaveChangesAsync();
                    var list = await GetAll();
                    model = list.Respuesta.FirstOrDefault(x => x.Guid == record.FTR_GGUID.ToString());
                    response.AsignarRespuesta(model);
                }
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        public async Task<NotificacionRespuesta<bool>> Delete(FeaturesRulesGrid_UI model)
        {
            NotificacionRespuesta<bool> response = new NotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<TBL_TFEATURES_RULES>(model.Map());
                await dbContext.GuardarCambiosAsync();
                response.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        private bool ValidateCreate(string product, string subproduct, string entity)
        {
            var context = dbContext.obtenerContexto().Set<TBL_TFEATURES_RULES>();

            if (context.Any(p => p.FTR_CPRODUCT_TYPE.Equals(product) && p.FTR_CPRODUCT_SUBTYPE.Equals(subproduct) && p.FTR_CENTITY_CODE.Equals(entity)))
            {
                throw new Exception(RscGlobalMessages.BusinessRulesCreate);
            }
            return true;
        }
        #endregion
    }
}
