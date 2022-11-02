using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Coopcentral.DataAccess.ViewModels.Integracion;
using Visionamos.Coopcentral.DataReads.Integracion;
using Visionamos.Coopcentral.SitiosWeb.Resources;

namespace Visionamos.Coopcentral.SitiosWeb.Controllers.Integracion
{
    public class NotificacionesEmailController : Controller
    {
        // GET: NotificacionesEmail
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.GetEmail();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_emailGrid_UI model)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.CreateEMail(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_emailGrid_UI model)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.DeleteEmail(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> SetAgregador([DataSourceRequest] DataSourceRequest request, int IdProv, bool OldCheck, bool NewCheck)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.UpdateEmailAgregador(IdProv,OldCheck,NewCheck);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> SetRecaudador([DataSourceRequest] DataSourceRequest request, int IdProv, bool OldCheck, bool NewCheck)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.UpdateEmailRecaudador(IdProv, OldCheck, NewCheck);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> SetComercio([DataSourceRequest] DataSourceRequest request, int IdProv, bool OldCheck, bool NewCheck)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.UpdateEmailComercio(IdProv, OldCheck, NewCheck);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

    }
}