using HALQRLabel.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HALQRLabel.DB
{
   public class DBUtils
    {

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

       /* static string sql = "SELECT [DLVRY_NBR],[DLVRY_ITM],a.[MTRL_NBR],[SHRT_TXT] as [Mat_Desc],[BTCH_NBR],[PLNT] ,b.GRS_WT,b.WT_UOM_CD " +
            " FROM [DUN02_HESDATAMART01].[dbo].[DLVRY_ITM] A with(nolock)  JOIN [DUN02_HESDATAMART01].[dbo].[MTRL] B WITH(NOLOCK) ON B.MTRL_NBR = A.MTRL_NBR " +
            " where DLVRY_NBR like '%@delNum' and DLVRY_ITM like '%@delItem' ";*/
        //821658597 | 10


        public static MatDao getMaterial(String deliveryNum, string item)
        {
            MatDao matDao = null;
            /*  string sql = "SELECT [DLVRY_NBR],[DLVRY_ITM],a.[MTRL_NBR],[SHRT_TXT] as [Mat_Desc],[BTCH_NBR],[PLNT] ,b.GRS_WT,b.WT_UOM_CD " +
             " FROM [DUN02_HESDATAMART01].[dbo].[DLVRY_ITM] A with(nolock)  JOIN [DUN02_HESDATAMART01].[dbo].[MTRL] B WITH(NOLOCK) ON B.MTRL_NBR = A.MTRL_NBR " +
             " where DLVRY_NBR like '%"+ deliveryNum + "' and DLVRY_ITM like '%"+ item + "' ";*/

            string sql = "SELECT REPLACE(LTRIM(REPLACE(A.[DLVRY_NBR],'0',' ')),' ','0') AS DLVRY_NBR , " +
                " REPLACE(LTRIM(REPLACE(A.[DLVRY_ITM], '0', ' ')), ' ', '0') AS DLVRY_ITM      " +
                " , REPLACE(LTRIM(REPLACE(B.Material_NOZERO, '0', ' ')), ' ', '0') AS MTRL_NBR, B.RevLev ," +
                " REPLACE(LTRIM(REPLACE(A.BTCH_NBR, '0', ' ')), ' ', '0') AS BTCH_NBR, " +
                " [SHRT_TXT] as Mat_Desc    ,[PLNT], b.Gross_Weight as GRS_WT, b.Weight_UOM  as WT_UOM_CD" +
                "  FROM [DUN02_HESDATAMART01].[dbo].[DLVRY_ITM] A WITH(NOLOCK) JOIN [CAR01_CPS_DATA].[dbo].[MATERIAL_MASTER_CPS_HEADER] B WITH(NOLOCK) ON B.Material = A.MTRL_NBR " +
                "where DLVRY_NBR like '%"+ deliveryNum + "' and DLVRY_ITM like '%"+ item + "'";

            using (SqlConnection sqlCon = new SqlConnection(MyGlobal.getCString()))
            {
                sqlCon.Open();
                log.Info(" getMaterial()  " + sql );
                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.CommandTimeout = 0;//infinite
                    cmd.CommandType = CommandType.Text;
                  
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                matDao = new MatDao();                            
                               
                                String DLVRY_NBR = string.Empty;
                                string DLVRY_ITM = string.Empty;
                                string Mat_Desc = string.Empty;
                                string BTCH_NBR = string.Empty;
                                string MTRL_NBR = string.Empty;
                                string PLNT = string.Empty;
                                Decimal GRS_WT = (Decimal)0.0;
                                string WT_UOM_CD = string.Empty; ;
                                string rev = string.Empty; ;



                                if (reader["DLVRY_NBR"].GetType() != typeof(DBNull))
                                {
                                      DLVRY_NBR = (string)reader["DLVRY_NBR"];
                                }

                                if (reader["DLVRY_ITM"].GetType() != typeof(DBNull))
                                {
                                    DLVRY_ITM = (string)reader["DLVRY_ITM"];
                                }

                                if (reader["Mat_Desc"].GetType() != typeof(DBNull))
                                {
                                    Mat_Desc = (string)reader["Mat_Desc"];
                                }

                                if (reader["BTCH_NBR"].GetType() != typeof(DBNull))
                                {
                                    BTCH_NBR = (string)reader["BTCH_NBR"];
                                }

                                if (reader["MTRL_NBR"].GetType() != typeof(DBNull))
                                {
                                    MTRL_NBR = (string)reader["MTRL_NBR"];
                                }

                                if (reader["PLNT"].GetType() != typeof(DBNull))
                                {
                                    PLNT = (string)reader["PLNT"];
                                }

                                if (reader["WT_UOM_CD"].GetType() != typeof(DBNull))
                                {
                                    WT_UOM_CD = (string)reader["WT_UOM_CD"];
                                }

                                try
                                {
                                    if (reader["RevLev"].GetType() != typeof(DBNull))
                                    {
                                        rev = (string)reader["RevLev"];
                                    }
                                }catch(Exception ee)
                                {
                                    log.Error("Error in revision ee " + ee.Message);
                                }

                                if (reader["GRS_WT"].GetType() != typeof(DBNull))
                                {
                                    GRS_WT = (Decimal)reader["GRS_WT"];
                                }

                               // Decimal GRS_WT = (Decimal)reader["GRS_WT"];


                                // string DLVRY_ITM = (string)reader["DLVRY_ITM"];
                               // string Mat_Desc = (string)reader["Mat_Desc"];
                               // string BTCH_NBR = (string)reader["BTCH_NBR"];
                               // string MTRL_NBR = (string)reader["MTRL_NBR"];
                              //  string PLNT = (string)reader["PLNT"];                               
                              //  string WT_UOM_CD = (string)reader["WT_UOM_CD"];
                               // string rev = (string)reader["RevLev"];


                                matDao.DeliveryNum = DLVRY_NBR;
                                matDao.DeliveryItem = DLVRY_ITM;
                                matDao.BatchNum = BTCH_NBR;
                                matDao.GrossWeight = GRS_WT;
                                matDao.MaterialDesc = Mat_Desc;
                                matDao.MaterialNum = MTRL_NBR.TrimStart(new Char[] { '0' });
                                matDao.Plant = PLNT;
                                matDao.WeightUnit = WT_UOM_CD;
                                matDao.MaterialRev = rev;

                                log.Info("DeliveryNum=" + DLVRY_NBR + ",BTCH_NBR= " + BTCH_NBR + ", MaterialDesc=" + Mat_Desc);
                            }
                        }catch(Exception ee)
                        {
                            log.Error("Error in ee " + ee.Message);
                        }

                    }
                }
            }

            return matDao;
        }

        private static string ApmfgCString =   @"Data Source=APMFGDBS001;Initial Catalog=MPM;User ID=iusr_server;Password=iusr";
        public static void doWifiPrinter()
        {
            int affRows = 0;
            log.Info(" string = " + MyGlobal.getApmfgCString());
            using (SqlConnection cnn = new SqlConnection(ApmfgCString))
            {
                cnn.Open();
                log.Info(" doWifiPrinter  ");
                string error_code = "";
                string error_msg = "";

                using (SqlCommand cmd = new SqlCommand("MPM.HSP_PrintLogisticsPartLabels", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        string json = "[{\"QrMaterial\":\"100006488\",\"Material\":\"100006488\",\"MaterialDesc1\":\"PKR.HF 1.9653 TBG\",\"MaterialDesc2\":\"PCL REL..NX1\",\"SearialNo\":\"4443432 - 05\",\"Weights\":\"0.6 LB\"}]";
                        log.Info("Json = " + json);

                        cmd.Parameters.Add(new SqlParameter("@Plant_CD", "2088"));
                        cmd.Parameters.Add(new SqlParameter("@Empl_Nbr", "00691364"));
                        cmd.Parameters.Add(new SqlParameter("@Prntr_Oid", 906));
                        cmd.Parameters.Add(new SqlParameter("@LabelSize", 12));
                        cmd.Parameters.Add(new SqlParameter("@UpdateJson", json));
                        cmd.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.VarChar, 10));
                        cmd.Parameters.Add(new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 250));
                       

                       // cmd.Parameters.Add("@ClientName", SqlDbType.VarChar, 100);
                        //cmd.Parameters["@ClientName"].Direction = ParameterDirection.Output;

                        cmd.Parameters["@ErrorCode"].Direction = ParameterDirection.Output;
                        cmd.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;

                        affRows = cmd.ExecuteNonQuery();
                        log.Info("Affrows = " + affRows);

                        error_code = Convert.ToString(cmd.Parameters["@ErrorCode"].Value);
                        error_msg = Convert.ToString(cmd.Parameters["@ErrorMessage"].Value);

                        log.Info("Error code " + error_code + ", error_msg=" + error_msg + "\n");
                    }catch(Exception ee)
                    {
                        log.Error("EE = " + ee.Message);
                    }
                }
            }
        }



        public static ArrayList getAllSubCategories(String maincat, string plant)
        {
            ArrayList al = new ArrayList();

            string sql = "select sub_category from t_tool where category='" + maincat + "' and plant='" + plant + "'" +
                " group by sub_category order by sub_category";
            using (SqlConnection sqlCon = new SqlConnection(MyGlobal.getCString()))
            {
                sqlCon.Open();
                log.Info(" getAllSubCategories()  " + sql);
                using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            String cat = (string)reader["sub_category"];
                            al.Add(cat);
                        }
                    }
                }
            }

            return al;
        }


        public static MatDao doFetchMaterial(String ponum)
        {
            MatDao dao = null;
            

            string sql = " select po.PROD_ORDR_NBR, po.BTCH_NBR , po.TOT_ORDR_QTY , substring(m.mtrl_nbr, 10, 20) as MTRL_NBR, m.GRS_WGHT, m.BASE_UOM_CD, m.DRAW_DOC_NBR, m.OLD_MTRL_NBR " +
                " from PROD_ORDR po  inner join mtrl m on po.mtrl_oid = m.oid where po.PROD_ORDR_NBR like '%" + ponum + "'; ";
            try
            {
                using (SqlConnection cnn = new SqlConnection(MyGlobal.getCString4SCGREPORTING()))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dao = new MatDao();
                                dao.BatchNum = (string)reader["BTCH_NBR"];
                                dao.MaterialNum = (string)reader["MTRL_NBR"];
                                dao.OldMaterialNum = (string)reader["OLD_MTRL_NBR"];
                                decimal qty = (decimal)reader["TOT_ORDR_QTY"];
                                log.Info("qty = "+qty);
                                dao.TotOrdQty = (Int32) qty;

                                //remove prefix
                                if (dao.MaterialNum.Length > 10)
                                {
                                    string mnum = dao.MaterialNum;
                                    //000000000102112963
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ee)
            {
                log.Info("DBUtils doFetchMaterial() ee = " + ee.Message);
                
            }

            return dao;
        }

    }
}
