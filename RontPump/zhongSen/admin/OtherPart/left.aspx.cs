using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnterpriseComm;

namespace Enterprise.Admin_bs.OtherPart
{
    public partial class left : System.Web.UI.Page
    {
        public int roles = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //int num = new UserManager().GetIsAdmin(CurrentUser.GetUserInfo.ID);
                //roles=num;
            }
        }
    }
}