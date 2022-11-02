using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.Operations.DataAccess.Models.EnterpriseSecurity
{
    public class TBL_TPASSWORD_RULES
    {
        [Key]
        public Guid PSS_GGID { get; set; }
        public string PSS_CENTITY { get; set; }
        public string PSS_CCODE { get; set; }
        public string PSS_CDESCRIPTION { get; set; }
        public string PSS_CVALUE { get; set; }
    }
}
