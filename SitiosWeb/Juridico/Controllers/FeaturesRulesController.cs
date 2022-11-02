using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Operations.Common.Logger;
using Visionamos.Operations.DataAccess.ViewModels.Products;
using Visionamos.Operations.DataReads.Products;
using Visionamos.SitiosWeb.Extends.Controladores;
using Visionamos.SitiosWeb.Recursos;

namespace Visionamos.SitiosWeb.Controllers.Products
{
    public class FeaturesRulesController : Controller
    {
        private static readonly ILogger _log = new Logger<ExtendController>();

        public static ILogger Log
        {
            [DebuggerStepThrough]
            get { return _log; }
        }

        // GET: FeaturesRules
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                FeaturesRules clsFeatureRules = new FeaturesRules();
                var result = await clsFeatureRules.GetAll();
                Log.Info($"Error al leer en features {result}");

                if (result.Codigo != HttpStatusCode.OK.ToString())
                {
                    ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                    return Json(ModelState.ToDataSourceResult(request));
                }
                return Json(result.Respuesta.ToDataSourceResult(request));
            }
            catch (Exception error)
            {
                Log.Error($"error en el metodo leer en features: {error.Message}");
                throw;
            }
        }

        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, FeaturesRulesGrid_UI model)
        {
            try
            {
                FeaturesRules clsFeatureRules = new FeaturesRules();
                var result = await clsFeatureRules.Create(model);
                Log.Info($"Error al guardar en features {result}");

                if (result.Codigo != HttpStatusCode.OK.ToString())
                {
                    ModelState.AddModelError(string.Empty, result.Mensaje);
                    return Json(ModelState.ToDataSourceResult());
                }
                return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
            }
            catch (Exception error)
            {
                Log.Error($"error en el metodo crear en features: {error.Message}");
                throw;
            }
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, FeaturesRulesGrid_UI model)
        {
            FeaturesRules clsFeatureRules = new FeaturesRules();
            var result = await clsFeatureRules.Update(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, FeaturesRulesGrid_UI model)
        {
            FeaturesRules clsFeatureRules = new FeaturesRules();
            var result = await clsFeatureRules.Delete(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }
            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }
    }
}