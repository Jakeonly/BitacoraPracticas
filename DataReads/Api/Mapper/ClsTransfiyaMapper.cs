using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visionamos.Coopcentral.DataAccess.Models.Ecgts;
using Visionamos.Coopcentral.DataAccess.ViewModels.Ecgts;
using Visionamos.Coopcentral.DataAccess.ViewModels.Integracion;

namespace Visionamos.Coopcentral.DataReads.Mappers
{
    public static class ClsTransfiyaMapper
    {
        #region Contactless
        public static clients_accounts_limit_contactless Map(this clients_accounts_limit_contactless_UI model) => new clients_accounts_limit_contactless
        {
            SRC = model.SRC,
            MAX_OPE = Convert.ToInt32(model.MAX_OPE),
            MAX_AMO = Convert.ToInt32(model.MAX_AMO),
            MAX_VALUE = Convert.ToInt32(model.MAX_VALUE),
        };

        public static clients_accounts_limit_contactless_UI Map(this clients_accounts_limit_contactless entity) => new clients_accounts_limit_contactless_UI
        {
            SRC = entity.SRC,
            MAX_OPE = entity.MAX_OPE.ToString(),
            MAX_AMO = entity.MAX_AMO,
            MAX_VALUE = entity.MAX_VALUE,
        };
        #endregion
        #region Debito
        public static clients_accounts_limit_low_amount Map(this clients_accounts_limit_low_amount_UI model) => new clients_accounts_limit_low_amount
        {
            SRC = model.SRC,
            MAX_OPE = Convert.ToInt32(model.MAX_OPE),
            MAX_AMO = Convert.ToInt32(model.MAX_AMO),
            MAX_VALUE = Convert.ToInt32(model.MAX_VALUE),
        };

        public static clients_accounts_limit_low_amount_UI Map(this clients_accounts_limit_low_amount entity) => new clients_accounts_limit_low_amount_UI
        {
            SRC = entity.SRC,
            MAX_OPE = entity.MAX_OPE.ToString(),
            MAX_AMO = entity.MAX_AMO,
            MAX_VALUE = entity.MAX_VALUE,
        };
        #endregion
        #region Credito
        public static clients_accounts_limit_low_amount_credit Map(this clients_accounts_limit_low_amount_credit_UI model) => new clients_accounts_limit_low_amount_credit
        {
            SRC = model.SRC,
            MAX_OPE = Convert.ToInt32(model.MAX_OPE),
            MAX_AMO = Convert.ToInt32(model.MAX_AMO),
            MAX_VALUE = Convert.ToInt32(model.MAX_VALUE),
        };

        public static clients_accounts_limit_low_amount_credit_UI Map(this clients_accounts_limit_low_amount_credit entity) => new clients_accounts_limit_low_amount_credit_UI
        {
            SRC = entity.SRC,
            MAX_OPE = entity.MAX_OPE.ToString(),
            MAX_AMO = entity.MAX_AMO,
            MAX_VALUE = entity.MAX_VALUE,
        };
        #endregion
    }
}
