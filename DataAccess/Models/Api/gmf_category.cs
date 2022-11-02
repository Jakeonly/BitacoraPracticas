using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.Ecgts
{
	public class gmf_category
	{
		[Key]
		public string CODE { get; set; }
		public string NAME { get; set; }
		public long EXEM_TOP { get; set; }
		public double EXEM_PER { get; set; }
	}
}
