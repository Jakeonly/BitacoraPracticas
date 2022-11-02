using System;
using Visionamos.Coopcentral.Common.Constantes;
using Visionamos.Coopcentral.DataAccess.Models.Ecgts;
using Visionamos.Coopcentral.DataAccess.ViewModels.Integracion;

namespace Visionamos.Coopcentral.DataReads.Mappers
{
    public static class ClsEntitiesStateMapper
    {
        public static commerce Map(this EntitiesStateGrid_UI model) => new commerce
        {
            CODE = model.Code,
            NAME = model.Name,
        };

        public static EntitiesStateGrid_UI Map(this commerce entity) => new EntitiesStateGrid_UI
        {
           Code = entity.CODE,
           Name = entity.NAME
        };
    }
}
