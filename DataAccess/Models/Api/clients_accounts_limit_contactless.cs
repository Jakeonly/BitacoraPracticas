using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.Ecgts
{
	public class clients_accounts_limit_contactless
	{
		[Key]
		public string SRC { get; set; }
		public int MAX_OPE { get; set; }
		public long MAX_AMO { get; set; }
		public long MAX_VALUE { get; set; }
	}
}
