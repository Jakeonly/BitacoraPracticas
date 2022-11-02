using System.ComponentModel.DataAnnotations;
using Visionamos.Operations.DataAccess.Recursos;

namespace Visionamos.Operations.DataAccess.ViewModels.Products
{
    /// <summary>
    /// Source File:   ProductsGrid_UI.cs                                             
    /// Description:   ViewModel de ProductsGrid_UI
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class BusinessRulesGrid_UI
    {
        public string GuidBusinessRules { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string CodeEntity { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        public string NameEntity { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.ProductType))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
          ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [UIHint("UiHint/ComboBoxAccountType")]
        public string CodeTypeBusiness { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.ProductType))]
        public string NameTypeBusiness { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.ProductSubtype))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
          ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [UIHint("UiHint/ComboBoxAccountSubtype")]
        public string CodeSubtypeBusiness { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.ProductSubtype))]
        public string NameSubtypeBusiness { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowsPayment))]
        public bool BallowsPayment { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowsOthersValues))]
        public bool BallowsOthersValues { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowsLessMinimum))]
        public bool BallowsLessMinimum { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowsMoreMaximum))]
        public bool BallowsMoreMaximum { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowsDebits))]
        public bool BallowsDebits { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.AllowsCredits))]
        public bool BallowsCredits { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.InitialValue))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
          ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(14, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        public string InitialValue { get; set; }
    }
}
