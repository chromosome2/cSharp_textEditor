using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TextEditor_na_sm
{
    public class C_na
    {
        OracleConnection conn;
        public C_na() 
        {
            try
            {
                //ORACLE 연결
                string constr = "Data Source = (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.86.231)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE)));" +
                    "User Id = c##testArticle;" +
                    "Password = 1234 ;";

                conn = new OracleConnection(constr);
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("ORACLE 데이터베이스 연결 실패입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataSet VIEW(string num)
        {
            string query = "SELECT * FROM NAVER_ARTICLE_LIST";
            if (!string.IsNullOrEmpty(num))
            {
                query += " WHERE ARTICLENUM = " + num;
            }
            OracleCommand cmd = new OracleCommand(query, conn);
            OracleDataAdapter oraAdapter = new OracleDataAdapter();
            DataSet ds = new DataSet();

            oraAdapter = new OracleDataAdapter(query, conn);
            oraAdapter.Fill(ds);

            conn.Close();

            return ds;
        }

        public void INSERT(string title, string content)
        {
            //string query = "INSERT INTO NAVER_ARTICLE_LIST (title, cont) VALUES('" + title + "', ";
            //content = content.Replace("'", "''");

            //string str = "";
            //int cnt = content.Length % 4000 > 0 ? content.Length / 4000 + 1 : content.Length/4000;
            //for (int i=0; i<cnt; i++)
            //{
            //    str = i + 1 != cnt ? content.Substring(i*4000, 4000) : content.Substring(i * 4000, content.Length % 4000);
            //    query += " TO_CLOB('" + str + "') ";
            //    if(i + 1 != cnt)
            //    {
            //        query += " || ";
            //    }
            //}

            //query += " );";

            //OracleCommand cmd = new OracleCommand(query, conn);

            //cmd.ExecuteNonQuery();

            //conn.Close();




            OracleCommand cmd = new OracleCommand();

            OracleDataAdapter oraAdapter = new OracleDataAdapter();



            cmd.CommandText = "INSERT_NAVER";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("P_TITLE", OracleDbType.Varchar2).Value = title;
            cmd.Parameters.Add("P_CONT", OracleDbType.Clob).Value = content;

            cmd.Connection = conn;



            cmd.ExecuteNonQuery();

            conn.Dispose();

            conn.Close();
        }

    }
}
