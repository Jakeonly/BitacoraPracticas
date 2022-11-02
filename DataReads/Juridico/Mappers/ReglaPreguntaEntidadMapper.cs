using System;
using Visionamos.Operations.DataAccess.Models.EnterpriseSecurity;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity;

namespace Visionamos.Operations.DataReads.Mappers.EnterpriseSecurity
{
    /// <summary>
    /// Source File:   ReglaPorEntidad.cs                                             
    /// Description:   Mapper de ReglaPorEntidad
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/07/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public static class ReglaPreguntaEntidadMapper
    {
        /// <summary>
        /// Mapper de TBL_TRULE_QUESTION_ENTITY a ReglaPorEntidadGrid_UI.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TBL_TRULE_QUESTION_ENTITY Map(this ReglaPreguntaEntidadGrid_UI model) => new TBL_TRULE_QUESTION_ENTITY
        {
            RQE_GGID = string.IsNullOrEmpty(model.Guid) ? Guid.NewGuid() : Guid.Parse(model.Guid),
            RQE_CENTITY = model.EntityCode,
            RQE_NQUESTION_NUMBER = Convert.ToInt32(model.NumberQuestion),
            RQE_NANSWER_NUMBER = Convert.ToInt32(model.NumberAnswer)
        };

        /// <summary>
        /// Mapper de ReglaPorEntidadGrid_UI a TBL_TRULE_QUESTION_ENTITY.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ReglaPreguntaEntidadGrid_UI Map(this TBL_TRULE_QUESTION_ENTITY entity) => new ReglaPreguntaEntidadGrid_UI
        {
            Guid = entity.RQE_GGID.ToString(),
            EntityCode = entity.RQE_CENTITY,
            EntityName = string.Empty,
            NumberQuestion = Convert.ToString(entity.RQE_NQUESTION_NUMBER),
            NumberAnswer = Convert.ToString(entity.RQE_NANSWER_NUMBER)
        };
    }
}
