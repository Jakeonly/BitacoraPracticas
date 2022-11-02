using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.LowAmountDeposit
{
	public class TBL_TRULES_PROVIDER
	{
		[Key]
		public Guid RLS_GGID { get; set; }
		public string RLS_CENTITY { get; set; }
		public Guid PRV_GGID { get; set; }
		public int RLS_NWAIT_TIME { get; set; }

		[ForeignKey("PRV_GGID")]
		public virtual TBL_TPROVIDER TBL_TPROVIDER { get; set; }
	}
}
