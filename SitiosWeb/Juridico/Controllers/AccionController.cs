using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseSecurity;
using Visionamos.Operations.DataReads.EnterpriseSecurity;
using Visionamos.SitiosWeb.Recursos;

namespace Visionamos.SitiosWeb.Controllers.EnterpriseSecurity
{
    public class AccionController : Controller
    {
        // GET: Accion
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            Accion Action = new Accion();
            var result = await Action.GetAll();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult(request));
            }
            return Json(result.Respuesta.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, AccionGrid_UI model)
        {
            Accion Action = new Accion();
            var result = await Action.Create(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request,
           AccionGrid_UI model)
        {
            Accion Action = new Accion();
            var result = await Action.Update(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request,
            AccionGrid_UI model)
        {
            Accion Action = new Accion();
            var result = await Action.Delete(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

    }
}