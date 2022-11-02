using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.ViewModels.Ecgts
{
	public class gmf_category_UI
	{
		[DisplayName("Codigo"),
		 StringLength(2, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
		 Required(ErrorMessage = "El campo {0} es requerido.")]
		public string CODE { get; set; }
		[DisplayName("Nombre"),
		 StringLength(50, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
		 Required(ErrorMessage = "El campo {0} es requerido.")]
		public string NAME { get; set; }
		[DisplayName("Tope"),
		 Required(ErrorMessage = "El campo {0} es requerido.")]
		public long EXEM_TOP { get; set; }
		[DisplayName("Porcentaje"),
		 Required(ErrorMessage = "El campo {0} es requerido.")]
		public double EXEM_PER { get; set; }
		[DisplayName("Porcentaje")]
		public double EXEM_PER_UI { get; set; }
	}
}
