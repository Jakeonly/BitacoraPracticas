using System.ComponentModel.DataAnnotations;
using Visionamos.Operations.DataAccess.Recursos;

namespace Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   SubmenuGrid_UI                                             
    /// Description:   ViewModel de SubmenuGrid_UI
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class SubmenuGrid_UI
    {

        public string Guid { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Name))]
        [StringLength(56, ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string SubmenuName { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Order))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public decimal SubmenuOrder { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.State))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public bool State { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Description))]
        [StringLength(256, ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string SubmenuDescription { get; set; }

        public string SBM_CTOOLTIP { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Menu))]
        public string MenuCode { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Menu))]
        public string MenuName { get; set; }
    }
}
