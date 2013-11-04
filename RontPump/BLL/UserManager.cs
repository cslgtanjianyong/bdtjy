using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Models;

namespace BLL
{
    public class UserManager
    {
        UserService usma = new UserService();
        public int IsLogin(UserInfo us)
        {
            return usma.IsLogin(us);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool EditPwd(UserInfo us)
        {
            return usma.EditPwd(us);
        }
    }
}
