using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Coopcentral.DataAccess.Contexts;
using Visionamos.Coopcentral.DataAccess.Models;
using Visionamos.Coopcentral.DataAccess.Models.LowAmountDeposit;
using Visionamos.Coopcentral.DataAccess.ViewModels.LowAmountDeposit;
using Visionamos.Coopcentral.DataReads.Mappers;
using Visionamos.Coopcentral.DataReads.Utilidades;

namespace Visionamos.Coopcentral.DataReads.LowAmountDeposit
{
    public class ClsProvider
    {
        /// <summary>
        /// variable con representa el contexto para la base ded atos integracion
        /// </summary>
        public ClsOperationsModels<LowAmountDepositContext> dbContext;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context"></param>
        public ClsProvider(ClsOperationsModels<LowAmountDepositContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new ClsOperationsModels<LowAmountDepositContext>();
            }
        }
        public async Task<ClsNotificacionRespuesta<List<TBL_TPROVIDER_UI>>> GetAll()
        {
            ClsNotificacionRespuesta<List<TBL_TPROVIDER_UI>> respuesta = new ClsNotificacionRespuesta<List<TBL_TPROVIDER_UI>>();
            try
            {
                var context = dbContext.obtenerContexto();
                List<TBL_TPROVIDER> actions = (List<TBL_TPROVIDER>)await dbContext.ObtenerTodosAsync<TBL_TPROVIDER>();
                var result = actions.Select(x => x.Map()).ToList();

                respuesta.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        public async Task<ClsNotificacionRespuesta<TBL_TPROVIDER_UI>> Create(TBL_TPROVIDER_UI model)
        {
            ClsNotificacionRespuesta<TBL_TPROVIDER_UI> respuesta = new ClsNotificacionRespuesta<TBL_TPROVIDER_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<TBL_TPROVIDER>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetAll();
                model = list.Respuesta.FirstOrDefault(x => x.PRV_GGID == record.PRV_GGID.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<TBL_TPROVIDER_UI>> Update(TBL_TPROVIDER_UI model)
        {
            ClsNotificacionRespuesta<TBL_TPROVIDER_UI> respuesta = new ClsNotificacionRespuesta<TBL_TPROVIDER_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TPROVIDER>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<bool>> Delete(TBL_TPROVIDER_UI model)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<TBL_TPROVIDER>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<List<TBL_TPROVIDER>> ObtenerTodosAsync()
        {
            try
            {
                IEnumerable<TBL_TPROVIDER> lista = await dbContext.ObtenerTodosAsync<TBL_TPROVIDER>();
                return lista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
