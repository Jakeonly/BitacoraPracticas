using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Coopcentral.DataAccess.ViewModels.Ecgts;
using Visionamos.Coopcentral.DataReads.ECGTS;
using Visionamos.Coopcentral.DataReads.Integracion;
using Visionamos.Coopcentral.SitiosWeb.Resources;
namespace Visionamos.Coopcentral.SitiosWeb.Controllers.ecgts
{
    public class GmfCommerceController : Controller
    {
        // GET: GmfCommerce
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, gmf_commerce_UI model)
        {
            ClsConfigGmf ClsConfigGmf = new ClsConfigGmf();
            var result = await ClsConfigGmf.CreateCommerce(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            ClsConfigGmf ClsConfigGmf = new ClsConfigGmf();
            var result = await ClsConfigGmf.GetCommerce();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, gmf_commerce_UI model)
        {
            ClsConfigGmf ClsConfigGmf = new ClsConfigGmf();
            var result = await ClsConfigGmf.UpdateCommerce(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, gmf_commerce_UI model)
        {
            ClsConfigGmf ClsConfigGmf = new ClsConfigGmf();
            var result = await ClsConfigGmf.DeleteCommerce(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}