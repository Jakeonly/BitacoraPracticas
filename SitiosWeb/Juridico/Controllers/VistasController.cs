using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop;
using Visionamos.Operations.DataReads.EnterpriseBackdrop;
using Visionamos.SitiosWeb.Recursos;

namespace Visionamos.SitiosWeb.Controllers.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   VistasController.cs                                             
    /// Description:   Controller de VistasController
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class VistasController : Controller
    {
        // GET: Vistas
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, Guid guidSubmenu)
        {
            Vista view = new Vista();
            var result = await view.GetAll(guidSubmenu);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(result.Respuesta.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, VistasGrid_UI model, Guid guidSubmenu)
        {
            Vista view = new Vista();
            var result = await view.Create(model, guidSubmenu);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, VistasGrid_UI model)
        {
            Vista view = new Vista();
            var result = await view.Update(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, VistasGrid_UI model)
        {
            Vista view = new Vista();
            var result = await view.Delete(model);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        public ActionResult ReadForSubmenu([DataSourceRequest] DataSourceRequest request, Guid guidSubmenu)
        {
            try
            {
                IEnumerable<TBL_TVIEW> viewList = new Vista().GetSubmenu(guidSubmenu);
                DataSourceResult viewLst = viewList.ToDataSourceResult(request);
                return Content(JsonConvert.SerializeObject(viewLst), contentType: "application/json");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}