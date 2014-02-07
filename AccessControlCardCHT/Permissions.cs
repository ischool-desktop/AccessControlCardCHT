using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessControlCardCHT
{
    class Permissions
    {
        public static string 發送設定 { get { return "AccessControlCardCHT.frmSettings.cs"; } }
        public static bool 發送設定權限
        {
            get
            {
                bool check1 = FISCA.Permission.UserAcl.Current[發送設定].Executable;
                return check1;
            }
        }

        public static string 維護門禁對應資料 { get { return "AccessControlCardCHT.frmAccessControlMapping.cs"; } }
        public static bool 維護門禁對應資料權限
        {
            get
            {
                bool check1 = FISCA.Permission.UserAcl.Current[維護門禁對應資料].Executable;
                return check1;
            }
        }

        public static string 查詢門禁簡訊發送記錄 { get { return "AccessControlCardCHT.frmQuerySMS.cs"; } }
        public static bool 查詢門禁簡訊發送記錄權限
        {
            get
            {
                bool check1 = FISCA.Permission.UserAcl.Current[查詢門禁簡訊發送記錄].Executable;
                return check1;
            }
        }

        public static string 查詢未刷卡學生 { get { return "AccessControlCardCHT.frmQueryNoAccessControl.cs"; } }
        public static bool 查詢未刷卡學生權限
        {
            get
            {
                bool check1 = FISCA.Permission.UserAcl.Current[查詢未刷卡學生].Executable;
                return check1;
            }
        }

        public static string 查詢學生刷卡歷程 { get { return "AccessControlCardCHT.CheckFrom.SMSSendInquiry.cs"; } }
        public static bool 查詢學生刷卡歷程權限
        {
            get
            {
                bool check1 = FISCA.Permission.UserAcl.Current[查詢學生刷卡歷程].Executable;
                return check1;
            }
        }

        public static string 匯入卡號及手機號碼資料 { get { return "AccessControlCardCHT.ImportAccessControlCard.cs"; } }
        public static bool 匯入卡號及手機號碼資料權限
        {
            get
            {
                bool check1 = FISCA.Permission.UserAcl.Current[匯入卡號及手機號碼資料].Executable;
                return check1;
            }
        }

        public static string 匯入卡號及手機號碼_新生 { get { return "AccessControlCardCHT.ImportAccessControlCard_newStudent.cs"; } }
        public static bool 匯入卡號及手機號碼_新生_權限
        {
            get
            {
                bool check1 = FISCA.Permission.UserAcl.Current[匯入卡號及手機號碼_新生].Executable;
                return check1;
            }
        }

        public static string 門禁刷卡歷程 { get { return "AccessControlCardCHT.StudentExtendControls.AccessStudent.cs"; } }
        public static bool 門禁刷卡歷程權限
        {
            get
            {
                bool check1 = FISCA.Permission.UserAcl.Current[門禁刷卡歷程].Executable;
                return check1;
            }
        }
    }
}
