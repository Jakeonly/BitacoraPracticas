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
    public class TransfiyaDebitController : Controller
    {
        // GET: TransfiyaDebit
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, clients_accounts_limit_low_amount_UI model)
        {
            ClsContactLess ClsContactLess = new ClsContactLess();
            string decimales = "00";
            string max_amo = ((model.MAX_VALUE * Convert.ToInt32(model.MAX_OPE)) + 1).ToString();
            string max_value = (model.MAX_VALUE + 1).ToString();

            max_value = max_value + decimales;
            max_amo = max_amo + decimales;

            model.MAX_VALUE = Convert.ToInt32(max_value);
            model.MAX_AMO = Convert.ToInt32(max_amo);
            var result = await ClsContactLess.CreateDebito(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            ClsContactLess ClsContactLess = new ClsContactLess();
            var result = await ClsContactLess.GetDebito();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, clients_accounts_limit_low_amount_UI model)
        {
            ClsContactLess ClsContactLess = new ClsContactLess();
            string decimales = "00";
            string max_amo = ((model.MAX_VALUE * Convert.ToInt32(model.MAX_OPE)) + 1).ToString();
            string max_value = (model.MAX_VALUE + 1).ToString();

            max_value = max_value + decimales;
            max_amo = max_amo + decimales;

            model.MAX_VALUE = Convert.ToInt32(max_value);
            model.MAX_AMO = Convert.ToInt32(max_amo);
            var result = await ClsContactLess.UpdateDebito(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, clients_accounts_limit_low_amount_UI model)
        {
            ClsContactLess ClsContactLess = new ClsContactLess();
            var result = await ClsContactLess.DeleteDebito(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}