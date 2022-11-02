using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visionamos.Coopcentral.DataAccess.Models.LowAmountDeposit;
using Visionamos.Coopcentral.DataAccess.ViewModels.LowAmountDeposit;

namespace Visionamos.Coopcentral.DataReads.Mappers
{
    public static class ClsProviderMapper
    {
        public static TBL_TPROVIDER Map(this TBL_TPROVIDER_UI model) => new TBL_TPROVIDER
        {
            PRV_GGID = string.IsNullOrEmpty(model.PRV_GGID) ? Guid.NewGuid() : Guid.Parse(model.PRV_GGID),
            PRV_NAME = model.PRV_NAME,
        };

        public static TBL_TPROVIDER_UI Map(this TBL_TPROVIDER entity) => new TBL_TPROVIDER_UI
        {
            PRV_GGID = entity.PRV_GGID.ToString(),
            PRV_NAME = entity.PRV_NAME,
        };
    }
}
