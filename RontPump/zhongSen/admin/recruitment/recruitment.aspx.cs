using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;
using System.IO;
using EnterpriseComm;

namespace zhongSen.admin.recruitment
{
    public partial class recruitment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Models.Recruitment> _rt = new RecruitmentManager().GetRecruitmentList();
                this.UEditor1.Value = _rt[0].rcontents;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Recruitment _info = new Recruitment();
            _info.rcontents = this.UEditor1.Value;
            if (Convert.ToBoolean(new RecruitmentManager().UpdateRecruitment(_info)) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('修改成功！'); window.location.href='recruitment.aspx'</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('修改失败！'); window.location.href='recruitment.aspx'</script>");
 
            }
        }

    }
}