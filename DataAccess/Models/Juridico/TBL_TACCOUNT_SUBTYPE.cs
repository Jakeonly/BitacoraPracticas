using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.Operations.DataAccess.Models.Homologation
{
    /// <summary>
    /// Source File:   TBL_TACCOUNT_SUBTYPE.cs                                             
    /// Description:   Tabla de TBL_TACCOUNT_SUBTYPE
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          24/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class TBL_TACCOUNT_SUBTYPE
    {
        [Key]
        public Guid AST_GID { get; set; }
        public string AST_CSWITCH_TYPE { get; set; }
        public string AST_COPEN_BANKING_TYPE { get; set; }
        public string AST_CPORTAL_TYPE { get; set; }
        public string AST_CDESCRIPTION { get; set; }
        public bool AST_BACTIVE { get; set; }
        public string AST_COPEN_BANKING_TYPEPARENT { get; set; }
    }
}
