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
    public partial class casenewsadd : System.Web.UI.Page
    {
        CaseTypeManager ctManager = new CaseTypeManager();

        public static string ctids = "";

        private string filePath = HttpContext.Current.Server.MapPath(Com.BDZG.Web.PageData.GetOutterPath(Com.BDZG.Web.PageData.GetTempPath()).ToLower()) + "upload";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utility.RegisterTypeForAjax(typeof(casenewsadd));
                InitCaseTypes();
                this.txtAddTime.Value = DateTime.Now.ToString();
            }
        }

        void InitCaseTypes()
        {
            this.rpt_case_type.DataSource = ctManager.GetCaseType(" where ModelID <> 0 ");
            this.rpt_case_type.DataBind();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ctids.Length < 1)
            {
                this.lblAlert.Text = jsOnClient.Alert("未知分类");
                return;
            }

            Cases _Cs = new Cases();
            _Cs.CName = txtCName.Value;
            //缺失分类
            _Cs.CTID = ctids;
            _Cs.Content = UEditor1.Value;
            _Cs.IsTop = this.chkIsTop.Checked == true ? true : false;
            _Cs.AddTime = Convert.ToDateTime(txtAddTime.Value);
            //_Cs.SmallIMGURL = "";
            //_Cs.BigIMGURL = "";
            _Cs.ImgSrc = "";

            string tempFile = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(999999).ToString();

            if (Files.HasFile)
            {
                Com.BDZG.Web.PageData.createDir(filePath);
            }
            if (Files.HasFile)
            {
                if (!Com.BDZG.Web.PageData.CheckPic(Path.GetExtension(Files.FileName).ToLower()))
                {
                    lblAlert.Text = jsOnClient.Alert("你所选择的附件格式不正确！"); return;
                }
                else
                {

                    string filename = tempFile + "-1" + Path.GetExtension(Files.FileName).ToLower();
                    string savePath = filePath + "/" + filename;
                    Files.SaveAs(savePath);
                    //_Cs.SmallIMGURL = Com.BDZG.Web.PageData.GetOutterPath(Com.BDZG.Web.PageData.GetTempPath()).ToLower() + "upload" + "/" + filename;
                    _Cs.ImgSrc = Com.BDZG.Web.PageData.GetOutterPath(Com.BDZG.Web.PageData.GetTempPath()).ToLower() + "upload" + "/" + filename;
                }
            }
            //if (fu_proimg.HasFile)
            //{
            //    if (!Com.BDZG.Web.PageData.CheckPic(Path.GetExtension(fu_proimg.FileName).ToLower()))
            //    {
            //        lblAlert.Text = jsOnClient.Alert("你所选择的附件格式不正确！"); return;
            //    }
            //    else
            //    {

            //        string filename = tempFile + "-2" + Path.GetExtension(fu_proimg.FileName).ToLower();
            //        string savePath = filePath + "/" + filename;
            //        fu_proimg.SaveAs(savePath);
            //        _Cs.BigIMGURL = Com.BDZG.Web.PageData.GetOutterPath(Com.BDZG.Web.PageData.GetTempPath()).ToLower() + "upload" + "/" + filename;
            //    }
            //}



            if (Convert.ToBoolean(new CaseManager().AddCase(_Cs)) == true)
            {
                Response.Write("<script>alert('添加成功！');window.location.href='casenewsadd.aspx';</script>");
            }
            else
            {
                lblAlert.Text = jsOnClient.Alert("添加失败"); return;

            }
        }

        [AjaxMethod]
        public void StdCaseType(string ctid)
        {
            ctids = ctid;
        }
    }
}