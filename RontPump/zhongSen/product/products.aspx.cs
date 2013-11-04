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

namespace zhongSen.product
{
    public partial class products : System.Web.UI.Page
    {
        ViewPointManager vpManager = new ViewPointManager();
        CaseManager caseManager = new CaseManager();
        CaseTypeManager ctManager = new CaseTypeManager();

        int currentPageIndex = 1;
        int pageSize = 20;
        public static CaseType caseT = null;

        public static IList<CaseType> list = null;
        public static IList<CaseType> list2 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ViewState["CTID"] = Request.QueryString["ctid"] != null ? Request.QueryString["ctid"] : "0";
                ViewState["page"] = Request.QueryString["page"] != null ? Request.QueryString["page"] : "1";
                currentPageIndex = Convert.ToInt32(ViewState["page"]);
                ViewState["SKey"] = Request.QueryString["key"] != null ? Request.QueryString["key"] : "";

                //加载产品分类
                InitCaseTypeLvO();

                //加载推荐新闻
                InitNewsListForRank();

                //加载产品for marq
                InitProductsForMarq();

                //加载产品列表
                InitProducts();
            }
        }


        #region 加载marq产品
        void InitProductsForMarq()
        {
            this.rpt_prct_for_marq.DataSource = caseManager.GetCaseListByStrWhere(12, "");
            this.rpt_prct_for_marq.DataBind();
        }
        #endregion

        #region 加载推荐新闻
        void InitNewsListForRank()
        {
            this.rpt_news_list_for_rank.DataSource = vpManager.GetViewPointListById_top6();
            this.rpt_news_list_for_rank.DataBind();
        }
        #endregion

        #region 加载产品列表
        void InitProducts()
        {
            StringBuilder tblName = new StringBuilder();
            StringBuilder fldName = new StringBuilder();
            StringBuilder strWhere = new StringBuilder();
            StringBuilder fldSort = new StringBuilder();
            fldSort.Append("ID");
            bool sort = false;

            tblName.Append("Cases");
            fldName.Append("*");
            strWhere.Append(" ");

            if (ViewState["CTID"].ToString() != "0")
            {
                strWhere.Append(" and CTID = '" + jsOnClient.ReplaceBadChar(ViewState["CTID"].ToString()) + "' or CTID like '%," + jsOnClient.ReplaceBadChar(ViewState["CTID"].ToString()) + "' or CTID like '" + jsOnClient.ReplaceBadChar(ViewState["CTID"].ToString()) + ",%' or CTID like '%," + jsOnClient.ReplaceBadChar(ViewState["CTID"].ToString()) + ",%'");
                caseT = ctManager.GetCaseTypeByID(Convert.ToInt32(ViewState["CTID"]));
            }

            if (!string.IsNullOrEmpty(ViewState["SKey"].ToString()))
            {
                strWhere.Append(" and CName like '%" + jsOnClient.ReplaceBadChar(ViewState["SKey"].ToString()) + "%' ");
            }


            int pageCount;
            int counts;

            this.rpt_product_list.DataSource = caseManager.GetPagedProducts(tblName.ToString(), fldName.ToString(), pageSize, currentPageIndex, fldSort.ToString(), sort, strWhere.ToString(), out pageCount, out counts);
            this.rpt_product_list.DataBind();

            //string url = "?ctid=" + ViewState["CTID"].ToString() + "&page={0}";
            string url = "http://www.rontpump.com/products-" + ViewState["CTID"].ToString() + "-{0}.html";
            div_showpage.InnerHtml = PageControl.DisplayPagers(currentPageIndex, counts, pageSize, "", url, "");

        }
        #endregion

        #region 加载产品分类
        public void InitCaseTypeLvO()
        {
            list = ctManager.GetCaseType(0);
        }
        public IList<CaseType> InitCaseTypeLvS(int mid)
        {
            list2 = ctManager.GetCaseType(mid);
            return list2;
        }
        #endregion
    }
}