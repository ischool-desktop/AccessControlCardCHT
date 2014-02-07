using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Campus.DocumentValidator;
using FISCA.Data;

namespace AccessControlCardCHT
{
    public class CardNoCheck_double : IRowVaildator
    {
        private Task mTask;
        private QueryHelper mQueryHelper = new QueryHelper();
        private List<StudentCardNo> StudentCardNos = new List<StudentCardNo>();

        public CardNoCheck_double()
        {
            mTask = Task.Factory.StartNew(() =>
            {
                DataTable table = mQueryHelper.Select("select id,student_number,card_no from student inner join $access_control_card.student_cardno on $access_control_card.student_cardno.ref_student_id=student.id where status=1");

                foreach (DataRow Row in table.Rows)
                {
                    StudentCardNo vStudentCardNo = new StudentCardNo();
                    vStudentCardNo.StudentID = Row.Field<string>("id");
                    vStudentCardNo.StudentNumber = Row.Field<string>("student_number");
                    vStudentCardNo.CardNo = Row.Field<string>("card_no");

                    StudentCardNos.Add(vStudentCardNo);
                }
            });
        }

        #region IRowVaildator Members

        public string Correct(IRowStream Value)
        {
            return string.Empty;
        }

        public bool Validate(IRowStream Value)
        {
            mTask.Wait();

            string StudentNumber = Value.GetValue("學號");
            string CardNo = Value.GetValue("卡號");

            //若卡號不為空白進行檢查
            if (!string.IsNullOrEmpty(CardNo))
            {
                //學生學號
                if (!string.IsNullOrEmpty(StudentNumber))
                {
                    //檢查是否有2名以上學生使用此卡號
                    List<StudentCardNo> vStudentCardNos = StudentCardNos
                        .FindAll(x =>
                            x.CardNo.Equals(CardNo) &&
                            !x.StudentNumber.Equals(StudentNumber));

                    if (vStudentCardNos.Count >= 2)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public string ToString(string template)
        {
            return template;
        }
        #endregion
    }
}