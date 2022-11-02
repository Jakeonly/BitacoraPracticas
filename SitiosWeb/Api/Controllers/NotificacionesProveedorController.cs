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
    public class NotificacionesProveedorController : Controller
    {
        // GET: NotificacionesProveedor
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var resultado = await ClsComercioNotificaciones.GetComercioProveedor();

            if (resultado.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult(request));
            }
            return Json(resultado.Respuesta.ToDataSourceResult(request));
        }

        public async Task<ActionResult> ReadCombo([DataSourceRequest] DataSourceRequest request)
        {
            ClsComercioNotificaciones ClsComercioNotificaciones = new ClsComercioNotificaciones();
            var resultado = await ClsComercioNotificaciones.GetComercioProveedorComboBox();

            if (resultado.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult(request));
            }
            return Json(resultado.Respuesta.ToDataSourceResult(request));
        }
    }
}