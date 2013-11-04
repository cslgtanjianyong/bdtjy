using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BoCaseTypeService
    {
        /// <summary>
        /// 添加一个分类
        /// </summary>
        /// <param name="tpName"></param>
        /// <returns></returns>
        public bool AddCaseType(string tpName)
        {
            string sql = "insert into BoCaseType (TypeName) values(@TypeName)";
            SqlParameter[] para ={
                                     new SqlParameter("@TypeName",tpName)
                                };
            if (DbHelper.ExecuteCommandBySql(sql,para)>0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取案例分类列表
        /// </summary>
        /// <returns></returns>
        public List<BoCaseType> GetBoCaseType()
        {
            List<BoCaseType> list=new List<BoCaseType>();
            string sql = "select ID,TypeName from BoCaseType";
            DataSet ds = DbHelper.GetDataSetBySql(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BoCaseType tp = new BoCaseType();
                tp.ID = Convert.ToInt32(dr["ID"]);
                tp.TypeName = dr["TypeName"].ToString();
                list.Add(tp);
            }
            return list;
        }
    }
}
