using System.Data;

namespace AccessControlCardCHT
{
    public class StudentCard
    {
        public StudentCard()
        {
 
        }

        public StudentCard(DataRow Row)
        {
            StudentID = Row.Field<string>("id");
            StudentNumber = Row.Field<string>("student_number");
            ClassName = Row.Field<string>("class_name");
            GradeYear = Row.Field<string>("grade_year");
            StudentName = Row.Field<string>("name");
            StudentSeatNo = Row.Field<string>("seat_no");
            StudentPhone = Row.Field<string>("cell_phone");
            CardNo = Row.Field<string>("card_no");
        }

        public string StudentID { get; set; }

        public string StudentNumber { get; set;}

        public string ClassName { get; set;}

        public string GradeYear { get; set; }

        public string StudentSeatNo { get; set;}

        public string StudentName {　get; set;}

        public string StudentPhone { get; set; }

        public string CardNo { get; set; }
    }
}