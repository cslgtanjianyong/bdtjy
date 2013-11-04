using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Configuration;
using Models;

namespace EnterpriseComm
{
    public class BasePage : Page
    {
        protected UserInfo CurUserInfo = new UserInfo();

        protected string strLog;

        public BasePage()
        {
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }
        private void InitializeComponent()
        {
            if (CheckLogon() == false)
            {
                //HttpContext.Current.Response.Redirect("~/index.aspx");
                string strLogonUrl = "/login.aspx";
                HttpContext.Current.Response.Write("<script language='javascript' type='text/javascript'>parent.parent.location.href='" + strLogonUrl + "';</script>");
                HttpContext.Current.Response.End();
            }
            else
            {
                StartProcessRequest(this.CurUserInfo.ID);
            }
        }
        /// <summary>
        /// 检查用户是否登陆

        /// </summary>
        /// <returns></returns>
        private bool CheckLogon()
        {
            CurUserInfo = (UserInfo)HttpContext.Current.Session["ACCOUNT_KEY"];
            if (CurUserInfo == null)
            {
                return false;
            }
            Response.CacheControl = "no-cache";
            strLog = CurUserInfo.ID.ToString() + "," + Request.ServerVariables["REMOTE_ADDR"].ToString();
            return true;
        }

        #region SQL注入式攻击代码分析

        /**/
        /// <summary>
        /// 处理用户提交的请求

        /// </summary>
        private void StartProcessRequest(int intUserID)
        {
            try
            {
                string getkeys = "";
                //string strErrorPage = System.Configuration.ConfigurationSettings.AppSettings["CustomErrorPage"].ToString();
                string strErrorPage = ConfigurationManager.AppSettings["CustomErrorPage"].ToString();
                if (System.Web.HttpContext.Current.Request.QueryString != null)
                {
                    for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.QueryString[getkeys]))
                        {
                            System.Web.HttpContext.Current.Response.Redirect(strErrorPage);
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }
                if (System.Web.HttpContext.Current.Request.Form != null)
                {
                    for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.Form.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.Form[getkeys]))
                        {
                            System.Web.HttpContext.Current.Response.Redirect(strErrorPage);
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }
            }
            catch
            {
                // 错误处理: 处理用户提交信息!
            }
        }
        /**/
        /// <summary>
        /// 分析用户请求是否正常
        /// </summary>
        /// <param name="strPara">传入用户提交数据</param>
        /// <returns>返回是否含有SQL注入式攻击代码</returns>
        private bool ProcessSqlStr(string strPara)
        {
            String Str = strPara.ToLower().ToString();
            bool ReturnValue = true;
            try
            {
                if (Str != "")
                {
                    //string SqlStr = System.Configuration.ConfigurationSettings.AppSettings["FiltrateString"].ToString();
                    string SqlStr = ConfigurationManager.AppSettings["FiltrateString"].ToString();
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.IndexOf(ss) >= 0)
                        {
                            ReturnValue = false;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }
        #endregion

    }
}
