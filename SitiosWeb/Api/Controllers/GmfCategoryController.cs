using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Coopcentral.DataAccess.ViewModels.Ecgts;
using Visionamos.Coopcentral.DataReads.ECGTS;
using Visionamos.Coopcentral.DataReads.Integracion;
using Visionamos.Coopcentral.SitiosWeb.Resources;

namespace Visionamos.Coopcentral.SitiosWeb.Controllers.ecgts
{
    public class GmfCategoryController : Controller
    {
        // GET: GmfCategory
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, gmf_category_UI model)
        {
            ClsConfigGmf ClsConfigGmf = new ClsConfigGmf();
            string decimales = "00";
            string exem_top = (model.EXEM_TOP+1).ToString();

            exem_top = exem_top + decimales;

            model.EXEM_TOP = Convert.ToInt32(exem_top);
            var result = await ClsConfigGmf.CreateCategory(model);

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
            var result = await ClsConfigGmf.GetCategory();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, gmf_category_UI model)
        {
            ClsConfigGmf ClsConfigGmf = new ClsConfigGmf();
            string decimales = "00";
            string exem_top = (model.EXEM_TOP+1).ToString();

            exem_top = exem_top + decimales;

            model.EXEM_TOP = Convert.ToInt32(exem_top);
            var result = await ClsConfigGmf.UpdateCategory(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, gmf_category_UI model)
        {
            ClsConfigGmf ClsConfigGmf = new ClsConfigGmf();
            var result = await ClsConfigGmf.DeleteCategory(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}