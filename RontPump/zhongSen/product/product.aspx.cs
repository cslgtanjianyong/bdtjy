using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;

namespace zhongSen.product
{
    public partial class product : System.Web.UI.Page
    {

        ViewPointManager vpManager = new ViewPointManager();
        CaseManager caseManager = new CaseManager();
        CaseTypeManager ctManager = new CaseTypeManager();

        public static Cases proct = null;

        public static IList<CaseType> list = null;
        public static IList<CaseType> list2 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载推荐新闻
                InitNewsListForRank();
                InitCaseTypeLvO();
                //加载产品信息
                InitProductInfo();
            }
        }

        #region 加载推荐新闻
        void InitNewsListForRank()
        {
            this.rpt_news_list_for_rank.DataSource = vpManager.GetViewPointListById_top6();
            this.rpt_news_list_for_rank.DataBind();
        }
        #endregion

        #region 加载产品信息
        void InitProductInfo()
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);

            proct = caseManager.GetCaseByID(id);

            this.Page.Title = proct.CName + "-隆恩特";
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