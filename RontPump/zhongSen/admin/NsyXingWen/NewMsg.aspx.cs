﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;

namespace zhongSen.admin.NsyXingWen
{
    public partial class NewMsg : System.Web.UI.Page
    {
        NsyNewsManager NewMage = new NsyNewsManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getPages();
            }
            ViewState["Ordertype"] = "id";
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
            pg.types = ViewState["Ordertype"].ToString().Trim();
            if (ViewState["Tiaojian"] != null)
            {
                pg.Tiaojian = ViewState["Tiaojian"].ToString();
            }
            else
            {
                pg.Tiaojian = null;
            }

            this.RepeaterNew.DataSource = NewMage.GetNsyNewList(pg);
            this.RepeaterNew.DataBind();
        }
        //获取总页数
        private void getPages()
        {
            int pages = 0;
            int cout = NewMage.getCount();
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
                string path = HttpContext.Current.Server.MapPath("~/FirstPage/new/");
                if (NewMage.DelFriendShop(strIds,path))
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！')</script>");
                    Loadlist(this.fen_pages1.PagesSize, this.fen_pages1.PagesIndex);
                };
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
            getPages();
            Loadlist(this.fen_pages1.PagesSize, this.fen_pages1.PagesIndex);
        }
    }
}