using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.Operations.DataAccess.Models.Products
{
    public class TBL_TFEATURES_RULES
    {
        [Key]
        public Guid FTR_GGUID { get; set; }
        public string FTR_CENTITY_CODE { get; set; }
        public string FTR_CPRODUCT_TYPE { get; set; }
        public string FTR_CPRODUCT_SUBTYPE { get; set; }
        public bool FTR_BALLOWS_QR { get; set; }
        public bool FTR_BALLOWS_CP { get; set; }
        public bool FTR_BALLOWS_MOVEMENTS_QUERY { get; set; }
        public bool FTR_BALLOWS_OBLIGATION_DETAILS { get; set; }
        public bool? FTR_BALLOWS_VIEW_AVAILABLE_BALANCE { get; set; }
        public bool? FTR_BALLOWS_VIEW_DUE_DATE { get; set; }
        public bool? FTR_BALLOWS_VIEW_LED_BALANCE { get; set; }
        public bool? FTR_BALLOWS_VIEW_MINIMUM_PAYMENT { get; set; }
        public bool? FTR_BALLOWS_VIEW_TOTAL_PAYMENT { get; set; }
    }
}
