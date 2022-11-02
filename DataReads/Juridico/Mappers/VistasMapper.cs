using System;
using Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop;

namespace Visionamos.Operations.DataReads.Mappers.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   VistasMapper.cs                                             
    /// Description:   Mapper de VistasMapper
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public static class VistasMapper
    {
        /// <summary>
        /// Mapper de TBL_TVIEW a VistasGrid_UI
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static TBL_TVIEW Map(this VistasGrid_UI viewModel) => new TBL_TVIEW
        {
            VIW_GGID = string.IsNullOrEmpty(viewModel.Guid) ? Guid.NewGuid() : Guid.Parse(viewModel.Guid),
            VIW_CNAME = viewModel.ViewName,
            VIW_BSTATE = viewModel.State,
            VIW_NORDER = viewModel.ViewOrder,
            VIW_BOTP = viewModel.VIW_BOTP,
            VIW_CDESCRIPTION = viewModel.ViewDescription,
            VIW_CTOOLTIP = viewModel.VIW_CTOOLTIP,
            VIW_CACTION = viewModel.ViewAction,
            SBM_GGID = string.IsNullOrEmpty(viewModel.SubmenuCode) ? Guid.NewGuid() : Guid.Parse(viewModel.SubmenuCode)
        };

        /// <summary>
        /// Mapper de VistasGrid_UI a TBL_TVIEW 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static VistasGrid_UI Map(this TBL_TVIEW entity) => new VistasGrid_UI
        {
            Guid = entity.VIW_GGID.ToString(),
            ViewName = entity.VIW_CNAME,
            State = entity.VIW_BSTATE,
            ViewOrder = entity.VIW_NORDER,
            VIW_BOTP = entity.VIW_BOTP,
            OTP_UI = entity.VIW_BOTP ? "Activo" : "Inactivo",
            ViewDescription = entity.VIW_CDESCRIPTION,
            VIW_CTOOLTIP = entity.VIW_CTOOLTIP,
            ViewAction = entity.VIW_CACTION,
            SubmenuCode = entity.SBM_GGID.ToString(),
            SubmenuName = entity.TBL_TSUBMENU.SBM_CDESCRIPTION
        };
    }
}
