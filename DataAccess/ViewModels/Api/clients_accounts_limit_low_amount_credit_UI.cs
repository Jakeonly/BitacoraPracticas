using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.ViewModels.Ecgts
{
	public class clients_accounts_limit_low_amount_credit_UI
	{
        [DisplayName("Entidad"),
        StringLength(8, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
        Required(ErrorMessage = "El campo {0} es requerido.")]
        [UIHint("UiHint/ComboBoxEntidades")]
        public string SRC { get; set; }
        [DisplayName("Entidad")]
        public string SRC_TXT { get; set; }
        [DisplayName("Número de operaciones"),
        Required(ErrorMessage = "El campo {0} es requerido.")]
        [UIHint("UiHint/ComboBoxNumberlist")]
        public string MAX_OPE { get; set; }
        [DisplayName("Monto Máximo"),
         Required(ErrorMessage = "El campo {0} es requerido.")]
        public long MAX_AMO { get; set; }
        [DisplayName("Valor Máximo"),
         Required(ErrorMessage = "El campo {0} es requerido.")]
        public long MAX_VALUE { get; set; }
    }
}
