using System.ComponentModel.DataAnnotations;
using Visionamos.Operations.DataAccess.Recursos;

namespace Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity
{
    /// <summary>
    /// Source File:   ReglaPorEntidadGrid_UI.cs                                             
    /// Description:   ViewModel de ReglaPorEntidadGrid_UI
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/07/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class ReglaPreguntaEntidadGrid_UI
    {
        public string Guid { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [UIHint("UiHint/ComboBoxEntidades")]
        public string EntityCode { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        public string EntityName { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.NumberQuestion))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(2, ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        public string NumberQuestion { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.NumberAnswer))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(2, ErrorMessageResourceType = typeof(RscGlobalMessages),
            ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        public string NumberAnswer { get; set; }
    }
}
