using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    /// <summary>
    /// 内部方法整体改动 
    /// ctid 支持多类
    /// </summary>
    public class CaseService
    {
        /// <summary>
        /// 已修改
        /// </summary>
        /// <param name="_c"></param>
        /// <returns></returns>
        public bool AddCase(Cases _c)
        {
            bool flag = false;

            SqlParameter[] paras = { 
                                    //new SqlParameter("@CTID",_c.CaseType.ID),
                                    new SqlParameter("@CTID",_c.CTID),
                                    new SqlParameter("@CName",_c.CName),
                                    //new SqlParameter("@ImgSrc",_c.SmallIMGURL),
                                    //new SqlParameter("@BigIMGURL",_c.BigIMGURL),
                                    new SqlParameter("@ImgSrc",_c.ImgSrc),
                                    new SqlParameter("@Content",_c.Content),
                                    new SqlParameter("@IsTop",_c.IsTop),
                                    new SqlParameter("@AddTime",_c.AddTime)
                                   };
            flag = SqlHelper.ExecuteNonQuery("proc_AddCase", paras, CommandType.StoredProcedure) > 0 ? true : false;
            return flag;
        }

        /// <summary>
        /// had updated by xiaotian
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cases GetCaseByID(int id)
        {
            Cases cs = new Cases();

            SqlParameter[] para = { 
                                    new SqlParameter("@ID",id)
                                  };
            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_GetCaseByID", para, CommandType.StoredProcedure))
            {
                if (dr.Read())
                {
                    cs.ID = Convert.ToInt32(dr["ID"]);
                    //cs.CaseType.ID = Convert.ToInt32(dr["CTID"]);
                    cs.CTID = Convert.IsDBNull(dr["CTID"]) ? "" : dr["CTID"].ToString();
                    //cs.CaseType.CTName = dr["CTName"].ToString();
                    cs.CName = dr["CName"].ToString();
                    cs.ImgSrc = dr["ImgSrc"].ToString();
                    //cs.SmallIMGURL = Convert.IsDBNull(dr["SmallIMGURL"]) ? "" : dr["SmallIMGURL"].ToString();
                    //cs.BigIMGURL = Convert.IsDBNull(dr["BigIMGURL"]) ? "" : dr["BigIMGURL"].ToString();
                    cs.Content = dr["Content"].ToString();
                    cs.IsTop = Convert.ToBoolean(dr["IsTop"]);
                    cs.AddTime = Convert.ToDateTime(dr["AddTime"]);
                }
                dr.Close();
            }
            return cs;
        }

        //had modified by xiaotian
        //proc_GetCaseListByStrWhere
        public IList<Cases> GetCaseListByStrWhere(int _topN, string strWhere)
        {
            IList<Cases> list = new List<Cases>();

            SqlParameter[] paras = { 
                                    new SqlParameter("@TopN",_topN),
                                    new SqlParameter("@StrWhere",strWhere)
                                   };
            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_GetCaseListByStrWhere", paras, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    Cases cs = new Cases();
                    cs.ID = Convert.ToInt32(dr["ID"]);
                    //cs.CaseType.ID = Convert.ToInt32(dr["CTID"]);
                    cs.CTID = Convert.IsDBNull(dr["CTID"]) ? "" : dr["CTID"].ToString();
                    cs.CName = dr["CName"].ToString();
                    cs.ImgSrc = dr["ImgSrc"].ToString();
                    //cs.SmallIMGURL = Convert.IsDBNull(dr["SmallIMGURL"]) ? "" : dr["SmallIMGURL"].ToString();
                    //cs.BigIMGURL = Convert.IsDBNull(dr["BigIMGURL"]) ? "" : dr["BigIMGURL"].ToString();
                    cs.Content = dr["Content"].ToString();
                    cs.IsTop = Convert.ToBoolean(dr["IsTop"]);
                    cs.AddTime = Convert.ToDateTime(dr["AddTime"]);
                    list.Add(cs);
                }
                dr.Close();
            }

            return list;
        }

        //had updated by xiaotian
        //proc_GetCaseListNoTopByStrWhere
        public IList<Cases> GetCaseListByStrWhere(string strWhere)
        {
            IList<Cases> list = new List<Cases>();

            SqlParameter[] paras = { 
                                    new SqlParameter("@StrWhere",strWhere)
                                   };
            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_GetCaseListNoTopByStrWhere", paras, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    Cases cs = new Cases();
                    cs.ID = Convert.ToInt32(dr["ID"]);
                    //cs.CaseType.ID = Convert.ToInt32(dr["CTID"]);
                    cs.CTID = Convert.IsDBNull(dr["CTID"]) ? "" : dr["CTID"].ToString();
                    cs.CName = dr["CName"].ToString();
                    cs.ImgSrc = dr["ImgSrc"].ToString();
                    //cs.SmallIMGURL = Convert.IsDBNull(dr["SmallIMGURL"]) ? "" : dr["SmallIMGURL"].ToString();
                    //cs.BigIMGURL = Convert.IsDBNull(dr["BigIMGURL"]) ? "" : dr["BigIMGURL"].ToString();
                    cs.Content = dr["Content"].ToString();
                    cs.IsTop = Convert.ToBoolean(dr["IsTop"]);
                    cs.AddTime = Convert.ToDateTime(dr["AddTime"]);
                    list.Add(cs);
                }
                dr.Close();
            }

            return list;
        }

        #region 通过IDS删除——by-cony
        /// <summary>
        /// 通过IDS删除——by-cony
        /// </summary>
        /// <param name="IDS"></param>
        /// <returns></returns>
        public int DeleteCasesByIDS(string IDS)
        {
            int rowsAffected = 0;
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@IDS", IDS) };
            rowsAffected = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Pro_DeleteCasesByIDS", param);
            return rowsAffected;
        }
        #endregion

        #region 修改Cases--zfcony
        /// <summary>
        /// 修改Cases
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateCasesById(Cases _info)
        {
            string sql = "proc_UpdateCases";
            SqlParameter[] para = {
                                      new SqlParameter("@ID",_info.ID),
                                      //new SqlParameter("@CTID",_info.CaseType.ID),
                                      new SqlParameter("@CTID",_info.CTID),
                                      new SqlParameter("@CName",_info.CName),
                                      new SqlParameter("@ImgSrc",_info.ImgSrc),
                                      //new SqlParameter("@SmallIMGURL",_info.SmallIMGURL),
                                      //new SqlParameter("@BigIMGURL",_info.BigIMGURL),
                                      new SqlParameter("@Content",_info.Content),
                                      new SqlParameter("@IsTop",_info.IsTop)
                                  };
            if (DbHelper.ExecuteCommandByProc(sql, para) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 修改Cases取消置顶操作--zfcony
        /// <summary>
        /// 修改Cases取消置顶操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateQxIsTopByID(int _id)
        {
            string sql = "proc_UpdateQxIsTopByID";
            SqlParameter[] para = {
                                      new SqlParameter("@ID",_id),
                                  };
            if (DbHelper.ExecuteCommandByProc(sql, para) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 修改Cases设置置顶操作--zfcony
        /// <summary>
        /// 修改Cases设置置顶操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateSZIsTopByID(int _id)
        {
            string sql = "proc_UpdateSZIsTopByID";
            SqlParameter[] para = {
                                      new SqlParameter("@ID",_id),
                                  };
            if (DbHelper.ExecuteCommandByProc(sql, para) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region list page for product
        public IList<Cases> GetPagedProducts(string tblName, string fldName, int pageSize, int currentPageIndex, string fldSort, bool sort, string strWhere, out int pageCount, out int counts)
        {
            IList<Cases> list = new List<Cases>();
            counts = 0;
            SqlParameter outPageCount = new SqlParameter("@pageCount", 4);
            outPageCount.Direction = ParameterDirection.Output;
            SqlParameter outCounts = new SqlParameter("@Counts", 4);
            outCounts.Direction = ParameterDirection.Output;
            SqlParameter[] para = {
                                    new SqlParameter("@tblName",tblName),
                                     new SqlParameter("@fldName",fldName),
                                     new SqlParameter("@pageSize",pageSize),
                                     new SqlParameter("@page",currentPageIndex),
                                     new SqlParameter("@fldSort",fldSort),
                                     new SqlParameter("@Sort",sort),
                                     new SqlParameter("@strWhere",strWhere),

                                     new SqlParameter("@ID","ID"),
                                     new SqlParameter("@Dist",0),
                                     //new SqlParameter("@pageCount",4),
                                     outPageCount,
                                     outCounts
                                     //new SqlParameter("@Counts",4)

                                  };
            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_ListPageForProduct", para, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    Cases cs = new Cases();
                    cs.ID = Convert.ToInt32(dr["ID"]);
                    //cs.CaseType.ID = Convert.ToInt32(dr["CTID"]);
                    cs.CTID = Convert.IsDBNull(dr["CTID"]) ? "" : dr["CTID"].ToString();
                    cs.CName = dr["CName"].ToString();
                    cs.ImgSrc = dr["ImgSrc"].ToString();
                    //cs.SmallIMGURL = Convert.IsDBNull(dr["SmallIMGURL"]) ? "" : dr["SmallIMGURL"].ToString();
                    //cs.BigIMGURL = Convert.IsDBNull(dr["BigIMGURL"]) ? "" : dr["BigIMGURL"].ToString();
                    cs.Content = dr["Content"].ToString();
                    cs.IsTop = Convert.ToBoolean(dr["IsTop"]);
                    cs.AddTime = Convert.ToDateTime(dr["AddTime"]);
                    list.Add(cs);
                }
                dr.Close();
            }
            pageCount = Convert.ToInt32(outPageCount.Value);
            counts = Convert.ToInt32(outCounts.Value);
            return list;
        }
        #endregion

        #region 获取前十个案例图 --zfcony
        /// <summary>
        /// 获取前十个案例图
        /// </summary>
        /// <param name="p">id</param>
        /// <returns></returns>
        public List<Cases> GetCasesListById_top10()
        {
            List<Cases> list = new List<Cases>();
            string sql = "select top 10 ID,CName,IsTop,AddTime,ImgSrc from Cases where 1=1 order by IsTop desc, AddTime desc";
            SqlParameter[] para = { };
            DataSet ds = DbHelper.GetDataSetBySql(sql, para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Cases vp = new Cases();
                vp.ID = Convert.ToInt32(dr["ID"]);
                vp.ImgSrc = dr["ImgSrc"].ToString();

                vp.CName = dr["CName"].ToString();
                vp.AddTime = Convert.ToDateTime(dr["AddTime"]);
                list.Add(vp);
            }
            return list;
        }
        #endregion

    }
}