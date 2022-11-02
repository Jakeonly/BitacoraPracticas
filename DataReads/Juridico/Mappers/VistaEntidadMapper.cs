using System;
using Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop;

namespace Visionamos.Operations.DataReads.Mappers.EnterpriseBackdrop
{
    public static class VistaEntidadMapper
    {
        public static TBL_TVIEW_ENTITY Map(this VistaEntidadGrid_UI model) => new TBL_TVIEW_ENTITY
        {
            VEN_GGID = string.IsNullOrEmpty(model.VEN_GGID) ? Guid.NewGuid() : Guid.Parse(model.VEN_GGID),
            VEN_ENTITY_CODE = model.VEN_ENTITY_CODE,
            VEN_BSTATE = model.VEN_BSTATE,
            VIW_GGID = string.IsNullOrEmpty(model.VIW_GGID) ? Guid.NewGuid() : Guid.Parse(model.VIW_GGID),
            PRF_GGID = string.IsNullOrEmpty(model.PRF_GGID) ? Guid.NewGuid() : Guid.Parse(model.PRF_GGID)
        };

        public static VistaEntidadGrid_UI Map(this TBL_TVIEW_ENTITY entity) => new VistaEntidadGrid_UI
        {
            VEN_GGID = entity.VEN_GGID.ToString(),
            VEN_ENTITY_CODE = entity.VEN_ENTITY_CODE,
            VEN_BSTATE = entity.VEN_BSTATE,
            VIW_GGID = entity.VIW_GGID.ToString(),
            PRF_GGID = entity.PRF_GGID.ToString()
        };
    }
}
