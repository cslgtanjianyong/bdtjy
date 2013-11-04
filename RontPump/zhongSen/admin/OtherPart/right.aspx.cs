using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;

namespace Enterprise.Admin_bs.OtherPart
{
    public partial class right : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepaet(0);
            }
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindRepaet(int id)
        {
            RepeaterLy.DataSource = new MemosManager().GetMemosList(id);
            RepeaterLy.DataBind();
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

                if (new MemosManager().DelectMemos(strIds))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！')</script>");
                    BindRepaet(Convert.ToInt32(this.DropDownList.SelectedItem.Value));
                };
            }
        }

        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRepaet(Convert.ToInt32(this.DropDownList.SelectedItem.Value));
        }
    }
}