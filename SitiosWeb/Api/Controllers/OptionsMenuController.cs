using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Coopcentral.DataAccess.ViewModels.Integracion;
using Visionamos.Coopcentral.DataReads.Integracion;
using Visionamos.Coopcentral.SitiosWeb.Resources;

namespace Visionamos.Coopcentral.SitiosWeb.Controllers.Integracion
{
    public class OptionsMenuController : Controller
    {
        // GET: OpcionesMenu
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, string entity)
        {
            ClsOptionMenu ClsOptionMenu = new ClsOptionMenu();
            var result = await ClsOptionMenu.GetAllEntities(entity);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request));
        }

        public async Task<ActionResult> CreateOrDelete([DataSourceRequest] DataSourceRequest request, string Code, bool ExistsBefore, bool Exists)
        {
            ClsOptionMenu ClsOptionMenu = new ClsOptionMenu();
            var result = await ClsOptionMenu.CreateOrDelete(Code, ExistsBefore, Exists);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}