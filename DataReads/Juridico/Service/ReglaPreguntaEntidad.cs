using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Operations.DataAccess.Contexts;
using Visionamos.Operations.DataAccess.Models;
using Visionamos.Operations.DataAccess.Models.Ecgts;
using Visionamos.Operations.DataAccess.Models.EnterpriseSecurity;
using Visionamos.Operations.DataAccess.Recursos;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity;
using Visionamos.Operations.DataReads.ECGTS;
using Visionamos.Operations.DataReads.Mappers.EnterpriseSecurity;
using Visionamos.Operations.DataReads.Utilidades;

namespace Visionamos.Operations.DataReads.EnterpriseSecurity
{
    /// <summary>
    /// Source File:   ReglaPorEntidad.cs                                             
    /// Description:   Clase contiene las consultas de ReglaPorEntidad
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/07/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class ReglaPreguntaEntidad
    {
        #region Internals
        public OperationsModels<EnterpriseSecurityContext> dbContext;
        #endregion

        #region Constructor
        public ReglaPreguntaEntidad(OperationsModels<EnterpriseSecurityContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<EnterpriseSecurityContext>();
            }
        }
        #endregion

        #region Internals
        public async Task<NotificacionRespuesta<List<ReglaPreguntaEntidadGrid_UI>>> GetAll()
        {
            NotificacionRespuesta<List<ReglaPreguntaEntidadGrid_UI>> response = new NotificacionRespuesta<List<ReglaPreguntaEntidadGrid_UI>>();

            try
            {
                var context = dbContext.obtenerContexto();
                Commerce clsCommerce = new Commerce();
                List<commerce> commerces = await clsCommerce.ObtenerListaOrdenadaAsync();
                List<TBL_TRULE_QUESTION_ENTITY> preguntaEntityList = (List<TBL_TRULE_QUESTION_ENTITY>)await dbContext.ObtenerTodosAsync<TBL_TRULE_QUESTION_ENTITY>();
                var result = preguntaEntityList.Join(commerces,
                    lr => lr.RQE_CENTITY,
                    c => c.CODE,
                    (lr, c) => new ReglaPreguntaEntidadGrid_UI
                    {
                        Guid = lr.RQE_GGID.ToString(),
                        EntityCode = lr.RQE_CENTITY,
                        EntityName = c.NAME,
                        NumberQuestion = Convert.ToString(lr.RQE_NQUESTION_NUMBER),
                        NumberAnswer = Convert.ToString(lr.RQE_NANSWER_NUMBER)
                    }).OrderBy(x => x.EntityName).ToList();

                response.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<ReglaPreguntaEntidadGrid_UI>> Create(ReglaPreguntaEntidadGrid_UI model)
        {
            NotificacionRespuesta<ReglaPreguntaEntidadGrid_UI> response = new NotificacionRespuesta<ReglaPreguntaEntidadGrid_UI>();

            try
            {
                bool exist = dbContext.ObtenerTodos<TBL_TRULE_QUESTION_ENTITY>().Any(x => x.RQE_CENTITY == model.EntityCode);

                if (!exist)
                {
                    var context = dbContext.obtenerContexto();
                    var record = context.Set<TBL_TRULE_QUESTION_ENTITY>().Add(model.Map());
                    await context.SaveChangesAsync();
                    var list = await GetAll();
                    model = list.Respuesta.FirstOrDefault(x => x.Guid == record.RQE_GGID.ToString());
                    response.AsignarRespuesta(model);
                }
                else
                {
                    throw new Exception(message: RscGlobalMessages.EntityRule);
                }
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<ReglaPreguntaEntidadGrid_UI>> Update(ReglaPreguntaEntidadGrid_UI model)
        {
            NotificacionRespuesta<ReglaPreguntaEntidadGrid_UI> response = new NotificacionRespuesta<ReglaPreguntaEntidadGrid_UI>();

            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TRULE_QUESTION_ENTITY>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<bool>> Delete(ReglaPreguntaEntidadGrid_UI model)
        {
            NotificacionRespuesta<bool> response = new NotificacionRespuesta<bool>();

            try
            {
                bool exist = dbContext.ObtenerTodos<TBL_TQUESTION_ENTITY>().Any(x => x.QEN_CENTITY == model.EntityCode);

                if (!exist)
                {
                    dbContext.Eliminar(model.Map());
                    await dbContext.GuardarCambiosAsync();
                    response.AsignarRespuesta(true);
                }
                else
                {
                    throw new Exception(message: RscGlobalMessages.DeleteRule);
                }
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
