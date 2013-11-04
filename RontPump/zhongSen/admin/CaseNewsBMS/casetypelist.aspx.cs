using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Models;
using BDZG.Control;
using System.Text;

namespace zhongSen.admin.CaseNewsBMS
{
    public partial class casetypelist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindrpt_casetype();
            }
        }
        void bindrpt_casetype()
        {
            rpt_casetype.DataSource = new CaseTypeManager().GetAllCaseTypes();
            rpt_casetype.DataBind();
        }
        /// <summary>
        /// 获取大分类的名称GetCaseTypeByID
        /// </summary>
        public string GetModelName(string _mid)
        {
            CaseType _CT = new CaseTypeManager().GetCaseTypeByID(Convert.ToInt32(_mid));
            return _CT.CTName;
        }
    }
}