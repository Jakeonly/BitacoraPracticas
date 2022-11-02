using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.Operations.DataAccess.Models.Homologation
{
    /// <summary>
    /// Source File:   TBL_TACCOUNT_TYPE.cs                                             
    /// Description:   Tabla de TBL_TACCOUNT_TYPE
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          24/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class TBL_TACCOUNT_TYPE
    {
        [Key]
        public Guid ACT_GID { get; set; }
        public string ACT_CSWITCH_TYPE { get; set; }
        public string ACT_COPEN_BANKING_TYPE { get; set; }
        public string ACT_CPORTAL_TYPE { get; set; }
        public string ACT_CDESCRIPTION { get; set; }
        public bool ACT_BACTIVE { get; set; }
    }
}
