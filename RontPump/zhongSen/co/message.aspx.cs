using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BLL;
using Models;
using BDZG.Control;

namespace zhongSen.co
{
    public partial class message : System.Web.UI.Page
    {
        MemosManager msgManager = new MemosManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_msg_submit_Click(object sender, EventArgs e)
        {
            if (!code_img.Equals(this.txt_code.Text.Trim()))
            {
                this.lbl_msg_result.ForeColor = Color.Red;
                this.lbl_msg_result.Text = "验证码错误";
                //this.lbl_msg_result.Text = "<font style='color:#f00;'>验证码错误</font>";
                return;
            }

            Memos msg = new Memos();
            msg.UserName = this.txt_name.Text.Trim();
            msg.Cop = this.txt_coname.Text.Trim();
            msg.TelPhone = this.txt_tel.Text.Trim();
            msg.Email = this.txt_email.Text.Trim();
            msg.MemosContent = this.txt_content.Text.Trim();

            if (msgManager.AddMemosInfo(msg))
            {
                this.lbl_msg_result.ForeColor = Color.Green;
                this.lbl_msg_result.Text = "留言提交成功";
                //this.lbl_msg_result.Text = "<font style='color:#270;'>留言提交成功</font>";
                string js = "alert('留言提交成功');window.location.href = window.location.href";
                this.ltl_js.Text = jsOnClient.ResponseJS(js);
            }
            else
            {
                this.lbl_msg_result.ForeColor = Color.Red;
                this.lbl_msg_result.Text = "留言提交失败|请稍后再试";
                //this.lbl_msg_result.Text = "<font style='color:#f00;'>留言提交失败|请稍后再试</font>";
                this.ltl_js.Text = jsOnClient.Alert("留言提交失败\n请稍后再试");
            }

        }
    }
}