using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.Integracion
{
	public class comercios_proveedor_notificaciones_agregador
	{
		[Key]
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public string EmailNotificaciones { get; set; }
		public Guid IdComercioProveedorMaestroEmail { get; set; }

		[ForeignKey("IdComercioProveedorMaestroEmail")]
		public virtual comercios_proveedor_maestro_notificaciones comercios_proveedor_maestro_notificaciones { get; set; }
	}
}
