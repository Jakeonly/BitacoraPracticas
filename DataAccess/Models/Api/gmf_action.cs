using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.Ecgts
{
	public class gmf_action
	{
		[Key]
		public int CODE { get; set; }
		public string NAME { get; set; }
	}
}
