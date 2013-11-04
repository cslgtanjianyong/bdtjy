<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinksAdd.aspx.cs" Inherits="zhongSen.admin.LinksBMS.LinksAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>友情链接</title>
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
<body >
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="30" align="center"><img src="../images/listbiao.gif" width="13" height="27"></td>
                <td width="130" class="fontzr15" ><b>添加友链</b></td>
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
        <table width="99%" align="center" cellpadding="1" class="tab">
            <tr>
           <td background="../images/dotlineh.gif" colspan="3" height="5"></td>
           </tr>
           <tr>
              <td class="td1">链接网址：</td>
              <td><asp:TextBox ID="txUrl" runat="server" onblur="return checkurl();"></asp:TextBox></td>
              <td class="td3"><font color="red">&nbsp;* &nbsp;&nbsp;<asp:Label ID="laltxUrl" runat="server" Text=""></asp:Label></font></td> 
           </tr>
           <tr>
              <td background="../images/dotlineh.gif" colspan="3" height="5"></td>
           </tr>
           <tr>
              <td class="td1">链接名称：</td>
              <td><asp:TextBox ID="txLinkName" runat="server"></asp:TextBox></td>  
              <td class="td3"></td>     
           </tr>
           <tr>
              <td background="../images/dotlineh.gif" colspan="3" height="5"></td>
           </tr>
           
           <%if (sendId!=-1){%>
           <tr>
              <td class="td1">添加时间：</td>
              <td><asp:TextBox ID="txAddTime" runat="server" Enabled="false"></asp:TextBox></td>  
              <td class="td3"></td>     
           </tr>
           <tr>
              <td background="../images/dotlineh.gif" colspan="3" height="5"></td>
           </tr>
           <%} %>
           <tr>
              <td colspan="2" align="center">
                 <asp:Button ID="btSaveInfo" runat="server" Text="保 存"  
                      OnClientClick="return com_validate()" onclick="btSaveInfo_Click"/>&nbsp;&nbsp;
                 <asp:Button ID="btReSet" runat="server" Text="重 置" onclick="btReSet_Click"  />
                </td>
           </tr>
        </table>
    </div>
    <script type="text/javascript">
//        var isKong = false;
//        $(document).ready(function () {
//            ///网址
//            $("#txUrl").blur(function () {
//                var strRegex = "^((https|http|ftp|rtsp|mms)?://)"
//                + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@
//                + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184
//                + "|" // 允许IP和DOMAIN（域名）
//                + "([0-9a-z_!~*'()-]+\.)*" // 域名- www.
//                + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名
//                + "[a-z]{2,6})" // first level domain- .com or .museum
//                + "(:[0-9]{1,4})?" // 端口- :80
//                + "((/?)|" // a slash isn't required if there is no file name
//                + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
//                var reg = new RegExp(strRegex);
//                var td3 = $(this).parent().parent().find("td[class='td3']");
//                var url = $(this).val();
//                if (reg.test(url)) {
//                    td3.text("有效网址！");
//                    td3.css("color", "green");
//                    isKong = true;
//                } else {
//                    td3.text("*网址格式不正确！");
//                    td3.css("color", "red");
//                    isKong = false;
//                }
//            });
//        });

//        $(document).ready(function () {
//           ///网址
//            var td3 = $(this).parent().parent().find("td[class='td3']");
//            if ($("#txUrl").val().length == 0) {
//                td3.html("<span style='color:red'>&nbsp;请输入有效网址!</span>");
//                return false;
//            }
//            else {
//                td3.html.html("<span style='color:green'>&nbsp;称谓正确</span>");
//                return true;
//            }
//                });
//      });

        function checkurl() {
            var isKong = false;
            //var td3 = $(this).parent().parent().find("td[class='td3']");
            if ($("#txUrl").val().length == 0) {
                document.getElementById("laltxUrl").innerHTML = "<span style='color:red;'>请输入有效网址！</span>";
                return false;
            }
            else {
                document.getElementById("laltxUrl").innerHTML = "<span style='color:green;'>正确！</span>";
                return true;
            }
        }
 

        function com_validate() {
//            if ($(":text").val() == "") {
//                alert("请填写以上内容！");
//                return false;
//            }
//            if (isKong == false) {
//                alert("请正确输入网址！");
//                return false;
//            }
            // return true;
            checkurl();
            if (checkurl() == true) {
                return true;
            }
            else {
                alert("请检查所填信息");
                return true;
            }
        }
    </script>
    </form>
</body>
</html>
