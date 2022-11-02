using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Coopcentral.DataReads.ECGTS;
using Visionamos.Coopcentral.DataReads.Integracion;
using Visionamos.Coopcentral.SitiosWeb.Resources;

namespace Visionamos.Coopcentral.SitiosWeb.Controllers.ecgts
{
    public class GmfActionController : Controller
    {
        // GET: GmfAction
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            ClsConfigGmf ClsConfigGmf = new ClsConfigGmf();
            var result = await ClsConfigGmf.GetAction();

            return Json(result.ToDataSourceResult(request));
        }
    }
}