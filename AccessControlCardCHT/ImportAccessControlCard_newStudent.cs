using System.Collections.Generic;
using System.Data;
using System.Linq;
using Campus.DocumentValidator;
using Campus.Import;
using FISCA.Data;
using FISCA.UDT;
using K12.Data;
using System.Text;
using AccessControlCardCHT.UDT;

namespace AccessControlCardCHT
{
    /// <summary>
    /// 匯入班級
    /// </summary>
    public class ImportAccessControlCard_newStudent : ImportWizard
    {
        private const string constStudentID = "學生系統編號";
        private const string constMobilePhone = "行動電話";
        private const string constCardNo = "卡號";
        private ImportOption mOption;
        private AccessHelper mAccessHelper = new AccessHelper();
        private UpdateHelper mUpdateHelper = new UpdateHelper();
        private QueryHelper mQueryHelper = new QueryHelper();
        Dictionary<string, LogObj> _OldDic, _NewDic; //added by Cloud

        //須更新的學生系統編號
        Dictionary<int, AccessControlCard> _StudentCardDic = new Dictionary<int, AccessControlCard>();

        //學生學號 : 學生系統編號
        //private Dictionary<string, string> mStudentNumberIDs = new Dictionary<string, string>();

        //學生學號 : 學生姓名
        //private Dictionary<string, string> mStudentNumberNameDic = new Dictionary<string, string>();

        //學生系統編號 : 學生姓名
        //private Dictionary<string, string> mStudentKeyDic = new Dictionary<string, string>();

        //"系統編號(自動產生，可看不可以改)、學號、班級、座號、姓名、卡號、簡訊手機。使用者可以匯入批次修改。可以系統編號、學號做為匯入的鍵值。
        //卡號不得重覆。"

        public ImportAccessControlCard_newStudent()
        {
            this.IsSplit = false;
        }

        public override ImportAction GetSupportActions()
        {
            return ImportAction.Update;
        }

        /// <summary>
        /// 取得驗證規則
        /// </summary>
        public override string GetValidateRule()
        {
            return Properties.Resources.AccessControlCard_newStudent;
        }

        public override void Prepare(ImportOption Option)
        {
            mOption = Option;
            List<AccessControlCard> StudentCards = mAccessHelper.Select<AccessControlCard>();
            foreach (AccessControlCard card in StudentCards)
            {
                if (!_StudentCardDic.ContainsKey(card.StudentID))
                {
                    _StudentCardDic.Add(card.StudentID, card);
                }
            }

            //DataTable table = mQueryHelper.Select("select id,student_number,name from student where status=1");

            //foreach (DataRow row in table.Rows)
            //{
            //    string StudentID = "" + row["id"];
            //    string StudentNumber = "" + row["student_number"];
            //    string Name = "" + row["name"];

            //    if (!mStudentNumberIDs.ContainsKey(StudentNumber))
            //    {
            //        mStudentNumberIDs.Add(StudentNumber, StudentID);
            //        mStudentNumberNameDic.Add(StudentNumber, Name);
            //    }

            //    if (!mStudentKeyDic.ContainsKey(StudentID))
            //    {
            //        mStudentKeyDic.Add(StudentID, Name);
            //    }
            //}
        }

