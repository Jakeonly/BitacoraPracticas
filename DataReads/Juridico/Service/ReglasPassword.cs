using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Operations.DataAccess.Contexts;
using Visionamos.Operations.DataAccess.Models;
using Visionamos.Operations.DataAccess.Models.Ecgts;
using Visionamos.Operations.DataAccess.Models.EnterpriseSecurity;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity;
using Visionamos.Operations.DataReads.ECGTS;
using Visionamos.Operations.DataReads.Mappers.EnterpriseSecurity;
using Visionamos.Operations.DataReads.Utilidades;

namespace Visionamos.Operations.DataReads.EnterpriseSecurity
{
    public class ReglasPassword
    {
        #region Internals
        public OperationsModels<EnterpriseSecurityContext> dbContext;
        #endregion

        #region Constructor
        public ReglasPassword(OperationsModels<EnterpriseSecurityContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<EnterpriseSecurityContext>();
            }
        }
        #endregion

        #region Methods
        public async Task<NotificacionRespuesta<List<ReglasPasswordGrid_UI>>> GetAll(string entity)
        {
            NotificacionRespuesta<List<ReglasPasswordGrid_UI>> response = new NotificacionRespuesta<List<ReglasPasswordGrid_UI>>();

            try
            {
                var context = dbContext.obtenerContexto();
                List<TBL_TPASSWORD_RULES> passwordList = (List<TBL_TPASSWORD_RULES>)await dbContext.ObtenerTodosAsync<TBL_TPASSWORD_RULES>();
                Commerce commerce = new Commerce();
                List<commerce> CommerceList = await commerce.ObtenerListaOrdenadaAsync();
                var result = passwordList.Join(CommerceList,
                    lr => lr.PSS_CENTITY,
                    com => com.CODE,
                   (lr, com) => new ReglasPasswordGrid_UI
                   {
                       Guid = lr.PSS_GGID.ToString(),
                       EntityCode = lr.PSS_CENTITY,
                       EntityName = com.NAME,
                       Code = lr.PSS_CCODE,
                       Description = lr.PSS_CDESCRIPTION,
                       Value = lr.PSS_CVALUE,
                   }).OrderBy(x => x.EntityName).Where(x => x.EntityCode == entity).ToList();

                response.AsignarRespuesta(result);

            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }


        public async Task<NotificacionRespuesta<ReglasPasswordGrid_UI>> Update(ReglasPasswordGrid_UI model)
        {
            NotificacionRespuesta<ReglasPasswordGrid_UI> response = new NotificacionRespuesta<ReglasPasswordGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TPASSWORD_RULES>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        public async Task<NotificacionRespuesta<ReglasPasswordGrid_UI>> Create(ReglasPasswordGrid_UI model, string entity)
        {
            NotificacionRespuesta<ReglasPasswordGrid_UI> response = new NotificacionRespuesta<ReglasPasswordGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<TBL_TPASSWORD_RULES>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetAll(entity);
                model = list.Respuesta.FirstOrDefault(x => x.Guid == record.PSS_GGID.ToString());
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        public async Task<NotificacionRespuesta<bool>> Delete(ReglasPasswordGrid_UI model)
        {
            NotificacionRespuesta<bool> response = new NotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<TBL_TPASSWORD_RULES>(model.Map());
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
