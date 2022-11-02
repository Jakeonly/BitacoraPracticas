using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   TBL_TVIEW.cs                                             
    /// Description:   Tabla de TBL_TVIEW
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c),
    public class TBL_TVIEW
    {
        [Key]
        public Guid VIW_GGID { get; set; }
        public string VIW_CNAME { get; set; }
        public bool VIW_BSTATE { get; set; }
        public int VIW_NORDER { get; set; }
        public bool VIW_BOTP { get; set; }
        public string VIW_CDESCRIPTION { get; set; }
        public string VIW_CTOOLTIP { get; set; }
        public string VIW_CACTION { get; set; }       
        public Guid SBM_GGID { get; set; }
        [ForeignKey("SBM_GGID")]
        public virtual TBL_TSUBMENU TBL_TSUBMENU { get; set; }
    }
}
