using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessControlCardCHT.UDT
{
    /// <summary>
    /// 學生卡號電話設定
    /// </summary>
    [FISCA.UDT.TableName("cht_access_control_card.student_cardno")]
    public class AccessControlCard : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 卡號
        /// </summary>
        [FISCA.UDT.Field(Field = "card_no", Indexed = true)]
        public string CardNo { get; set; }

        /// <summary>
        /// 學生系統編號
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_student_id")]
        public int StudentID { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        [FISCA.UDT.Field(Field = "cell_phone")]
        public string CellPhone { get; set; }

    }
}
