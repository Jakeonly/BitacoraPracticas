using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visionamos.Coopcentral.DataAccess.Models.Ecgts;
using Visionamos.Coopcentral.DataAccess.ViewModels.Ecgts;

namespace Visionamos.Coopcentral.DataReads.Mappers
{
    public static class ClsConfigGmfMapper
    {
        #region Category
        public static gmf_category Map(this gmf_category_UI model) => new gmf_category
        {
           CODE = model.CODE,
           NAME = model.NAME,
           EXEM_TOP = Convert.ToInt32(model.EXEM_TOP),
           EXEM_PER = Convert.ToInt32(model.EXEM_PER),
        };

        public static gmf_category_UI Map(this gmf_category entity) => new gmf_category_UI
        {
            CODE = entity.CODE,
            NAME = entity.NAME,
            EXEM_TOP = Convert.ToInt32(entity.EXEM_TOP.ToString().Remove(entity.EXEM_TOP.ToString().Length - 2))-1,
            EXEM_PER = entity.EXEM_PER,
            EXEM_PER_UI = (entity.EXEM_PER)/100,
        };
        #endregion
        #region Commerce
        public static gmf_commerce Map(this gmf_commerce_UI model) => new gmf_commerce
        {
            SRC = model.SRC,
            CAT = model.CAT,
            ACT = Convert.ToInt32(model.ACT),
        };

        public static gmf_commerce_UI Map(this gmf_commerce entity) => new gmf_commerce_UI
        {
            SRC = entity.SRC,
            CAT = entity.CAT,
            ACT = entity.ACT.ToString(),
        };
        #endregion
    }
}
