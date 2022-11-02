using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Operations.DataAccess.ViewModels.Products;
using Visionamos.Operations.DataReads.Products;
using Visionamos.SitiosWeb.Recursos;
using Visionamos.Operations.Common.Logger;
using Visionamos.SitiosWeb.Extends.Controladores;
using System.Diagnostics;
using System;

namespace Visionamos.SitiosWeb.Controllers.Products
{
    public class BusinessRulesController : Controller
    {
        private static readonly ILogger _log = new Logger<ExtendController>();

        public static ILogger Log
        {
            [DebuggerStepThrough]
            get { return _log; }
        }
        // GET: BusinessRules
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, string entity)
        {
            try
            {
                BusinessRules businessRule = new BusinessRules();
                var result = await businessRule.GetAll(entity);

                if (result.Codigo != HttpStatusCode.OK.ToString())
                {
                    ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                    return Json(ModelState.ToDataSourceResult(request));
                }

                return Json(result.Respuesta.ToDataSourceResult(request));
            }
            catch (Exception error)
            {
                throw;
            }
        }

        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, BusinessRulesGrid_UI model, string entity)
        {
            try
            {
                BusinessRules businessRule = new BusinessRules();
                var result = await businessRule.Create(model, entity);

                if (result.Codigo != HttpStatusCode.OK.ToString())
                {
                    ModelState.AddModelError(string.Empty, result.Mensaje);
                    return Json(ModelState.ToDataSourceResult());
                }

                return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
            }
            catch (Exception error)
            {
                throw;
            }
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, BusinessRulesGrid_UI model)
        {
            BusinessRules businessRule = new BusinessRules();
            var result = await businessRule.Update(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, BusinessRulesGrid_UI model)
        {
            BusinessRules businessRule = new BusinessRules();
            var result = await businessRule.Eliminar(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}