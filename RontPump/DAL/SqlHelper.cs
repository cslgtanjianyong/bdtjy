using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class SqlHelper
    {

        private static readonly string connString = ConfigurationManager.ConnectionStrings["conStr"].ToString();

        /// <summary>
        /// 数据库连接
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connString);
            }
        }

        /// <summary>
        /// 使用T-SQL语句或存储过程执行增删改
        /// </summary>
        /// <param name="sqlName">T-SQL语句或存储过程</param>
        /// <param name="pars">参数列表</param>
        /// <param name="cmdType">命令类型</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(string sqlName, SqlParameter[] pars, CommandType cmdType)
        {
            int result = 0;
            using (SqlConnection conn = Connection)
            {
                SqlCommand cmd = new SqlCommand(sqlName, conn);
                try
                {
                    cmd.CommandType = cmdType;
                    cmd.Parameters.AddRange(pars);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return result;
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 使用T-SQL语句或存储过程执行查询
        /// </summary>
        /// <param name="sqlName">T-SQL语句或存储过程</param>
        /// <param name="pars">参数列表</param>
        /// <param name="cmdType">命令类型</param>
        /// <returns>reader对象</returns>
        public static SqlDataReader ExecuteReader(string sqlName, SqlParameter[] pars, CommandType cmdType)
        {
            SqlDataReader rd = null;
            SqlConnection conn = Connection;
            SqlCommand cmd = new SqlCommand(sqlName, conn);
            try
            {
                cmd.CommandType = cmdType;
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }
                conn.Open();
                rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
            }
            return rd;
        }
        /// <summary>
        /// 获取一行一列的值
        /// </summary>
        /// <param name="sqlName"></param>
        /// <param name="paras"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sqlName, SqlParameter[] paras, CommandType cmdType)
        {
            object result = null;
            using (SqlConnection conn = Connection)
            {
                SqlCommand cmd = new SqlCommand(sqlName, conn);
                try
                {
                    cmd.CommandType = cmdType;
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    conn.Open();
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    conn.Close();
                }
            }
            return result;
        }
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        public static DataSet GetDataSet(String strSql)
        {
            SqlConnection p_Conn = new SqlConnection(connString);
            SqlDataAdapter p_Dr = new SqlDataAdapter(strSql, p_Conn);
            DataSet p_Ds = new DataSet();
            p_Dr.Fill(p_Ds);
            p_Dr.Dispose();
            p_Conn.Dispose();
            return p_Ds;
        }
        public static DataSet GetDataSet(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 300;
            try
            {
                PrepareCommand(sqlCmd, sqlConn, null, cmdType, cmdText, cmdParams);
                SqlDataAdapter cmdDa = new SqlDataAdapter();
                cmdDa.SelectCommand = sqlCmd;
                DataSet ds = new DataSet();
                cmdDa.Fill(ds);

                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConn.Dispose();
            }
        }

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }


}
