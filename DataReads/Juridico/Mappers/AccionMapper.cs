using System;
using Visionamos.Operations.DataAccess.Models.EnterpriseSecurity;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity;

namespace Visionamos.Operations.DataReads.Mappers.EnterpriseSecurity
{
    public static class AccionMapper
    {
        public static TBL_TACTION Map(this AccionGrid_UI model) => new TBL_TACTION
        {
            CTN_GGID = string.IsNullOrEmpty(model.Guid) ? Guid.NewGuid() : Guid.Parse(model.Guid),
            CTN_CNAME = model.ActionName,
            CTN_CDESCRIPTION = model.ActionDescription,
            CTN_BSTATE = Convert.ToBoolean(model.ActionState),
            CTN_CCODE = model.ActionCode
        };

        public static AccionGrid_UI Map(this TBL_TACTION entity) => new AccionGrid_UI
        {
            Guid = entity.CTN_GGID.ToString(),
            ActionName = entity.CTN_CNAME,
            ActionDescription = entity.CTN_CDESCRIPTION,
            ActionState = Convert.ToString(entity.CTN_BSTATE),
            State = entity.CTN_BSTATE ? "Activo" : "Inactivo",
            ActionCode = entity.CTN_CCODE
        };

    }
}
