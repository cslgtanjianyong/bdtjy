using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BoutiqueCaseService
    {

        #region 通过ID得到实体得到所有产品（服务）——by-cony


        /// <summary>
        /// 通过ID得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BoutiqueCase GetBoutiqueCasebyID(int id)
        {
            BoutiqueCase _info;
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ID", id),
            };
            using (SqlDataReader dr = DbHelper.ExecuteReader("Pro_GetBoutiqueCasebyID", param, CommandType.StoredProcedure))
            {

                if (dr.Read())
                {
                    _info = new BoutiqueCase();
                    _info.ID = Convert.ToInt32(dr["ID"]);
                    _info.item = Convert.ToString(dr["item"]);
                    _info.Logo = Convert.ToString(dr["Logo"]);
                    _info.TpId = Convert.ToInt32(dr["TpId"]);
                    _info.Hanye = Convert.ToString(dr["Hanye"]);
                    _info.gain = Convert.ToString(dr["gain"]);
                    _info.Client = Convert.ToString(dr["Client"]);
                    _info.Challenge = Convert.ToString(dr["Challenge"]);
                    _info.Background = Convert.ToString(dr["Background"]);
                    _info.AddTime = Convert.ToDateTime(dr["AddTime"]);

                }
                else
                {
                    _info = null;
                }
            }
            return _info;
        }
        #endregion






        /// <summary>
        /// 添加一个案例
        /// </summary>
        /// <param name="cas"></param>
        public bool AddBoutiqueCase(BoutiqueCase cas)
        {
            string sql = "proc_Add_BoutiqueCase";
            SqlParameter[] para ={
                                     new SqlParameter("@logo",cas.Logo),
                                     new SqlParameter("@client",cas.Client),
                                     new SqlParameter("@item",cas.item),
                                     new SqlParameter("@backGd",cas.Background),
                                     new SqlParameter("@Chall",cas.Challenge),
                                     new SqlParameter("@gain",cas.gain),
                                     new SqlParameter("@Hanye",cas.Hanye)
                                };
            if (DbHelper.ExecuteCommandByProc(sql,para)>0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获得案例列表（分页）
        /// </summary>
        /// <param name="pg"></param>
        /// <returns></returns>
        public List<BoutiqueCase> GetBoutiqueCaseList(Pages pg)
        {
            List<BoutiqueCase> list = new List<BoutiqueCase>();
            string sql = "proc_BoutiqueCase_fenye";
            SqlParameter[] para ={
                                     new SqlParameter("@pageIndex",pg.PageIndex),
                                     new SqlParameter("@pageSize",pg.PagesSize),
                                     new SqlParameter("@ListName",pg.types),
                                     new SqlParameter("@require",pg.Tiaojian)
                                };
            DataSet ds = DbHelper.GetDataSetByProc(sql, para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BoutiqueCase bcase = new BoutiqueCase();
                bcase.ID=Convert.ToInt32(dr["ID"]);
                bcase.Logo = dr["Logo"].ToString();
                bcase.Background = dr["background"].ToString();
                bcase.Challenge = dr["Challenge"].ToString();
                bcase.Client = dr["Client"].ToString();
                bcase.gain = dr["gain"].ToString();
                bcase.Hanye = dr["Hanye"].ToString();
                bcase.item = dr["item"].ToString();
                bcase.AddTime = Convert.ToDateTime(dr["AddTime"]);
                list.Add(bcase);
            }
            return list;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getCount(int d)
        {
            string sql = "select count(1) from BoutiqueCase ";
            int counts = (int)DbHelper.ExecuteScalarBySql(sql);
            return counts;
        }
        /// <summary>
        /// 删除案例
        /// </summary>
        /// <returns></returns>
        public bool DelBoutiqueCase(int d)
        {
            string sql = "delete BoutiqueCase where ID=@id";
            SqlParameter[] para ={
                                     new SqlParameter("@id",d)
                                };
            if (DbHelper.ExecuteCommandBySql(sql, para) > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 修改案例
        /// </summary>
        /// <param name="cas"></param>
        /// <returns></returns>
        public bool EidtBoutiqueCase(BoutiqueCase cas)
        {
            string sql = "proc_Edit_BoutiqueCase";
            SqlParameter[] para ={
                                     new SqlParameter("@logo",cas.Logo),
                                     new SqlParameter("@client",cas.Client),
                                     new SqlParameter("@item",cas.item),
                                     new SqlParameter("@backGd",cas.Background),
                                     new SqlParameter("@Chall",cas.Challenge),
                                     new SqlParameter("@gain",cas.gain),
                                     new SqlParameter("@Hanye",cas.Hanye),
                                     new SqlParameter("@id",cas.ID),
                                };
            if (DbHelper.ExecuteCommandByProc(sql, para) > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 得到一条案例
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public BoutiqueCase GetBCase(int d)
        {
            BoutiqueCase BCase = new BoutiqueCase();
            string sql = "select * from BoutiqueCase where ID=@id";
            SqlParameter[] para = {
                                      new SqlParameter("@id",d)
                                  };
            DataSet ds = DbHelper.GetDataSetBySql(sql, para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BCase.Logo = dr["Logo"].ToString();
                BCase.Background = dr["background"].ToString();
                BCase.Challenge = dr["Challenge"].ToString();
                BCase.Client = dr["Client"].ToString();
                BCase.gain = dr["gain"].ToString();
                BCase.Hanye = dr["Hanye"].ToString();
                BCase.item = dr["item"].ToString();
            }
            return BCase;
        }



        #region 分页 -- zfcony
        public IList<BoutiqueCase> GetList(string fldNamet, int PageSize, int PageCurren, string fldSort, string Sort, string strWhere, out int pageCount, out int Counts)
        {
            Counts = 0;
            SqlParameter outPageCount = new SqlParameter("@pageCount", 4);
            outPageCount.Direction = ParameterDirection.Output;
            SqlParameter outCounts = new SqlParameter("@Counts", 4);
            outCounts.Direction = ParameterDirection.Output;
            SqlParameter[] para = {
                                    new SqlParameter("@tblName","BoutiqueCase"),
                                     new SqlParameter("@fldName",fldNamet),
                                     new SqlParameter("@pageSize",PageSize),
                                     new SqlParameter("@page",PageCurren),
                                     new SqlParameter("@fldSort",fldSort),
                                     new SqlParameter("@Sort",Sort),
                                     new SqlParameter("@strWhere",strWhere),

                                     new SqlParameter("@ID","Addtime"),
                                     new SqlParameter("@Dist",0),
                                     //new SqlParameter("@pageCount",4),
                                     outPageCount,
                                     outCounts
                                     //new SqlParameter("@Counts",4)

                                  };
            IList<BoutiqueCase> list = new List<BoutiqueCase>();
            using (SqlDataReader dr = DbHelper.ExecuteReader("Proc_ListPage", para, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    BoutiqueCase boutiquecase = new BoutiqueCase();
                    boutiquecase.ID = Convert.ToInt32(dr["ID"]);
                    boutiquecase.Logo = Convert.ToString(dr["Logo"]);
                    boutiquecase.Client = dr["Client"].ToString();
                    boutiquecase.item = dr["item"].ToString();
                    boutiquecase.Hanye = dr["Hanye"].ToString();
                    list.Add(boutiquecase);
                }
                dr.Close();
            }
            pageCount = Convert.ToInt32(outPageCount.Value);
            Counts = Convert.ToInt32(outCounts.Value);
            return list;
        }
        #endregion

        /// <summary>
        /// 获取9条数据
        /// </summary>
        /// <returns></returns>
        public List<BoutiqueCase> GetBoutiqueList_Top6()
        {
            List<BoutiqueCase> list=new List<BoutiqueCase>();
            string sql = "select ID,Logo,Client,Hanye,item from BoutiqueCase order by Addtime desc";
            DataSet ds = DbHelper.GetDataSetBySql(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BoutiqueCase BCase = new BoutiqueCase();
                BCase.ID = Convert.ToInt32(dr["ID"]);
                BCase.Logo = dr["Logo"].ToString();
                BCase.Client = dr["Client"].ToString();
                BCase.Hanye = dr["Hanye"].ToString();
                BCase.item = dr["item"].ToString();
                list.Add(BCase);
            }
            return list;
        }
    }
}
