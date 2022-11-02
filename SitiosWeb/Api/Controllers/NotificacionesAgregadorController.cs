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
    public class NotificacionesAgregadorController : Controller
    {
        // GET: NotificacionesAgregador
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.GetAgregador();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_agregadorGrid_UI model)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.CreateAgregador(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_agregadorGrid_UI model)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.UpdateAgregador(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_agregadorGrid_UI model)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.DeleteAgregador(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

    }

}
