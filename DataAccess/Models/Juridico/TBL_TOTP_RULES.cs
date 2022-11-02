using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.Operations.DataAccess.Models.EnterpriseSecurity
{
    public class TBL_TOTP_RULES
    {
        [Key]
        public Guid OTP_GGID { get; set; }
        public string OTP_CCODE { get; set; }
        public string OTP_CDESCRIPTION { get; set; }
        public string OTP_CENTITY { get; set; }
        public int OTP_NLIFE_TIME { get; set; }
        public int OTP_NLENGTH { get; set; }
        public string OTP_NMAIL_TEMPLATE { get; set; }
        public int OTP_NATTEMPS { get; set; }
        public bool OTP_BUSER_CHOICE { get; set; }
        public bool OTP_BSMS_NOTIFY { get; set; }
        public bool OTP_BMAIL_NOTIFY { get; set; }
        public bool OTP_BDYNAMIC_INPUT { get; set; }
    }
}
