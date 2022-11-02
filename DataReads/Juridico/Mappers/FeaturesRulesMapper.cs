using System;
using Visionamos.Operations.DataAccess.Models.Products;
using Visionamos.Operations.DataAccess.ViewModels.Products;

namespace Visionamos.Operations.DataReads.Mappers.Products
{
    public static class FeaturesRulesMapper
    {
        public static TBL_TFEATURES_RULES Map(this FeaturesRulesGrid_UI model) => new TBL_TFEATURES_RULES
        {
            FTR_GGUID = string.IsNullOrEmpty(model.Guid) ? Guid.NewGuid() : Guid.Parse(model.Guid),
            FTR_CENTITY_CODE = model.EntityCode,
            FTR_CPRODUCT_TYPE = model.ProductType,
            FTR_CPRODUCT_SUBTYPE = model.ProductSubType,
            FTR_BALLOWS_QR = model.AllowsQr,
            FTR_BALLOWS_CP = model.AllowsCp,
            FTR_BALLOWS_MOVEMENTS_QUERY = model.AllowsMovements,
            FTR_BALLOWS_OBLIGATION_DETAILS = model.AllowsDetails,
            FTR_BALLOWS_VIEW_AVAILABLE_BALANCE = model.AllowViewBalance,
            FTR_BALLOWS_VIEW_DUE_DATE = model.AllowViewDueDate,
            FTR_BALLOWS_VIEW_LED_BALANCE = model.AllowViewLedBalance,
            FTR_BALLOWS_VIEW_MINIMUM_PAYMENT = model.AllowViewMinimumPay,
            FTR_BALLOWS_VIEW_TOTAL_PAYMENT = model.AllowViewTotalPayment
        };

        public static FeaturesRulesGrid_UI Map(this TBL_TFEATURES_RULES entity) => new FeaturesRulesGrid_UI
        {
            Guid = entity.FTR_GGUID.ToString(),
            EntityName = string.Empty,
            EntityCode = entity.FTR_CENTITY_CODE,
            ProductType = entity.FTR_CPRODUCT_TYPE,
            ProductSubType = entity.FTR_CPRODUCT_SUBTYPE,
            AllowsQr = entity.FTR_BALLOWS_QR,
            AllowsCp = entity.FTR_BALLOWS_CP,
            AllowsMovements = entity.FTR_BALLOWS_MOVEMENTS_QUERY,
            AllowsDetails = entity.FTR_BALLOWS_OBLIGATION_DETAILS,
            AllowViewBalance = entity.FTR_BALLOWS_VIEW_AVAILABLE_BALANCE,
            AllowViewDueDate = entity.FTR_BALLOWS_VIEW_DUE_DATE,
            AllowViewLedBalance = entity.FTR_BALLOWS_VIEW_LED_BALANCE,
            AllowViewMinimumPay = entity.FTR_BALLOWS_VIEW_MINIMUM_PAYMENT,
            AllowViewTotalPayment = entity.FTR_BALLOWS_VIEW_TOTAL_PAYMENT
        };
    }
}
