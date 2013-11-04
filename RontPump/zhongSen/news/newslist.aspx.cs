using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BLL;
using Models;
using BDZG.Control;
using zhongsen.Comm;

namespace zhongSen.news
{
    public partial class newslist : System.Web.UI.Page
    {

        ViewPointManager vpManager = new ViewPointManager();
        PointTypeManager ptManager = new PointTypeManager();

        public static PointType pointT = null;

        int pageSize = 6;
        int currentPageIndex = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ViewState["type"] = Request.QueryString["type"] != null ? Request.QueryString["type"] : "";
                ViewState["page"] = Request.QueryString["page"] != null ? Request.QueryString["page"] : "1";
                currentPageIndex = Convert.ToInt32(ViewState["page"]);



                //加载推荐新闻
                InitNewsListForRank();
                //加载新闻列表
                InitNewsListForPage();
            }
        }

        #region 加载推荐新闻
        void InitNewsListForRank()
        {
            this.rpt_news_list_for_rank.DataSource = vpManager.GetViewPointListById_top6();
            this.rpt_news_list_for_rank.DataBind();
        }
        #endregion

        #region 加载新闻列表
        void InitNewsListForPage()
        {
            string tblName = "ViewPoint";
            string fldName = "*";
            string fldSort = "ID";
            bool sort = true;

            StringBuilder _str = new StringBuilder();
            _str.Append(" ");

            //判断分类
            if (!string.IsNullOrEmpty(ViewState["type"].ToString()))
            {
                _str.Append(" and TpId = " + jsOnClient.ReplaceBadChar(ViewState["type"].ToString()) + " ");
                pointT = ptManager.GetPointType(Convert.ToInt32(ViewState["type"]));
            }


            int pageCount;
            int counts;

            this.rpt_news_list_for_page.DataSource = vpManager.GetViewPointList(tblName, fldName, pageSize, currentPageIndex, fldSort, sort, _str.ToString(), out pageCount, out counts);
            this.rpt_news_list_for_page.DataBind();

            //string url = "?type=" + jsOnClient.ReplaceBadChar(ViewState["Type"].ToString()) + "&page={0}";
            string url = "http://www.rontpump.com/news-" + jsOnClient.ReplaceBadChar(ViewState["type"].ToString()) + "-{0}.html";
            //string url = "?page={0}";
            div_showpage.InnerHtml = PageControl.DisplayPagers(currentPageIndex, counts, pageSize, "", url, "");
        }
        #endregion

    }
}