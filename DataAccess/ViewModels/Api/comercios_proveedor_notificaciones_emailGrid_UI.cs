using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.ViewModels.Integracion
{
	public class comercios_proveedor_notificaciones_emailGrid_UI
	{
		public string Id { get; set; }
		[UIHint("UiHint/ComboBoxComercios")]
		public string IdComercioProveedor { get; set; }
		[DisplayName("Comercio")]
		public string NombreComercio { get; set; }
		[DisplayName("Notificar Agregador: ")]
		public bool NotificarEmailAgregador { get; set; }
		[DisplayName("Notificar Recaudador: ")]
		public bool NotificarEmailRecaudador { get; set; }
		[DisplayName("Notificar Comercio: ")]
		public bool NotificarEmailComercio { get; set; }
	}
}
