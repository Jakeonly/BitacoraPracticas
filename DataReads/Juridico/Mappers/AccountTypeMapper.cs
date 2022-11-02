using System;
using Visionamos.Operations.DataAccess.Models.Homologation;
using Visionamos.Operations.DataAccess.ViewModels.Homologation;

namespace Visionamos.Operations.DataReads.Mappers.Homologation
{
    /// <summary>
    /// Source File:   TipoCuentaMapper.cs                                             
    /// Description:   Mapper de TipoCuentaMapper
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public static class AccountTypeMapper
    {
        /// <summary>
        /// Mapper de TBL_TACCOUNT_TYPE a TipoCuentaGrid_UI.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static TBL_TACCOUNT_TYPE Map(this AccountTypeGrid_UI viewModel) => new TBL_TACCOUNT_TYPE
        {
            ACT_GID = string.IsNullOrEmpty(viewModel.ACT_GID) ? Guid.NewGuid() : Guid.Parse(viewModel.ACT_GID),
            ACT_BACTIVE = viewModel.ACT_BACTIVE,
            ACT_CDESCRIPTION = viewModel.ACT_CDESCRIPTION,
            ACT_COPEN_BANKING_TYPE = viewModel.ACT_COPEN_BANKING_TYPE,
            ACT_CPORTAL_TYPE = viewModel.ACT_CPORTAL_TYPE,
            ACT_CSWITCH_TYPE = viewModel.ACT_CSWITCH_TYPE
        };

        /// <summary>
        /// Mapper de TipoCuentaGrid_UI a TBL_TACCOUNT_TYPE
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountTypeGrid_UI Map(this TBL_TACCOUNT_TYPE entity) => new AccountTypeGrid_UI
        {
            ACT_GID = entity.ACT_GID.ToString(),
            ACT_BACTIVE = entity.ACT_BACTIVE,
            ACT_CDESCRIPTION = entity.ACT_CDESCRIPTION,
            ACT_COPEN_BANKING_TYPE = entity.ACT_COPEN_BANKING_TYPE,
            ACT_CPORTAL_TYPE = entity.ACT_CPORTAL_TYPE,
            ACT_CSWITCH_TYPE = entity.ACT_CSWITCH_TYPE
        };
    }
}
