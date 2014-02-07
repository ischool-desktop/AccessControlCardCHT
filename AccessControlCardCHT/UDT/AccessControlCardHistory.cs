using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessControlCardCHT.UDT
{
    /// <summary>
    /// 學校簡訊訊息設定
    /// </summary>
    [FISCA.UDT.TableName("cht_access_control_card.history")]
    public class AccessControlCardHistory : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 卡號
        /// </summary>
        [FISCA.UDT.Field(Field = "card_no", Indexed = true)]
        public string CardNo { get; set; }

        /// <summary>
        /// 卡鐘台號
        /// </summary>
        [FISCA.UDT.Field(Field = "oclock_name")]
        public string OClockName { get; set; }

        /// <summary>
        /// 刷卡時間
        /// </summary>
        [FISCA.UDT.Field(Field = "use_time")]
        public DateTime UseTime { get; set; }

        /// <summary>
        /// 刷卡類別
        /// </summary>
        [FISCA.UDT.Field(Field = "use_type")]
        public string UseType { get; set; }

        /// <summary>
        /// 學生系統編號
        /// </summary>
        [FISCA.UDT.Field(Field = "ref_student_id")]
        public int StudentID { get; set; }

        /// <summary>
        /// 手機號碼
        /// </summary>
        [FISCA.UDT.Field(Field = "cell_phone")]
        public string CellPhone { get; set; }

        /// <summary>
        /// 傳送日期時間
        /// </summary>
        [FISCA.UDT.Field(Field = "send_date")]
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 傳送簡訊內容
        /// </summary>
        [FISCA.UDT.Field(Field = "send_message")]
        public string SendMessage { get; set; }

        /// <summary>
        /// 中華電信簡訊ID
        /// </summary>
        [FISCA.UDT.Field(Field = "cht_msg_id")]
        public string CHTMsgID { get; set; }

        /// <summary>
        /// 中華電信簡訊傳送狀態
        /// </summary>
        [FISCA.UDT.Field(Field = "cht_status")]
        public string CHTStatus { get; set; }

        /// <summary>
        /// 中華電信簡訊傳送狀態訊息
        /// </summary>
        [FISCA.UDT.Field(Field = "cht_message")]
        public string CHTMessage { get; set; }

        /// <summary>
        /// 中華電信簡訊狀態檢查日期
        /// </summary>
        [FISCA.UDT.Field(Field = "cht_chk_date")]
        public DateTime CHTChkDate { get; set; }
    }
}
