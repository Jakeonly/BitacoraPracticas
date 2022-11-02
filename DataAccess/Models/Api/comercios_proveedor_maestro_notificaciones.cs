using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.Integracion
{
	public class comercios_proveedor_maestro_notificaciones
	{
		[Key]
		public Guid Id { get; set; }
		public string Descripcion { get; set; }
	}
}
