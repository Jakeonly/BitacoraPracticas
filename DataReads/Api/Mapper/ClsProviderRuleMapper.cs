using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visionamos.Coopcentral.DataAccess.Models.LowAmountDeposit;
using Visionamos.Coopcentral.DataAccess.ViewModels.LowAmountDeposit;

namespace Visionamos.Coopcentral.DataReads.Mappers
{
    public static class ClsProviderRuleMapper
    {
        public static TBL_TRULES_PROVIDER Map(this TBL_TRULES_PROVIDER_UI model) => new TBL_TRULES_PROVIDER
        {
            RLS_GGID = string.IsNullOrEmpty(model.RLS_GGID) ? Guid.NewGuid() : Guid.Parse(model.RLS_GGID),
            RLS_CENTITY = model.RLS_CENTITY,
            PRV_GGID = string.IsNullOrEmpty(model.PRV_GGID) ? Guid.NewGuid() : Guid.Parse(model.PRV_GGID),
            RLS_NWAIT_TIME = Convert.ToInt32(model.RLS_NWAIT_TIME),
        };

        public static TBL_TRULES_PROVIDER_UI Map(this TBL_TRULES_PROVIDER entity) => new TBL_TRULES_PROVIDER_UI
        {
            RLS_GGID = entity.RLS_GGID.ToString(),
            RLS_CENTITY = entity.RLS_CENTITY,
            PRV_GGID = entity.PRV_GGID.ToString(),
            RLS_NWAIT_TIME = entity.RLS_NWAIT_TIME.ToString(),
        };
    }
}
