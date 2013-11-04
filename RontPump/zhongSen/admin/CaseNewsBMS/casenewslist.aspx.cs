using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Models;
using BDZG.Control;
using System.Text;
using Ajax;
using System.IO;

namespace zhongSen.admin.CaseNewsBMS
{
    public partial class casenewslist : System.Web.UI.Page
    {
        CaseTypeManager ctManager = new CaseTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ajax.Utility.RegisterTypeForAjax(typeof(casenewslist));
                BindDll();
                ViewState["title"] = Request.QueryString["title"] != null ? Request.QueryString["title"] : "";
                ViewState["CTID"] = Request.QueryString["CTID"] != null ? Request.QueryString["CTID"] : "0";
                ViewState["MID"] = Request.QueryString["MID"] != null ? Request.QueryString["MID"] : "0";
                ViewState["bDate"] = Request.QueryString["bDate"] != null ? Request.QueryString["bDate"] : "";
                ViewState["eDate"] = Request.QueryString["eDate"] != null ? Request.QueryString["eDate"] : "";
                txtTime1.Value = ViewState["bDate"].ToString();
                txtTime2.Value = ViewState["eDate"].ToString();
                txtTitle.Text = ViewState["title"].ToString();
                ddlFLInfo.SelectedValue = ViewState["MID"].ToString();
                ddlFLInfoclass.Items.Clear();
                ddlFLInfoclass.DataSource = new CaseTypeManager().GetModulesclassListbyadmin(Convert.ToInt32(ViewState["MID"].ToString()));
                ddlFLInfoclass.DataTextField = "CTName";
                ddlFLInfoclass.DataValueField = "ID";
                ddlFLInfoclass.DataBind();
                ListItem li = new ListItem("--请选择--", "0");
                this.ddlFLInfoclass.Items.Insert(0, li);
                ddlFLInfoclass.Value = ViewState["CTID"].ToString();
                Repeater1.DataSource = pds();
                Repeater1.DataBind();
            }
        }

        private void BindDll()
        {
            ddlFLInfo.Items.Clear();
            ddlFLInfo.DataSource = new CaseTypeManager().GetCaseTypeListbyadmin();
            ddlFLInfo.DataTextField = "CTName";
            ddlFLInfo.DataValueField = "ID";
            ddlFLInfo.DataBind();
            ListItem li = new ListItem("--请选择--", "0");
            this.ddlFLInfo.Items.Insert(0, li);
        }


        private PagedDataSource pds()
        {
            string Strwhere = Bind();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = new CaseManager().GetCaseListByStrWhere(Strwhere);
            pds.AllowPaging = true;//允许分页
            pds.PageSize = 15;//单页显示项数
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }
        private string Bind()
        {
            StringBuilder _str1 = new StringBuilder();
            if (!string.IsNullOrEmpty(ViewState["title"].ToString()))
            {
                _str1.Append(" and CName like '%" + jsOnClient.ReplaceBadChar(ViewState["title"].ToString()) + "%'");
            }
            if (!string.IsNullOrEmpty(ViewState["CTID"].ToString()))
            {
                if (ViewState["CTID"].ToString() != "0")
                {
                    _str1.Append(" and CTID=" + jsOnClient.ReplaceBadChar(ViewState["CTID"].ToString()));

                }
                else
                {
                    _str1.Append("");
                }
            }
            if (!string.IsNullOrEmpty(ViewState["bDate"].ToString()))
            {
                _str1.Append(" and datediff(dd,'" + ViewState["bDate"].ToString() + "',Cases.addtime)>=0");
            }
            if (!string.IsNullOrEmpty(ViewState["eDate"].ToString()))
            {
                _str1.Append(" and datediff(dd,'" + ViewState["eDate"].ToString() + "',Cases.addtime)<=0");
            }
            return _str1.ToString();
        }


        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                DropDownList ddlp = (DropDownList)e.Item.FindControl("ddlp");

                HyperLink lpfirst = (HyperLink)e.Item.FindControl("hlfir");
                HyperLink lpprev = (HyperLink)e.Item.FindControl("hlp");
                HyperLink lpnext = (HyperLink)e.Item.FindControl("hln");
                HyperLink lplast = (HyperLink)e.Item.FindControl("hlla");

                pds().CurrentPageIndex = ddlp.SelectedIndex;

                int n = Convert.ToInt32(pds().PageCount);//n为分页数
                int i = Convert.ToInt32(pds().CurrentPageIndex);//i为当前页

                Label lblpc = (Label)e.Item.FindControl("lblpc");
                lblpc.Text = n.ToString();
                Label lblp = (Label)e.Item.FindControl("lblp");
                lblp.Text = Convert.ToString(pds().CurrentPageIndex + 1);

                if (!IsPostBack)
                {
                    for (int j = 0; j < n; j++)
                    {
                        ddlp.Items.Add(Convert.ToString(j + 1));
                    }
                }

                if (i <= 0)
                {
                    lpfirst.Enabled = false;
                    lpprev.Enabled = false;
                    lplast.Enabled = true;
                    lpnext.Enabled = true;
                }
                else
                {
                    StringBuilder _str = new StringBuilder();
                    _str.Append("casenewslist.aspx?page=" + (i - 1));
                    _str.Append("&title=" + jsOnClient.ReplaceBadChar(txtTitle.Text) + "");
                    _str.Append("&CTID=" + ddlFLInfoclass.Value + "");
                    _str.Append("&MID=" + ddlFLInfo.SelectedValue + "");
                    _str.Append("&bDate=" + txtTime1.Value + "");
                    _str.Append("&eDate=" + txtTime2.Value + "");
                    lpprev.NavigateUrl = _str.ToString();
                }
                if (i >= n - 1)
                {
                    lpfirst.Enabled = true;
                    lplast.Enabled = false;
                    lpnext.Enabled = false;
                    lpprev.Enabled = true;
                }
                else
                {
                    StringBuilder _str = new StringBuilder();
                    _str.Append("?page=" + (i + 1));
                    _str.Append("&title=" + jsOnClient.ReplaceBadChar(txtTitle.Text) + "");
                    _str.Append("&CTID=" + ddlFLInfoclass.Value + "");
                    _str.Append("&MID=" + ddlFLInfo.SelectedValue + "");
                    _str.Append("&bDate=" + txtTime1.Value + "");
                    _str.Append("&eDate=" + txtTime2.Value + "");
                    lpnext.NavigateUrl = _str.ToString();
                }

                StringBuilder _str1 = new StringBuilder();
                _str1.Append("?page=0");
                _str1.Append("&title=" + jsOnClient.ReplaceBadChar(txtTitle.Text) + "");
                _str1.Append("&CTID=" + ddlFLInfoclass.Value + "");
                _str1.Append("&MID=" + ddlFLInfo.SelectedValue + "");
                _str1.Append("&bDate=" + txtTime1.Value + "");
                _str1.Append("&eDate=" + txtTime2.Value + "");
                lpfirst.NavigateUrl = _str1.ToString();
                StringBuilder _str2 = new StringBuilder();
                _str2.Append("casenewslist.aspx?page=" + (n - 1));
                _str2.Append("&title=" + jsOnClient.ReplaceBadChar(txtTitle.Text) + "");
                _str2.Append("&CTID=" + ddlFLInfoclass.Value + "");
                _str2.Append("&MID=" + ddlFLInfo.SelectedValue + "");
                _str2.Append("&bDate=" + txtTime1.Value + "");
                _str2.Append("&eDate=" + txtTime2.Value + "");
                lplast.NavigateUrl = _str2.ToString();

                ddlp.SelectedIndex = Convert.ToInt32(pds().CurrentPageIndex);//更新下拉列表框中的当前选中页序号
            }

        }
        //分页操作跳转到第几页
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pg = Convert.ToString((Convert.ToInt32(((DropDownList)sender).SelectedValue) - 1));//获取列表框当前选中项
            StringBuilder _str = new StringBuilder();
            _str.Append("casenewslist.aspx?page=" + pg);
            _str.Append("&title=" + jsOnClient.ReplaceBadChar(txtTitle.Text) + "");
            _str.Append("&CTID=" + ddlFLInfoclass.Value + "");
            _str.Append("&MID=" + ddlFLInfo.SelectedValue + "");
            _str.Append("&bDate=" + txtTime1.Value + "");
            _str.Append("&eDate=" + txtTime2.Value + "");
            Response.Redirect(_str.ToString());

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gojump();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string p_strIds = Request.Form["chkEleId"];
            if (p_strIds != null)
            {
                TruedeleteImage(p_strIds);
                CaseManager _man = new CaseManager();
                _man.DeleteCasesByIDS(p_strIds);
                gojump();
            }
        }
        void gojump()
        {
            StringBuilder _str = new StringBuilder();
            _str.Append("casenewslist.aspx");
            _str.Append("?title=" + jsOnClient.ReplaceBadChar(txtTitle.Text) + "");
            _str.Append("&CTID=" + ddlFLInfoclass.Value + "");
            _str.Append("&MID=" + ddlFLInfo.SelectedValue + "");
            _str.Append("&bDate=" + txtTime1.Value + "");
            _str.Append("&eDate=" + txtTime2.Value + "");
            Response.Redirect(_str.ToString());
        }
        public string CTName(string _ctids)
        {
            string temp = string.Empty;

            string[] ctid = _ctids.Split(',');

            for (int i = 0; i < ctid.Length; i++)
            {
                if (i < ctid.Length - 1)
                {
                    temp += ctManager.GetCaseTypeByID(Convert.ToInt32(ctid[i])).CTName;
                    if (i > 0 && i % 2 == 0)
                    {
                        temp += "<br />";
                    }
                    else
                    {
                        temp += " | ";
                    }
                }
                else
                {
                    temp += ctManager.GetCaseTypeByID(Convert.ToInt32(ctid[i])).CTName;
                }
            }
            return temp;
        }
        // 删除首页导航图（真删除）
        public void TruedeleteImage(string IDS)
        {
            string[] listids = IDS.Split(new string[] { "," }, StringSplitOptions.None);
            foreach (string s in listids)
            {
                int gsID = Convert.ToInt32(s);
                Cases _info = new CaseManager().GetCaseByID(gsID);
                string ImgUrl = _info.ImgSrc;
                //string ImgUrl = _info.SmallIMGURL;
                if (ImgUrl != "")
                {
                    //如果存在则删除
                    string rr = HttpContext.Current.Server.MapPath("~" + ImgUrl);
                    if (File.Exists(rr))
                    {
                        File.Delete(rr);
                    }
                }
            }

        }
        //置顶判断
        [Ajax.AjaxMethod()]
        public bool checkIszd(int _id)
        {
            Cases _info = new CaseManager().GetCaseByID(_id);
            return _info.IsTop;
        }
        //取消置顶
        [Ajax.AjaxMethod()]
        public bool QxIszd(int _id)
        {
            if (Convert.ToBoolean(new CaseManager().UpdateQxIsTopByID(_id)) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //设置置顶
        [Ajax.AjaxMethod()]
        public bool SZIszd(int _id)
        {
            if (Convert.ToBoolean(new CaseManager().UpdateSZIsTopByID(_id)) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void ddlFLInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _gid = Convert.ToInt32(ddlFLInfo.SelectedItem.Value);
            ddlFLInfoclass.Items.Clear();
            ddlFLInfoclass.DataSource = new CaseTypeManager().GetModulesclassListbyadmin(_gid);
            ddlFLInfoclass.DataTextField = "CTName";
            ddlFLInfoclass.DataValueField = "ID";
            ddlFLInfoclass.DataBind();
            ListItem li = new ListItem("--请选择--", "0");
            this.ddlFLInfoclass.Items.Insert(0, li);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "checkAddInfoTitle();", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "b", "checkclass();", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "c", "checkAddInfoAddAuthor();", true);
        }

        //解析分类名称
        public string whattypename(string _cid)
        {
            CaseType _ct = new CaseTypeManager().GetCaseTypeByID(Convert.ToInt32(_cid));
            return _ct.CTName;
        }
    }
}