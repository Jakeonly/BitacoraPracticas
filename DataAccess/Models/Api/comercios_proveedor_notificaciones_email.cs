using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.Integracion
{
	public class comercios_proveedor_notificaciones_email
	{
		[Key]
		public Guid Id { get; set; }
		public int IdComercioProveedor { get; set; }
		public bool NotificarEmailAgregador { get; set; }
		public bool NotificarEmailRecaudador { get; set; }
		public bool NotificarEmailComercio { get; set; }

		[ForeignKey("IdComercioProveedor")]
		public virtual comercios_proveedor comercios_proveedor { get; set; }
	}
}
