using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ViewPointService
    {
        /// <summary>
        /// 添加一个观点
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        public bool AddViewPoint(ViewPoint _info, out int id)
        {
            string sql = "proc_Add_ViewPoint";
            SqlParameter thisID = new SqlParameter("@thisID", 0);
            thisID.Direction = ParameterDirection.Output;
            SqlParameter[] para ={
                                     new SqlParameter("@article",_info.Article),
                                     new SqlParameter("@title",_info.Title),
                                     new SqlParameter("@TpId",_info.TpId),
                                     new SqlParameter("@Istop",_info.Istop),
                                     new SqlParameter("@vtag",_info.vtag),
                                     new SqlParameter("@MetaKey",_info.MetaKey),
                                     new SqlParameter("@MetaDesc",_info.MetaDesc),
                                     new SqlParameter("@CShortDes",_info.CShortDes),
                                     thisID
                                };
            id = 0;
            if (DbHelper.ExecuteCommandByProc(sql, para) > 0)
            {
                id = Convert.ToInt32(thisID.Value);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获得页数
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public int getCount(int d)
        {
            string sql = "select count(1) from ViewPoint ";
            if (d != 0)
            {
                sql += " where TpId=@id";
            }
            SqlParameter[] para ={
                                     new SqlParameter("@id",d)
                                };
            int counts = (int)DbHelper.ExecuteScalarBySql(sql, para);
            return counts;

        }
        /// <summary>
        /// 获得观点列表
        /// </summary>
        /// <param name="pg"></param>
        /// <returns></returns>
        public List<ViewPointExtend> GetViewPointList(Pages pg)
        {
            List<ViewPointExtend> list = new List<ViewPointExtend>();
            string sql = "proc_ViewPoint_fenye";
            SqlParameter[] para ={
                                     new SqlParameter("@pageIndex",pg.PageIndex),
                                     new SqlParameter("@pageSize",pg.PagesSize),
                                     new SqlParameter("@ListName",pg.types),
                                     new SqlParameter("@require",pg.Tiaojian),
                                     new SqlParameter("@id",pg.id)
                                };
            DataSet ds = DbHelper.GetDataSetByProc(sql, para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ViewPointExtend vp = new ViewPointExtend();
                vp.ID = Convert.ToInt32(dr["ID"]);
                vp.Title = dr["Title"].ToString();
                vp.AddTime = Convert.ToDateTime(dr["AddTime"]);
                vp.TypeName = dr["TpName"].ToString();
                vp.Istop = Convert.ToInt32(dr["Istop"]);
                list.Add(vp);
            }
            return list;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool DelViewPoint(int p)
        {
            string sql = "delete ViewPoint where ID=@id";
            SqlParameter[] para ={
                                     new SqlParameter("@id",p)
                                };
            if (DbHelper.ExecuteCommandBySql(sql, para) > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获得一个观点
        /// </summary>
        /// <param name="d">id</param>
        /// <returns></returns>
        public ViewPoint GetViewPoint(int d)
        {
            ViewPoint vp = new ViewPoint();
            string sql = "select Title,Article,TpId,Istop,MetaKey,MetaDesc,vtag,CShortDes from ViewPoint where ID=@id";
            SqlParameter[] para ={
                                     new SqlParameter("@id",d)
                                };
            DataSet ds = DbHelper.GetDataSetBySql(sql, para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                vp.Title = dr["Title"].ToString();
                vp.Article = dr["Article"].ToString();
                vp.TpId = Convert.ToInt32(dr["TpId"]);
                vp.Istop = Convert.ToInt32(dr["Istop"]);
                vp.MetaKey = (Convert.IsDBNull(dr["MetaKey"]) ? "" : Convert.ToString(dr["MetaKey"]));
                vp.MetaDesc = (Convert.IsDBNull(dr["MetaDesc"]) ? "" : Convert.ToString(dr["MetaDesc"]));
                vp.vtag = (Convert.IsDBNull(dr["vtag"]) ? "" : Convert.ToString(dr["vtag"]));
                vp.CShortDes = (Convert.IsDBNull(dr["CShortDes"]) ? "" : Convert.ToString(dr["CShortDes"]));
            }
            return vp;

        }
        public ViewPoint GetViewPointByID(int id)
        {
            ViewPoint vp = new ViewPoint();
            SqlParameter[] para = { 
                                    new SqlParameter("@ID",id)
                                  };
            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_GetViewPointByID", para, CommandType.StoredProcedure))
            {
                if (dr.Read())
                {
                    vp.ID = id;
                    vp.Article = dr["Article"].ToString();
                    vp.TpId = Convert.ToInt32(dr["TpId"]);
                    vp.AddTime = Convert.ToDateTime(dr["AddTime"]);
                    vp.Title = dr["Title"].ToString();
                    vp.Istop = Convert.ToInt32(dr["Istop"]);
                }
                dr.Close();
            }
            return vp;
        }
        public ViewPointExtend GetViewPointExtendByID(int id)
        {
            ViewPointExtend vp = new ViewPointExtend();

            SqlParameter[] para = { 
                                    new SqlParameter("@ID",id)
                                  };

            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_GetViewPointByID", para, CommandType.StoredProcedure))
            {
                if (dr.Read())
                {
                    vp.ID = id;
                    vp.Article = dr["Article"].ToString();
                    vp.TpId = Convert.ToInt32(dr["TpId"]);
                    vp.TypeName = Convert.IsDBNull(dr["TypeName"]) ? "" : dr["TypeName"].ToString();
                    vp.AddTime = Convert.ToDateTime(dr["AddTime"]);
                    vp.Title = dr["Title"].ToString();
                    vp.Istop = Convert.ToInt32(dr["Istop"]);
                }
                dr.Close();
            }
            return vp;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        public bool EditViewPoint(ViewPoint _info)
        {
            string sql = "proc_Edit_ViewPoint";
            SqlParameter[] para ={
                                     new SqlParameter("@ID",_info.ID),
                                     new SqlParameter("@article",_info.Article),
                                     new SqlParameter("@title",_info.Title),
                                     new SqlParameter("@TpId",_info.TpId),
                                     new SqlParameter("@Istop",_info.Istop),
                                     new SqlParameter("@vtag",_info.vtag),
                                     new SqlParameter("@MetaKey",_info.MetaKey),
                                     new SqlParameter("@MetaDesc",_info.MetaDesc),
                                     new SqlParameter("@CShortDes",_info.CShortDes),
                                };
            if (DbHelper.ExecuteCommandByProc(sql, para) > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取前6条数据
        /// </summary>
        /// <param name="p">id</param>
        /// <returns></returns>
        public List<ViewPoint> GetViewPointListById_top6(int p)
        {
            List<ViewPoint> list = new List<ViewPoint>();
            string sql = "select top 6 ID,Title,Istop,AddTime from ViewPoint where TpId=@tpid order by Istop desc, AddTime desc";
            SqlParameter[] para = {
                                  new SqlParameter("@tpid",p)
                                  };
            DataSet ds = DbHelper.GetDataSetBySql(sql, para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ViewPoint vp = new ViewPoint();
                vp.ID = Convert.ToInt32(dr["ID"]);
                vp.Title = dr["Title"].ToString();
                vp.AddTime = Convert.ToDateTime(dr["AddTime"]);
                list.Add(vp);
            }
            return list;
        }
        /// <summary>
        /// 获取前6条数据
        /// </summary>
        /// <param name="p">id</param>
        /// <returns></returns>
        public List<ViewPoint> GetViewPointListById_top6()
        {
            List<ViewPoint> list = new List<ViewPoint>();
            string sql = "select top 6 ID,Title,AddTime from ViewPoint order by AddTime desc";
            DataSet ds = DbHelper.GetDataSetBySql(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ViewPoint vp = new ViewPoint();
                vp.ID = Convert.ToInt32(dr["ID"]);
                vp.Title = dr["Title"].ToString();
                vp.AddTime = Convert.ToDateTime(dr["AddTime"]);
                list.Add(vp);
            }
            return list;
        }
        /// <summary>
        /// 根据id去获取ViewPoint
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public ViewPointExtend GetViewPointTpName(int id)
        {
            ViewPointExtend vp = new ViewPointExtend();
            string sql = "select b.ID, a.AddTime, Title,TypeName,tag,Article,MetaKey,MetaDesc,vtag from ViewPoint a inner join PointType b on a.TpId=b.ID where a.ID=@id";
            SqlParameter[] para = {
                                    new SqlParameter("@id",id)
                                };
            DataSet ds = DbHelper.GetDataSetBySql(sql, para);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                vp.Title = dr["Title"].ToString();
                vp.TypeName = dr["TypeName"].ToString();
                vp.Tag = dr["tag"].ToString();
                vp.Article = dr["Article"].ToString();
                vp.AddTime = Convert.ToDateTime(dr["AddTime"]);
                vp.ID = Convert.ToInt32(dr["ID"]);
                vp.MetaKey = dr["MetaKey"].ToString();
                vp.MetaDesc = dr["MetaDesc"].ToString();
                vp.vtag = dr["vtag"].ToString();
            }
            return vp;
        }

        public List<ViewPoint> GetViewPointList(string tblName, string fldName, int pageSize, int currentPageIndex, string fldSort, bool sort, string strWhere, out int pageCount, out int counts)
        {
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
            List<ViewPoint> list = new List<ViewPoint>();
            using (SqlDataReader dr = DbHelper.ExecuteReader("proc_ListPageForNews", para, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    ViewPoint vp = new ViewPoint();
                    vp.ID = Convert.ToInt32(dr["ID"]);
                    vp.Title = dr["Title"].ToString();
                    vp.CShortDes = dr["CShortDes"].ToString();
                    vp.AddTime = Convert.ToDateTime(dr["AddTime"]);
                    list.Add(vp);
                }
                dr.Close();
            }
            pageCount = Convert.ToInt32(outPageCount.Value);
            counts = Convert.ToInt32(outCounts.Value);
            return list;
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <returns></returns>
        public ViewPoint GetViewPointNext(int id)
        {
            string sql = "select top 1 * from ViewPoint where @id<ID order by ID desc";
            ViewPoint vp = new ViewPoint();
            SqlParameter[] para = {
                                      new SqlParameter("@id",id)
                                  };
            DataSet ds = DbHelper.GetDataSetBySql(sql, para);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                vp.Title = dr["Title"].ToString();
                vp.ID = Convert.ToInt32(dr["ID"]);
            }
            return vp;
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <returns></returns>
        public ViewPoint GetViewPointUp(int id)
        {
            string sql = "select top 1 * from ViewPoint where @id>ID order by ID asc";
            ViewPoint vp = new ViewPoint();
            SqlParameter[] para = {
                                      new SqlParameter("@id",id)
                                  };
            DataSet ds = DbHelper.GetDataSetBySql(sql, para);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                vp.Title = dr["Title"].ToString();
                vp.ID = Convert.ToInt32(dr["ID"]);
            }
            return vp;
        }
        /// <summary>
        /// 推荐观点6条(按时间排序)
        /// </summary>
        /// <returns></returns>
        public List<ViewPointExtend> GetViewPointList()
        {
            List<ViewPointExtend> list = new List<ViewPointExtend>();
            string sql = "select top 4 a.ID,Title,TypeName from ViewPoint a inner join PointType b on a.TpId=b.ID";
            DataSet ds = DbHelper.GetDataSetBySql(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ViewPointExtend vpe = new ViewPointExtend();
                vpe.ID = Convert.ToInt32(dr["ID"]);
                vpe.Title = dr["Title"].ToString();
                vpe.TypeName = dr["TypeName"].ToString();
                list.Add(vpe);
            }
            return list;
        }

        public IList<ViewPointExtend> GetViewPointList(int topN, int tid)
        {
            IList<ViewPointExtend> list = new List<ViewPointExtend>();

            string sql = "select top ( @topN ) vp.ID,vp.Title,vp.AddTime from ViewPoint vp inner join PointType pt on pt.ID = vp.TpId where pt.ID = @Tid order by vp.AddTime desc";

            SqlParameter[] paras = { 
                                    new SqlParameter("@TopN",topN),
                                    new SqlParameter("@Tid",tid)
                                   };

            using (SqlDataReader dr = SqlHelper.ExecuteReader(sql, paras, CommandType.Text))
            {
                while (dr.Read())
                {
                    ViewPointExtend vp = new ViewPointExtend();
                    vp.ID = Convert.IsDBNull(dr["ID"]) ? 0 : Convert.ToInt32(dr["ID"]);
                    vp.Title = Convert.IsDBNull(dr["Title"]) ? "" : dr["Title"].ToString();
                    vp.AddTime = Convert.IsDBNull(dr["AddTime"]) ? DateTime.Now : Convert.ToDateTime(dr["AddTime"]);
                    list.Add(vp);
                }
                dr.Close();
            }
            return list;
        }


        #region 修改ViewPoint取消置顶操作--zfcony
        /// <summary>
        /// 修改ViewPoint取消置顶操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateViewPointQxIsTopByID(int _id)
        {
            string sql = "proc_UpdateViewPointQxIsTopByID";
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

        #region 修改ViewPoint设置置顶操作--zfcony
        /// <summary>
        /// 修改ViewPoint设置置顶操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateViewPointSZIsTopByID(int _id)
        {
            string sql = "proc_UpdateViewPointSZIsTopByID";
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
    }
}
