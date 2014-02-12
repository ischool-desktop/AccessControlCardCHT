using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccessControlCardCHT.UDT;
using FISCA.UDT;
using System.Web;
using System.IO;
using System.Net;

namespace AccessControlCardCHT.DAL
{
    public class DALTransfer
    {
        /// <summary>
        /// 透過UID取得門禁刷卡資料
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public static List<AccessControlCardHistory> GetAccessControlCardHistoryByUIDList(List<string> idList)
        {
            List<AccessControlCardHistory> retVal = new List<AccessControlCardHistory>();
            if (idList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                string query = "uid in(" + string.Join(",", idList.ToArray()) + ")";
                retVal = accessHelper.Select<AccessControlCardHistory>(query);
            }
            return retVal;
        }

        /// <summary>
        /// 傳送簡訊到中華電信
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static AccessControlCardHistory SendCHTSMSData(AccessControlCardHistory data)
        {
           // 取得中華電信回傳代碼Dict
            Dictionary<string, string> CHTRCodeDict = CHTReturnCodeDict();
            // 測試帳號
            string account = "14525";
            // 測試密碼
            string password = "14525";

            // 訊息編碼 
            string msg = HttpUtility.UrlEncode(data.SendMessage, System.Text.Encoding.Default);

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("http://imsp.emome.net:8008/imsp/sms/servlet/SubmitSM?account=");
                sb.Append(account);
                sb.Append("&password=" + password);
                sb.Append("&from_addr_type=" + "0");
                sb.Append("&from_addr=" + "");
                sb.Append("&to_addr_type=" + "0");
                sb.Append("&to_addr=" + data.CellPhone);
                sb.Append("&msg_expire_time=" + "0");
                sb.Append("&msg_type=" + "0");
                sb.Append("&msg=" + msg);

                // 送出簡訊並取得回傳訊息
                string[] result = CHTSubmit(sb);                
                if (result != null)
                {
                    data.SendDate = System.DateTime.Now;
                    //長度為4是正確的回傳資料
                    if (result.Length == 4)
                    {                        
                        data.CHTMsgID = result[2];
                        data.CHTStatus = result[1];
                        data.CHTChkDate = System.DateTime.Now;
                        data.CHTMessage = CHTRCodeDict.ContainsKey(data.CHTStatus) ? CHTRCodeDict[data.CHTStatus] : result[3];                        
                    }
                    else
                    {
                        //例外錯誤訊息
                        data.CHTMessage = result[0];
                    }
                }
            }
            catch (Exception ex)
            {
                data.CHTChkDate = System.DateTime.Now;
                data.CHTMessage = "傳送到中華電信發生錯誤," + ex.Message;
                return data;
            }
            return data;
        }

        /// <summary>
        /// 傳送到中華電信主機並接收回傳訊息
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        private static string[] CHTSubmit(StringBuilder sb)
        {
            try
            {
                WebClient client = new WebClient();
                string response = "";
                //用using來自動關閉資源
                using (Stream data = client.OpenRead(sb.ToString()))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        //讀取每一行
                        while ((response = reader.ReadLine()) != null)
                        {
                            //直到<body>再讀取下一行
                            if (response.StartsWith("<body>"))
                            {
                                //取得response後跳離
                                response = reader.ReadLine();
                                break;
                            }
                        }
                    }
                }

                //刪去結尾<br>標記
                response = response.Replace("<br>", "");

                //response拆解
                string[] result = response.Split('|');

                //回傳結果
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 中華電信傳送後回傳代碼資料
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> CHTReturnCodeDict()
        {
            Dictionary<string, string> CodeDic = new Dictionary<string, string>();
            CodeDic.Add("-1", "系統或是資料庫故障。");
            CodeDic.Add("0", "訊息已成功發送至接收端。");
            CodeDic.Add("1", "訊息傳送中。");
            CodeDic.Add("2", "系統無法找到您要找的訊息。請檢查你的 toaddr 和messageid 是否正確。");
            CodeDic.Add("3", "訊息無法成功送達手機。");
            CodeDic.Add("4", "系統或是資料庫故障。");
            CodeDic.Add("5", "訊息狀態不明。此筆訊息已被刪除。");
            CodeDic.Add("8", "接收端 SIM 已滿，造成訊息傳送失敗。");
            CodeDic.Add("9", "錯誤的接收端號碼，可能是空號。");
            CodeDic.Add("11", "號碼格式錯誤。");
            CodeDic.Add("12", "收訊手機已設定拒收簡訊。");
            CodeDic.Add("13", "手機錯誤。");
            CodeDic.Add("16", "系統無法執行msisdn<->subno，請稍候再試。");
            CodeDic.Add("17", "系統無法找出對應此 subno之電話號碼，請查明 subno是否正確。");
            CodeDic.Add("18", "請檢查受訊方號碼格式是否正確。");
            CodeDic.Add("21", "請檢查 Message id 格式是否正確。");
            CodeDic.Add("23", "你的登入 IP 未在系統註冊。");
            CodeDic.Add("24", "帳號已停用。");
            CodeDic.Add("31", "訊息尚未傳送到 SMSC 。");
            CodeDic.Add("32", "訊息無法傳送到簡訊中心。");
            CodeDic.Add("33", "訊息無法傳送到簡訊中心(訊務繁忙)。");
            CodeDic.Add("48", "受訊客戶要求拒收加值簡訊，請不要再重送。");
            CodeDic.Add("55", "http (port 8008) 連線不允許使用 GET 方法，請改用 POST 或改為 https(port 4443) 連線。");
            return CodeDic;        
        }
    }
}
