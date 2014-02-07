using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AccessControlCardCHT
{
    class SMSInquirtRecord
    {
        public SMSInquirtRecord(DataRow row)
        {
            ref_student_id = "" + row["id"];
            student_number = "" + row["student_number"];
            class_name = "" + row["class_name"];
            seat_no = "" + row["seat_no"];
            name = "" + row["name"];

            card_no = "" + row["card_no"];
            DateTime dt_1;
            DateTime.TryParse("" + row["use_time"], out dt_1);
            if (dt_1 != null)
                use_time = dt_1.ToString("yyyy/MM/dd HH:mm");

            oclock_name = "" + row["oclock_name"];
            if ("" + row["use_type"] == "01")
            {
                use_type = "上學";
            }
            else if ("" + row["use_type"] == "02")
            {
                use_type = "放學";
            }


        }

        /// <summary>
        /// 學生系統編號
        /// </summary>
        public string ref_student_id { get; set; }

        /// <summary>
        /// 學號
        /// </summary>
        public string student_number { get; set; }

        /// <summary>
        /// 班級名稱
        /// </summary>
        public string class_name { get; set; }

        /// <summary>
        /// 座號
        /// </summary>
        public string seat_no { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 卡號
        /// </summary>
        public string card_no { get; set; }

        /// <summary>
        /// 刷卡時間
        /// </summary>
        public string use_time { get; set; }

        /// <summary>
        /// 卡鐘編號
        /// </summary>
        public string oclock_name { get; set; }

        /// <summary>
        /// 上學或放學
        /// </summary>
        public string use_type { get; set; }
    }
}
