using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BLL;

namespace zhongSen.admin.NiceCase
{
    public partial class CaseMsg : System.Web.UI.Page
    {
        BoutiqueCaseManager boMang = new BoutiqueCaseManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //BingDropList();
                ViewState["Ordertype"] = "id";
                getPages(0);
            }
            
            this.fen_pages1.BindDatalist += Loadlist;
        }

        /// <summary>
        /// 加载列表
        /// </summary>
        private void Loadlist(int pageSize, int pageIndex)
        {
            Pages pg = new Pages();
            pg.PageIndex = pageIndex;
            pg.PagesSize = pageSize;
            //pg.id = 0;
            //pg.id = Convert.ToInt32(this.ddlFLInfoclass.SelectedValue);
            pg.types = ViewState["Ordertype"].ToString().Trim();
            if (ViewState["Tiaojian"] != null)
            {
                pg.Tiaojian = ViewState["Tiaojian"].ToString();
            }
            else
            {
                pg.Tiaojian = null;
            }

            this.RepeaterDate.DataSource = boMang.GetBoutiqueCaseList(pg);
            this.RepeaterDate.DataBind();
        }
        //获取总页数
        private void getPages(int d)
        {
            int pages = 0;
            int cout = boMang.getCount(d);
            int sizes = Convert.ToInt32(this.fen_pages1.PagesSize);
            if (cout % sizes != 0)
            {
                pages = cout / sizes + 1;
            }
            else
            {
                pages = cout / sizes;
            }
            this.fen_pages1.PageCount = pages;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string strIds = Request.Form["chkEleId"];
            if (strIds != null)
            {
                if (boMang.DelBoutiqueCase(strIds))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！')</script>");
                    Loadlist(this.fen_pages1.PagesSize, this.fen_pages1.PagesIndex);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！')</script>");
                }
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["Tiaojian"] = this.txtTitle.Text;
            //getPages(Convert.ToInt32(ddlFLInfoclass.SelectedItem.Value)); 
            Loadlist(this.fen_pages1.PagesSize, this.fen_pages1.PagesIndex);
            //Response.Redirect("ViewPointMsg.aspx?id=" + ddlFLInfoclass.SelectedValue + "&til=" + this.txtTitle.Text);
        }
        /// <summary>
        /// 绑定下拉
        /// </summary>
        //private void BingDropList()
        //{
        //    this.ddlFLInfoclass.Items.Clear();
        //    this.ddlFLInfoclass.DataSource = new PointTypeManager().GetPointTypeList();
        //    this.ddlFLInfoclass.DataValueField = "ID";
        //    this.ddlFLInfoclass.DataTextField = "TypeName";
        //    this.ddlFLInfoclass.DataBind();
        //    ListItem li = new ListItem("--请选择--", "0");
        //    this.ddlFLInfoclass.Items.Insert(0, li);
        //}
    }
}