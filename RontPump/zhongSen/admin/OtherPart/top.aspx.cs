using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnterpriseComm;
using BLL;
using Models;

namespace Enterprise.Admin_bs.OtherPart
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //int Uid = CurrentUser.GetUserInfo.ID;
                lalUserName.Text = CurrentUser.GetUserInfo.LogName;
                //UserInfo _info= new UserManager().GetUserInfoByID(Uid);
                //if (_info == null)
                //{
                    
                //    return;
                //}
                //else
                //{
                //    lalUserName.Text = _info.LogName;
                //}
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            CurrentUser.SetUserInfo = null;
            Session.Clear();
            Response.Write("<script>parent.location.href='../../login.aspx'</script>");
            
        }
    }
}