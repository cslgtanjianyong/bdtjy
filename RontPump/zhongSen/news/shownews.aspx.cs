using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;

namespace zhongSen.news
{
    public partial class shownews : System.Web.UI.Page
    {

        ViewPointManager vpManager = new ViewPointManager();
        public static ViewPointExtend vp = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载推荐新闻
                InitNewsListForRank();

                //加载新闻信息
                InitNewsInfoByID();
            }
        }

        #region 加载推荐新闻
        void InitNewsListForRank()
        {
            this.rpt_news_list_for_rank.DataSource = vpManager.GetViewPointListById_top6();
            this.rpt_news_list_for_rank.DataBind();
        }
        #endregion

        #region  加载新闻信息
        void InitNewsInfoByID()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            vp = vpManager.GetViewPointExtendByID(id);
            this.Page.Title = vp.Title + "-隆恩特";
        }
        #endregion

    }
}