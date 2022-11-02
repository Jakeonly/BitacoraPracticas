using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.ViewModels.Integracion
{
	public class comercios_proveedor_notificaciones_comercioGrid_UI
	{
		public string Id { get; set; }
		public int IdComercioProveedor { get; set; }
		public string ComercioNombre { get; set; }
		[DisplayName("Nombre"),
		 StringLength(50, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
		 Required(ErrorMessage = "El campo {0} es requerido.")]
		public string Nombre { get; set; }
		[DisplayName("Correo"),
		 StringLength(100, ErrorMessage = "{0} no puede tener mas de {1} caracteres"),
		 Required(ErrorMessage = "El campo {0} es requerido.")]
		public string EmailNotificaciones { get; set; }
		public string IdComercioProveedorMaestroEmail { get; set; }
	}
}
