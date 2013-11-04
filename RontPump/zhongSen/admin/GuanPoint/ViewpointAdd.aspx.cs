using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BLL;
using System.Text;
using System.IO;

namespace zhongSen.admin.GuanPoint
{
    public partial class ViewpointAdd : System.Web.UI.Page
    {
        ViewPointManager vpMang = new ViewPointManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropList();
                string id = Request.QueryString["CID"];
                if (!string.IsNullOrEmpty(id))
                {
                    LoadInfo(Convert.ToInt32(id));
                }
            }
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadInfo(int d)
        {
            ViewPoint fir = vpMang.GetViewPoint(d);

            if (fir != null)
            {
                ViewState["isNUlls"] = d;
                this.txtTitle.Value = fir.Title;
                this.ddlFLInfoclass.SelectedValue = fir.TpId.ToString();
                this.UEditor1.Value = fir.Article;
                txt_metadesc.Text = fir.MetaDesc;
                txt_metakey.Text = fir.MetaKey;
                txt_tag.Text = fir.vtag;
                txt_shortdes.Text = fir.CShortDes;
                if (fir.Istop == 1)
                {
                    chkIsTop.Checked = true;
                }
                else
                {
                    chkIsTop.Checked = false;
                }
            }
        }
        //protected void btnOK_Click(object sender, EventArgs e)
        //{
        //    ViewPoint _info = new ViewPoint();
        //    _info.Title= this.txtTitle.Value.Trim();
        //    _info.Article= UEditor1.Value;
        //    _info.TpId = Convert.ToInt32(ddlFLInfoclass.SelectedItem.Value);
        //    if (ViewState["isNUlls"] == null)
        //    {
        //        if (new ViewPointManager().AddViewPoint(_info))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('添加成功！');</script>");
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('添加失败！');</script>");
        //        }
        //    }
        //    else {
        //        _info.ID = Convert.ToInt32(ViewState["isNUlls"]);
        //        if (new ViewPointManager().EditViewPoint(_info))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('修改成功！');window.location.href='ViewpointAdd.aspx'</script>");
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('修改失败！');</script>");
        //        }
        //    }
            
        //}
        //绑定下拉
        private void BindDropList() 
        {
            this.ddlFLInfoclass.DataSource = new PointTypeManager().GetPointTypeList();
            this.ddlFLInfoclass.DataTextField = "TypeName";
            this.ddlFLInfoclass.DataValueField = "ID";
            this.ddlFLInfoclass.DataBind();
            ListItem li = new ListItem("--请选择--", "0");
            this.ddlFLInfoclass.Items.Insert(0, li);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ~/FirstPage/new/ndetail_id.html
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ViewPointExtend point = new ViewPointExtend();
            point.Title = this.txtTitle.Value;
            string vName = this.ddlFLInfoclass.SelectedItem.Text;
            point.Article = this.UEditor1.Value;
            point.TpId = Convert.ToInt32(this.ddlFLInfoclass.SelectedItem.Value);
            point.TypeName = vName.Substring(0, 2);
            if (chkIsTop.Checked == true)
            {
                point.Istop = 1;
            }
            else
            {
                point.Istop = 0;
            }
            point.MetaDesc = txt_metadesc.Text;
            point.MetaKey = txt_metakey.Text;
            point.vtag = txt_tag.Text;
            point.CShortDes = txt_shortdes.Text;
            if (ViewState["isNUlls"] == null)
            {
                int id = 0;
                if (vpMang.AddViewPoint(point,out id))
                {
                    point.ID = id;//id
                    //ViewPoint vpnext = new ViewPointManager().GetViewPointNext(point.ID);
                    //ViewPoint vpUp = new ViewPointManager().GetViewPointUp(point.ID);
                    //WirteFile(point,vpnext,vpUp);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('添加成功！');window.location.href='ViewPointMsg.aspx'</script>");
                }
            }
            else
            {
                point.ID = Convert.ToInt32(ViewState["isNUlls"]);
                if (vpMang.EditViewPoint(point))
                {
                    //string path = HttpContext.Current.Server.MapPath("~/FirstPage/viewpoint/");
                    //string hurl = "vdetail_" + point.ID.ToString() + ".html";
                    //ViewPoint vpnext = new ViewPointManager().GetViewPointNext(point.ID);
                    //ViewPoint vpUp = new ViewPointManager().GetViewPointUp(point.ID);
                    //File.Delete(path + hurl);
                    //WirteFile(point,vpnext,vpUp);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('修改成功！');</script>");
                }
            }

        }
        /// <summary>
        /// 写入页面
        /// </summary>
        public void WirteFile(ViewPointExtend news, ViewPoint NextText, ViewPoint UpText)
        {
            string path = HttpContext.Current.Server.MapPath("~/FirstPage/viewpoint/");
            Encoding code = Encoding.GetEncoding("gb2312");
            string temp = HttpContext.Current.Server.MapPath("viewdetail.html");
            StreamReader sr = null;
            StreamWriter sw = null;
            string str = "";
            try
            {
                sr = new StreamReader(temp, code);
                str = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
                sr.Close();
            }
            string NextStr = "<span>下一篇:&nbsp;<a href='vdetail_"+NextText.ID+".html'>"+NextText.Title+"</a></span>";
            string UpStr = "<span>下一篇:&nbsp;<a href='vdetail_" + UpText.ID + ".html'>" + UpText.Title + "</a></span>";
            str = str.Replace("[title]", news.Title)
                    .Replace("[Content]", news.Article)
                    .Replace("[TypeName]", news.TypeName)
                    .Replace("[UpText]", UpStr)
                    .Replace("[NextText]", NextStr);

            string hurl = "vdetail_" + news.ID.ToString() + ".html";
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