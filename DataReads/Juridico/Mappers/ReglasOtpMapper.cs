using System;
using Visionamos.Operations.DataAccess.Models.EnterpriseSecurity;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity;

namespace Visionamos.Operations.DataReads.Mappers.EnterpriseSecurity
{
    public static class ReglasOtpMapper
    {
        public static TBL_TOTP_RULES Map(this ReglasOtpGrid_UI model) => new TBL_TOTP_RULES
        {
            OTP_GGID = string.IsNullOrEmpty(model.Guid) ? Guid.NewGuid() : Guid.Parse(model.Guid),
            OTP_CCODE = model.Code,
            OTP_CDESCRIPTION = model.Description,
            OTP_CENTITY = model.EntityCode,
            OTP_NLIFE_TIME = Convert.ToInt32(model.TimeLife),
            OTP_NLENGTH = Convert.ToInt32(model.Length),
            OTP_NMAIL_TEMPLATE = model.TemplateMail,
            OTP_NATTEMPS = Convert.ToInt32(model.Attempts),
            OTP_BUSER_CHOICE = model.SelectUser,
            OTP_BSMS_NOTIFY = model.NotificationSms,
            OTP_BMAIL_NOTIFY = model.NotificationMail,
            OTP_BDYNAMIC_INPUT = model.DynamicKeyboard
        };

        public static ReglasOtpGrid_UI Map(this TBL_TOTP_RULES entity) => new ReglasOtpGrid_UI
        {
            Guid = entity.OTP_GGID.ToString(),
            Code = entity.OTP_CCODE,
            Description = entity.OTP_CDESCRIPTION,
            EntityCode = entity.OTP_CENTITY,
            EntityName = string.Empty,
            TimeLife = entity.OTP_NLIFE_TIME.ToString(),
            Length = Convert.ToString(entity.OTP_NLENGTH),
            TemplateMail = entity.OTP_NMAIL_TEMPLATE,
            Attempts = Convert.ToString(entity.OTP_NATTEMPS),
            SelectUser = entity.OTP_BUSER_CHOICE,
            SelectUserTxt = entity.OTP_BUSER_CHOICE ? "Activo" : "Inactivo",
            NotificationSms = entity.OTP_BSMS_NOTIFY,
            NotificationSmsTxt = entity.OTP_BSMS_NOTIFY ? "Activo" : "Inactivo",
            NotificationMail = entity.OTP_BMAIL_NOTIFY,
            NotificationMailTxt = entity.OTP_BMAIL_NOTIFY ? "Activo" : "Inactivo",
            DynamicKeyboard = entity.OTP_BDYNAMIC_INPUT,
            DynamicKeyboardTxt = entity.OTP_BDYNAMIC_INPUT ? "Activo" : "Inactivo",
        };

    }
}
