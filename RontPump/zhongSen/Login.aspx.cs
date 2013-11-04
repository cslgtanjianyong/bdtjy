using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnterpriseComm;
using Models;
using BLL;

namespace zhongSen
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ToLogin_Click(object sender, EventArgs e)
        {
            string lgName = this.UserName.Value;
            string lgPwd = BaseTools.MD5(this.UserPassWord.Value);
            if (string.IsNullOrEmpty(lgName))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请填写用户名！')</script>");
                return;
            }
            if (string.IsNullOrEmpty(lgPwd))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请填写密码！')</script>");
                return;
            }
            if (string.IsNullOrEmpty(this.validateText.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请填验证码！')</script>");
                return;
            }
            else if (!ValidateCode.Equals(this.validateText.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('验证码不正确！')</script>");
                return;
            }
            UserInfo uss = new UserInfo();
            uss.LogName = lgName;
            uss.LogPwd = lgPwd;
            int num = new UserManager().IsLogin(uss);
            if (num != -1)
            {
                UserInfo us = new UserInfo();
                us.ID = num;
                us.LogName = lgName;
                CurrentUser.SetUserInfo = us;
                Response.Redirect("admin/Default.aspx");
                return;
            }

            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('账号或密码错误！')</script>");
            }
        }
    }
}