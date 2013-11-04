using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BkShop.UsersControls
{
    public partial class fen_pages : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PagesIndex = 1;
                
                if (BindDatalist != null)
                {
                    BtState();
                    BindDatalist(PagesSize, PagesIndex);
                    this.lbCount.Text = PageCount.ToString();
                    LoadDropDown();
                }
                
                
                
            }
        }
        /// <summary>
        /// 下拉
        /// </summary>
        private void LoadDropDown()
        {

            this.DropDownList1.Items.Insert(0,"-");
            for (int i = 0; i < PageCount; i++)
            {
                this.DropDownList1.Items.Insert(i + 1,(i+1).ToString());
            }
        }
        /// <summary>
        /// 每页显示多少
        /// </summary>
        public int PagesSize 
        {
            get {
                if (ViewState["pageSize"]==null)
                {
                    return 5;
                }
                return Convert.ToInt32(ViewState["pageSize"]); 
            }
            set{
                ViewState["pageSize"] = value;
            }
        }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PagesIndex 
        {
            get {
                if (ViewState["pageIndex"]==null)
                {
                    return 1; 
                }
                return (int)ViewState["pageIndex"];
            }
            set 
            {
                ViewState["pageIndex"] = value;
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            set
            {
                ViewState["PageCount"] = value;
            }
            get
            {
                if (ViewState["PageCount"] != null)
                {
                    return (int)ViewState["PageCount"];
                }
                else
                    return 0;
            }
        }
        protected void OPerate_Click(object sender, EventArgs e)
        {
            LinkButton bt = sender as LinkButton;
            if (bt.CommandName == "First")
            {
                PagesIndex = 1;
            }
            if (bt.CommandName == "End")
            {
                PagesIndex = PageCount;
            }
            if (bt.CommandName == "Up")
            {
                PagesIndex--;
            }
            if (bt.CommandName == "Next")
            {
                PagesIndex++;
            }
            
            BindDatalist(PagesSize, PagesIndex);
            BtState();
        }
        //状态
        private void BtState()
        {
            if (PagesIndex == 1)
            {
                this.likFirst.Enabled = false;
                this.likEnd.Enabled = true;
                this.likNext.Enabled = true;
                this.likUp.Enabled = false;
            }
            if (PagesIndex == PageCount)
            {
                this.likFirst.Enabled = true;
                this.likEnd.Enabled = false;
                this.likNext.Enabled = false;
                this.likUp.Enabled = true;
            }
            if (PagesIndex > 1 && PagesIndex < PageCount)
            {
                this.likFirst.Enabled = true;
                this.likEnd.Enabled = true;
                this.likNext.Enabled = true;
                this.likUp.Enabled = true;
            }
        }
        public delegate void BindData(int pageSize, int pageIndex);
        public BindData BindDatalist;
        //跳转

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tp = this.DropDownList1.SelectedItem.Value;
            PagesIndex = Convert.ToInt32(tp);
            BindDatalist(PagesSize, PagesIndex);
            BtState();
        }
    }
}