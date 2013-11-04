<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPointMsg.aspx.cs" Inherits="zhongSen.admin.GuanPoint.ViewPointMsg" %>

<%@ Register Src="../../UsersControls/fen_pages.ascx" TagName="fen_pages" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../images/Stylecony.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScriptcony.js" type="text/javascript"></script>
    <style type="text/css">
        .pgFenye
        {
            border-top: 0px;
            border: 1px #AECCEB solid;
            width: 98.9%;
            height: 30px;
            margin: 0 auto;
            border-top:0;
        }
    </style>
        <script type="text/javascript">
            function QtcheckIszd(value) {
                if (ViewPointMsg.checkIszd(value).value == true) {
                    if (confirm("确定要取消置顶吗？") == true) {
                        if (ViewPointMsg.QxIszd(value).value == true) {
                            alert("取消置顶成功！");
                            //window.location.href='ArticlesList.aspx';
                            window.location.reload();
                        }
                        else {
                            alert("设置失败！");
                            return false;
                        }
                    }
                }
                else {
                    if (confirm("确定要设为置顶么？") == true) {
                        if (ViewPointMsg.SZIszd(value).value == true) {
                            alert("设置置顶成功！");
                            //  window.location.href='ArticlesList.aspx';
                            window.location.reload();
                        }
                        else {
                            alert("设置失败！");
                            return false;
                        }
                    }
                }
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <table width="99%" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="30" align="center">
                                <img src="../images/listbiao.gif" width="13" height="27">
                            </td>
                            <td width="130" class="fontzr15">
                                <b>新闻管理</b>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <b>关键字：</b><asp:TextBox ID="txtTitle" runat="server" CssClass="inputTime" MaxLength="50"></asp:TextBox>
                                &nbsp;&nbsp<b>模块：</b> &nbsp;
                                <asp:DropDownList ID="ddlFLInfoclass" runat="server" AutoPostBack="True" >
                                </asp:DropDownList>
                            </td>
                            <td align="right" width="150px">
                                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查询" onMouseOver="onButton(this);"
                                    onMouseOut="offButton(this);" OnClick="btnSearch_Click"></asp:Button>&nbsp;&nbsp;<asp:Button
                                        ID="btnDelete" runat="server" CssClass="button" Text="删除" onMouseOver="onButton(this);"
                                        onMouseOut="offButton(this);" OnClick="btnDelete_Click" OnClientClick="javascript:return SubmitAll(this.form);">
                                    </asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <img src="../images/listxian.gif" width="160" height="5">
                            </td>
                            <td height="5" background="../images/listxian.gif" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" height="5" background="../images/blank.gif">
                            </td>
                        </tr>
                    </table>
                    <table width="99%" border="0" align="center" cellpadding="2" cellspacing="1" class="td1">

                        <asp:Repeater ID="RepeaterDate" runat="server">
                            <HeaderTemplate>
                                <tr class="tr1">
                                    <td align="center" width="5%">
                                        <b>序号</b>
                                    </td>
                                    <td align="center" width="30%">
                                        标题
                                    </td>
                                    <td align="center" width="25%">
                                        模块
                                    </td>
                                    <td align="center" width="15%">
                                        添加时间
                                    </td>
                                 <td align="center" width="10%">
                                        置顶
                                    </td>
                                    <td align="center" width="10%">
                                        操作
                                    </td>
                                    <td align="center" width="5%">
                                        <input onclick="javascript:SelectAll(this.form);" type="checkbox" name="chkAll" title="全选">
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr valign="middle" bgcolor="#FFFFFF" height="26" onmouseout="mOut(this,'#Ffffff');"
                                    onmouseover="mOvr(this,'#F0F1EF');">
                                    <td align="center">
                                        <%# Container.ItemIndex +1 %>
                                    </td>
                                    <td align="left">
                                        <%#DataBinder.Eval(Container.DataItem, "Title")%>
                                    </td>
                                    <td align="center">
                                        <%#DataBinder.Eval(Container.DataItem, "TypeName").ToString()%>
                                    </td>
                                    <td align="center">
                                        <%#DataBinder.Eval(Container.DataItem, "AddTime")%>
                                    </td>
<td align="center"><a href="javascript:void(0)" onclick="QtcheckIszd(<%#DataBinder.Eval(Container.DataItem, "ID")%>)" ><%#DataBinder.Eval(Container.DataItem, "IsTop").ToString() == "1" ? "取消置顶" : "置顶"%></a></td>
                                    <td align="center">
                                        <a href="ViewpointAdd.aspx?CID=<%#DataBinder.Eval(Container.DataItem, "ID")%>">修改</a>
                                    </td>
                                    <td align="center">
                                        <input type='checkbox' name='chkEleId' value="<%#DataBinder.Eval (Container.DataItem,"ID")%>">
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                </td>
            </tr>
        </table>
        <div class="pgFenye">
            <uc1:fen_pages ID="fen_pages1" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
