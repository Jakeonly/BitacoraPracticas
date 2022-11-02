using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visionamos.Coopcentral.DataAccess.Models.Integracion;
using Visionamos.Coopcentral.DataAccess.ViewModels.Integracion;

namespace Visionamos.Coopcentral.DataReads.Mappers
{
   public  class ClsComerciosProveedoresMapper
    {
        public static comercios_proveedor Map(comercios_proveedor_UI dto)
        {
            return new comercios_proveedor()
            {
                IdComercioProveedor = dto.IdComercioProveedor,
                EntidadComercio = dto.EntidadComercio,
                Documento = dto.Documento,
                IdTipoDocumento = dto.IdTipoDocumento,
                EntidadRecaudadora = dto.EntidadRecaudadora,
                NombreComercio = dto.NombreComercio,
                Email = dto.Email,
                EmailNotificaciones = dto.EmailNotificaciones,
                Telefono = dto.Telefono,
                Contacto = dto.Contacto,
                NombreProductoEstandar = dto.NombreProductoEstandar,
                ReferenciaEstandar = dto.ReferenciaEstandar,
                IdComercioExterno = dto.IdComercioExterno,
                IdComercioVisionamos = dto.IdComercioVisionamos,
                CodigoComercioExterno = dto.CodigoComercioExterno,
                UrlRetorno = dto.UrlRetorno,
                RutaGet = dto.RutaGet,
                CodigoProducto = dto.CodigoProducto,
                EntidadProducto = dto.EntidadProducto,
                Estado = dto.Estado,
                ServicioExterno = dto.ServicioExterno,
                CodigoServicioExterno = dto.CodigoServicioExterno
            };
        }

        public static comercios_proveedor_UI Map(comercios_proveedor entity)
        {
            return new comercios_proveedor_UI()
            {
                IdComercioProveedor = entity.IdComercioProveedor,
                EntidadComercio = entity.EntidadComercio,
                Documento = entity.Documento,
                IdTipoDocumento = entity.IdTipoDocumento,
                EntidadRecaudadora = entity.EntidadRecaudadora,
                NombreComercio = entity.NombreComercio,
                Email = entity.Email,
                EmailNotificaciones = entity.EmailNotificaciones,
                Telefono = entity.Telefono,
                Contacto = entity.Contacto,
                NombreProductoEstandar = entity.NombreProductoEstandar,
                ReferenciaEstandar = entity.ReferenciaEstandar,
                IdComercioExterno = entity.IdComercioExterno,
                IdComercioVisionamos = entity.IdComercioVisionamos,
                CodigoComercioExterno = entity.CodigoComercioExterno,
                UrlRetorno = entity.UrlRetorno,
                RutaGet = entity.RutaGet,
                CodigoProducto = entity.CodigoProducto,
                EntidadProducto = entity.EntidadProducto,
                Estado = entity.Estado,
                ServicioExterno = entity.ServicioExterno,
                CodigoServicioExterno = entity.CodigoServicioExterno
            };
        }
    }
}
