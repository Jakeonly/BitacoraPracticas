using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.Operations.DataAccess.Models.EnterpriseSecurity
{
    public class TBL_TACTION
    {
        [Key]
        public Guid CTN_GGID { get; set; }
        public string CTN_CNAME { get; set; }
        public string CTN_CDESCRIPTION { get; set; }
        public bool CTN_BSTATE { get; set; }
        public string CTN_CCODE { get; set; }
    }
}
