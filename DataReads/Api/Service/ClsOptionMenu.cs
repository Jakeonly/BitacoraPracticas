using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.Coopcentral.Common.Extensiones;
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
    public class ClsOptionMenu
    {
        /// <summary>
        /// variable con representa el contexto para la base ded atos integracion
        /// </summary>
        public ClsOperationsModels<IntegracionContext> dbContext;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context"></param>
        public ClsOptionMenu(ClsOperationsModels<IntegracionContext> context = null)
        {
            dbContext = context;
            if (dbContext == null)
            {
                dbContext = new ClsOperationsModels<IntegracionContext>();
            }
        }

        public async Task<ClsNotificacionRespuesta<List<EntitiesStateGrid_UI>>> GetAllEntities(string entity)
        {
            ClsNotificacionRespuesta<List<EntitiesStateGrid_UI>> respuesta = new ClsNotificacionRespuesta<List<EntitiesStateGrid_UI>>();
            try
            {
                int form = 58;
                var context = dbContext.obtenerContexto();
                ClsCommerce clsCommerce = new ClsCommerce();
                ClsOptionMenu clsForm = new ClsOptionMenu();
                List<commerce> list = await clsCommerce.ObtenerListaOrdenadaAsync();
                List<opciones_menu_aplicaciones> listOptionMenu = await clsForm.ObtenerTodosAsync();

                var response_entity = new List<EntitiesMetadata>();

                list.ForEach(commerce_count =>
                {
                    var Exists = listOptionMenu.FirstOrDefault(x => x.id_entidad == commerce_count.CODE && x.id_formularios_menu.ToString() == form.ToString());

                    if (Exists != null)
                    {
                        response_entity.Add(new EntitiesMetadata
                        {
                            Code = commerce_count.CODE,
                            Name = commerce_count.NAME,
                            Exists = true
                        });
                    }
                    else
                    {
                        response_entity.Add(new EntitiesMetadata
                        {
                            Code = commerce_count.CODE,
                            Name = commerce_count.NAME,
                            Exists = false
                        });
                    }
                });

                if (entity != "")
                {
                    var response = response_entity.Select(x => new EntitiesStateGrid_UI
                    {
                        Code = x.Code,
                        Name = x.Name,
                        Exists = x.Exists
                    }).Where(x => x.Code == entity).ToList();
                    respuesta.AsignarRespuesta(response);
                }
                else
                {
                    var response = response_entity.Select(x => new EntitiesStateGrid_UI
                    {
                        Code = x.Code,
                        Name = x.Name,
                        Exists = x.Exists
                    }).ToList();
                    respuesta.AsignarRespuesta(response);
                }

            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        public async Task<ClsNotificacionRespuesta<bool>> CreateOrDelete(string Code, bool ExistsBefore, bool Exists)
        {
            ClsNotificacionRespuesta<bool> respuesta = new ClsNotificacionRespuesta<bool>();

            try
            {
                ClsOptionMenu clsOptionM = new ClsOptionMenu();
                List<opciones_menu_aplicaciones> listOptionMenu = await clsOptionM.ObtenerTodosAsync();

                int id_formularios_menu = 58;
                string id_entidad = Code;
                string titulo = "RedCoop Pagos PSE";
                string descripcion = "Opción para realizar multiples pagos por PSE";
                string icono = null;

                if (ExistsBefore == Exists)
                {
                    if (ExistsBefore == true)
                    {
                        ExistsBefore = false;
                    }
                    else
                    {
                        if (ExistsBefore == false)
                        {
                            ExistsBefore = true;
                        }
                    }
                }

                var validate_data = listOptionMenu.FirstOrDefault(
                    x => x.id_formularios_menu == id_formularios_menu 
                    && x.id_entidad == id_entidad
                    && x.titulo == titulo 
                    && x.descripcion == descripcion 
                    && x.icono == icono
                    );


                if (validate_data == null)
                {
                    opciones_menu_aplicaciones model = new opciones_menu_aplicaciones
                    {
                        id_opciones_menu = null,
                        id_formularios_menu = id_formularios_menu,
                        id_entidad = id_entidad,
                        titulo = titulo,
                        descripcion = descripcion,
                        icono = icono
                    };

                    dbContext.Adicionar<opciones_menu_aplicaciones>(model);
                    dbContext.GuardarCambios();
                    respuesta.AsignarRespuesta(true);
                }
                else
                {
                    opciones_menu_aplicaciones model = new opciones_menu_aplicaciones
                    {
                        id_opciones_menu = validate_data.id_opciones_menu,
                        id_formularios_menu = id_formularios_menu,
                        id_entidad = id_entidad,
                        titulo = titulo,
                        descripcion = descripcion,
                        icono = icono
                    };

                    dbContext.Eliminar(model);
                    dbContext.GuardarCambios();
                    respuesta.AsignarRespuesta(true);
                }
            }
            catch (Exception ex)
            {
                respuesta.AsignarRespuesta(ex);
            }

            return respuesta;
        }

        public async Task<List<opciones_menu_aplicaciones>> ObtenerTodosAsync()
        {
            try
            {
                IEnumerable<opciones_menu_aplicaciones> lista = await dbContext.ObtenerTodosAsync<opciones_menu_aplicaciones>();
                return lista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
