using System.ComponentModel.DataAnnotations;
using Visionamos.Operations.DataAccess.Recursos;

namespace Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity
{
    public class ReglasOtpGrid_UI
    {
        public string Guid { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Code))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(3, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 3)]
        [UIHint("UiHint/ComboBoxCodigoOTP")]
        public string Code { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Description))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(72, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        public string Description { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        [StringLength(8, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 8)]
        [UIHint("UiHint/ComboBoxEntidades")]
        public string EntityCode { get; set; }
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Entity))]
        public string EntityName { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.LifeTimes))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string TimeLife { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Length))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string Length { get; set; }

        [StringLength(8, ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.StringLenghtValidation), MinimumLength = 1)]
        public string TemplateMail { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.Attempts))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public string Attempts { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.UserSelection))]
        public string SelectUserTxt { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.UserSelection))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public bool SelectUser { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.NotificactionSms))]
        public string NotificationSmsTxt { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.NotificactionSms))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public bool NotificationSms { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.NotificactionMail))]
        public string NotificationMailTxt { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.NotificactionMail))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public bool NotificationMail { get; set; }

        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.DynamicKeyboard))]
        public string DynamicKeyboardTxt { get; set; }
       
        [Display(ResourceType = typeof(RscGlobalMessages), Name = nameof(RscGlobalMessages.DynamicKeyboard))]
        [Required(ErrorMessageResourceType = typeof(RscGlobalMessages), ErrorMessageResourceName = nameof(RscGlobalMessages.RequiredValidation))]
        public bool DynamicKeyboard { get; set; }
    }
}
