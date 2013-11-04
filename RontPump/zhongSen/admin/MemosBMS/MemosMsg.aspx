<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemosMsg.aspx.cs" Inherits="zhongSen.admin.MemosBMS.MemosMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>留言详细</title>
    <style  type="text/css">
        body{ background:url(../images/otherpic.gif)}
        #lxchid{ width:700px; height:580px; margin:0 auto; }
        #lxchid p{ height:34px; line-height:34px; font-size:16px;}
        #lxchid p img{ cursor:pointer;}
        #lxchid span{ width:240px; display:inline-block; font-size:14px;}
        .lxname{ width:140px; display:inline-block; text-align:right;  color:Blue;}
        .lxTxt{ width:269px;  display:inline-block; text-align:left;}
        #lxchid p{ height:40px; margin:0; padding:0; border-bottom:1px solid gray;}
    </style>
    <script src="../../js/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="30" align="center"><img src="../images/listbiao.gif" width="13" height="27"></td>
            <td width="130" class="fontzr15" >留言详细</td>
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
    <table>
        <tr>
            <td>联系人:</td>
            <td><label class="lxTxt"><%=mem.UserName %></label></td>
        </tr>
        <tr>
            <td>联系电话：</td>
            <td><label class="lxTxt"><%=mem.TelPhone%></label></td>
        </tr>
        <tr>
            <td>邮箱：</td>
            <td><label class="lxTxt"><%=mem.Email%></label></td>
        </tr>
                <tr>
            <td>公司名称：</td>
            <td><label class="lxTxt"><%=mem.Cop%></label></td>
        </tr>
         <tr>
         <td>留言内容：</td>
            <td><label class="lxTxt"><%=mem.MemosContent%></label></td>
        </tr>
<%--        <tr>
            <td>行业：</td>
            <td><label class="lxTxt"><%=mem.Hanye%></label></td>
        </tr>
        <tr>
            <td>顾客职务：</td>
            <td><label class="lxTxt"><%=mem.Zhiwei%></label></td>
        </tr>
        <tr>
            <td>品牌名称：</td>
            <td><label class="lxTxt"><%=mem.BrandName%></label></td>
        </tr>
        <tr>
            <td>品牌网站：</td>
            <td><label class="lxTxt"><%=mem.BrandWeb%></label></td>
        </tr>
        <tr>
            <td>联系电话：</td>
            <td><label class="lxTxt"><%=mem.TelPhone%></label></td>
        </tr>--%>
    </table>
<%--    <div>
        <div style=" width:98%; height:600px; margin:0 auto;"> 
            <div id="lxchid">
                <p style=" height:50px;">&nbsp;</p>
                <p><label class="lxname">公司名称：</label><label class="lxTxt"><%=mem.Cop%></label></p>
                <p><label class="lxname">联系电话：</label><label class="lxTxt"><%=mem.TelPhone%></label><span>&nbsp;</span></p>
                <p><label class="lxname">联系地址：</label><label class="lxTxt"><%=mem.CopAddress %></label></p>
                <p><label class="lxname" >联系人：</label><label class="lxTxt"><%=mem.UserName %></label><span>&nbsp;</span></p>
                <p><label class="lxname" >QQ：</label><label class="lxTxt"><%=mem.QQ %></label><span>&nbsp;</span></p>
                <p style="margin:5px 0; border:0;"><label class="lxname" style="float:left;">详细说明：</label></p>
                <p style=" height:150px; width:300px; margin:0; padding:0; border:0;"><%=mem.MemosContent %></p>
                <hr />
            </div>        
        </div>
    </div>--%>
    </form>
</body>
</html>
