using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Operations.DataAccess.Contexts;
using Visionamos.Operations.DataAccess.Models;
using Visionamos.Operations.DataAccess.Models.Ecgts;
using Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop;
using Visionamos.Operations.DataAccess.Models.EnterpriseSecurity;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop.Transversal;
using Visionamos.Operations.DataReads.ECGTS;
using Visionamos.Operations.DataReads.EnterpriseSecurity;
using Visionamos.Operations.DataReads.Utilidades;

namespace Visionamos.Operations.DataReads.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   MenuEntidad.cs                                             
    /// Description:   Clase contiene las consultas de MenuEntidad
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          01/09/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class MenuEntidad
    {
        #region Internals
        public OperationsModels<EnterpriseSecurityContext> dbContext;
        public OperationsModels<EnterpriseBackdropContext> Context;
        public OperationsModels<EcgtsContext> ContextEntity;
        #endregion

        #region Constructor
        public MenuEntidad(OperationsModels<EnterpriseSecurityContext> contextSecurity = null, OperationsModels<EnterpriseBackdropContext> contextBackdrop = null)
        {
            dbContext = contextSecurity;
            Context = contextBackdrop;
            if (dbContext == null && Context == null)
            {
                dbContext = new OperationsModels<EnterpriseSecurityContext>();
                Context = new OperationsModels<EnterpriseBackdropContext>();
            }
        }
        #endregion

        #region Methods
        public async Task<NotificacionRespuesta<List<EntityProfileMenuSubView>>> GetAll(string entity, string profile)
        {
            NotificacionRespuesta<List<EntityProfileMenuSubView>> respuesta = new NotificacionRespuesta<List<EntityProfileMenuSubView>>();
            try
            {
                Commerce comercios = new Commerce();
                PerfilesEntidad perfiles = new PerfilesEntidad();
                Vista vista = new Vista();
                Submenu submenu = new Submenu();
                MenuBackdrop menu = new MenuBackdrop();
                VistaEntidad vistaEntity = new VistaEntidad();

                List<TBL_TPROFILE> listaPerfiles = await perfiles.GetAllAsync();
                List<TBL_TVIEW> listaVista = await vista.GetAllAsync();
                List<TBL_TSUBMENU> listaSubmenu = await submenu.GetAllAsync();
                List<TBL_TMENU> listaMenu = await menu.GetAllAsync();
                List<TBL_TVIEW_ENTITY> listaVistaEntidad = await vistaEntity.ObtenerTodasAsync();
                List<commerce> listaComercios = await comercios.ObtenerListaOrdenadaAsync();

                var listParent = (from e in listaComercios
                                  from p in listaPerfiles
                                  from m in listaMenu
                                  select new
                                  {
                                      e,
                                      p,
                                      m
                                  }).ToList();

                var Submenu_View = (from view in listaVista
                                    join viewSub in listaSubmenu on view.SBM_GGID equals viewSub.SBM_GGID
                                    select new
                                    {
                                        GUID_SUBMENU = viewSub.SBM_GGID,
                                        NAME_SUBMENU = viewSub.SBM_CNAME,
                                        STATE_SUBMENU = viewSub.SBM_BSTATE,
                                        GUID_VIEW = view.VIW_GGID,
                                        NAME_VIEW = view.VIW_CNAME,
                                    }).ToList();

                var View_Entity_State = (from view in listaVista
                                         join viewSub in listaSubmenu on view.SBM_GGID equals viewSub.SBM_GGID
                                         join viewEntity in listaVistaEntidad on view.VIW_GGID equals viewEntity.VIW_GGID
                                         select new
                                         {
                                             GUID_VIEW = viewEntity.VIW_GGID,
                                             NAME_VIEW = view.VIW_CNAME,
                                             IS_ACTIVE = viewEntity.VEN_BSTATE,
                                             ENTITY_CODE = viewEntity.VEN_ENTITY_CODE,
                                             PROFILE_GUID = viewEntity.PRF_GGID,
                                             VIEW_ENTITY_GUID = viewEntity.VEN_GGID
                                         }).Where(x => x.ENTITY_CODE == entity && x.PROFILE_GUID.ToString() == profile).ToList();


                var vistasTreeList = new List<SubmenuViewMetadata>();

                listaMenu.ForEach(menus =>
                {
                    Submenu_View.ForEach(viewSubmenus =>
                    {
                        {
                            var viewEntity = View_Entity_State.FirstOrDefault(x => x.GUID_VIEW == viewSubmenus.GUID_VIEW);

                            if (viewEntity == null)
                            {
                                vistasTreeList.Add(new SubmenuViewMetadata
                                {
                                    MenuCode = menus.MEN_GGID.ToString(),
                                    SubmenuCode = viewSubmenus.GUID_SUBMENU.ToString(),
                                    ViewCode = viewSubmenus.GUID_VIEW.ToString(),
                                    ViewName = viewSubmenus.NAME_VIEW,
                                    IsActive = false,
                                    Guid = null
                                });
                            }
                            else
                            {
                                vistasTreeList.Add(new SubmenuViewMetadata
                                {
                                    MenuCode = menus.MEN_GGID.ToString(),
                                    SubmenuCode = viewSubmenus.GUID_SUBMENU.ToString(),
                                    ViewCode = viewSubmenus.GUID_VIEW.ToString(),
                                    ViewName = viewSubmenus.NAME_VIEW,
                                    IsActive = viewEntity.IS_ACTIVE,
                                    Guid = viewEntity.VIEW_ENTITY_GUID.ToString()
                                });
                            }
                        }
                    });
                });

                var listViewSubmenu = listParent.Select(x => new
                {
                    EntityCode = x.e.CODE,
                    EntityName = x.e.NAME,
                    ProfileCode = x.p.PRF_GGID,
                    ProfileName = x.p.PRF_CNAME,
                    MenuName = x.m.MEN_CNAME,
                    MenuState = x.m.MEN_BSTATE,
                    MenuCode = x.m.MEN_GGID,
                    MenuSubmenuViews = listaSubmenu.Select(sbm => new
                    {
                        Submenu = sbm,
                        Views = vistasTreeList.Where(c => c.MenuCode == x.m.MEN_GGID.ToString() && c.SubmenuCode == sbm.SBM_GGID.ToString()).Select(vw => new
                        {
                            ViewCode = vw.ViewCode,
                            ViewName = vw.ViewName,
                            SubmenuCode = vw.SubmenuCode,
                            IsActive = vw.IsActive,
                            Guid = vw.Guid
                        })
                    })
                }).ToList();

                var responseMenu = listViewSubmenu.Where(x => x.EntityCode == entity && x.ProfileCode.ToString() == profile).ToList();

                var EntityProfileMenu = JsonConvert.SerializeObject(responseMenu).ToString();
                var response = JsonConvert.DeserializeObject<List<EntityProfileMenuSubView>>(EntityProfileMenu);

                respuesta.AsignarRespuesta(response);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        public async Task<NotificacionRespuesta<bool>> setView(string viewCode, bool isActiveBefore, bool isActive, string entity, string profile)
        {
            NotificacionRespuesta<bool> respuesta = new NotificacionRespuesta<bool>();

            try
            {
                VistaEntidad vistaEntity = new VistaEntidad();
                List<TBL_TVIEW_ENTITY> listaVistaEntidad = await vistaEntity.ObtenerTodasAsync();

                if (isActiveBefore == isActive)
                {
                    if (isActiveBefore == true)
                    {
                        isActiveBefore = false;
                    }
                    else
                    {
                        if (isActiveBefore == false)
                        {
                            isActiveBefore = true;
                        }
                    }
                }

                var Exists = listaVistaEntidad.FirstOrDefault(x => x.VEN_ENTITY_CODE == entity
                && x.VEN_BSTATE == isActiveBefore
                && x.VIW_GGID.ToString() == viewCode
                && x.PRF_GGID.ToString() == profile
                );


                if (Exists == null)
                {
                    TBL_TVIEW_ENTITY model = new TBL_TVIEW_ENTITY
                    {
                        VEN_GGID = Guid.NewGuid(),
                        VEN_ENTITY_CODE = entity,
                        VEN_BSTATE = isActive,
                        VIW_GGID = Guid.Parse(viewCode),
                        PRF_GGID = Guid.Parse(profile)
                    };

                    Context.Adicionar<TBL_TVIEW_ENTITY>(model);
                    Context.GuardarCambios();
                    respuesta.AsignarRespuesta(true);
                }
                else
                {
                    TBL_TVIEW_ENTITY model = new TBL_TVIEW_ENTITY
                    {
                        VEN_GGID = Exists.VEN_GGID,
                        VEN_ENTITY_CODE = entity,
                        VEN_BSTATE = isActive,
                        VIW_GGID = Guid.Parse(viewCode),
                        PRF_GGID = Guid.Parse(profile)
                    };
                    Context.Actualizar<TBL_TVIEW_ENTITY>(model);
                    Context.GuardarCambios();

                    respuesta.AsignarRespuesta(true);
                }
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        #endregion
    }
}
