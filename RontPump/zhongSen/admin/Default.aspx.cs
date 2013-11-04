using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnterpriseComm;

namespace Enterprise.Admin_bs
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentUser.GetUserInfo==null)
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }
    }
}