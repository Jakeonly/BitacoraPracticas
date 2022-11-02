using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visionamos.Coopcentral.DataAccess.Contexts;
using Visionamos.Coopcentral.DataAccess.Models;
using Visionamos.Coopcentral.DataAccess.Models.Ecgts;
using Visionamos.Coopcentral.DataAccess.ViewModels.Ecgts;
using Visionamos.Coopcentral.DataReads.ECGTS;
using Visionamos.Coopcentral.DataReads.Mappers;
using Visionamos.Coopcentral.DataReads.Utilidades;

namespace Visionamos.Coopcentral.DataReads.ECGTS
{
    public class ClsContactLess
    {
        #region Internals
        private readonly ClsOperationsModels<EcgtsContext> dbContext;

        public ClsContactLess(ClsOperationsModels<EcgtsContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new ClsOperationsModels<EcgtsContext>();
            }
        }
        #endregion
        #region Methods
        #region Contactless
        public async Task<ClsNotificacionRespuesta<List<clients_accounts_limit_contactless_UI>>> GetContactLess()
        {
            ClsNotificacionRespuesta<List<clients_accounts_limit_contactless_UI>> respuesta = new ClsNotificacionRespuesta<List<clients_accounts_limit_contactless_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<clients_accounts_limit_contactless>();
                ClsCommerce clsCommercio = new ClsCommerce();
                List<commerce> comercios = await clsCommercio.ObtenerTodosAsync();
                var lista = context.ToList();
                var result = lista.Join(comercios,
                    lr => lr.SRC,
                    com => com.CODE,
                   (lr, c) => new clients_accounts_limit_contactless_UI
                   {
                       SRC = lr.SRC,
                       SRC_TXT = c.NAME,
                       MAX_OPE = lr.MAX_OPE.ToString(),
                       MAX_AMO = Convert.ToInt32(lr.MAX_AMO.ToString().Remove(lr.MAX_AMO.ToString().Length-2))-1,
                       MAX_VALUE = Convert.ToInt32(lr.MAX_VALUE.ToString().Remove(lr.MAX_VALUE.ToString().Length-2))-1,
                   }).ToList();

                respuesta.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<clients_accounts_limit_contactless_UI>> CreateContactLess(clients_accounts_limit_contactless_UI model)
        {
            ClsNotificacionRespuesta<clients_accounts_limit_contactless_UI> respuesta = new ClsNotificacionRespuesta<clients_accounts_limit_contactless_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<clients_accounts_limit_contactless>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetContactLess();
                model = list.Respuesta.FirstOrDefault(x => x.SRC == record.SRC.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<clients_accounts_limit_contactless_UI>> UpdateConctactLess(clients_accounts_limit_contactless_UI model)
        {
            ClsNotificacionRespuesta<clients_accounts_limit_contactless_UI> respuesta = new ClsNotificacionRespuesta<clients_accounts_limit_contactless_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<clients_accounts_limit_contactless>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<bool>> DeleteContactLess(clients_accounts_limit_contactless_UI model)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<clients_accounts_limit_contactless>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        #endregion
        #region Debito
        public async Task<ClsNotificacionRespuesta<List<clients_accounts_limit_low_amount_UI>>> GetDebito()
        {
            ClsNotificacionRespuesta<List<clients_accounts_limit_low_amount_UI>> respuesta = new ClsNotificacionRespuesta<List<clients_accounts_limit_low_amount_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<clients_accounts_limit_low_amount>();
                ClsCommerce clsCommercio = new ClsCommerce();
                List<commerce> comercios = await clsCommercio.ObtenerTodosAsync();
                var lista = context.ToList();
                var result = lista.Join(comercios,
                    lr => lr.SRC,
                    com => com.CODE,
                   (lr, c) => new clients_accounts_limit_low_amount_UI
                   {
                       SRC = lr.SRC,
                       SRC_TXT = c.NAME,
                       MAX_OPE = lr.MAX_OPE.ToString(),
                       MAX_AMO = Convert.ToInt32(lr.MAX_AMO.ToString().Remove(lr.MAX_AMO.ToString().Length - 2)) - 1,
                       MAX_VALUE = Convert.ToInt32(lr.MAX_VALUE.ToString().Remove(lr.MAX_VALUE.ToString().Length - 2)) - 1,
                   }).ToList();

                respuesta.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<clients_accounts_limit_low_amount_UI>> CreateDebito(clients_accounts_limit_low_amount_UI model)
        {
            ClsNotificacionRespuesta<clients_accounts_limit_low_amount_UI> respuesta = new ClsNotificacionRespuesta<clients_accounts_limit_low_amount_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<clients_accounts_limit_low_amount>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetDebito();
                model = list.Respuesta.FirstOrDefault(x => x.SRC == record.SRC.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<clients_accounts_limit_low_amount_UI>> UpdateDebito(clients_accounts_limit_low_amount_UI model)
        {
            ClsNotificacionRespuesta<clients_accounts_limit_low_amount_UI> respuesta = new ClsNotificacionRespuesta<clients_accounts_limit_low_amount_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<clients_accounts_limit_low_amount>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<bool>> DeleteDebito(clients_accounts_limit_low_amount_UI model)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<clients_accounts_limit_low_amount>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        #endregion
        #region Credito
        public async Task<ClsNotificacionRespuesta<List<clients_accounts_limit_low_amount_credit_UI>>> GetCredito()
        {
            ClsNotificacionRespuesta<List<clients_accounts_limit_low_amount_credit_UI>> respuesta = new ClsNotificacionRespuesta<List<clients_accounts_limit_low_amount_credit_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<clients_accounts_limit_low_amount_credit>();
                ClsCommerce clsCommercio = new ClsCommerce();
                List<commerce> comercios = await clsCommercio.ObtenerTodosAsync();
                var lista = context.ToList();
                var result = lista.Join(comercios,
                    lr => lr.SRC,
                    com => com.CODE,
                   (lr, c) => new clients_accounts_limit_low_amount_credit_UI
                   {
                       SRC = lr.SRC,
                       SRC_TXT = c.NAME,
                       MAX_OPE = lr.MAX_OPE.ToString(),
                       MAX_AMO = Convert.ToInt32(lr.MAX_AMO.ToString().Remove(lr.MAX_AMO.ToString().Length - 2)) - 1,
                       MAX_VALUE = Convert.ToInt32(lr.MAX_VALUE.ToString().Remove(lr.MAX_VALUE.ToString().Length - 2)) - 1,
                   }).ToList();

                respuesta.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<clients_accounts_limit_low_amount_credit_UI>> CreateCredito(clients_accounts_limit_low_amount_credit_UI model)
        {
            ClsNotificacionRespuesta<clients_accounts_limit_low_amount_credit_UI> respuesta = new ClsNotificacionRespuesta<clients_accounts_limit_low_amount_credit_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<clients_accounts_limit_low_amount_credit>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetCredito();
                model = list.Respuesta.FirstOrDefault(x => x.SRC == record.SRC.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<clients_accounts_limit_low_amount_credit_UI>> UpdateCredito(clients_accounts_limit_low_amount_credit_UI model)
        {
            ClsNotificacionRespuesta<clients_accounts_limit_low_amount_credit_UI> respuesta = new ClsNotificacionRespuesta<clients_accounts_limit_low_amount_credit_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<clients_accounts_limit_low_amount_credit>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<bool>> DeleteCredito(clients_accounts_limit_low_amount_credit_UI model)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<clients_accounts_limit_low_amount_credit>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        #endregion
        #endregion
    }
}
