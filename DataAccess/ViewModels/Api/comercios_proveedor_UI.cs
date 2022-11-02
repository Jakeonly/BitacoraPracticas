using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.ViewModels.Integracion
{
    public class comercios_proveedor_UI
    {
        public int IdComercioProveedor { get; set; }
        public bool EntidadComercio { get; set; }
        public String Documento { get; set; }
        public int IdTipoDocumento { get; set; }
        [DisplayName("Entidad Recaudadora")]
        public string EntidadRecaudadora { get; set; }
        public string EntidadRecaudadoraTxt { get; set; }
        public string NombreComercio { get; set; }
        public string Email { get; set; }
        public string EmailNotificaciones { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public string NombreProductoEstandar { get; set; }

        [DisplayName("Comercio Externo")]
        public string IdComercioExterno { get; set; }
        [DisplayName("Comercio Visionamos")]
        public string IdComercioVisionamos { get; set; }
        public string CodigoComercioExterno { get; set; }
        public string UrlRetorno { get; set; }
        public string RutaGet { get; set; }
        [DisplayName("Código Prodcuto")]
        public string CodigoProducto { get; set; }
        public string EntidadProducto { get; set; }
        public string Estado { get; set; }
        public string ReferenciaEstandar { get; set; }

        [DisplayName("Tipo Documento")]
        public string TipoDocumento { get; set; }



        [DisplayName("Servicio Externo")]
        public string ServicioExterno { get; set; }

        [DisplayName("Código de Servicio (ACH)")]
        public string CodigoServicioExterno { get; set; }

    }
}
