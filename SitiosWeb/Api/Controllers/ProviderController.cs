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
    public class ProviderController : Controller
    {
        // GET: Provider
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            ClsProvider ClsProviders = new ClsProvider();
            var result = await ClsProviders.GetAll();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult(request));
            }
            return Json(result.Respuesta.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, TBL_TPROVIDER_UI model)
        {
            ClsProvider ClsProviders = new ClsProvider();
            var result = await ClsProviders.Create(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, TBL_TPROVIDER_UI model)
        {
            ClsProvider ClsProviders = new ClsProvider();
            var result = await ClsProviders.Update(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, TBL_TPROVIDER_UI model)
        {
            ClsProvider ClsProviders = new ClsProvider();
            var result = await ClsProviders.Delete(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}