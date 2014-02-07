using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using K12.Data;
using System.Data;

namespace AccessControlCardCHT
{
    /// <summary>
    /// 學生系統編號是否存在系統
    /// </summary>
    class StudentIDExistenceValidator : IFieldValidator
    {
        List<string> _StudentList { get; set; }

        public StudentIDExistenceValidator()
        {
            _StudentList = GetStudent();
        }
        #region IFieldValidator 成員

        //自動修正
        public string Correct(string Value)
        {
            return Value;
        }
        //回傳驗證訊息
        public string ToString(string template)
        {
            return template;
        }

        public bool Validate(string Value)
        {
            if (_StudentList.Contains(Value)) //包含此系統編號
            {
                return true;
            }
            else //不包含此學號
            {
                return false;
            }
        }

        /// <summary>
        /// 取得學生系統編號
        /// </summary>
        private List<string> GetStudent()
        {
            FISCA.Data.QueryHelper _queryHelper = new FISCA.Data.QueryHelper();
            List<string> list = new List<string>();
            DataTable dt = _queryHelper.Select("select id from student");
            foreach (DataRow row in dt.Rows)
            {
                string StudentID = "" + row[0];

                if (string.IsNullOrEmpty(StudentID))
                    continue;

                if (!list.Contains(StudentID))
                {
                    list.Add(StudentID);
                }
            }
            return list;

        }

        #endregion
    }
}
