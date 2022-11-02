using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Operations.DataAccess.Contexts;
using Visionamos.Operations.DataAccess.Models;
using Visionamos.Operations.DataAccess.Models.Ecgts;
using Visionamos.Operations.DataAccess.Models.EnterpriseSecurity;
using Visionamos.Operations.DataAccess.Recursos;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity;
using Visionamos.Operations.DataReads.ECGTS;
using Visionamos.Operations.DataReads.Mappers.EnterpriseSecurity;
using Visionamos.Operations.DataReads.Utilidades;

namespace Visionamos.Operations.DataReads.EnterpriseSecurity
{
    public class ReglasOtp
    {
        #region Internals
        public OperationsModels<EnterpriseSecurityContext> dbContext;
        #endregion

        #region Constructor
        public ReglasOtp(OperationsModels<EnterpriseSecurityContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<EnterpriseSecurityContext>();
            }
        }
        #endregion

        #region Methods
        public async Task<NotificacionRespuesta<List<ReglasOtpGrid_UI>>> GetAll(string entity)
        {
            NotificacionRespuesta<List<ReglasOtpGrid_UI>> response = new NotificacionRespuesta<List<ReglasOtpGrid_UI>>();

            try
            {
                var context = dbContext.obtenerContexto();
                List<TBL_TOTP_RULES> rulesOtpList = (List<TBL_TOTP_RULES>)await dbContext.ObtenerTodosAsync<TBL_TOTP_RULES>();
                Commerce commerce = new Commerce();
                List<commerce> commerceList = await commerce.ObtenerListaOrdenadaAsync();
                var result = rulesOtpList.Join(commerceList,
                    l => l.OTP_CENTITY,
                    com => com.CODE,
                    (l, com) => new ReglasOtpGrid_UI
                    {
                        Guid = l.OTP_GGID.ToString(),
                        Code = l.OTP_CCODE,
                        EntityCode = l.OTP_CENTITY,
                        Description = l.OTP_CDESCRIPTION,
                        Attempts = l.OTP_NATTEMPS.ToString(),
                        Length = l.OTP_NLENGTH.ToString(),
                        EntityName = com.NAME,
                        NotificationMail = l.OTP_BMAIL_NOTIFY,
                        NotificationMailTxt = l.OTP_BMAIL_NOTIFY ? "Activo" : "Inactivo",
                        NotificationSms = l.OTP_BSMS_NOTIFY,
                        NotificationSmsTxt = l.OTP_BSMS_NOTIFY ? "Activo" : "Inactivo",
                        TemplateMail = l.OTP_NMAIL_TEMPLATE,
                        SelectUser = l.OTP_BUSER_CHOICE,
                        SelectUserTxt = l.OTP_BUSER_CHOICE ? "Activo" : "Inactivo",
                        DynamicKeyboard = l.OTP_BDYNAMIC_INPUT,
                        DynamicKeyboardTxt = l.OTP_BDYNAMIC_INPUT ? "Activo" : "Inactivo",
                        TimeLife = l.OTP_NLIFE_TIME.ToString()
                    }).OrderBy(x => x.EntityName).Where(x => x.EntityCode == entity).ToList();

                response.AsignarRespuesta(result);

            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }


        public async Task<NotificacionRespuesta<ReglasOtpGrid_UI>> Update(ReglasOtpGrid_UI model)
        {
            NotificacionRespuesta<ReglasOtpGrid_UI> response = new NotificacionRespuesta<ReglasOtpGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TOTP_RULES>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        public async Task<NotificacionRespuesta<ReglasOtpGrid_UI>> Create(ReglasOtpGrid_UI model, string entity)
        {
            NotificacionRespuesta<ReglasOtpGrid_UI> response = new NotificacionRespuesta<ReglasOtpGrid_UI>();
            try
            {
                if (ValidarRegistros(model.EntityCode, model.Code))
                {
                    var context = dbContext.obtenerContexto();
                    var record = context.Set<TBL_TOTP_RULES>().Add(model.Map());
                    await context.SaveChangesAsync();
                    var list = await GetAll(entity);
                    model = list.Respuesta.FirstOrDefault(x => x.Guid == record.OTP_GGID.ToString());
                    response.AsignarRespuesta(model);
                }
                else
                {
                    throw new Exception(message: RscGlobalMessages.EntityOTPRule);
                }
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        public async Task<NotificacionRespuesta<bool>> Delete(ReglasOtpGrid_UI model)
        {
            NotificacionRespuesta<bool> response = new NotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<TBL_TOTP_RULES>(model.Map());
                await dbContext.GuardarCambiosAsync();
                response.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }
            return response;
        }

        private bool ValidarRegistros(string entity, string codigo)
        {
            var context = dbContext.obtenerContexto().Set<TBL_TOTP_RULES>();
            if (context.Any(p => p.OTP_CENTITY.Equals(entity) && p.OTP_CCODE.Equals(codigo)))
            {
                throw new Exception(message: RscGlobalMessages.EntityOTPRule);
            }
            return true;
        }
        #endregion
    }
}

