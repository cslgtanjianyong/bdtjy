using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using System.IO;

namespace BLL
{
    public class NsyNewsManager
    {
        NsyNewsService NewSv = new NsyNewsService();
        public int getCount()
        {
            return NewSv.getCount();
        }

        public List<NsyNews> GetNsyNewList(Pages pg)
        {
            return NewSv.GetNsyNewList(pg);
        }
        public List<NsyNews> GetNsyNewList()
        {
            return null;
        }

        public bool DelFriendShop(string strIds,string path)
        {
            string[] str = strIds.Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                try
                {
                    NewSv.DelNsyNews(Convert.ToInt32(str[i]));
                    string hurl = "ndetail_" + str[i] + ".html";
                    File.Delete(path + hurl);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public NsyNews GetNsyNews(int d)
        {
            return NewSv.GetNsyNews(d);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="news"></param>
        public bool AddNsyNews(NsyNews news,out int id)
        {
            return NewSv.AddNsyNews(news,out id);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="news"></param>
        public bool EditNsyNews(NsyNews news)
        {
            return NewSv.EditNsyNews(news);
        }
        /// <summary>
        /// 获得ID
        /// </summary>
        /// <returns></returns>
        public int GetNsyNewsID(string til)
        {
            return NewSv.GetNsyNewsID(til);
        }

        public List<NsyNews> GetNsyNewListById(string fldNamet, int PageSize, int PageCurren, string fldSort, string Sort, string strWhere, out int pageCount, out int Counts)
        {
            return NewSv.GetNsyNewListById(fldNamet, PageSize, PageCurren, fldSort, Sort, strWhere, out pageCount, out Counts);
        }
    }
}
