using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AccessControlCardCHT
{
    class AccessExtendRecord
    {
        public AccessExtendRecord(DataRow row)
        {
            oclock_name = "" + row["oclock_name"];

            DateTime dt_1;
            DateTime.TryParse("" + row["use_time"], out dt_1);
            if (dt_1 != null)
                use_time = dt_1.ToString("yyyy/MM/dd HH:mm");

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
