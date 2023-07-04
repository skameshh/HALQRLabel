using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HALQRLabel.Global
{
    public class MyGlobal
    {
        public static String USE_DB = "";
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string VERSION = "v1.2.2";

        public  static int FORM_VAL_GC_MC = 1;
        public static int FORM_VAL_IC_MC = 2;
        public static int FORM_VAL_LOGIS = 3;
       
        public static int FORM_VAL_GC_AT = 4;
        public static int FORM_VAL_ICI_AT = 5;

        public static int FORM_VAL_LH_MC = 6;

        public static String getCString()
        {
            USE_DB = MyGlobal.GetSettingValue("DB");

            log.Info("use_db=" + USE_DB);

            if (USE_DB.Equals("ProDev"))
            {
                return @"Data Source=CARDEV001;Initial Catalog=CIMS;User ID=CIMS_USER;Password=D2c?Z7w^E8e!;";
            }
            else if (USE_DB.Equals("SCGReporting"))
            {
                return @"Data Source=SCGREPORTING;Initial Catalog=DUN02_HESDATAMART01;User ID=2088_REPORTS;Password=L4c^K0i~K1f#;";
            }
            else if (USE_DB.Equals("TPC"))
            {
                return @"Data Source=NTBK616741\SQLEXPRESS;Initial Catalog=sing3_gc;User ID=sa;Password=ABCD7890&*();";
            }
            else if (USE_DB.Equals("Sing3"))
            {
                return @"Data Source=DKTP611587\SQLEXPRESS;Initial Catalog=SING3_MEIE;User ID=sa;Password=ABCD7890&*();";
            }
            return null;
        }

        public static String getApmfgCString()
        {
            return @"Data Source=APMFGDBS001;Initial Catalog=MPM;User ID=iusr_server;Password=iusr;";
        }

        public static string GetSettingValue(string paramName)
        {
            return String.Format(ConfigurationManager.AppSettings[paramName]);
        }



        private static String CSTRING_SCGREPORTING = @"Data Source=SCGREPORTING;Initial Catalog=AP101_MPM;User ID=2088_REPORTS;Password=L4c^K0i~K1f#;";
        public static String getCString4SCGREPORTING()
        {
            return CSTRING_SCGREPORTING;
        }


    }
}
