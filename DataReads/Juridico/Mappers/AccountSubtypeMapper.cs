using System;
using Visionamos.Operations.DataAccess.Models.Homologation;
using Visionamos.Operations.DataAccess.ViewModels.Homologation;

namespace Visionamos.Operations.DataReads.Mappers.Homologation
{
    /// <summary>
    /// Source File:   SubtipoCuentaMapper.cs                                             
    /// Description:   Mapper de SubtipoCuentaMapper
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public static class AccountSubtypeMapper
    {
        /// <summary>
        /// Mapper de TBL_TACCOUNT_SUBTYPE a SubtipoCuentaGrid_UI
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static TBL_TACCOUNT_SUBTYPE Map(this AccountSubtypeGrid_UI viewModel) => new TBL_TACCOUNT_SUBTYPE
        {
            AST_GID = string.IsNullOrEmpty(viewModel.AST_GID) ? Guid.NewGuid() : Guid.Parse(viewModel.AST_GID),
            AST_BACTIVE = viewModel.AST_BACTIVE,
            AST_CDESCRIPTION = viewModel.AST_CDESCRIPTION,
            AST_COPEN_BANKING_TYPE = viewModel.AST_COPEN_BANKING_TYPE,
            AST_COPEN_BANKING_TYPEPARENT = viewModel.AST_COPEN_BANKING_TYPEPARENT,
            AST_CPORTAL_TYPE = viewModel.AST_CPORTAL_TYPE,
            AST_CSWITCH_TYPE = viewModel.AST_CSWITCH_TYPE
        };

        /// <summary>
        /// Mapper de SubtipoCuentaGrid_UI a TBL_TACCOUNT_SUBTYPE
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AccountSubtypeGrid_UI Map(this TBL_TACCOUNT_SUBTYPE entity) => new AccountSubtypeGrid_UI
        {
            AST_GID = entity.AST_GID.ToString(),
            AST_BACTIVE = entity.AST_BACTIVE,
            AST_CDESCRIPTION = entity.AST_CDESCRIPTION,
            AST_COPEN_BANKING_TYPE = entity.AST_COPEN_BANKING_TYPE,
            AST_COPEN_BANKING_TYPEPARENT = entity.AST_COPEN_BANKING_TYPEPARENT,
            AST_CPORTAL_TYPE = entity.AST_CPORTAL_TYPE,
            AST_CSWITCH_TYPE = entity.AST_CSWITCH_TYPE
        };
    }
}
