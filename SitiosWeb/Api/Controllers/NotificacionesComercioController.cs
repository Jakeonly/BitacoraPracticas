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
    public class NotificacionesComercioController : Controller
    {
        // GET: NotificacionesComercio
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, int CodigoComercio)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var resultado = await ClsComercioNotificaciones.GetComercio();

            if (resultado.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult(request));
            }
            var final = resultado.Respuesta.Where(x => x.IdComercioProveedor == CodigoComercio);
            return Json(final.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_comercioGrid_UI model, int CodigoComercio)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.CreateComercio(model, CodigoComercio);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_comercioGrid_UI model, int CodigoComercio)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.UpdateComercio(model, CodigoComercio);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, comercios_proveedor_notificaciones_comercioGrid_UI model, int CodigoComercio)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var result = await ClsComercioNotificaciones.DeleteComercio(model, CodigoComercio);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

    }

}
