using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class UserService
    {
        public int IsLogin(UserInfo us)
        {
            int ud = -1;
            string sql = "proc_userInfo_isLogin";
            SqlParameter[] para = {
                                          new SqlParameter("@Name",us.LogName),
                                          new SqlParameter("@pwd",us.LogPwd)
                                      };
            object num = DbHelper.ExecuteScalarByProc(sql, para);
            if (num != null)
            {
                ud = (int)num;
            }
            return ud;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool EditPwd(UserInfo us)
        {
            string sql = "update UserInfo set LogPwd=@pwd where ID=@id";
            SqlParameter[] para ={
                                     new SqlParameter("@pwd",us.LogPwd),
                                     new SqlParameter("@id",us.ID),
                                };
            if (DbHelper.ExecuteCommandBySql(sql,para)>0)
            {
                return true;
            }
            return false;
        }
    }
}
