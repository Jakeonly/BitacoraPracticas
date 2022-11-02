using System;
using Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop;

namespace Visionamos.Operations.DataReads.Mappers.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   SubMenuMapper.cs                                             
    /// Description:   Mapper de SubMenuMapper
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public static class SubMenuMapper
    {
        /// <summary>
        /// Mapper de TBL_TSUBMENU a SubmenuGrid_UI
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static TBL_TSUBMENU Map(this SubmenuGrid_UI viewModel) => new TBL_TSUBMENU
        {
            SBM_GGID = string.IsNullOrEmpty(viewModel.Guid) ? Guid.NewGuid() : Guid.Parse(viewModel.Guid),
            SBM_CNAME = viewModel.SubmenuName,
            SBM_NORDER = viewModel.SubmenuOrder,
            SBM_BSTATE = viewModel.State,
            SBM_CDESCRIPTION = viewModel.SubmenuDescription,
            SBM_CTOOLTIP = viewModel.SBM_CTOOLTIP,
            MEN_GGID = string.IsNullOrEmpty(viewModel.MenuCode) ? Guid.NewGuid() : Guid.Parse(viewModel.MenuCode)
        };

        /// <summary>
        /// Mapper de SubmenuGrid_UI a TBL_TSUBMENU
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static SubmenuGrid_UI Map(this TBL_TSUBMENU entity) => new SubmenuGrid_UI
        {
            Guid = entity.SBM_GGID.ToString(),
            SubmenuName = entity.SBM_CNAME,
            SubmenuOrder = entity.SBM_NORDER,
            State = entity.SBM_BSTATE,
            SubmenuDescription = entity.SBM_CDESCRIPTION,
            SBM_CTOOLTIP = entity.SBM_CTOOLTIP,
            MenuCode = entity.MEN_GGID.ToString(),
            MenuName = entity.TBL_TMENU.MEN_CDESCRIPTION
        };
    }
}
