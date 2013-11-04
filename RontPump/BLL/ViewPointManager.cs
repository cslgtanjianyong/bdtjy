using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Models;
using System.IO;

namespace BLL
{
    public class ViewPointManager
    {
        ViewPointService vip = new ViewPointService();
        /// <summary>
        /// 添加一个观点
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        public bool AddViewPoint(ViewPoint _info, out int id)
        {
            return vip.AddViewPoint(_info, out id);
        }
        /// <summary>
        /// 获得数量
        /// </summary>
        /// <returns></returns>
        public int getCount(int d)
        {
            return vip.getCount(d);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strIds"></param>
        /// <returns></returns>
        public bool DelViewPoint(string strIds)
        {
            bool IsDel = true;
            string[] ids = strIds.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                if (vip.DelViewPoint(Convert.ToInt32(ids[i])) == false)
                {
                    IsDel = false;
                    break;
                }
                //string hurl = "vdetail_" + ids[i] + ".html";
                //File.Delete(path + hurl);
            }
            return IsDel;
        }
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="pg"></param>
        /// <returns></returns>
        public List<ViewPointExtend> GetViewPointList(Pages pg)
        {
            return vip.GetViewPointList(pg);
        }
        /// <summary>
        /// 获得一个观点
        /// </summary>
        /// <param name="d">id</param>
        /// <returns></returns>
        public ViewPoint GetViewPoint(int d)
        {
            return vip.GetViewPoint(d);
        }
        public ViewPoint GetViewPointByID(int id)
        {
            return vip.GetViewPointByID(id);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        public bool EditViewPoint(ViewPoint _info)
        {
            return vip.EditViewPoint(_info);
        }

        /// <summary>
        /// 根据id去获取ViewPoint前6条
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<ViewPoint> GetViewPointListById_top6(int p)
        {
            return vip.GetViewPointListById_top6(p);
        }
        /// <summary>
        /// 获取ViewPoint前6条
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<ViewPoint> GetViewPointListById_top6()
        {
            return vip.GetViewPointListById_top6();
        }
        /// <summary>
        /// 根据分类id获取列表
        /// </summary>
        /// <returns></returns>
        public List<ViewPoint> GetViewPointList(string tblName, string fldName, int pageSize, int currentPageIndex, string fldSort, bool sort, string strWhere, out int pageCount, out int counts)
        {
            return vip.GetViewPointList(tblName, fldName, pageSize, currentPageIndex, fldSort, sort, strWhere, out pageCount, out counts);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <returns></returns>
        public ViewPoint GetViewPointUp(int id)
        {
            return vip.GetViewPointUp(id);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <returns></returns>
        public ViewPoint GetViewPointNext(int id)
        {
            return vip.GetViewPointNext(id);
        }
        /// <summary>
        /// 推荐观点6条(按时间排序)
        /// </summary>
        /// <returns></returns>
        public List<ViewPointExtend> GetViewPointList()
        {
            return vip.GetViewPointList();
        }
        public bool UpdateViewPointQxIsTopByID(int _id)
        {
            return vip.UpdateViewPointQxIsTopByID(_id);
        }
        public bool UpdateViewPointSZIsTopByID(int _id)
        {
            return vip.UpdateViewPointSZIsTopByID(_id);
        }
        public ViewPointExtend GetViewPointTpName(int id)
        {
            return vip.GetViewPointTpName(id);
        }


        //补加方法
        public IList<ViewPointExtend> GetViewPointList(int topN, int tid)
        {
            return vip.GetViewPointList(topN, tid);
        }
        public ViewPointExtend GetViewPointExtendByID(int id) {
            return vip.GetViewPointExtendByID(id);
        }
    }
}
