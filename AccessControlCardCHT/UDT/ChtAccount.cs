using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessControlCardCHT.UDT
{
    /// <summary>
    /// 中華電信簡訊帳號密碼
    /// </summary>
    [FISCA.UDT.TableName("cht_access_control_card.account")]
    public class ChtAccount : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [FISCA.UDT.Field(Field = "account", Indexed = true)]
        public string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [FISCA.UDT.Field(Field = "password", Indexed = true)]
        public string Password { get; set; }

    }
}
