using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.ViewModels.LowAmountDeposit
{
    public class TBL_TPROVIDER_UI
    {
        [DisplayName("ProveedorId"),
         Required(ErrorMessage = "El campo {0} es requerido.")]
        public string PRV_GGID { get; set; }
        [DisplayName("Proveedor"),
         StringLength(72, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
         Required(ErrorMessage = "El campo {0} es requerido.")]
        public string PRV_NAME { get; set; }
    }
}
