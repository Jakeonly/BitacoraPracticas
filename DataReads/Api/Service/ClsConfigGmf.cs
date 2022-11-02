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

namespace Visionamos.Coopcentral.DataReads.Integracion
{
    public class ClsConfigGmf
    {
        #region Internals
        private readonly ClsOperationsModels<EcgtsContext> dbContext;

        public ClsConfigGmf(ClsOperationsModels<EcgtsContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new ClsOperationsModels<EcgtsContext>();
            }
        }
        #endregion
        #region Methods
        #region Category
        public async Task<ClsNotificacionRespuesta<gmf_category_UI>> CreateCategory(gmf_category_UI model)
        {
            ClsNotificacionRespuesta<gmf_category_UI> respuesta = new ClsNotificacionRespuesta<gmf_category_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<gmf_category>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetCategory();
                model = list.Respuesta.FirstOrDefault(x => x.CODE == record.CODE.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<List<gmf_category_UI>>> GetCategory()
        {
            ClsNotificacionRespuesta<List<gmf_category_UI>> respuesta = new ClsNotificacionRespuesta<List<gmf_category_UI>>();
            try
            {
                var context = dbContext.obtenerContexto();
                List<gmf_category> categories = (List<gmf_category>)await dbContext.ObtenerTodosAsync<gmf_category>();
                var result = categories.Select(x => x.Map()).ToList();
               
                respuesta.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<gmf_category_UI>> UpdateCategory(gmf_category_UI model)
        {
            ClsNotificacionRespuesta<gmf_category_UI> respuesta = new ClsNotificacionRespuesta<gmf_category_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<gmf_category>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<bool>> DeleteCategory(gmf_category_UI model)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<gmf_category>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<List<gmf_category>> ObtenerCategory()
        {
            try
            {
                IEnumerable<gmf_category> lista = await dbContext.ObtenerTodosAsync<gmf_category>();
                return lista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region Commerce
        public async Task<ClsNotificacionRespuesta<gmf_commerce_UI>> CreateCommerce(gmf_commerce_UI model)
        {
            ClsNotificacionRespuesta<gmf_commerce_UI> respuesta = new ClsNotificacionRespuesta<gmf_commerce_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<gmf_commerce>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetCommerce();
                model = list.Respuesta.FirstOrDefault(x => x.SRC == record.SRC.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<List<gmf_commerce_UI>>> GetCommerce()
        {
            ClsNotificacionRespuesta<List<gmf_commerce_UI>> respuesta = new ClsNotificacionRespuesta<List<gmf_commerce_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<gmf_commerce>();
                ClsCommerce clsCommercio = new ClsCommerce();
                ClsConfigGmf clsConfigGmf = new ClsConfigGmf();
                List<commerce> comercios = await clsCommercio.ObtenerTodosAsync();
                List<gmf_category> categorias = await clsConfigGmf.ObtenerCategory();
                List<gmf_action> acciones = await clsConfigGmf.GetAction();
                var lista = context.ToList();
                var result = lista
                     .Join(comercios, l => l.SRC, com => com.CODE, (l, com) => new { l, com })
                     .Join(categorias, lc => lc.l.CAT, cat => cat.CODE, (lc, cat) => new { lc, cat })
                     .Join(acciones, la => la.lc.l.ACT, act => act.CODE, (la, act)
                     => new gmf_commerce_UI
                     {
                         SRC = la.lc.l.SRC,
                         SRC_TXT = la.lc.com.NAME,
                         CAT = la.lc.l.CAT,
                         CAT_TXT = la.cat.NAME,
                         ACT = la.lc.l.ACT.ToString(),
                         ACT_TXT = act.NAME,
                     }).ToList();

                respuesta.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<gmf_commerce_UI>> UpdateCommerce(gmf_commerce_UI model)
        {
            ClsNotificacionRespuesta<gmf_commerce_UI> respuesta = new ClsNotificacionRespuesta<gmf_commerce_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<gmf_commerce>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<bool>> DeleteCommerce(gmf_commerce_UI model)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<gmf_commerce>(model.Map());
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
        #region Action
        public async Task<List<gmf_action>> GetAction()
        {
            try
            {
                IEnumerable<gmf_action> lista = await dbContext.ObtenerTodosAsync<gmf_action>();
                return lista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #endregion
    }
}
