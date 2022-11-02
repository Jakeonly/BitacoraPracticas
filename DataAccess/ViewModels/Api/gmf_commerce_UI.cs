using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.ViewModels.Ecgts
{
	public class gmf_commerce_UI
	{
		[DisplayName("Entidad"),
		 StringLength(8, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
		 Required(ErrorMessage = "El campo {0} es requerido.")]
		[UIHint("UiHint/ComboBoxEntidades")]
		public string SRC { get; set; }
		[DisplayName("Entidad")]
		public string SRC_TXT { get; set; }
		[DisplayName("Categoria"),
		 StringLength(2, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
		 Required(ErrorMessage = "El campo {0} es requerido.")]
		[UIHint("UiHint/ComboBoxGmfCategory")]
		public string CAT { get; set; }
		[DisplayName("Categoria")]
		public string CAT_TXT { get; set; }
		[DisplayName("Acción"),
		 Required(ErrorMessage = "El campo {0} es requerido.")]
		[UIHint("UiHint/ComboBoxGmfAction")]
		public string ACT { get; set; }
		[DisplayName("Acción")]
		public string ACT_TXT { get; set; }
	}
}
