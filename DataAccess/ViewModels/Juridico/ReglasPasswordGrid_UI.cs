using System.ComponentModel.DataAnnotations;
using Visionamos.Operations.DataAccess.Recursos;

namespace Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity
{
    public class ReglasPasswordGrid_UI
    {
        public string Guid { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [UIHint("UiHint/ComboBoxEntidades")]
        public string EntityCode { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        public string EntityName { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Code))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(3, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 3)]
        public string Code { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Description))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(72, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        public string Description { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.ExpirationTime))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(16, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        public string Value { get; set; }
    }
}
