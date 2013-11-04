using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;
using BDZG.Control;

namespace zhongSen.news
{
    public partial class news : System.Web.UI.Page
    {
        ViewPointManager vpManager = new ViewPointManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载行业动态
                InitNewsListForHangYe();
                //加载企业新闻
                InitNewsListForCo();
            }
        }

        #region 加载行业动态
        void InitNewsListForHangYe()
        {
            this.rpt_news_list_for_hangye.DataSource = vpManager.GetViewPointList(7,1);
            this.rpt_news_list_for_hangye.DataBind();
        }
        #endregion

        #region 加载企业新闻
        void InitNewsListForCo()
        {
            this.rpt_news_list_for_co.DataSource = vpManager.GetViewPointList(7, 2);
            this.rpt_news_list_for_co.DataBind();
        }
        #endregion

    }
}