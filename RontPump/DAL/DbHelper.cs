using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DbHelper
    {
        public static string conStr = ConfigurationManager.ConnectionStrings["conStr"].ToString();



        /// <summary>
        /// 数据库连接---zfcony
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(conStr);
            }
        }

        /// <summary>
        /// 返回受影响的行数(存储过程)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static int ExecuteCommandByProc(string sql, params SqlParameter[] para)
        {
            int num = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                num = cmd.ExecuteNonQuery();
                con.Close();
            }
            return num;
        }
        /// <summary>
        /// 返回受影响的行数(sql语句)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static int ExecuteCommandBySql(string sql, params SqlParameter[] para)
        {
            int num = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                num = cmd.ExecuteNonQuery();
                con.Close();
            }
            return num;
        }
        /// <summary>
        /// 获得DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        #region 获取DataSet
        public static DataSet GetDataSetBySql(string sql, params SqlParameter[] para)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(ds);
                con.Close();
            }

            return ds;
        }
        #endregion
        /// <summary>
        /// 获得ExecuteScalar的值(判断有无对应数据数据)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        #region 获得ExecuteScalarBySql的值
        public static object ExecuteScalarBySql(string sql, params SqlParameter[] para)
        {
            object scalar = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                scalar = cmd.ExecuteScalar();
                con.Close();
            }
            return scalar;

        }
        #endregion
        /// <summary>
        /// 获得ExecuteScalar的值(判断有无对应数据数据)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        #region 获得ExecuteScalarByProc的值
        public static object ExecuteScalarByProc(string sql, params SqlParameter[] para)
        {
            object scalar = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                scalar = cmd.ExecuteScalar();
                con.Close();
            }
            return scalar;

        }
        #endregion
        /// <summary>
        /// 获取存储过程中的dataset
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        #region 获取存储过程中的dataset
        public static DataSet GetDataSetByProc(string sql, params SqlParameter[] para)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(ds);
                con.Close();
            }
            return ds;
        }
        #endregion


        //以下方法来自---zfcony

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
    }
}
