using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Log4Net;
//using BIMTClassLibrary.db;

namespace BIMTClassLibrary.DBF
{
    public class LocalDBHelper
    {
        public static string m_strDBPath = PublicVar.DBFilePath;


        public LocalDBHelper()
        {
            
        }
        /// <summary>
        /// 查询dbf文件
        /// </summary>
        /// <param name="p_strSQL"></param>
        /// <returns></returns>
        public static DataSet ExcuteQuery(string p_strSQL)
        {
            //string _strDbPath = m_strDBPath;
//            string connectString = @"Provider=VFPOLEDB.1;Data Source=" + _strDbPath + @";
//                                    Mode=Share Deny None;
//                                    User ID="";
//                                    Mask Password=False;
//                                    Cache Authentication=False;
//                                    Encrypt Password=False;
//                                    Collating Sequence=MACHINE;DSN="";
//                                    DELETED=True;
//                                    CODEPAGE=936;
//                                    MVCOUNT=16384;
//                                    ENGINEBEHAVIOR=90;
//                                    TABLEVALIDATE=3;
//                                    REFRESH=5;
//                                    VARCHARMAPPING=False;
//                                    ANSI=True;
//                                    REPROCESS=5;";
            //LiteratureDataSet literature = new LiteratureDataSet();
            //literature.Tables["literature"].Rows.
            string connectString = PublicVar.ConnectString;// string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", _strDbPath);
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(p_strSQL, connection);
                    command.Fill(ds, "ds");
                    return ds;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(typeof(LocalDBHelper),ex);
                }
            }
            return null;
        }

      
        /// <summary>
        /// 操作写入DBF数据 wuahilong 2016-04-12
        /// </summary>
        /// <param name="strFileName">DBF文件全路径</param>
        /// <param name="p_strSQL">SQL语句</param>
        /// <returns>true：执行成功 false 执行失败</returns>
        public static int ExcuteNonQuery(string p_strSQL)
        {
            try
            {
                //string strFileName = m_strDBPath;
                //string strPath = strFileName.Substring(0, strFileName.LastIndexOf('\\'));
                //string strName = strFileName.Substring(strFileName.LastIndexOf('\\') + 1);
                string strConstr = PublicVar.ConnectString;// @"Provider=VFPOLEDB.1;Data Source=" + strFileName + @";Mode=Share Deny None;User ID="";Mask Password=False;Cache Authentication=False;Encrypt Password=False;Collating Sequence=MACHINE;DSN="";DELETED=True;CODEPAGE=936;MVCOUNT=16384;ENGINEBEHAVIOR=90;TABLEVALIDATE=3;REFRESH=5;VARCHARMAPPING=False;ANSI=True;REPROCESS=5;";
                using (OleDbConnection con = new OleDbConnection(strConstr))
                {
                    con.Open();
                    OleDbCommand cmdInsert = new OleDbCommand();
                    cmdInsert.Connection = con;
                    cmdInsert.CommandText = p_strSQL;
                    return cmdInsert.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(LocalDBHelper), ex);
            }
            return -1;
        }
    }
}
