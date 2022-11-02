using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop.Transversal;
using Visionamos.Operations.DataReads.EnterpriseBackdrop;
using Visionamos.SitiosWeb.Recursos;

namespace Visionamos.SitiosWeb.Controllers.EnterpriseBackdrop
{
    public class MenuEntidadesController : Controller
    {
        // GET: MenuEntidad
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, string entity, string profile)
        {
            MenuEntidad menuEntidad = new MenuEntidad();
            var resultado = await menuEntidad.GetAll(entity, profile);

            if (resultado.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            var final = await BuildDataView(resultado.Respuesta);

            return Json(final.ToTreeDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> setView([DataSourceRequest] DataSourceRequest request, string viewCode, bool isActiveBefore, bool isActive, string entity, string profile)
        {
            MenuEntidad clsMenuEntidad = new MenuEntidad();

            var result = await clsMenuEntidad.setView(viewCode, isActiveBefore, isActive, entity, profile);

            if (result.Codigo != HttpStatusCode.OK.ToString())
            {
                ModelState.AddModelError(string.Empty, WebUiResourceForms.SolicitudNoExitosa);
                return Json(ModelState.ToDataSourceResult());
            }

            return Json(new[] { result.Respuesta }.ToDataSourceResult(request));
        }

        private async Task<List<MenuTransversal_UI>> BuildDataView(List<EntityProfileMenuSubView> data)
        {
            List<MenuTransversal_UI> response = new List<MenuTransversal_UI>();
            int num = 1;
            foreach (var (item, index) in data.Select((s, index) => (s, index)))
            {
                response.Add(new MenuTransversal_UI
                {
                    Id = index,
                    ParentId = null,
                    Description = item.MenuName
                });

                //Arma Submenu
                foreach (var submenu in item.MenuSubmenuViews)
                {

                    if (item.MenuCode == submenu.Submenu.MEN_GGID.ToString())
                    {
                        int idSubMenu = 100 + index + num;
                        response.Add(new MenuTransversal_UI
                        {
                            Id = idSubMenu,
                            ParentId = index,
                            Description = submenu.Submenu.SBM_CNAME
                        });


                        if (submenu.Views.Count() > 0)
                        {
                            var dataView = submenu.Views;
                            foreach (var view in dataView)
                            {

                                if (submenu.Submenu.SBM_GGID.ToString() == view.SubmenuCode)
                                {
                                    int idView = 1000 + index;
                                    response.Add(new MenuTransversal_UI
                                    {
                                        Id = idView,
                                        ParentId = idSubMenu,
                                        Description = view.ViewName,
                                        ViewCode = view.ViewCode,
                                        IsActive = view.IsActive,
                                        Guid = view.Guid
                                    });
                                }
                            }
                        }
                        num++;
                    }
                }
            }
            return response;
        }

    }
}