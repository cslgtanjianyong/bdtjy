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
using System.IO;
using Ajax;

namespace zhongSen.admin.CaseNewsBMS
{
    public partial class casenewsedit : System.Web.UI.Page
    {
        CaseTypeManager ctManager = new CaseTypeManager();

        public static Cases _info = null;
        public static string ctids = "";


        private string filePath = HttpContext.Current.Server.MapPath(Com.BDZG.Web.PageData.GetOutterPath(Com.BDZG.Web.PageData.GetTempPathcn()).ToLower()) + "upload";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utility.RegisterTypeForAjax(typeof(casenewsedit));

                //绑定分类
                InitCaseTypes();

                //加载信息
                InitCasesInfo();
            }
        }

        void InitCaseTypes()
        {
            this.rpt_case_type.DataSource = ctManager.GetCaseType(" where ModelID <> 0 ");
            this.rpt_case_type.DataBind();
        }

        void InitCasesInfo()
        {
            _info = new CaseManager().GetCaseByID(Convert.ToInt32(Request.QueryString["id"]));
            txtCName.Value = _info.CName;


            if (!string.IsNullOrEmpty(_info.ImgSrc))
            {
                LbRecUpload.Text = "<a href=" + _info.ImgSrc + " target='_blank' style='color:green;'>查看图片</a>";
            }
            UEditor1.Value = _info.Content;
            this.chkIsTop.Checked = _info.IsTop;

            //加载分类已选中项
            ctids = _info.CTID;
            string[] tempctids = _info.CTID.Split(',');

            string jstempctids = "";
            for (int i = 0; i < tempctids.Length; i++)
            {
                if (i < tempctids.Length - 1)
                {
                    jstempctids += "'" + tempctids[i] + "',";
                }
                else
                {
                    jstempctids += "'" + tempctids[i] + "'";
                }
            }

            string js = " var jsctids = new Array(); jsctids.unshift(" + jstempctids + "); $('.cbo').each(function () { for (var i = 0; i < jsctids.length; i++) { if ($(this).attr('data-id') == jsctids[i]) { $(this).addClass('std'); arri = arri + 1; ctid.splice(arri, 0, $(this).attr('data-id')); } } })";
            this.lblAlert.Text = jsOnClient.ResonseJsText(js);
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
            //Cases _info = new Cases();
            _info.CName = txtCName.Value;
            //_info.CaseType.ID = Convert.ToInt32(ddlFLInfoclass.Value);
            //分类缺失
            if (ctids.Trim().Length < 1)
            {
                this.lblAlert.Text = jsOnClient.Alert("未知分类");
                return;
            }
            _info.CTID = ctids;

            _info.Content = UEditor1.Value;
            _info.IsTop = this.chkIsTop.Checked == true ? true : false;
            //_info.ID = Convert.ToInt32(Request.QueryString["id"]);

            if (Files.HasFile)
            {
                if (!Com.BDZG.Web.PageData.CheckPic(Path.GetExtension(Files.FileName).ToLower()))
                {
                    lblAlert.Text = jsOnClient.Alert("你所选择的附件格式不正确！"); return;
                }
                else
                {
                    DeleteOldPic(_info.ImgSrc);
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(999999).ToString() + Path.GetExtension(Files.FileName).ToLower();
                    string savePath = filePath + "/" + filename;
                    Files.SaveAs(savePath);
                    _info.ImgSrc = Com.BDZG.Web.PageData.GetOutterPath(Com.BDZG.Web.PageData.GetTempPathcn()).ToLower() + "upload" + "/" + filename;

                }
            }
            //else
            //{
            //    _info.ImgSrc = new CaseManager().GetCaseByID(Convert.ToInt32(Request.QueryString["id"])).ImgSrc;
            //}

            if (Convert.ToBoolean(new CaseManager().UpdateCasesById(_info)) == true)
            {
                //Response.Write("<script>alert('修改成功！');window.location.href='casenewsedit.aspx?id=" + Request.QueryString["id"] + "';</script>");
                Response.Write("<script>alert('修改成功！');window.location.href='casenewslist.aspx';</script>");
            }
            else
            {
                lblAlert.Text = jsOnClient.Alert("操作失败"); return;
            }
        }
        void DeleteOldPic(string path)
        {
            //如果存在则删除
            string rr = HttpContext.Current.Server.MapPath("~" + path);
            if (File.Exists(rr))
            {
                File.Delete(rr);
            }
        }


        [AjaxMethod]
        public void StdCaseType(string ctid)
        {
            ctids = ctid;
        }
    }
}