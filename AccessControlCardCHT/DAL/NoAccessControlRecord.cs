
using System.Data;

namespace AccessControlCardCHT
{
    public class NoAccessControlRecord
    {
        public NoAccessControlRecord(DataRow Row,string Status)
        {
            StudentID = Row.Field<string>("id");
            StudentNumber = Row.Field<string>("student_number");
            ClassName = Row.Field<string>("class_name");
            StudentName = Row.Field<string>("name");
            StudentSeatNo = Row.Field<string>("seat_no");
            CardNo = Row.Field<string>("card_no");
            this.Status = Status;
        }

        public string StudentID { get; set; }

        public string StudentNumber { get; set;}

        public string ClassName { get; set;}

        public string StudentSeatNo { get; set;}

        public string StudentName {　get; set;}

        public string CardNo { get; set; }

        public string Status { get; set; }
    }
}