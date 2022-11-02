using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   TBL_TSUBMENU.cs                                             
    /// Description:   Tabla de TBL_TSUBMENU
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c),
    public class TBL_TSUBMENU
    {
        [Key]
        public Guid SBM_GGID { get; set; }
        public string SBM_CNAME { get; set; }
        public decimal SBM_NORDER { get; set; }
        public bool SBM_BSTATE { get; set; }
        public string SBM_CDESCRIPTION { get; set; }
        public string SBM_CTOOLTIP { get; set; }        
        public Guid MEN_GGID { get; set; }
        [ForeignKey("MEN_GGID")]
        public virtual TBL_TMENU TBL_TMENU { get; set; }
    }
}
