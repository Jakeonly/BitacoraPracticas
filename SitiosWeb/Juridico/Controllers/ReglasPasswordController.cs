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
    public class ReglasPasswordController : Controller
    {
        // GET: ReglasPassword
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, string entity)
        {
            ReglasPassword passwordRules = new ReglasPassword();
            var result = await passwordRules.GetAll(entity);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudExitosa);
                return Json(ModelState.ToDataSourceResult(request));
            }
            return Json(result.Respuesta.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, ReglasPasswordGrid_UI model, string entity)
        {
            ReglasPassword passwordRules = new ReglasPassword();
            var result = await passwordRules.Create(model, entity);
            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, result.Mensaje);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, ReglasPasswordGrid_UI model)
        {
            ReglasPassword passwordRules = new ReglasPassword();
            var result = await passwordRules.Update(model);
            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, result.Mensaje);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, ReglasPasswordGrid_UI model)
        {
            ReglasPassword passwordRules = new ReglasPassword();
            var result = await passwordRules.Delete(model);
            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}