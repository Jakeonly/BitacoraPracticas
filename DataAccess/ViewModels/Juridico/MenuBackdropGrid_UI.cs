using System;
using System.ComponentModel.DataAnnotations;
using Visionamos.Operations.DataAccess.Recursos;

namespace Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   MenuGrid_UI.cs                                             
    /// Description:   ViewModel de MenuGrid_UI
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class MenuBackdropGrid_UI
    {
        public string GuidMenu { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name =(nameof(RscGlobalMessages.Name)))]
        [StringLength(56, ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string MenuName { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = (nameof(RscGlobalMessages.Description)))]
        [StringLength(56, ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string MenuDescription { get; set; }
        public string MEN_CTOOLTIP { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = (nameof(RscGlobalMessages.State)))]
        public bool State { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = (nameof(RscGlobalMessages.Order)))]
        public string MenuOrder { get; set; }
    }
}
