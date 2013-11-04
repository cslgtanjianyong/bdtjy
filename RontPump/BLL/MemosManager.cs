using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace BLL
{
    public class MemosManager
    {
        MemosService IMemos = new MemosService();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mo"></param>
        /// <returns></returns>
        public bool AddMemosInfo(Memos mo) 
        {
            return IMemos.AddMemosInfo(mo) ;
        }
        /// <summary>
        /// 加载所有
        /// </summary>
        /// <returns></returns>
        public List<Memos> GetMemosList(int id)
        {
            return IMemos.GetMemosList(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strIds"></param>
        /// <returns></returns>
        public bool DelectMemos(string strIds)
        {
            string[] str = strIds.Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                try
                {
                    IMemos.DelMemos(Convert.ToInt32(str[i]));
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Memos GetMemos(int id)
        {
            return IMemos.GetMemos(id);
        }
        /// <summary>
        /// 设置为已读
        /// </summary>
        /// <param name="id"></param>
        public void UpdateMemosIsRead(int id)
        {
            IMemos.UpdateMemosIsRead(id);
        }
    }
}
