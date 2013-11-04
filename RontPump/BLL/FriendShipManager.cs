using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace BLL
{
    public class FriendShipManager
    {
        FriendShipService IFriend = new FriendShipService();
        /// <summary>
        /// 获得一条链接
        /// </summary>
        /// <param name="sendId"></param>
        /// <returns></returns>
        public FriendShip GetLinks(int sendId)
        {
            return IFriend.GetLinks(sendId);
        }
        /// <summary>
        /// 加载所有链接
        /// </summary>
        /// <param name="sendId"></param>
        /// <returns></returns>
        public List<FriendShip> GetLinksList(Pages pg)
        {
            return IFriend.GetLinksList(pg);
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <returns></returns>
        public bool EditFriendShip(FriendShip fir) {
            return IFriend.EditFriendShip(fir);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public bool AddFriendShip(FriendShip fir) 
        {
            return IFriend.AddFriendShip(fir);
        }
        public bool DelFriendShop(string ids) 
        {
            string[] str = ids.Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                try
                {
                    IFriend.DelFriendShop(Convert.ToInt32(str[i]));
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        public int getCount()
        {
            return IFriend.getCount();
        }
        /// <summary>
        /// 获得所以友链
        /// </summary>
        /// <returns></returns>
        public List<FriendShip> GetLinkList_all(string txts)
        {
            return IFriend.GetLinkList_all(txts);
        }
        public List<FriendShip> GetLinkList_all()
        {
            return IFriend.GetLinkList_all();
        }
    }
}
