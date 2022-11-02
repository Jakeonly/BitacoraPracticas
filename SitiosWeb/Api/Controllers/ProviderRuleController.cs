using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Coopcentral.DataAccess.ViewModels.LowAmountDeposit;
using Visionamos.Coopcentral.DataReads.LowAmountDeposit;
using Visionamos.Coopcentral.SitiosWeb.Resources;

namespace Visionamos.Coopcentral.SitiosWeb.Controllers.LowAmountDeposit
{
    public class ProviderRuleController : Controller
    {
        // GET: ProviderRule
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            ClsProviderRule ClsProviderRules = new ClsProviderRule();
            var result = await ClsProviderRules.GetAll();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult(request));
            }
            return Json(result.Respuesta.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, TBL_TRULES_PROVIDER_UI model)
        {
            ClsProviderRule ClsProviderRules = new ClsProviderRule();
            var result = await ClsProviderRules.Create(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, "Ya se encuentra registrada esta regla.");
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, TBL_TRULES_PROVIDER_UI model)
        {
            ClsProviderRule ClsProviderRules = new ClsProviderRule();
            var result = await ClsProviderRules.Update(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, TBL_TRULES_PROVIDER_UI model)
        {
            ClsProviderRule ClsProviderRules = new ClsProviderRule();
            var result = await ClsProviderRules.Delete(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}