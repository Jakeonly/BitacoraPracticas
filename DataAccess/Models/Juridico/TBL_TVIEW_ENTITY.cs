using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   TBL_TVIEW_ENTITY.cs                                             
    /// Description:   Tabla de TBL_TVIEW_ENTITY
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          01/09/2022
    /// Version:       1
    /// Copyright(c),
    public class TBL_TVIEW_ENTITY
    {
        [Key]
        public Guid VEN_GGID { get; set; }
        public string VEN_ENTITY_CODE { get; set; }
        public bool VEN_BSTATE { get; set; }
        public Guid VIW_GGID { get; set; }
        public Guid PRF_GGID { get; set; }
        [ForeignKey("VIW_GGID")]
        public virtual TBL_TVIEW TBL_TVIEW { get; set; }
    }
}
