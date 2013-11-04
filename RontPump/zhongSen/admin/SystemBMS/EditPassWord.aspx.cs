using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;
using EnterpriseComm;

namespace Enterprise.Admin_bs.SystemBMS
{
    public partial class EditPassWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 确认修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btSaveInfo_Click(object sender, EventArgs e)
        {
            UserInfo us = new UserInfo();
            us.ID = CurrentUser.GetUserInfo.ID;
            us.LogPwd = this.txNewPwd.Text;
            if (new UserManager().EditPwd(us))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('修改成功！');window.location.href='PartnerManage.aspx';</script>");
            }
            
        }
    }
}