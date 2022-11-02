using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Operations.DataAccess.Contexts;
using Visionamos.Operations.DataAccess.Models;
using Visionamos.Operations.DataAccess.Models.EnterpriseSecurity;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity;
using Visionamos.Operations.DataReads.Mappers.EnterpriseSecurity;
using Visionamos.Operations.DataReads.Utilidades;

namespace Visionamos.Operations.DataReads.EnterpriseSecurity
{
    public class Accion
    {
        #region Internals

        public OperationsModels<EnterpriseSecurityContext> dbContext;

        #endregion

        #region Constructor
        public Accion(OperationsModels<EnterpriseSecurityContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<EnterpriseSecurityContext>();
            }
        }
        #endregion

        #region Methods

        public async Task<NotificacionRespuesta<List<AccionGrid_UI>>> GetAll()
        {
            NotificacionRespuesta<List<AccionGrid_UI>> response = new NotificacionRespuesta<List<AccionGrid_UI>>();
            try
            {
                var context = dbContext.obtenerContexto();
                List<TBL_TACTION> actions = (List<TBL_TACTION>)await dbContext.ObtenerTodosAsync<TBL_TACTION>();
                var result = actions.Select(x => x.Map()).ToList();

                response.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<AccionGrid_UI>> Update(AccionGrid_UI model)
        {
            NotificacionRespuesta<AccionGrid_UI> response = new NotificacionRespuesta<AccionGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TACTION>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        public async Task<NotificacionRespuesta<AccionGrid_UI>> Create(AccionGrid_UI model)
        {
            NotificacionRespuesta<AccionGrid_UI> response = new NotificacionRespuesta<AccionGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<TBL_TACTION>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetAll();
                model = list.Respuesta.FirstOrDefault(x => x.Guid == record.CTN_GGID.ToString());
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        public async Task<NotificacionRespuesta<bool>> Delete(AccionGrid_UI model)
        {
            NotificacionRespuesta<bool> response = new NotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<TBL_TACTION>(model.Map());
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
