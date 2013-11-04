using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;
using System.IO;
using System.Text;

namespace zhongSen.admin.NsyXingWen
{
    public partial class NsyNewAdd : System.Web.UI.Page
    {
        NsyNewsManager newMang = new NsyNewsManager();
        public int sendId = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sId = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(sId))
                {
                    //判断是否为空
                    sendId = Convert.ToInt32(sId);
                    LoadInfo(sendId);
                }
            }
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadInfo(int d)
        {
            NsyNews fir = newMang.GetNsyNews(d);

            if (fir != null)
            {
                ViewState["isNUlls"] = d;
                this.txtTitle.Value = fir.Title;
                this.UEditor1.Value = fir.Contents;
                this.txAddTime.Text = fir.AddTime.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ~/FirstPage/new/ndetail_id.html
        protected void btnOK_Click(object sender, EventArgs e)
        {
            NsyNews news = new NsyNews();
            news.Title = this.txtTitle.Value;
            news.Contents = this.UEditor1.Value;
            news.AddTime = DateTime.Now;
            int id = 0;
            if (ViewState["isNUlls"]==null)
            {
                if (newMang.AddNsyNews(news,out id))
                {
                    news.ID = id;
                    WirteFile(news);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('添加成功！');window.location.href='NewMsg.aspx'</script>");

                }
            }
            else
            {
                news.ID = Convert.ToInt32(ViewState["isNUlls"]);
                if (newMang.EditNsyNews(news))
                {
                    string path = HttpContext.Current.Server.MapPath("~/FirstPage/new/");
                    string hurl = "ndetail_" + news.ID.ToString() + ".html";
                    File.Delete(path+hurl);
                    WirteFile(news);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('修改成功！');</script>");
                }
            }
            
        }
        /// <summary>
        /// 写入页面
        /// </summary>
        public void WirteFile(NsyNews news) 
        {
            string path = HttpContext.Current.Server.MapPath("~/FirstPage/new/");
            Encoding code = Encoding.GetEncoding("gb2312");
            string temp = HttpContext.Current.Server.MapPath("newdlt.htm");
            StreamReader sr = null;
            StreamWriter sw = null;
            string str = "";
            try
            {
                sr = new StreamReader(temp,code);
                str = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
                sr.Close();
            }
            str = str.Replace("[title]",news.Title)
                    .Replace("[time]", news.AddTime.ToString("yyyy-MM-dd"))
                    .Replace("[content]", news.Contents);
            string hurl = "ndetail_" + news.ID.ToString() + ".html";
            try
            {
                sw = new StreamWriter(path + hurl, false, code);
                sw.Write(str);
                sw.Flush();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
                throw;
            }
            finally
            {
                sw.Close();
            }
        }

    }
}