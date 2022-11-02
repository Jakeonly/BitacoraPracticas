using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Source File:   Vista.cs                                             
    /// Description:   Clase contiene las consultas de Vista
    /// Author(es):    Daniel Andrés Gómez
    /// Date:          05/08/2022
    /// Version:       1
    /// Copyright(c), 2022 Visionamos
    /// </summary>
    public class Vista
    {
        #region Internals
        public OperationsModels<EnterpriseBackdropContext> dbContext;
        #endregion

        #region Constructor
        public Vista(OperationsModels<EnterpriseBackdropContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new OperationsModels<EnterpriseBackdropContext>();
            }
        }
        #endregion

        #region Methods
        public async Task<NotificacionRespuesta<List<VistasGrid_UI>>> GetAll(Guid guidSubmenu)
        {
            NotificacionRespuesta<List<VistasGrid_UI>> response = new NotificacionRespuesta<List<VistasGrid_UI>>();

            try
            {
                var context = dbContext.obtenerContexto().Set<TBL_TVIEW>();
                List<TBL_TVIEW> list = (List<TBL_TVIEW>)await dbContext.ObtenerTodosAsync<TBL_TVIEW>();
                var SubmenuList = context.Include(nameof(TBL_TSUBMENU)).ToList();
                var result = SubmenuList.Select(x => x.Map()).Where(x => x.SubmenuCode == guidSubmenu.ToString()).ToList();
                response.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<VistasGrid_UI>> Create(VistasGrid_UI model, Guid guidSubmenu)
        {
            NotificacionRespuesta<VistasGrid_UI> response = new NotificacionRespuesta<VistasGrid_UI>();

            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<TBL_TVIEW>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetAll(guidSubmenu);
                model = list.Respuesta.FirstOrDefault(x => x.Guid == record.VIW_GGID.ToString());
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<VistasGrid_UI>> Update(VistasGrid_UI model)
        {
            NotificacionRespuesta<VistasGrid_UI> response = new NotificacionRespuesta<VistasGrid_UI>();

            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<TBL_TVIEW>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                response.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public async Task<NotificacionRespuesta<bool>> Delete(VistasGrid_UI model)
        {
            NotificacionRespuesta<bool> response = new NotificacionRespuesta<bool>();

            try
            {
                dbContext.Eliminar<TBL_TVIEW>(model.Map());
                await dbContext.GuardarCambiosAsync();
                response.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                response.AsignarRespuesta(ex);
            }

            return response;
        }

        public IEnumerable<TBL_TVIEW> GetSubmenu(Guid guidSubmenu)
        {
            try
            {
                IEnumerable<TBL_TVIEW> submenuList = null;
                if (!guidSubmenu.Equals(0))
                {
                    submenuList = (from c in dbContext.Extraer<TBL_TVIEW>()
                                    where (c.SBM_GGID == guidSubmenu)
                                    select c).Include(nameof(TBL_TSUBMENU)).ToList();
                }
                return submenuList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TBL_TVIEW>> GetAllAsync()
        {
            try
            {
                IEnumerable<TBL_TVIEW> list = await dbContext.ObtenerTodosAsync<TBL_TVIEW>();
                var active = list.Where(x => x.VIW_BSTATE.Equals(true)).ToList();

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
