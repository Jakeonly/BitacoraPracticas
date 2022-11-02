using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Operations.DataReads.Homologation;
using Visionamos.SitiosWeb.Recursos;

namespace Visionamos.SitiosWeb.Controllers.Homologation
{
    public class AccountSubtypeController : Controller
    {
        // GET: SubtipoCuenta
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, string typeBusiness)
        {
            AccountSubtype accountSubtype = new AccountSubtype();
            var result = await accountSubtype.GetAll(typeBusiness);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ReadAll([DataSourceRequest] DataSourceRequest request)
        {
            AccountSubtype accountSubtype = new AccountSubtype();
            var result = await accountSubtype.GetAllSub();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}