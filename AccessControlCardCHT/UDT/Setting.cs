using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessControlCardCHT.UDT
{
    /// <summary>
    /// 學校簡訊訊息設定
    /// </summary>
    [FISCA.UDT.TableName("cht_access_control_card.setting")]
    public class Setting : FISCA.UDT.ActiveRecord
    {
        /// <summary>
        /// 到校訊息
        /// </summary>
        [FISCA.UDT.Field(Field = "arrive_school_sms")]
        public string ArriveSchoolSMS { get; set; }

        /// <summary>
        /// 離校訊息
        /// </summary>
        [FISCA.UDT.Field(Field = "leave_school_sms")]
        public string LeaveSchoolSMS { get; set; }

        /// <summary>
        /// 啟用到校訊息
        /// </summary>
        [FISCA.UDT.Field(Field = "enable_arrive_school_sms")]
        public bool EnableArriveSchoolSMS { get; set; }

        /// <summary>
        /// 啟用離校訊息
        /// </summary>
        [FISCA.UDT.Field(Field = "enable_leave_school_sms")]
        public bool EnableLeaveSchoolSMS { get; set; }

        /// <summary>
        /// 發生錯誤傳送訊息電話
        /// </summary>
        [FISCA.UDT.Field(Field = "error_phone")]
        public string ErrorPhone { get; set; }

        /// <summary>
        /// 啟用發生錯誤傳送訊息
        /// </summary>
        [FISCA.UDT.Field(Field = "enable_error_sms")]
        public bool EnableErrorSMS { get; set; }

        /// <summary>
        /// 啟用自動發送功能
        /// </summary>
        [FISCA.UDT.Field(Field = "enable_auto_sms")]
        public bool EnableAutoSMS { get; set; }	
    }
}
