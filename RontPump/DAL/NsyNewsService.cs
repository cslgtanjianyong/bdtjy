using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class NsyNewsService
    {
        public List<NsyNews> GetNsyNewList(Pages pg)
        {
            List<NsyNews> list=new List<NsyNews>();
            string sql = "proc_NsyNews_fenye";
            SqlParameter[] para ={
                                     new SqlParameter("@pageIndex",pg.PageIndex),
                                     new SqlParameter("@pageSize",pg.PagesSize),
                                     new SqlParameter("@ListName",pg.types),
                                     new SqlParameter("@require",pg.Tiaojian)
                                };
            DataSet ds = DbHelper.GetDataSetByProc(sql, para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                NsyNews news = new NsyNews();
                news.ID = Convert.ToInt32(dr["ID"]);
                news.Title = dr["Title"].ToString();
                news.Contents = dr["Contents"].ToString();
                news.AddTime = Convert.ToDateTime(dr["AddTime"]);
                list.Add(news);
            }
            return list;
        }

        public bool DelNsyNews(int p)
        {
            string sql = "delete NsyNews where ID=@id";
            SqlParameter[] para ={
                                     new SqlParameter("@id",p)
                                };
            if (DbHelper.ExecuteCommandBySql(sql, para) > 0)
            {
                return true;
            }
            return false;
        }

        public int getCount()
        {
            string sql = "select count(1) from NsyNews ";
            int counts = (int)DbHelper.ExecuteScalarBySql(sql);
            return counts;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public bool AddNsyNews(NsyNews news,out int id)
        {
            string sql = "proc_Add_NsyNews";
            SqlParameter thisID = new SqlParameter("@thisID", 0);
            thisID.Direction = ParameterDirection.Output;
            SqlParameter[] para = {
                                      new SqlParameter("@title",news.Title),
                                      new SqlParameter("@contents",news.Contents),
                                      thisID
                                  };
            id = 0;
            if (DbHelper.ExecuteCommandByProc(sql,para)>0)
            {
                id = Convert.ToInt32(thisID.Value);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取一个
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public NsyNews GetNsyNews(int d)
        {
            NsyNews news = new NsyNews();
            string sql = "select * from NsyNews where ID=@id";
            SqlParameter[] para ={
                                     new  SqlParameter("@id",d)
                                };
            DataSet ds = DbHelper.GetDataSetBySql(sql, para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                news.ID = Convert.ToInt32(dr["ID"]);
                news.Title = dr["Title"].ToString();
                news.Contents = dr["Contents"].ToString();
                news.AddTime = Convert.ToDateTime(dr["AddTime"]);
            }
            return news;
        }

        public bool EditNsyNews(NsyNews news)
        {
            string sql = "proc_Edit_NsyNews";
            SqlParameter[] para = {
                                      new SqlParameter("@title",news.Title),
                                      new SqlParameter("@contents",news.Contents),
                                      new  SqlParameter("@id",news.ID)
                                  };
            if (DbHelper.ExecuteCommandByProc(sql,para)>0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 根据标题获取内容
        /// </summary>
        /// <param name="til"></param>
        /// <returns></returns>
        public int GetNsyNewsID(string til)
        {
            int d=-1;
            string sql = "select ID from NsyNews where Title=@til";
            SqlParameter[] para = {
                                    new SqlParameter("@til",til)
                                };
            d = (int)DbHelper.ExecuteScalarBySql(sql, para);
            return d;
        }
        /// <summary>
        /// 前台分页显示新闻列表
        /// </summary>
        /// <param name="fldNamet"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCurren"></param>
        /// <param name="fldSort"></param>
        /// <param name="Sort"></param>
        /// <param name="strWhere"></param>
        /// <param name="pageCount"></param>
        /// <param name="Counts"></param>
        /// <returns></returns>
        public List<NsyNews> GetNsyNewListById(string fldNamet, int PageSize, int PageCurren, string fldSort, string Sort, string strWhere, out int pageCount, out int Counts)
        {
            Counts = 0;
            SqlParameter outPageCount = new SqlParameter("@pageCount", 4);
            outPageCount.Direction = ParameterDirection.Output;
            SqlParameter outCounts = new SqlParameter("@Counts", 4);
            outCounts.Direction = ParameterDirection.Output;
            SqlParameter[] para = {
                                    new SqlParameter("@tblName","NsyNews"),
                                     new SqlParameter("@fldName",fldNamet),
                                     new SqlParameter("@pageSize",PageSize),
                                     new SqlParameter("@page",PageCurren),
                                     new SqlParameter("@fldSort",fldSort),
                                     new SqlParameter("@Sort",Sort),
                                     new SqlParameter("@strWhere",strWhere),

                                     new SqlParameter("@ID","ID"),
                                     new SqlParameter("@Dist",0),
                                     //new SqlParameter("@pageCount",4),
                                     outPageCount,
                                     outCounts
                                     //new SqlParameter("@Counts",4)

                                  };
            List<NsyNews> list = new List<NsyNews>();
            using (SqlDataReader dr = DbHelper.ExecuteReader("Proc_ListPage", para, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    NsyNews vp = new NsyNews();
                    vp.ID = Convert.ToInt32(dr["ID"]);
                    vp.Title = dr["Title"].ToString();
                    vp.AddTime=Convert.ToDateTime(dr["AddTime"]);
                    list.Add(vp);
                }
                dr.Close();
            }
            pageCount = Convert.ToInt32(outPageCount.Value);
            Counts = Convert.ToInt32(outCounts.Value);
            return list;
        }
    }
}
