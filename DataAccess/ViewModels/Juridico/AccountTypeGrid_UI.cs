using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Operations.DataAccess.ViewModels.Homologation
{
    /// <summary>
    /// Source File:   TipoCuentaGrid_UI.cs                                             
    /// Description:   ViewModel de TipoCuentaGrid_UI
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          24/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class AccountTypeGrid_UI
    {
        public string ACT_GID { get; set; }
        public string ACT_CSWITCH_TYPE { get; set; }
        public string ACT_COPEN_BANKING_TYPE { get; set; }
        public string ACT_CPORTAL_TYPE { get; set; }
        public string ACT_CDESCRIPTION { get; set; }
        public bool ACT_BACTIVE { get; set; }
    }
}
