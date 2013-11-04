using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Models;

namespace DAL
{
    public class MemosService
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="mo"></param>
        /// <returns></returns>
        public bool AddMemosInfo(Memos mo)
        {
            string sql = "up_Add_Memos";
            SqlParameter[] para = {
                                      new SqlParameter("@uName",mo.UserName),
                                      new SqlParameter("@TelPhone",mo.TelPhone),
                                      //new SqlParameter("@Zhiwei",mo.Zhiwei),
                                      //new SqlParameter("@Address",mo.CopAddress),
                                      new SqlParameter("@cop",mo.Cop),
                                      new SqlParameter("@content",mo.MemosContent),
                                      //new SqlParameter("@brand",mo.BrandName),
                                      //new SqlParameter("@web",mo.BrandWeb),
                                      //new SqlParameter("@obj",mo.Pkobj),
                                      //new SqlParameter("@hanye",mo.Hanye)
                                      new SqlParameter("@Email",mo.Email)
                                  };
            if (DbHelper.ExecuteCommandByProc(sql,para)>0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p"></param>
        public void DelMemos(int p)
        {
            string sql = "delete Memos where ID=@id";
            SqlParameter[] para = {
                                      new SqlParameter("@id",p)
                                  };
            DbHelper.ExecuteCommandBySql(sql,para);
        }
        /// <summary>
        /// 读取所有
        /// </summary>
        /// <returns></returns>
        public List<Memos> GetMemosList(int id)
        {
            List<Memos> list = new List<Memos>();
            string sql = "proc_Get_MemosList";
            SqlParameter[] para = {
                                      new SqlParameter("@id",id)
                                  };
            DataSet ds = DbHelper.GetDataSetByProc(sql,para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Memos me = new Memos();
                me.ID = Convert.ToInt32(dr["ID"]);
                me.UserName=dr["UserName"].ToString();
                me.TelPhone = dr["TelPhone"].ToString();
                //me.Cop = dr["Cop"].ToString();
                me.Cop = (Convert.IsDBNull(dr["Cop"]) ? "" : Convert.ToString(dr["Cop"]));
                me.Email = dr["Email"].ToString();
                //me.Zhiwei = dr["Zhiwei"].ToString();
                me.SubTime = dr["SubTime"].ToString();
                list.Add(me);
            }
            return list;
        }

        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Memos GetMemos(int id)
        {
            Memos me = new Memos();
            string sql = "select * from Memos where id=@id";
            SqlParameter[] para = {
                                      new SqlParameter("@id",id)
                                  };
            DataSet ds = DbHelper.GetDataSetBySql(sql,para);
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                me.UserName = dr["UserName"].ToString();
                me.TelPhone = dr["TelPhone"].ToString();
                me.Cop = dr["Cop"].ToString();
                me.Zhiwei = dr["Zhiwei"].ToString();
                me.MemosContent = dr["MemosContent"].ToString();
                me.SubTime = dr["SubTime"].ToString();
                me.Hanye = dr["Hanye"].ToString();
                me.BrandName = dr["BrandName"].ToString();
                me.BrandWeb = dr["BrandWeb"].ToString();
                me.Email = dr["Email"].ToString();
            }
            return me;
        }

        /// <summary>
        /// 设置为已读
        /// </summary>
        /// <param name="id"></param>
        public void UpdateMemosIsRead(int id)
        {
            string sql = "update Memos set IsRead=1 where id=@id";
            SqlParameter[] para = {
                                      new SqlParameter("@id",id)
                                  };
            DbHelper.ExecuteCommandBySql(sql,para);
        }
    }
}
