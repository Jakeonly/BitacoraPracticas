using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Coopcentral.DataAccess.ViewModels.Integracion;
using Visionamos.Coopcentral.DataReads.Integracion;
using Visionamos.Coopcentral.SitiosWeb.Resources;

namespace Visionamos.Coopcentral.SitiosWeb.Controllers.Integracion
{
    public class NotificacionesRecaudadorController : Controller
    {
        // GET: NotificacionesRecaudador
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, string CodigoEntidad)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var resultado = await ClsComercioNotificaciones.GetRecaudador();

            if (resultado.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult(request));
            }
            var final = resultado.Respuesta.Where(x => x.CodigoRecaudador == CodigoEntidad);
            return Json(final.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_recaudadorGrid_UI model, string CodigoEntidad)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.CreateRecaudador(model, CodigoEntidad);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_recaudadorGrid_UI model, string CodigoEntidad)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.UpdateRecaudador(model, CodigoEntidad);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_recaudadorGrid_UI model, string CodigoEntidad)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.DeleteRecaudador(model, CodigoEntidad);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

    }

}
