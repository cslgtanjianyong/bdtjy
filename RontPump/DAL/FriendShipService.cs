using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Models;

namespace DAL
{
    public class FriendShipService
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EditFriendShip(FriendShip fir)
        {
            string sql = "proc_Edit_FriendShip";
            SqlParameter[] para = {
                                      new SqlParameter("@word",fir.Fword),
                                      new SqlParameter("@url",fir.FUrl),
                                      new SqlParameter("@id",fir.ID),
                                  };
            if (DbHelper.ExecuteCommandByProc(sql, para) > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 读取所有
        /// </summary>
        /// <returns></returns>
        public List<FriendShip> GetLinksList(Pages pg)
        {
            List<FriendShip> list = new List<FriendShip>();
            string sql = "proc_FriendShipList_fenye";
            SqlParameter[] para ={
                                     new SqlParameter("@pageIndex",pg.PageIndex),
                                     new SqlParameter("@pageSize",pg.PagesSize),
                                     new SqlParameter("@ListName",pg.types),
                                     new SqlParameter("@require",pg.Tiaojian)
                                };
            DataSet ds = DbHelper.GetDataSetByProc(sql,para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                FriendShip fri = new FriendShip();
                fri.Fword = dr["Fword"].ToString();
                fri.FUrl = dr["FUrl"].ToString();
                fri.ID = Convert.ToInt32(dr["ID"]);
                fri.AddTime = Convert.ToDateTime(dr["AddTime"]);
                list.Add(fri);
            }
            return list;
        }
        /// <summary>
        /// 读取一条
        /// </summary>
        /// <returns></returns>
        public FriendShip GetLinks(int d)
        {
            FriendShip fir=new FriendShip();
            string sql = "proc_get_FriendShip";
            SqlParameter[] para = {
                                      new SqlParameter("@id",d)
                                  };
            DataSet ds = DbHelper.GetDataSetByProc(sql,para);
            DataRow dr=ds.Tables[0].Rows[0];
            fir.Fword = dr["Fword"].ToString();
            fir.FUrl = dr["FUrl"].ToString();
            fir.AddTime = Convert.ToDateTime(dr["AddTime"]);
            return fir;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public bool AddFriendShip(FriendShip fir)
        {
            string sql = "proc_Add_FriendShip";
            SqlParameter[] para = {
                                      new SqlParameter("@word",fir.Fword),
                                      new SqlParameter("@url",fir.FUrl),
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
        public void DelFriendShop(int p)
        {
            string sql = "proc_Del_FriendShip";
            SqlParameter[] para = {
                                      new SqlParameter("@id",p),
                                  };
            DbHelper.ExecuteCommandByProc(sql, para);

        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        public int getCount()
        {
            int counts = 0;
            string sql = "select count(1) from FriendShip";
            object num = DbHelper.ExecuteScalarBySql(sql);
            if (num!=null)
            {
                counts = (int)num;
            }
            return counts;
        }

        /// <summary>
        /// 获取所有链接
        /// </summary>
        /// <param name="txts"></param>
        /// <returns></returns>
        public List<FriendShip> GetLinkList_all(string txts)
        {
            List<FriendShip> list = new List<FriendShip>();
            //string sql = "select Fword,FUrl from FriendShip";
            //DataSet ds = DbHelper.GetDataSetByProc(sql);
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    FriendShip fri = new FriendShip();
            //    fri.Fword = dr["Fword"].ToString();
            //    fri.FUrl ="http://"+dr["FUrl"].ToString();
            //    fri.ID = Convert.ToInt32(dr["ID"]);
            //    list.Add(fri);
            //}
            return list;
        }

        /// <summary>
        /// 获取所有链接
        /// </summary>
        /// <param name="txts"></param>
        /// <returns></returns>
        public List<FriendShip> GetLinkList_all()
        {
            List<FriendShip> list = new List<FriendShip>();
            string sql = "select ID,Fword,FUrl from FriendShip";
            DataSet ds = DbHelper.GetDataSetBySql(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                FriendShip fri = new FriendShip();
                fri.Fword = dr["Fword"].ToString();
                fri.FUrl = "http://" + dr["FUrl"].ToString();
                fri.ID = Convert.ToInt32(dr["ID"]);
                list.Add(fri);
            }
            return list;
        }
    }
}
