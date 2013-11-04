using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnterpriseComm;
using BLL;
using Models;

namespace zhongSen.admin.LinksBMS
{
    public partial class LinksAdd : System.Web.UI.Page
    {
        public int sendId = -1;
        FriendShipManager firMang = new FriendShipManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sId = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(sId))
                {
                    //判断是否为空
                    sendId = Convert.ToInt32(sId);
                    LoadInfo(sendId);
                }

            }
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadInfo(int d)
        {
            FriendShip fir = firMang.GetLinks(d);
            if (fir != null)
            {
                ViewState["isNUlls"] = sendId;
                this.txLinkName.Text = fir.Fword;
                this.txUrl.Text = fir.FUrl;
                this.txAddTime.Text = fir.AddTime.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btSaveInfo_Click(object sender, EventArgs e)
        {
            FriendShip fir = new FriendShip();
            fir.Fword = this.txLinkName.Text;
            fir.FUrl = this.txUrl.Text;
            if (ViewState["isNUlls"]!= null)
            {
                fir.ID = Convert.ToInt32(ViewState["isNUlls"]);
                if (firMang.EditFriendShip(fir))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('修改成功！');</script>");
                    LoadInfo(Convert.ToInt32(ViewState["isNUlls"]));
                }
            }
            else 
            {
                if (firMang.AddFriendShip(fir))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('添加成功！');window.location.href='LinksManage.aspx';</script>");
                }
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        private void ResSet() 
        {
            this.txLinkName.Text = null;
            this.txUrl.Text = null;
            this.txAddTime.Text = null;
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btReSet_Click(object sender, EventArgs e)
        {
            ResSet();
        }
    }
}