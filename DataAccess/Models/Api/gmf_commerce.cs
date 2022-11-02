using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.Ecgts
{
	public class gmf_commerce
	{
		[Key]
		public string SRC { get; set; }
		public string CAT { get; set; }
		public int ACT { get; set; }
	}
}
