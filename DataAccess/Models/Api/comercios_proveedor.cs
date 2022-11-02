using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.Models.Integracion
{
    public class comercios_proveedor
    {
        [Key]
        public int IdComercioProveedor { get; set; }
        public bool EntidadComercio { get; set; }
        public String Documento { get; set; }
        public int IdTipoDocumento { get; set; }
        public string EntidadRecaudadora { get; set; }
        public string NombreComercio { get; set; }
        public string Email { get; set; }
        public string EmailNotificaciones { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public string NombreProductoEstandar { get; set; }
        public string ReferenciaEstandar { get; set; }
        public string IdComercioExterno { get; set; }
        public string IdComercioVisionamos { get; set; }
        public string CodigoComercioExterno { get; set; }
        public string UrlRetorno { get; set; }
        public string RutaGet { get; set; }
        public string CodigoProducto { get; set; }
        public string EntidadProducto { get; set; }
        public string Estado { get; set; }


        public string ServicioExterno { get; set; }
        public string CodigoServicioExterno { get; set; }
    }
}
