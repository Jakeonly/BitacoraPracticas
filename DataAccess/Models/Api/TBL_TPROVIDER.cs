using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.LowAmountDeposit
{
	public class TBL_TPROVIDER
	{
		[Key]
		public Guid PRV_GGID { get; set; }
		public string PRV_NAME { get; set; }
	}
}
