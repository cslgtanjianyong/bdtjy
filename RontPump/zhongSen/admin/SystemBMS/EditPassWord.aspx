<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPassWord.aspx.cs" Inherits="Enterprise.Admin_bs.SystemBMS.EditPassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .td1{ width:45%; text-align:center;}
        .fontzr15 {
            color: #1D759D;
            font-family: 宋体;
            font-size: 15px;
            font-weight: bold;
            line-height: 20pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="30" align="center"><img src="../images/listbiao.gif" width="13" height="27"></td>
                <td width="130" class="fontzr15">修改密码</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2"><img src="../images/listxian.gif" width="160" height="5"></td>
                    <td height="5" background="../images/listxian.gif" colspan="3"></td>
            </tr>
            <tr>
                <td colspan="5" height="5" background="../images/blank.gif"></td>
            </tr>
        </table>
        <div>
            <table width="99%" align="center" cellpadding="1" class="tab">
                <tr>
           <td background="../images/dotlineh.gif" colspan="3" height="5"></td>
           </tr>
               <tr>
                  <td class="td1">旧密码：</td>
                  <td><asp:TextBox ID="txOldPwd" runat="server" TextMode="Password"></asp:TextBox></td>  
                  <td class="td3"></td>     
               </tr>
               <tr>
                    <td background="../images/dotlineh.gif" colspan="3" height="5"></td>
               </tr>
               <tr>
                  <td class="td1">新密码：</td>
                  <td style=" width:200px;"><asp:TextBox ID="txNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>  
                  <td class="td3"></td>  
               </tr>
               <tr>
                  <td background="../images/dotlineh.gif" colspan="3" height="5"></td>
               </tr>
               <tr>
                  <td class="td1">重复密码：</td>
                  <td><asp:TextBox ID="txReNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>  
                  <td class="td3"></td>  
               </tr>
               <tr>
                  <td background="../images/dotlineh.gif" colspan="3" height="5"></td>
               </tr>
               <tr>
                <td colspan="3" align="center" style=" width:800px;">
                 <asp:Button ID="btSaveInfo" runat="server" Text="确认修改"  
                      OnClientClick="return com_validate()" onclick="btSaveInfo_Click"/>&nbsp;&nbsp;
                 <asp:Button ID="btExit" runat="server" Text="取消保存" />

                </td>
                </tr>
           </table>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#txReNewPwd").blur(function () {
                    if ($("#Password").val() != $(this).val()) {
                        $(this).parent().parent().find(".td3").html("<span style='color:red;'>两次密码输入不一致!</span>");
                    }
                });
            });
            function com_validate() {
                if ($(":password").val() == "") {
                    alert("请填写以上内容！");
                    return false;
                }
                return true;
            }
        </script>       
     </form>
</body>
</html>
