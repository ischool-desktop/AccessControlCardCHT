using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using FISCA.UDT;
using AccessControlCardCHT.UDT;
using AccessControlCardCHT.Properties;
using FISCA.Permission;

namespace AccessControlCardCHT
{
    public class Program
    {
        [FISCA.MainMethod()]
        public static void Main()
        {
            //驗證規則
            FactoryProvider.FieldFactory.Add(new FieldValidatorFactory());
            FactoryProvider.RowFactory.Add(new RowValidatorFactory());

            #region 避免 SyncSchema 影響載入效能

            SchemaManager Manager = new SchemaManager(FISCA.Authentication.DSAServices.DefaultConnection);
            K12.Data.Configuration.ConfigData cd = K12.Data.School.Configuration["世界高中門禁系統UDT_CHT載入設定"];

            bool checkClubUDT = false;
            string name = "世界高中門禁系統UDT_CHT";

            //如果尚無設定值,預設為
            if (string.IsNullOrEmpty(cd[name]))
            {
                cd[name] = "false";
            }
            //檢查是否為布林
            bool.TryParse(cd[name], out checkClubUDT);

            if (!checkClubUDT)
            {
                Manager.SyncSchema(new Setting());
                Manager.SyncSchema(new AccessControlCard());
                Manager.SyncSchema(new AccessControlCardHistory());
                Manager.SyncSchema(new ChtAccount());

                cd[name] = "true";
                cd.Save();
            }            
            #endregion

            //毛毛蟲
            FeatureAce UserPermission = FISCA.Permission.UserAcl.Current[Permissions.門禁刷卡歷程];
            if (UserPermission.Editable || UserPermission.Viewable)
                K12.Presentation.NLDPanels.Student.AddDetailBulider(new FISCA.Presentation.DetailBulider<AccessStudentItem>());
            
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["匯入"].Image = Resources.Import_Image;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["匯入"].Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Large;

            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["匯入"]["匯入卡號及手機號碼(學號)"].Enable = Permissions.匯入卡號及手機號碼資料權限;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["匯入"]["匯入卡號及手機號碼(學號)"].Click += delegate
            {
                new ImportAccessControlCard().Execute();
            };

            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["匯入"]["匯入卡號及手機號碼(系統編號)"].Enable = Permissions.匯入卡號及手機號碼_新生_權限;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["匯入"]["匯入卡號及手機號碼(系統編號)"].Click += delegate
            {
                new ImportAccessControlCard_newStudent().Execute();
            };

            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["發送設定"].Image = Resources.e_learning_config_128;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["發送設定"].Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Medium;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["發送設定"].Enable = Permissions.發送設定權限;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["發送設定"].Click += delegate
            {
                new frmSettings().ShowDialog();
            };

            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["維護門禁對應資料"].Image = Resources.classmate_config_128;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["維護門禁對應資料"].Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Medium;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["維護門禁對應資料"].Enable = Permissions.維護門禁對應資料權限;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["維護門禁對應資料"].Click += delegate
            {
                new frmAccessControlMapping().ShowDialog();
            };

            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢門禁簡訊發送記錄"].Image = Resources.Text_Message_128;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢門禁簡訊發送記錄"].Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Medium;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢門禁簡訊發送記錄"].Enable = Permissions.查詢門禁簡訊發送記錄權限;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢門禁簡訊發送記錄"].Click += delegate
            {
                new frmQuerySMS().ShowDialog();
            };

            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢未刷卡學生"].Image = Resources.admissions_close_128;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢未刷卡學生"].Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Medium;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢未刷卡學生"].Enable = Permissions.查詢未刷卡學生權限;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢未刷卡學生"].Click += delegate
            {
                new frmQueryNoAccessControl().ShowDialog();
            };

            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢學生刷卡歷程"].Image = Resources.layers_ok_64;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢學生刷卡歷程"].Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Medium;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢學生刷卡歷程"].Enable = Permissions.查詢學生刷卡歷程權限;
            FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "門禁系統(中華電信)"]["查詢學生刷卡歷程"].Click += delegate
            {
                new SMSSendInquiry().ShowDialog();
            };

            Catalog detail2 = RoleAclSource.Instance["學務作業"]["門禁系統(中華電信)"];
            detail2.Add(new ReportFeature(Permissions.發送設定, "發送設定"));
            detail2.Add(new ReportFeature(Permissions.維護門禁對應資料, "維護門禁對應資料"));
            detail2.Add(new ReportFeature(Permissions.查詢門禁簡訊發送記錄, "查詢門禁簡訊發送記錄"));
            detail2.Add(new ReportFeature(Permissions.查詢未刷卡學生, "查詢未刷卡學生"));
            detail2.Add(new ReportFeature(Permissions.查詢學生刷卡歷程, "查詢學生刷卡歷程"));
            detail2.Add(new ReportFeature(Permissions.匯入卡號及手機號碼資料, "匯入卡號及手機號碼(學號)"));
            detail2.Add(new ReportFeature(Permissions.匯入卡號及手機號碼_新生, "匯入卡號及手機號碼(系統編號)"));

            Catalog detail1 = RoleAclSource.Instance["學生"]["資料項目"];
            detail1.Add(new DetailItemFeature(Permissions.門禁刷卡歷程, "門禁刷卡歷程(中華電信)"));
        }
    }
}
