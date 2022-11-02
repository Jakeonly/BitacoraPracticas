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
    /// <summary>
    /// Source File:   ReglaPorEntidadController.cs                                             
    /// Description:   Controller de ReglaPorEntidadController
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          25/07/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class ReglaPreguntaEntidadController : Controller
    {
        // GET: ReglaPorEntidad
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            ReglaPreguntaEntidad entityRules = new ReglaPreguntaEntidad();
            var result = await entityRules.GetAll();

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request,
            ReglaPreguntaEntidadGrid_UI model)
        {
            ReglaPreguntaEntidad entityRules = new ReglaPreguntaEntidad();
            var result = await entityRules.Create(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, result.Mensaje);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request,
            ReglaPreguntaEntidadGrid_UI model)
        {
            ReglaPreguntaEntidad entityRules = new ReglaPreguntaEntidad();
            var result = await entityRules.Update(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request,
            ReglaPreguntaEntidadGrid_UI model)
        {
            ReglaPreguntaEntidad entityRules = new ReglaPreguntaEntidad();
            var result = await entityRules.Delete(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, result.Mensaje);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}