using System;
using Visionamos.Operations.DataAccess.Models.EnterpriseSecurity;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity;

namespace Visionamos.Operations.DataReads.Mappers.EnterpriseSecurity
{
    public static class ReglasPasswordMapper
    {
        public static TBL_TPASSWORD_RULES Map(this ReglasPasswordGrid_UI model) => new TBL_TPASSWORD_RULES
        {
            PSS_GGID = string.IsNullOrEmpty(model.Guid) ? Guid.NewGuid() : Guid.Parse(model.Guid),
            PSS_CENTITY = model.EntityCode,
            PSS_CCODE = model.Code,
            PSS_CDESCRIPTION = model.Description,
            PSS_CVALUE = model.Value
        };

        public static ReglasPasswordGrid_UI Map(this TBL_TPASSWORD_RULES entity) => new ReglasPasswordGrid_UI
        {
            Guid = entity.PSS_GGID.ToString(),
            EntityName = string.Empty,
            EntityCode = entity.PSS_CENTITY,
            Code = entity.PSS_CCODE,
            Description = entity.PSS_CDESCRIPTION,
            Value = entity.PSS_CVALUE
        };
    }
}
