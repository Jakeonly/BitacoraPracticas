using System;
using Visionamos.Operations.DataAccess.Models.Products;
using Visionamos.Operations.DataAccess.ViewModels.Products;

namespace Visionamos.Operations.DataReads.Mappers.Products
{
    /// <summary>
    /// Source File:   ProductsMapper.cs                                             
    /// Description:   Mapper de ProductsMapper
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public static class BusinessRulesMapper
    {
        /// <summary>
        /// Mapper de TBL_TBUSINESS_RULES a BusinessRulesGrid_UI
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static TBL_TBUSINESS_RULES Map(this BusinessRulesGrid_UI viewModel) => new TBL_TBUSINESS_RULES
        {
            BSR_GGUID = string.IsNullOrEmpty(viewModel.GuidBusinessRules) ? Guid.NewGuid() : Guid.Parse(viewModel.GuidBusinessRules),
            BSR_CENTITY_CODE = viewModel.CodeEntity,
            BSR_CPRODUCT_TYPE = viewModel.CodeTypeBusiness,
            BSR_CPRODUCT_SUBTYPE = viewModel.CodeSubtypeBusiness,
            BSR_BALLOWS_PAYMENT = viewModel.BallowsPayment,
            BSR_BALLOWS_OTHERS_VALUES = viewModel.BallowsOthersValues,
            BSR_BALLOWS_LESS_MINIMUM = viewModel.BallowsLessMinimum,
            BSR_BALLOWS_MORE_MAXIMUM = viewModel.BallowsMoreMaximum,
            BSR_BALLOWS_DEBITS = viewModel.BallowsDebits,
            BSR_BALLOWS_CREDITS = viewModel.BallowsCredits,
            BSR_NINITIAL_VALUE = Convert.ToInt32(viewModel.InitialValue)
        };

        /// <summary>
        /// Mapper de BusinessRulesGrid_UI a TBL_TBUSINESS_RULES
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static BusinessRulesGrid_UI Map(this TBL_TBUSINESS_RULES entity) => new BusinessRulesGrid_UI
        {
            GuidBusinessRules = entity.BSR_GGUID.ToString(),
            CodeEntity = entity.BSR_CENTITY_CODE,
            NameEntity = string.Empty,
            CodeTypeBusiness = entity.BSR_CPRODUCT_TYPE,
            NameTypeBusiness = string.Empty,
            CodeSubtypeBusiness = entity.BSR_CPRODUCT_SUBTYPE,
            NameSubtypeBusiness = string.Empty,
            BallowsPayment = entity.BSR_BALLOWS_PAYMENT,
            BallowsOthersValues = entity.BSR_BALLOWS_OTHERS_VALUES,
            BallowsLessMinimum = entity.BSR_BALLOWS_LESS_MINIMUM,
            BallowsMoreMaximum = entity.BSR_BALLOWS_MORE_MAXIMUM,
            BallowsDebits = entity.BSR_BALLOWS_DEBITS,
            BallowsCredits = entity.BSR_BALLOWS_CREDITS,
            InitialValue = entity.BSR_NINITIAL_VALUE.ToString()
        };
    }
}
