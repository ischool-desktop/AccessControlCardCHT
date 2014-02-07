using System.Data;

namespace AccessControlCardCHT
{
    public class SMSRecord
    {
        public SMSRecord(DataRow Row)
        {
            StudentNumber = Row.Field<string>("student_number");
            StudentName = Row.Field<string>("name");
            SendTime = Row.Field<string>("send_time");
            TargetPhone = Row.Field<string>("cell_phone");
            SMSContent = Row.Field<string>("send_message");
            Status = Row.Field<string>("cht_status");
            CardNo = Row.Field<string>("card_no");

            if (Status.Equals("0"))
                Status = "待傳送";
            else if (Status.Equals("1"))
                Status = "已傳送";
            else if (Status.Equals("2"))
                Status = "傳送失敗";
            else
                Status = "狀態未明";
        }

        public string StudentNumber { get; set; }

        public string StudentName { get; set; }

        public string SendTime { get; set; }

        public string TargetPhone { get; set; }

        public string Status { get; set; }

        public string CardNo { get; set; }

        public string SMSContent { get; set; }
    }
}