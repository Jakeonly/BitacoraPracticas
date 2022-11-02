using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visionamos.Coopcentral.DataAccess.ViewModels.Integracion
{
    public class TreeListRecaudador
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
    }
}
