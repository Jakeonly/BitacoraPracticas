using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.Operations.DataAccess.Models.EnterpriseSecurity
{
    /// <summary>
    /// Source File:   TBL_TRULE_QUESTION_ENTITY.cs                                             
    /// Description:   Tabla de TBL_TRULE_QUESTION_ENTITY
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          08/07/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class TBL_TRULE_QUESTION_ENTITY
    {
        [Key]
        public Guid RQE_GGID { get; set; }
        public string RQE_CENTITY { get; set; }
        public int RQE_NQUESTION_NUMBER { get; set; }
        public int RQE_NANSWER_NUMBER { get; set; }
    }
}
