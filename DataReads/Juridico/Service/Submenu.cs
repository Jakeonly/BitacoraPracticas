using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Operations.DataAccess.Contexts;
using Visionamos.Operations.DataAccess.Models;
using Visionamos.Operations.DataAccess.Models.EnterpriseBackdrop;
using Visionamos.Operations.DataAccess.ViewModels.EnterpriseBackdrop;
using Visionamos.Operations.DataReads.Mappers.EnterpriseBackdrop;
using Visionamos.Operations.DataReads.Utilidades;

namespace Visionamos.Operations.DataReads.EnterpriseBackdrop
{
    /// <summary>
    /// Source File:   Submenu.cs                                             
    /// Description:   Clase contiene las consultas de Submenu
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class Submenu
    {
        #region Internals
        public OperationsModels<EnterpriseBackdropContext> dbContext;
        #endregion

        #region Constructor
        public Submenu(OperationsModels<EnterpriseBackdropContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<EnterpriseBackdropContext>();
            }
        }
        #endregion

        #region Methods
        public async Task<NotificacionRespuesta<List<SubmenuGrid_UI>>> GetAll(Guid guidMenu)
        {
            NotificacionRespuesta<List<SubmenuGrid_UI>> response = new NotificacionRespuesta<List<SubmenuGrid_UI>>();

            try
            {
                var context = dbContext.obtenerContexto().Set<TBL_TSUBMENU>();
                List<TBL_TSUBMENU> list = (List<TBL_TSUBMENU>)await dbContext.ObtenerTodosAsync<TBL_TSUBMENU>();
                var menuList = context.Include(nameof(TBL_TMENU)).ToList();
                var result = menuList.Select(x => x.Map()).Where(x => x.MenuCode == guidMenu.ToString()).ToList();
                response.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<SubmenuGrid_UI>> Create(SubmenuGrid_UI model, Guid guidMenu)
        {
            NotificacionRespuesta<SubmenuGrid_UI> response = new NotificacionRespuesta<SubmenuGrid_UI>();

            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<TBL_TSUBMENU>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetAll(guidMenu);
                model = list.Respuesta.FirstOrDefault(x => x.Guid == record.SBM_GGID.ToString());
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<SubmenuGrid_UI>> Update(SubmenuGrid_UI model)
        {
            NotificacionRespuesta<SubmenuGrid_UI> response = new NotificacionRespuesta<SubmenuGrid_UI>();

            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TSUBMENU>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<bool>> Delete(SubmenuGrid_UI model)
        {
            NotificacionRespuesta<bool> response = new NotificacionRespuesta<bool>();

            try
            {
                dbContext.Eliminar<TBL_TSUBMENU>(model.Map());
                await dbContext.GuardarCambiosAsync();
                response.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<List<TBL_TSUBMENU>> GetAllAsync()
        {
            try
            {
                IEnumerable<TBL_TSUBMENU> list = await dbContext.ObtenerTodosAsync<TBL_TSUBMENU>();
                var active = list.Where(x => x.SBM_BSTATE.Equals(true)).ToList();

                return active;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}