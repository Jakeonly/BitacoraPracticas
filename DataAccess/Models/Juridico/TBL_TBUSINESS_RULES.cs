using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.Operations.DataAccess.Models.Products
{
    /// <summary>
    /// Source File:   TBL_TBUSINESS_RULES.cs                                             
    /// Description:   Tabla de TBL_TBUSINESS_RULES
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          24/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class TBL_TBUSINESS_RULES
    {
        [Key]
        public Guid BSR_GGUID { get; set; }
        public string BSR_CENTITY_CODE { get; set; }
        public string BSR_CPRODUCT_TYPE { get; set; }
        public string BSR_CPRODUCT_SUBTYPE { get; set; }
        public bool BSR_BALLOWS_PAYMENT { get; set; }
        public bool BSR_BALLOWS_OTHERS_VALUES { get; set; }
        public bool BSR_BALLOWS_LESS_MINIMUM { get; set; }
        public bool BSR_BALLOWS_MORE_MAXIMUM { get; set; }
        public bool BSR_BALLOWS_DEBITS { get; set; }
        public bool BSR_BALLOWS_CREDITS { get; set; }
        public int BSR_NINITIAL_VALUE { get; set; }
    }
}
