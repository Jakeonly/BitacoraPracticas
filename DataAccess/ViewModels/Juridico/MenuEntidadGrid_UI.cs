using System.ComponentModel.DataAnnotations;
using Visionamos.Operations.DataAccess.Recursos;

namespace Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   MenuEntidadGrid_UI.cs                                             
    /// Description:   ViewModel de MenuEntidadGrid_UI
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          01/09/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class MenuEntidadGrid_UI
    {
        public string GuidVistaEntidad { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        [UIHint("UiHint/ComboBoxEntidades")]
        public string CodigoEntidad { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        public string NombreEntidad { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.State))]
        public bool EstadoVistaEntidad { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Profile))]
        [UIHint("UiHint/ComboBoxPerfilesEntidad")]
        public string CodigoPerfil { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Profile))]
        public string NombrePerfil { get; set; }

        public string CodigoVista { get; set; }
        public string NombreVista { get; set; }

        public string CodigoSubmenu { get; set; }
        public string NombreSubmenu { get; set; }

        public string CodigoMenu { get; set; }
        public string NombreMenu { get; set; }

        public int Child { get; set; }
        public int Parent { get; set; }
    }
}
