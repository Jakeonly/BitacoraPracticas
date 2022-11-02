using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Operations.DataAccess.Contexts;
using Visionamos.Operations.DataAccess.Models;
using Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop;
using Visionamos.Operations.DataReads.Mappers.EnterpriseBackdrop;
using Visionamos.Operations.DataReads.Utilidades;

namespace Visionamos.Operations.DataReads.EnterpriseBackdrop
{
    public class VistaEntidad
    {
        #region Internals

        public OperationsModels<EnterpriseBackdropContext> dbContext;

        #endregion

        #region Constructor
        public VistaEntidad(OperationsModels<EnterpriseBackdropContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<EnterpriseBackdropContext>();
            }
        }
        #endregion

        #region Methods

        public async Task<NotificacionRespuesta<List<VistaEntidadGrid_UI>>> ObtenerTodas()
        {
            NotificacionRespuesta<List<VistaEntidadGrid_UI>> respuesta = new NotificacionRespuesta<List<VistaEntidadGrid_UI>>();
            try
            {
                var context = dbContext.obtenerContexto();
                List<TBL_TVIEW_ENTITY> acciones = (List<TBL_TVIEW_ENTITY>)await dbContext.ObtenerTodosAsync<TBL_TVIEW_ENTITY>();
                var result = acciones.Select(x => x.Map()).ToList();

                respuesta.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        public async Task<NotificacionRespuesta<VistaEntidadGrid_UI>> Actualizar(VistaEntidadGrid_UI model)
        {
            NotificacionRespuesta<VistaEntidadGrid_UI> respuesta = new NotificacionRespuesta<VistaEntidadGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TVIEW_ENTITY>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }

        public async Task<NotificacionRespuesta<VistaEntidadGrid_UI>> Crear(VistaEntidadGrid_UI model)
        {
            NotificacionRespuesta<VistaEntidadGrid_UI> respuesta = new NotificacionRespuesta<VistaEntidadGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<TBL_TVIEW_ENTITY>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await ObtenerTodas();
                model = list.Respuesta.FirstOrDefault(x => x.VEN_GGID == record.VEN_GGID.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }

        public async Task<NotificacionRespuesta<bool>> Eliminar(VistaEntidadGrid_UI model)
        {
            NotificacionRespuesta<bool> respuesta = new NotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<TBL_TVIEW_ENTITY>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }

        public async Task<List<TBL_TVIEW_ENTITY>> ObtenerTodasAsync()
        {
            try
            {
                IEnumerable<TBL_TVIEW_ENTITY> lista = await dbContext.ObtenerTodosAsync<TBL_TVIEW_ENTITY>();

                return lista.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
