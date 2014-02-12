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
            Status = Row.Field<string>("cht_message");
            CardNo = Row.Field<string>("card_no");
            UID = Row.Field<string>("uid");
            ChtMsgID = Row.Field<string>("cht_msg_id");
            ChtStatus = Row.Field<string>("cht_status");
            ChtChkDate=Row.Field<string>("cht_chk_date");            
        }

        public string StudentNumber { get; set; }

        public string StudentName { get; set; }

        public string SendTime { get; set; }

        public string TargetPhone { get; set; }

        public string Status { get; set; }

        public string CardNo { get; set; }

        public string SMSContent { get; set; }

        public string UID { get; set; }

        public string ChtMsgID { get; set; }

        public string ChtStatus { get; set; }

        public string ChtChkDate { get; set; }
        
    }
}