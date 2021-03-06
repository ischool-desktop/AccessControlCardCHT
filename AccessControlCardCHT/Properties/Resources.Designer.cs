﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccessControlCardCHT.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AccessControlCardCHT.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;?xml-stylesheet type=&quot;text/xsl&quot; href=&quot;format.xsl&quot; ?&gt;
        ///&lt;ValidateRule Name=&quot;卡號及手機號碼資料&quot;&gt;
        ///  &lt;DuplicateDetection&gt;
        ///    &lt;Detector Name=&quot;學號&quot;&gt;
        ///      &lt;Field Name=&quot;學號&quot; /&gt;
        ///    &lt;/Detector&gt;
        ///    &lt;Detector Name=&quot;卡號&quot; IsImportKey=&quot;False&quot;&gt;
        ///      &lt;Field Name=&quot;卡號&quot; /&gt;
        ///    &lt;/Detector&gt;
        ///  &lt;/DuplicateDetection&gt;
        ///  &lt;FieldList&gt;
        ///    &lt;!--
        ///        系統編號(自動產生，可看不可以改)、學號、班級、座號、姓名、卡號、簡訊手機。使用者可以匯入批次修改。可以系統編號、學號做為匯入的鍵值。
        ///卡號不得重覆。
        ///        --&gt;
        ///
        ///    &lt;!-- 學生系統編號 2013/9/24 - 俊威註解
        ///    	&lt;Field Required=&quot;True&quot; Empt [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AccessControlCard {
            get {
                return ResourceManager.GetString("AccessControlCard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;?xml-stylesheet type=&quot;text/xsl&quot; href=&quot;format.xsl&quot; ?&gt;
        ///&lt;ValidateRule Name=&quot;新生卡號及手機號碼資料&quot;&gt;
        ///  &lt;DuplicateDetection&gt;
        ///    &lt;Detector Name=&quot;學生系統編號&quot;&gt;
        ///      &lt;Field Name=&quot;學生系統編號&quot;/&gt;
        ///    &lt;/Detector&gt;
        ///    &lt;Detector Name=&quot;卡號&quot; IsImportKey=&quot;False&quot;&gt;
        ///      &lt;Field Name=&quot;卡號&quot;/&gt;
        ///    &lt;/Detector&gt;
        ///  &lt;/DuplicateDetection&gt;
        ///  &lt;FieldList&gt;
        ///    &lt;Field Required=&quot;True&quot; EmptyAlsoValidate=&quot;False&quot; Name=&quot;學生系統編號&quot; Description=&quot;每一名學生都擁有獨一無二由系統編列之學生系統編號&quot;&gt;
        ///      &lt;Validate AutoCorrect=&quot;False&quot; Description=&quot;「學生系統編號 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AccessControlCard_newStudent {
            get {
                return ResourceManager.GetString("AccessControlCard_newStudent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;?xml-stylesheet type=&quot;text/xsl&quot; href=&quot;format.xsl&quot; ?&gt;
        ///&lt;ValidateRule Name=&quot;卡號及手機號碼資料&quot;&gt;
        ///    &lt;DuplicateDetection&gt;
        ///
        ///        &lt;Detector Name=&quot;學生系統編號&quot;&gt;
        ///            &lt;Field Name=&quot;學生系統編號&quot; /&gt;
        ///        &lt;/Detector&gt;
        ///
        ///        &lt;Detector Name=&quot;卡號&quot; IsImportKey=&quot;False&quot;&gt;
        ///            &lt;Field Name=&quot;卡號&quot; /&gt;
        ///        &lt;/Detector&gt;
        ///
        ///    &lt;/DuplicateDetection&gt;
        ///    &lt;FieldList&gt;
        ///        &lt;!--
        ///        系統編號(自動產生，可看不可以改)、學號、班級、座號、姓名、卡號、簡訊手機。使用者可以匯入批次修改。可以系統編號、學號做為匯入的鍵值。
        ///卡號不得重覆。
        ///        --&gt;
        ///
        ///        &lt;Field R [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AccessControlCard_StudentID {
            get {
                return ResourceManager.GetString("AccessControlCard_StudentID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;?xml-stylesheet type=&quot;text/xsl&quot; href=&quot;format.xsl&quot; ?&gt;
        ///&lt;ValidateRule Name=&quot;卡號及手機號碼資料&quot;&gt;
        ///    &lt;DuplicateDetection&gt;
        ///
        ///        &lt;Detector Name=&quot;學號&quot;&gt;
        ///            &lt;Field Name=&quot;學號&quot; /&gt;
        ///        &lt;/Detector&gt;
        ///
        ///        &lt;Detector Name=&quot;卡號&quot; IsImportKey=&quot;False&quot;&gt;
        ///            &lt;Field Name=&quot;卡號&quot; /&gt;
        ///        &lt;/Detector&gt;
        ///
        ///    &lt;/DuplicateDetection&gt;
        ///    &lt;FieldList&gt;
        ///        &lt;!--
        ///        系統編號(自動產生，可看不可以改)、學號、班級、座號、姓名、卡號、簡訊手機。使用者可以匯入批次修改。可以系統編號、學號做為匯入的鍵值。
        ///卡號不得重覆。
        ///        --&gt;
        ///
        ///        &lt;Field Required= [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AccessControlCard_StudentNumber {
            get {
                return ResourceManager.GetString("AccessControlCard_StudentNumber", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap admissions_close_128 {
            get {
                object obj = ResourceManager.GetObject("admissions_close_128", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap classmate_config_128 {
            get {
                object obj = ResourceManager.GetObject("classmate_config_128", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap e_learning_config_128 {
            get {
                object obj = ResourceManager.GetObject("e_learning_config_128", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap find {
            get {
                object obj = ResourceManager.GetObject("find", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Import_Image {
            get {
                object obj = ResourceManager.GetObject("Import_Image", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap layers_ok_64 {
            get {
                object obj = ResourceManager.GetObject("layers_ok_64", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Text_Message_128 {
            get {
                object obj = ResourceManager.GetObject("Text_Message_128", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
