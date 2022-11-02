using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.ViewModels.LowAmountDeposit
{
    public class TBL_TRULES_PROVIDER_UI
    {
        public string RLS_GGID { get; set; }
        [DisplayName("Entidad"),
         StringLength(72, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
         Required(ErrorMessage = "El campo {0} es requerido.")]
        [UIHint("UiHint/ComboBoxEntidades")]
        public string RLS_CENTITY { get; set; }
        [DisplayName("Entidad")]
        public string RLS_CENTITY_TXT { get; set; }
        [DisplayName("Proveedor"),
         Required(ErrorMessage = "El campo {0} es requerido.")]
        [UIHint("UiHint/ComboBoxProvider")]
        public string PRV_GGID { get; set; }
        [DisplayName("Proveedor")]
        public string PRV_GGID_TXT { get; set; }
        [DisplayName("Tiempo de espera / (Minutos)"),
         StringLength(4, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
         Required(ErrorMessage = "El campo {0} es requerido.")]
        public string RLS_NWAIT_TIME { get; set; }
    }
}
