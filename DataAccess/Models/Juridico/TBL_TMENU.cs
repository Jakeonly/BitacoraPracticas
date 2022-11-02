using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   TBL_TMENU.cs                                             
    /// Description:   Tabla de TBL_TMENU
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c),
    public class TBL_TMENU
    {
        [Key]
        public Guid MEN_GGID { get; set; }
        public string MEN_CNAME { get; set; }
        public string MEN_CDESCRIPTION { get; set; }
        public string MEN_CTOOLTIP { get; set; }
        public bool MEN_BSTATE { get; set; }
        public decimal MEN_ORDER { get; set; }
    }
}
