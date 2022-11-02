using System.ComponentModel.DataAnnotations;
using Visionamos.Operations.DataAccess.Recursos;

namespace Visionamos.Operations.DataAccess.ViewModels.Products
{
    public class FeaturesRulesGrid_UI
    {
        public string Guid { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        public string EntityName { get; set; }
        public string EntityCode { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.ProductType))]
        [StringLength(2, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [UIHint("UiHint/ComboBoxAccountType")]
        public string ProductType { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.ProductType))]
        public string ProductTypeTxt { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.ProductSubtype))]
        [StringLength(2, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [UIHint("UiHint/ComboBoxAccountSubtype")]
        public string ProductSubType { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.ProductSubtype))]
        public string ProductSubTypeTxt { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowQr))]
        public bool AllowsQr { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowCp))]
        public bool AllowsCp { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowMov))]
        public bool AllowsMovements { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowDetail))]
        public bool AllowsDetails { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowViewBalance))]
        public bool? AllowViewBalance { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowViewDueDate))]
        public bool? AllowViewDueDate { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowViewLedBalance))]
        public bool? AllowViewLedBalance { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowViewMinimumPay))]
        public bool? AllowViewMinimumPay { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowViewTotalPayment))]
        public bool? AllowViewTotalPayment { get; set; }
    }
}