        /// <summary>
        /// 儲存學生卡號
        /// </summary>
        /// <param name="StudentCards"></param>
        private string SaveStudentCards(List<StudentCard> StudentCards, bool IsUpdateCardNo, bool IsUpdatePhone)
        {
            AccessHelper a = new AccessHelper();
            StringBuilder sb = new StringBuilder();

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(StudentCards))
            {
                //取得匯入的學生ID
                string ids = string.Join("','", StudentCards.Select(x => x.StudentID).ToArray());
                //儲存更新前的資料
                SavePreviousData(ids);

                List<AccessControlCard> updateList = new List<AccessControlCard>();
                List<AccessControlCard> insertList = new List<AccessControlCard>();

                #region 儲存卡號
                if (IsUpdateCardNo)
                {
                    foreach (StudentCard each in StudentCards)
                    {
                        AccessControlCard Card = new AccessControlCard();
                        Card.StudentID = int.Parse(each.StudentID);
                        Card.CardNo = each.CardNo;
                        Card.CellPhone = each.StudentPhone;

                        if (_StudentCardDic.ContainsKey(Card.StudentID))
                        {
                            _StudentCardDic[Card.StudentID].CardNo = Card.CardNo;
                            _StudentCardDic[Card.StudentID].CellPhone = Card.CellPhone;
                            updateList.Add(_StudentCardDic[Card.StudentID]);
                        }
                        else
                        {
                            insertList.Add(Card);
                        }
                    }

                    if (updateList.Count > 0)
                    {
                        sb.AppendLine("匯入更新「" + updateList.Count + "」筆卡號資料");
                        updateList.SaveAll();
                    }

                    if (insertList.Count > 0)
                    {
                        sb.AppendLine("匯入新增「" + insertList.Count + "」筆卡號資料");
                        a.InsertValues(insertList);
                    }
                //    #region 刪除卡號資料
                //    string StudentCondition_check = string.Join("','", StudentCards.Select(x => x.CardNo).ToArray());
                //    List<AccessControlCard> Cards_check = mAccessHelper.Select<AccessControlCard>("card_no in ('" + StudentCondition_check + "')");
                //    if (Cards_check.Count > 0)
                //    {
                //        a.DeletedValues(Cards_check);
                //    }
                //    #endregion

                //    #region 刪除學生卡號資料
                //    string StudentCondition = string.Join(",", StudentCards.Select(x => x.StudentID).ToArray());
                //    List<AccessControlCard> Cards_Student = mAccessHelper.Select<AccessControlCard>("ref_student_id in (" + StudentCondition + ")");
                //    if (Cards_Student.Count > 0)
                //    {
                //        a.DeletedValues(Cards_Student);
                //    }
                //    #endregion

                //    #region 新增卡號資料
                //    List<AccessControlCard> Cards_insert = new List<AccessControlCard>();
                //    foreach (StudentCard vStudentCard in StudentCards)
                //    {
                //        AccessControlCard Card = new AccessControlCard();
                //        Card.StudentID = int.Parse(vStudentCard.StudentID);
                //        Card.CardNo = vStudentCard.CardNo;
                //        Cards_insert.Add(Card);
                //    }

                //    //新增卡號的學生
                //    if (Cards_insert.Count > 0)
                //    {
                //        sb.AppendLine("匯入更新「" + Cards_insert.Count + "」筆卡號");
                //        a.InsertValues(Cards_insert);
                //    }
                //    #endregion
                }
                #endregion

                #region 儲存行動電話號碼
                //if (IsUpdatePhone)
                //{
                //    List<string> Commands = new List<string>();

                //    foreach (StudentCard vStudentCard in StudentCards)
                //    {
                //        if (!string.IsNullOrEmpty(vStudentCard.StudentPhone)) //如果門號為空,則不更新
                //        {
                //            Commands.Add("UPDATE $cht_access_control_card.student_cardno SET cell_phone='" + vStudentCard.StudentPhone + "' WHERE ref_student_id =" + vStudentCard.StudentID);
                //        }
                //    }
                //    sb.AppendLine("匯入更新「" + Commands.Count + "」筆行動電話");
                //    int Count = mUpdateHelper.Execute(Commands);
                //}
                #endregion

                //儲存現在的資料
                SaveCurrentData(ids);
                sb.Append(LogChecker());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 實際匯入
        /// </summary>
        /// <param name="Rows"></param>
        /// <returns></returns>
        public override string Import(List<Campus.DocumentValidator.IRowStream> Rows)
        {
            List<StudentCard> StudentCards = new List<StudentCard>();
            string Key = mOption.SelectedKeyFields[0];

            foreach (IRowStream Row in Rows)
            {
                string StudentID = Row.GetValue(constStudentID);

                //if (mStudentKeyDic.ContainsKey(StudentID))
                //{
                    string MobilePhone = Row.Contains(constMobilePhone) ? Row.GetValue(constMobilePhone) : string.Empty;
                    string CardNo = Row.Contains(constCardNo) ? Row.GetValue(constCardNo) : string.Empty;

                    if (!string.IsNullOrEmpty(StudentID))
                    {
                        StudentCard vStudentCard = new StudentCard();
                        vStudentCard.StudentID = StudentID;
                        //vStudentCard.StudentNumber = StudentNumber;
                        vStudentCard.StudentPhone = MobilePhone;
                        vStudentCard.CardNo = CardNo;

                        StudentCards.Add(vStudentCard);
                    }
                //}
            }

            string s = SaveStudentCards(StudentCards, Rows[0].Contains(constCardNo), Rows[0].Contains(constMobilePhone));


            //FISCA.LogAgent.ApplicationLog.Log("門禁系統", "匯入", "匯入更新學生卡號與門號\n" + s);


            return "匯入更新學生卡號與門號\n" + s;
        }

        //查詢並儲存學生被修改前的資料 by Cloud
        private void SavePreviousData(string id)
        {
            _OldDic = new Dictionary<string, LogObj>();
            string ids = "('" + id + "')";
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("select id,name,cell_phone,card_no from student ");
            strBuilder.Append("left join  $cht_access_control_card.student_cardno on  $cht_access_control_card.student_cardno.ref_student_id=student.id ");
            strBuilder.Append("where id in " + ids);

            QueryHelper _Q = new QueryHelper();
            DataTable dt = _Q.Select(strBuilder.ToString());

            foreach (DataRow row in dt.Rows)
            {
                if (!_OldDic.ContainsKey(row["id"].ToString()))
                {
                    _OldDic.Add(row["id"].ToString(), new LogObj(row));
                }
            }
        }
        //查詢並儲存學生更新後的資料 by Cloud
        private void SaveCurrentData(string id)
        {
            _NewDic = new Dictionary<string, LogObj>();
            string ids = "('" + id + "')";
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("select id,name,cell_phone,card_no from student ");
            strBuilder.Append("left join  $cht_access_control_card.student_cardno on  $cht_access_control_card.student_cardno.ref_student_id=student.id ");
            strBuilder.Append("where id in " + ids);

            QueryHelper _Q = new QueryHelper();
            DataTable dt = _Q.Select(strBuilder.ToString());

            foreach (DataRow row in dt.Rows)
            {
                if (!_NewDic.ContainsKey(row["id"].ToString()))
                {
                    _NewDic.Add(row["id"].ToString(), new LogObj(row));
                }
            }
        }

        //added by Cloud
        private string LogChecker()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string id in _OldDic.Keys)
            {
                if (_OldDic[id].Sms_phone != _NewDic[id].Sms_phone)
                {
                    sb.Append("學生「" + _OldDic[id].Name + "」的行動電話「" + _OldDic[id].Sms_phone + "」改為" + "「" + _NewDic[id].Sms_phone + "」\r\n");
                }

                if (_OldDic[id].Card_no != _NewDic[id].Card_no)
                {
                    sb.Append("學生「" + _OldDic[id].Name + "」的卡號「" + _OldDic[id].Card_no + "」改為" + "「" + _NewDic[id].Card_no + "」\r\n");
                }
            }

            return sb.ToString();
        }
    }
}