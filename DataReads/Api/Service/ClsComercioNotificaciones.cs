using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visionamos.Coopcentral.DataAccess.Contexts;
using Visionamos.Coopcentral.DataAccess.Models;
using Visionamos.Coopcentral.DataAccess.Models.Ecgts;
using Visionamos.Coopcentral.DataAccess.Models.Integracion;
using Visionamos.Coopcentral.DataAccess.ViewModels.Integracion;
using Visionamos.Coopcentral.DataReads.ECGTS;
using Visionamos.Coopcentral.DataReads.Mappers;
using Visionamos.Coopcentral.DataReads.Utilidades;
 
namespace Visionamos.Coopcentral.DataReads.Integracion
{
    public class ClsComercioNotificaciones
    {
        /// <summary>
        /// variable con representa el contexto para la base ded atos integracion
        /// </summary>
        public ClsOperationsModels<IntegracionContext> dbContext;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context"></param>
        public ClsComercioNotificaciones(ClsOperationsModels<IntegracionContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new ClsOperationsModels<IntegracionContext>();
            }
        }

        #region Metodos GET
        public async Task<ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_emailGrid_UI>>> GetEmail()
        {
            ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_emailGrid_UI>> respuesta = new ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_emailGrid_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<comercios_proveedor_notificaciones_email>();
                ClsComercioProveedor clsCommercio = new ClsComercioProveedor();
                List<comercios_proveedor> comercios = await clsCommercio.ObtenerTodosAsync();
                var lista = context.ToList();
                var result = lista.Join(comercios,
                    lr => lr.IdComercioProveedor,
                    com => com.IdComercioProveedor,
                   (lr, c) => new comercios_proveedor_notificaciones_emailGrid_UI
                   {
                       Id = lr.Id.ToString(),
                       IdComercioProveedor = lr.IdComercioProveedor.ToString(),
                       NombreComercio = c.NombreComercio,
                       NotificarEmailAgregador = lr.NotificarEmailAgregador,
                       NotificarEmailRecaudador = lr.NotificarEmailRecaudador,
                       NotificarEmailComercio = lr.NotificarEmailComercio,
                   }).ToList();

                respuesta.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        public async Task<ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_agregadorGrid_UI>>> GetAgregador()
        {
            ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_agregadorGrid_UI>> respuesta = new ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_agregadorGrid_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<comercios_proveedor_notificaciones_agregador>();
                ClsMaestroNotificaciones clsMaestro = new ClsMaestroNotificaciones();
                List<comercios_proveedor_maestro_notificaciones> maestros = await clsMaestro.ObtenerTodosAsync();
                var lista = context.ToList();
                var result = lista.Join(maestros,
                    lr => lr.IdComercioProveedorMaestroEmail,
                    mast => mast.Id,
                   (lr, c) => new comercios_proveedor_notificaciones_agregadorGrid_UI
                   {
                       Id = lr.Id.ToString(),
                       Nombre = lr.Nombre,
                       EmailNotificaciones = lr.EmailNotificaciones,
                       IdComercioProveedorMaestroEmail = lr.IdComercioProveedorMaestroEmail.ToString(),
                   }).ToList();

                respuesta.AsignarRespuesta(result);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        public async Task<ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_recaudadorGrid_UI>>> GetRecaudador()
        {
            ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_recaudadorGrid_UI>> respuesta = new ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_recaudadorGrid_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<comercios_proveedor_notificaciones_recaudador>();
                ClsMaestroNotificaciones clsMaestro = new ClsMaestroNotificaciones();
                ClsComercioRecaudador clsRecaudador = new ClsComercioRecaudador();
                ClsCommerce clsCommerce = new ClsCommerce();
                List<comercios_proveedor_maestro_notificaciones> maestros = await clsMaestro.ObtenerTodosAsync();
                List<commerce> comercios = await clsCommerce.ObtenerTodosAsync();
                var lista = context.ToList();

                var listParent = lista
                    .Join(maestros, l => l.IdComercioProveedorMaestroEmail, maest => maest.Id, (l, maest) => new { l, maest })
                    .Join(comercios, lm => lm.l.CodigoRecaudador, enti => enti.CODE, (le, enti)
                    => new comercios_proveedor_notificaciones_recaudadorGrid_UI
                    {
                        Id = le.l.Id.ToString(),
                        CodigoRecaudador = le.l.CodigoRecaudador,
                        NombreRecaudador = enti.NAME,
                        Nombre = le.l.Nombre,
                        EmailNotificaciones = le.l.EmailNotificaciones,
                        IdComercioProveedorMaestroEmail = le.l.IdComercioProveedorMaestroEmail.ToString(),
                    }
                     ).ToList();

                respuesta.AsignarRespuesta(listParent);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        public async Task<ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_comercioGrid_UI>>> GetComercio()
        {
            ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_comercioGrid_UI>> respuesta = new ClsNotificacionRespuesta<List<comercios_proveedor_notificaciones_comercioGrid_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<comercios_proveedor_notificaciones_comercio>();
                ClsMaestroNotificaciones clsMaestro = new ClsMaestroNotificaciones();
                ClsComercioProveedor clsComercio = new ClsComercioProveedor();
                List<comercios_proveedor_maestro_notificaciones> maestros = await clsMaestro.ObtenerTodosAsync();
                List<comercios_proveedor> comercios = await clsComercio.ObtenerTodosAsync();
                var lista = context.ToList();
                var listParent = lista
                     .Join(maestros, l => l.IdComercioProveedorMaestroEmail, maest => maest.Id, (l, maest) => new { l, maest })
                     .Join(comercios, lm => lm.l.IdComercioProveedor, com => com.IdComercioProveedor, (le, com)
                     => new comercios_proveedor_notificaciones_comercioGrid_UI
                     {
                         Id = le.l.Id.ToString(),
                         IdComercioProveedor = le.l.IdComercioProveedor,
                         ComercioNombre = com.NombreComercio,
                         Nombre = le.l.Nombre,
                         EmailNotificaciones = le.l.EmailNotificaciones,
                         IdComercioProveedorMaestroEmail = le.l.IdComercioProveedorMaestroEmail.ToString(),
                     }
                      ).ToList();

                respuesta.AsignarRespuesta(listParent);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        
        public async Task<ClsNotificacionRespuesta<List<comercios_proveedor_UI>>> GetComercioProveedor()
        {
            ClsNotificacionRespuesta<List<comercios_proveedor_UI>> respuesta = new ClsNotificacionRespuesta<List<comercios_proveedor_UI>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<comercios_proveedor>();
                ClsCommerce clsComercio = new ClsCommerce();
                List<commerce> comercios = await clsComercio.ObtenerTodosAsync();
                var lista = context.ToList();
                var listParent = lista
                     .Join(comercios, l => l.EntidadRecaudadora, com => com.CODE, (l, com)
                     => new comercios_proveedor_UI
                     {
                         IdComercioProveedor = l.IdComercioProveedor,
                         EntidadComercio = l.EntidadComercio,
                         Documento = l.Documento,
                         IdTipoDocumento = l.IdTipoDocumento,
                         EntidadRecaudadora = l.EntidadRecaudadora,
                         EntidadRecaudadoraTxt = com.NAME,
                         NombreComercio = l.NombreComercio,
                         Email = l.Email,
                         EmailNotificaciones = l.EmailNotificaciones,
                         Telefono = l.Telefono,
                         Contacto = l.Contacto,
                         NombreProductoEstandar = l.NombreProductoEstandar,
                         ReferenciaEstandar = l.ReferenciaEstandar,
                         IdComercioExterno = l.IdComercioExterno,
                         IdComercioVisionamos = l.IdComercioVisionamos,
                         CodigoComercioExterno = l.CodigoComercioExterno,
                         UrlRetorno = l.UrlRetorno,
                         RutaGet = l.RutaGet,
                         CodigoProducto = l.CodigoProducto,
                         EntidadProducto = l.EntidadProducto,
                         Estado = l.Estado,
                         ServicioExterno = l.ServicioExterno,
                         CodigoServicioExterno = l.CodigoServicioExterno
                     }
                      ).ToList();

                respuesta.AsignarRespuesta(listParent);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        public async Task<ClsNotificacionRespuesta<List<comercios_proveedor>>> GetComercioProveedorComboBox()
        {
            ClsNotificacionRespuesta<List<comercios_proveedor>> respuesta = new ClsNotificacionRespuesta<List<comercios_proveedor>>();
            try
            {
                var context = dbContext.obtenerContexto().Set<comercios_proveedor>();
                ClsCommerce clsComercio = new ClsCommerce();
                ClsComercioNotificaciones clsProveedores = new ClsComercioNotificaciones();
                List<commerce> comercios = await clsComercio.ObtenerTodosAsync();
                List<comercios_proveedor_notificaciones_email> listEmail = await clsProveedores.ObtenerTodosEmailAsync();
                var dataset = context.ToList();

                var ListaIdPrincipal = dataset.Select(x => x.IdComercioProveedor).ToList();
                var ListaIdSecundaria = listEmail.Select(x => x.IdComercioProveedor).ToList();

                var excluded = ListaIdPrincipal.Except(ListaIdSecundaria).ToList();

                var myProducts = from p in dataset
                                 where excluded.Contains(p.IdComercioProveedor)
                                 select p;

                respuesta.AsignarRespuesta(myProducts.ToList());
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        #endregion
        #region Metodos CREATE
        public async Task<ClsNotificacionRespuesta<comercios_proveedor_notificaciones_agregadorGrid_UI>> CreateAgregador(comercios_proveedor_notificaciones_agregadorGrid_UI model)
        {
            ClsNotificacionRespuesta<comercios_proveedor_notificaciones_agregadorGrid_UI> respuesta = new ClsNotificacionRespuesta<comercios_proveedor_notificaciones_agregadorGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<comercios_proveedor_notificaciones_agregador>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetAgregador();
                model = list.Respuesta.FirstOrDefault(x => x.Id == record.Id.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        
        public async Task<ClsNotificacionRespuesta<comercios_proveedor_notificaciones_comercioGrid_UI>> CreateComercio(comercios_proveedor_notificaciones_comercioGrid_UI model, int CodigoComercio)
        {
            ClsNotificacionRespuesta<comercios_proveedor_notificaciones_comercioGrid_UI> respuesta = new ClsNotificacionRespuesta<comercios_proveedor_notificaciones_comercioGrid_UI>();
            try
            {
                model.IdComercioProveedor = CodigoComercio;
                var context = dbContext.obtenerContexto();
                var record = context.Set<comercios_proveedor_notificaciones_comercio>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetComercio();
                model = list.Respuesta.FirstOrDefault(x => x.Id == record.Id.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }

        public async Task<ClsNotificacionRespuesta<comercios_proveedor_notificaciones_recaudadorGrid_UI>> CreateRecaudador(comercios_proveedor_notificaciones_recaudadorGrid_UI model, string CodigoEntidad)
        {
            ClsNotificacionRespuesta<comercios_proveedor_notificaciones_recaudadorGrid_UI> respuesta = new ClsNotificacionRespuesta<comercios_proveedor_notificaciones_recaudadorGrid_UI>();
            try
            {
                model.CodigoRecaudador = CodigoEntidad;
                var context = dbContext.obtenerContexto();
                var record = context.Set<comercios_proveedor_notificaciones_recaudador>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetRecaudador();
                model = list.Respuesta.FirstOrDefault(x => x.Id == record.Id.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }

        public async Task<ClsNotificacionRespuesta<comercios_proveedor_notificaciones_emailGrid_UI>> CreateEMail(comercios_proveedor_notificaciones_emailGrid_UI model)
        {
            ClsNotificacionRespuesta<comercios_proveedor_notificaciones_emailGrid_UI> respuesta = new ClsNotificacionRespuesta<comercios_proveedor_notificaciones_emailGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                var record = context.Set<comercios_proveedor_notificaciones_email>().Add(model.Map());
                await context.SaveChangesAsync();
                var list = await GetEmail();
                model = list.Respuesta.FirstOrDefault(x => x.Id == record.Id.ToString());
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        #endregion
        #region Metodos UPDATE
        public async Task<ClsNotificacionRespuesta<comercios_proveedor_notificaciones_agregadorGrid_UI>> UpdateAgregador(comercios_proveedor_notificaciones_agregadorGrid_UI model)
        {
            ClsNotificacionRespuesta<comercios_proveedor_notificaciones_agregadorGrid_UI> respuesta = new ClsNotificacionRespuesta<comercios_proveedor_notificaciones_agregadorGrid_UI>();
            try
            {
                var context = dbContext.obtenerContexto();
                context.Set<comercios_proveedor_notificaciones_agregador>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<comercios_proveedor_notificaciones_comercioGrid_UI>> UpdateComercio(comercios_proveedor_notificaciones_comercioGrid_UI model, int CodigoComercio)
        {
            ClsNotificacionRespuesta<comercios_proveedor_notificaciones_comercioGrid_UI> respuesta = new ClsNotificacionRespuesta<comercios_proveedor_notificaciones_comercioGrid_UI>();
            try
            {
                model.IdComercioProveedor = CodigoComercio;
                var context = dbContext.obtenerContexto();
                context.Set<comercios_proveedor_notificaciones_comercio>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<comercios_proveedor_notificaciones_recaudadorGrid_UI>> UpdateRecaudador(comercios_proveedor_notificaciones_recaudadorGrid_UI model, string CodigoEntidad)
        {
            ClsNotificacionRespuesta<comercios_proveedor_notificaciones_recaudadorGrid_UI> respuesta = new ClsNotificacionRespuesta<comercios_proveedor_notificaciones_recaudadorGrid_UI>();
            try
            {
                model.CodigoRecaudador = CodigoEntidad;
                var context = dbContext.obtenerContexto();
                context.Set<comercios_proveedor_notificaciones_recaudador>().AddOrUpdate(model.Map());
                await context.SaveChangesAsync();
                respuesta.AsignarRespuesta(model);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        #endregion
        #region Metodos DELETE
        public async Task<ClsNotificacionRespuesta<bool>> DeleteAgregador(comercios_proveedor_notificaciones_agregadorGrid_UI model)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<comercios_proveedor_notificaciones_agregador>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<bool>> DeleteComercio(comercios_proveedor_notificaciones_comercioGrid_UI model, int CodigoComercio)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                model.IdComercioProveedor = CodigoComercio;
                dbContext.Eliminar<comercios_proveedor_notificaciones_comercio>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        public async Task<ClsNotificacionRespuesta<bool>> DeleteRecaudador(comercios_proveedor_notificaciones_recaudadorGrid_UI model, string CodigoEntidad)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                model.CodigoRecaudador = CodigoEntidad;
                dbContext.Eliminar<comercios_proveedor_notificaciones_recaudador>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }

        public async Task<ClsNotificacionRespuesta<bool>> DeleteEmail(comercios_proveedor_notificaciones_emailGrid_UI model)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                dbContext.Eliminar<comercios_proveedor_notificaciones_email>(model.Map());
                await dbContext.GuardarCambiosAsync();
                respuesta.AsignarRespuesta(true);
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }
            return respuesta;
        }
        #endregion
        #region Metods SET EMAIL
        #region AGREGADOR
        public async Task<ClsNotificacionRespuesta<bool>> UpdateEmailAgregador(int IdProv, bool OldCheck, bool NewCheck)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                ClsComercioNotificaciones clsComercioEmail = new ClsComercioNotificaciones();
                List<comercios_proveedor_notificaciones_email> listEmail = await clsComercioEmail.ObtenerTodosEmailAsync();

                if (OldCheck == NewCheck)
                {
                    if (OldCheck == true)
                    {
                        OldCheck = false;
                    }
                    else
                    {
                        if (OldCheck == false)
                        {
                            OldCheck = true;
                        }
                    }
                }

                var validate_data = listEmail.FirstOrDefault(x => x.IdComercioProveedor == IdProv);

                comercios_proveedor_notificaciones_email model = new comercios_proveedor_notificaciones_email
                {
                    Id = validate_data.Id,
                    IdComercioProveedor = IdProv,
                    NotificarEmailAgregador = NewCheck,
                    NotificarEmailComercio = validate_data.NotificarEmailComercio,
                    NotificarEmailRecaudador = validate_data.NotificarEmailRecaudador
                };

                dbContext.Actualizar(model);
                dbContext.GuardarCambios();
                respuesta.AsignarRespuesta(true);

            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        #endregion
        #region RECAUDADOR
        public async Task<ClsNotificacionRespuesta<bool>> UpdateEmailRecaudador(int IdProv, bool OldCheck, bool NewCheck)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                ClsComercioNotificaciones clsComercioEmail = new ClsComercioNotificaciones();
                List<comercios_proveedor_notificaciones_email> listEmail = await clsComercioEmail.ObtenerTodosEmailAsync();

                if (OldCheck == NewCheck)
                {
                    if (OldCheck == true)
                    {
                        OldCheck = false;
                    }
                    else
                    {
                        if (OldCheck == false)
                        {
                            OldCheck = true;
                        }
                    }
                }

                var validate_data = listEmail.FirstOrDefault(x => x.IdComercioProveedor == IdProv);

                comercios_proveedor_notificaciones_email model = new comercios_proveedor_notificaciones_email
                {
                    Id = validate_data.Id,
                    IdComercioProveedor = IdProv,
                    NotificarEmailAgregador = validate_data.NotificarEmailAgregador,
                    NotificarEmailComercio = validate_data.NotificarEmailComercio,
                    NotificarEmailRecaudador = NewCheck
                };

                dbContext.Actualizar(model);
                dbContext.GuardarCambios();
                respuesta.AsignarRespuesta(true);

            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        #endregion
        #region COMERCIO
        public async Task<ClsNotificacionRespuesta<bool>> UpdateEmailComercio(int IdProv, bool OldCheck, bool NewCheck)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();
            try
            {
                ClsComercioNotificaciones clsComercioEmail = new ClsComercioNotificaciones();
                List<comercios_proveedor_notificaciones_email> listEmail = await clsComercioEmail.ObtenerTodosEmailAsync();

                if (OldCheck == NewCheck)
                {
                    if (OldCheck == true)
                    {
                        OldCheck = false;
                    }
                    else
                    {
                        if (OldCheck == false)
                        {
                            OldCheck = true;
                        }
                    }
                }

                var validate_data = listEmail.FirstOrDefault(x => x.IdComercioProveedor == IdProv);

                comercios_proveedor_notificaciones_email model = new comercios_proveedor_notificaciones_email
                {
                    Id = validate_data.Id,
                    IdComercioProveedor = IdProv,
                    NotificarEmailAgregador = validate_data.NotificarEmailAgregador,
                    NotificarEmailComercio = NewCheck,
                    NotificarEmailRecaudador = validate_data.NotificarEmailRecaudador
                };

                dbContext.Actualizar(model);
                dbContext.GuardarCambios();
                respuesta.AsignarRespuesta(true);

            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }
        #endregion
        #endregion
        #region Metodo ObtenerAsync
        public async Task<List<comercios_proveedor_notificaciones_email>> ObtenerTodosEmailAsync()
        {
            try
            {
                IEnumerable<comercios_proveedor_notificaciones_email> lista = await dbContext.ObtenerTodosAsync<comercios_proveedor_notificaciones_email>();
                return lista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<comercios_proveedor>> ObtenerTodosProveedorAsync()
        {
            try
            {
                IEnumerable<comercios_proveedor> lista = await dbContext.ObtenerTodosAsync<comercios_proveedor>();
                return lista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }

}
