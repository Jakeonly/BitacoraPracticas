using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Coopcentral.DataAccess.Contexts;
using Visionamos.Coopcentral.DataAccess.Models;
using Visionamos.Coopcentral.DataAccess.Models.Ecgts;
using Visionamos.Coopcentral.DataAccess.Models.LowAmountDeposit;
using Visionamos.Coopcentral.DataAccess.ViewModels.LowAmountDeposit;
using Visionamos.Coopcentral.DataReads.ECGTS;
using Visionamos.Coopcentral.DataReads.Mappers;
using Visionamos.Coopcentral.DataReads.Utilidades;

namespace Visionamos.Coopcentral.DataReads.LowAmountDeposit
{
    public class ClsProviderRule
    {
        /// <summary>
        /// variable con representa el contexto para la base ded atos integracion
        /// </summary>
        public ClsOperationsModels<LowAmountDepositContext> dbContext;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context"></param>
        public ClsProviderRule(ClsOperationsModels<LowAmountDepositContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new ClsOperationsModels<LowAmountDepositContext>();
            }
        }
        public async Task<ClsNotificacionRespuesta<List<TBL_TRULES_PROVIDER_UI>>> GetAll()
        {
            ClsNotificacionRespuesta<List<TBL_TRULES_PROVIDER_UI>> respuesta = new ClsNotificacionRespuesta<List<TBL_TRULES_PROVIDER_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<TBL_TRULES_PROVIDER>();
                ClsProvider clsProvider = new ClsProvider();
                ClsCommerce clsCommerce = new ClsCommerce();
                List<TBL_TPROVIDER> maestros = await clsProvider.ObtenerTodosAsync();
                List<commerce> comercios = await clsCommerce.ObtenerTodosAsync();
                var lista = context.ToList();

                var listParent = lista
                    .Join(maestros, l => l.PRV_GGID, prov => prov.PRV_GGID, (l, prov) => new { l, prov })
                    .Join(comercios, lm => lm.l.RLS_CENTITY, enti => enti.CODE, (lm, enti)
                    => new TBL_TRULES_PROVIDER_UI
                    {
                        RLS_GGID = lm.l.RLS_GGID.ToString(),
                        RLS_CENTITY = lm.l.RLS_CENTITY,
                        RLS_CENTITY_TXT = enti.NAME,
                        PRV_GGID = lm.l.PRV_GGID.ToString(),
                        PRV_GGID_TXT = lm.prov.PRV_NAME,
                        RLS_NWAIT_TIME = lm.l.RLS_NWAIT_TIME.ToString(),
                    }
                     ).ToList();

                respuesta.AsignarRespuesta(listParent);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<TBL_TRULES_PROVIDER_UI>> Create(TBL_TRULES_PROVIDER_UI model)
        {
            ClsNotificacionRespuesta<TBL_TRULES_PROVIDER_UI> respuesta = new ClsNotificacionRespuesta<TBL_TRULES_PROVIDER_UI>();
            try
            {
                if (CheckData(model.RLS_CENTITY, model.PRV_GGID))
                {
                    var context = dbContext.obtenerContexto();
                    var record = context.Set<TBL_TRULES_PROVIDER>().Add(model.Map());
                    await context.SaveChangesAsync();
                    var list = await GetAll();
                    model = list.Respuesta.FirstOrDefault(x => x.RLS_GGID == record.RLS_GGID.ToString());
                    respuesta.AsignarRespuesta(model);
                }
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<TBL_TRULES_PROVIDER_UI>> Update(TBL_TRULES_PROVIDER_UI model)
        {
            ClsNotificacionRespuesta<TBL_TRULES_PROVIDER_UI> respuesta = new ClsNotificacionRespuesta<TBL_TRULES_PROVIDER_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TRULES_PROVIDER>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<bool>> Delete(TBL_TRULES_PROVIDER_UI model)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<TBL_TRULES_PROVIDER>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        private bool CheckData(string entity, string provider)
        {
            var context = dbContext.obtenerContexto().Set<TBL_TRULES_PROVIDER>();
            if (context.Any(p => p.RLS_CENTITY.ToString() == entity && p.PRV_GGID.ToString() == provider))
            {
                throw new Exception(message: "Ya se encuentra registrada esta regla.");
            }
            return true;
        }
    }

}
