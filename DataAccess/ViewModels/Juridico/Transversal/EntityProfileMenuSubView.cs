using System.Collections.Generic;

namespace Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop.Transversal
{
    public class EntityProfileMenuSubView
    {
        public string EntityName { get; set; }
        public string EntityCode { get; set; }
        public string ProfileName { get; set; }
        public string ProfileCode { get; set; }
        public string ProfileState { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public List<MenuSubmenuView> MenuSubmenuViews { get; set; }
    }
}
