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

namespace zhongSen.admin.NiceCase
{
    public partial class AddCase : System.Web.UI.Page
    {
        BoutiqueCaseManager casema = new BoutiqueCaseManager();
        public string pic = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bindDropList();
                string sId = Request.QueryString["CID"];
                if (!string.IsNullOrEmpty(sId))
                {
                    LoadInfo(Convert.ToInt32(sId));
                }

            }
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadInfo(int d)
        {
            BoutiqueCase fir = casema.GetBCase(d);
            
            if (fir != null)
            {
                
                ViewState["isNUlls"] = d;
                pic = fir.Logo;
                ViewState["pic"] = pic;
                this.Txkehu.Value = fir.Client;
                this.TxItems.Value = fir.item;
                this.TxBackGd.Value = fir.Background;
                this.Txhanye.Value = fir.Hanye;
                this.Txtiaozhan.Value = fir.Challenge;
                this.UEditor1.Value = fir.gain;
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        private void ResSet()
        {
            this.Txkehu.Value = null;
            this.TxItems.Value = null;
            this.TxBackGd.Value = null;
            this.Txhanye.Value = null;
            this.Txtiaozhan.Value = null;
            this.UEditor1.Value = null;
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

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //string n = hidModel.Value;
            BoutiqueCase cas = new BoutiqueCase();
            int upInfo = uploadPic(FileUploadPic);
            if (upInfo == 1 && ViewState["pic"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('请选择图片！');</script>");
                return;
            }
            if (upInfo == 1 && ViewState["pic"] != null)
            {
                cas.Logo = ViewState["pic"].ToString();
            }else if(upInfo==2)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('图片格式不正确,请重新选择！');</script>");
                return;
            }
            else if (upInfo == 3)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('图片大小超出！');</script>");
                return;
            }
            else if (upInfo == 4)
            {
                cas.Logo = ViewState["Logo"].ToString();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('图片上传成功！');</script>");
            }
            //else {
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('图片上传失败！');</script>");
            //    return;
            //}

            
            cas.Client = this.Txkehu.Value;
            cas.item = this.TxItems.Value;
            cas.Background = this.TxBackGd.Value;
            cas.Hanye = this.Txhanye.Value;
            cas.Challenge = this.Txtiaozhan.Value;
            cas.gain = this.UEditor1.Value;
            if (ViewState["isNUlls"] == null)
            {
                if (casema.AddBoutiqueCase(cas))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('添加成功！'); window.location.href='CaseMsg.aspx'</script>");
                    ResSet();
                }
            }
            else 
            {
                cas.ID = Convert.ToInt32(ViewState["isNUlls"]);
                if (casema.EidtBoutiqueCase(cas))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>alert('修改成功！');</script>");
                    LoadInfo(Convert.ToInt32(ViewState["isNUlls"]));
                }
            }
            
        }
        
        /// <summary>
        /// 上传图片
        /// </summary>
        private int uploadPic( FileUpload fileup)
        {
            string[] formats = { "gif", "jpg", "png", "bmp" };
            string urls = fileup.PostedFile.FileName;
            if (string.IsNullOrEmpty(urls))
            {
                //this.LbRecUpload.Text = "请选择图片！";
                return 1;
            }
            string layout = urls.Substring(urls.LastIndexOf(".")+1);//获取格式
            bool isFormat = false;
            for (int i = 0; i < formats.Length; i++)
            {
                if (layout == formats[i])
                {
                    isFormat = true;
                    break;
                }
            }
            if (isFormat == false)
            {
                //this.LbRecUpload.Text = "图片格式不正确,请重新选择！";
                return 2;
            }
            int FileLength = fileup.PostedFile.ContentLength;
            //****判断是否伪装格式

            //判断是否大小是超出
            if (FileLength > 52100)
            {
                //this.LbRecUpload.Text = "图片大小超出！";
                return 3;
            }
            else
            {
                if (Directory.Exists(Server.MapPath("~/upload/Logo")) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(Server.MapPath("~/upload/Logo"));
                }
                urls =DateTime.Now.ToString("yyMMddhhmmssms")+"." + layout;
                string serverpath = Server.MapPath("~/upload/Logo/") + urls;//转换成具体的物理路径

                fileup.SaveAs(serverpath);

                if (File.Exists(serverpath))//判断是否上传到服务器
                {
                    //this.LbRecUpload.Text = "上传成功!";
                    ViewState["Logo"] = "/../../upload/Logo/" + urls;//服务器的地址
                    return 4;
                }
                else
                {
                    //this.LbRecUpload.Text = "上传失败!";
                    return 5;
                }
            }
        }


    }
}