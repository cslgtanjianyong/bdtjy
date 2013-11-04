using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Models;

namespace BLL
{
    public class BoutiqueCaseManager
    {
        BoutiqueCaseService BCaseSv = new BoutiqueCaseService();
        /// <summary>
        /// 加载案例
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public BoutiqueCase GetBCase(int d)
        {
            return BCaseSv.GetBCase(d);
        }
        /// <summary>
        /// 添加一个案例
        /// </summary>
        /// <param name="cas"></param>
        public bool AddBoutiqueCase(BoutiqueCase cas)
        {
            return BCaseSv.AddBoutiqueCase(cas);
        }
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="pg"></param>
        /// <returns></returns>
        public List<BoutiqueCase> GetBoutiqueCaseList(Pages pg)
        {
            return BCaseSv.GetBoutiqueCaseList(pg);
        }
        /// <summary>
        /// 获得总数
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public int getCount(int d)
        {
            return BCaseSv.getCount(d);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strIds"></param>
        /// <returns></returns>
        public bool DelBoutiqueCase(string strIds)
        {
            bool IsDel = true;
            string[] ids = strIds.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                if (BCaseSv.DelBoutiqueCase(Convert.ToInt32(ids[i])) == false)
                {
                    IsDel = false;
                    break;
                }
            }
            return IsDel;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="cas"></param>
        /// <returns></returns>
        public bool EidtBoutiqueCase(BoutiqueCase cas)
        {
            return BCaseSv.EidtBoutiqueCase(cas);
        }

        //分页---zfcony
        public IList<BoutiqueCase> GetList(string fldNamet, int PageSize, int PageCurren, string fldSort, string Sort, string strWhere, out int pageCount, out int Counts)
        {
            return BCaseSv.GetList(fldNamet, PageSize, PageCurren, fldSort, Sort, strWhere, out pageCount, out Counts);
        }
        
        /// <summary>
        /// 根据ID得到单个信息---zfcony
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public BoutiqueCase GetBoutiqueCasebyID(int id)
        {
            return BCaseSv.GetBoutiqueCasebyID(id);
        }
        /// <summary>
        /// 获取前9数据
        /// </summary>
        /// <returns></returns>
        public List<BoutiqueCase> GetBoutiqueList_Top6()
        {
            return BCaseSv.GetBoutiqueList_Top6();
        }
    }
}
