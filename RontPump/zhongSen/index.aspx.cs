using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;

namespace zhongSen
{
    public partial class index : System.Web.UI.Page
    {
        ViewPointManager vpManager = new ViewPointManager();
        FriendShipManager fsManager = new FriendShipManager();
        public static IList<FriendShip> links = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "专业生产耐酸碱泵，化工泵，自吸式磁力泵，气动双隔膜泵，价格一流尽在隆恩特(ront)";

                //加载新闻列表
                InitNewsList();
                //加载友链
                InitLinks();

            }
        }

        #region 加载新闻列表
        void InitNewsList()
        {
            IList<ViewPoint> list = vpManager.GetViewPointListById_top6();

            this.rpt_index_news_list.DataSource = list;
            this.rpt_index_news_list.DataBind();
        }
        #endregion

        #region 加载友链
        void InitLinks()
        {
            links = fsManager.GetLinkList_all();
        }
        #endregion

        #region
        protected void btn_go_search_Click(object sender, EventArgs e)
        {
            string key = this.txt_search_key.Text.Trim();
            Response.Redirect("http://www.rontpump.com/products.html?key=" + key);
        }
        #endregion
    }
}