using System.ComponentModel.DataAnnotations;
using Visionamos.Operations.DataAccess.Recursos;

namespace Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity
{
    public class AccionGrid_UI
    {
        public string Guid { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Name))]
        [StringLength(56, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string ActionName { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Description))]
        [StringLength(56, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string ActionDescription { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.State))]
        public string State { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.State))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [UIHint("UiHint/ComboBoxActivoInactivo")]
        public string ActionState { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Code))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(3, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 3)]
        public string ActionCode { get; set; }
    }
}
