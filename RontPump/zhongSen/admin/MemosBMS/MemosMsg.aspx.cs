using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BLL;

namespace zhongSen.admin.MemosBMS
{
    public partial class MemosMsg : System.Web.UI.Page
    {
        public Memos mem = new Memos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Pid = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(Pid))
                {
                    BindMemo(Convert.ToInt32(Pid));
                    setRead(Convert.ToInt32(Pid));
                }
                
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindMemo(int id) 
        {
            mem = new MemosManager().GetMemos(id);
        }
        /// <summary>
        /// 设置为已读
        /// </summary>
        private void setRead(int id) {
            new MemosManager().UpdateMemosIsRead(id);
        }
    }
}