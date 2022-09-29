using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace MyUtils.Function
{
    /// <summary>
    /// oracle工具类
    /// </summary>
    public static class DBUtils
    {
        public static string Host = "192.168.0.40";
        public static string Port = "1521";
        public static string ServiceName = "sunsoft";
        public static string UserName= "bsfy";
        public static string Password = "bsfy";

        public static DataTable GetSqlData(string sql)
        {
            OracleConnection conn = null;
            try
            {
                conn = OpenConn();
                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string conumn = reader.GetName(i);
                        if (!dt.Columns.Contains(conumn))
                        {
                            DataColumn dc = new DataColumn();
                            dc.ColumnName = conumn;
                            dt.Columns.Add(dc);
                        }
                        dr[i] = reader[i];
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
            finally
            {
                CloseConn(conn);
            }
            return null;
        }

        private static OracleConnection OpenConn()
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={Host})(PORT={Port}))(CONNECT_DATA=(SERVICE_NAME={ServiceName})));Persist Security Info=True;User ID={UserName};Password={Password};";
            conn.Open();
            return conn;
        }

        private static void CloseConn(OracleConnection conn)
        {
            if (conn == null) { return; }
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
