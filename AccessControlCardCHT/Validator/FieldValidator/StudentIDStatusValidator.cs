using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using K12.Data;
using System.Data;
using FISCA.Data;

namespace AccessControlCardCHT
{
    /// <summary>
    /// 學生系統編號必須是一般生
    /// </summary>
    class StudentIDStatusValidator : IFieldValidator
    {
        Dictionary<string, bool> _StudentDic { get; set; }
        public StudentIDStatusValidator()
        {
            _StudentDic = GetStudent();
        }

        #region IFieldValidator 成員

        public string Correct(string Value)
        {
            return Value;
        }

        public string ToString(string template)
        {
            return template;
        }

        public bool Validate(string Value)
        {
            if (_StudentDic.ContainsKey(Value)) //包含此系統編號
            {
                return _StudentDic[Value];//True表示學生為一般生
            }
            return false;
        }

        /// <summary>
        /// 取得學生學號 vs 系統編號
        /// </summary>
        private Dictionary<string, bool> GetStudent()
        {
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            QueryHelper _Q = new QueryHelper();
            DataTable dt = _Q.Select("select id,status from student");
            foreach (DataRow row in dt.Rows)
            {
                string StudentID = "" + row[0];
                string Status = "" + row[1];

                if (string.IsNullOrEmpty(StudentID))
                    continue;
                if (!dic.ContainsKey(StudentID))
                {
                    if (Status == "1" || Status == "2")
                    {
                        //狀況是一般或延修
                        dic.Add(StudentID, true);
                    }
                    else
                    {
                        //狀態不為一般或延修,或不存在系統
                        dic.Add(StudentID, false);
                    }
                }
                else
                {
                    //當學號重覆於一般狀態之外時,為錯誤
                    dic[StudentID] = false;
                }

            }
            return dic;

        }

        #endregion
    }
}
