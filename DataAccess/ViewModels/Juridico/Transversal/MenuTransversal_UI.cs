namespace Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop.Transversal
{
    public class MenuTransversal_UI
    {
        public string Guid { get; set; }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }

        public string ViewCode { get; set; }
        public string ProfileCode { get; set; }
        public string EntityCode { get; set; }
        public bool? IsActive { get; set; }
    }
}
