<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="casenewslist.aspx.cs" Inherits="zhongSen.admin.CaseNewsBMS.casenewslist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/JScriptcony.js" type="text/javascript"></script>
    <link href="../images/Stylecony.css" rel="stylesheet" type="text/css" />
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function QtcheckIszd(value) {
            if (casenewslist.checkIszd(value).value == true) {
                if (confirm("确定要取消置顶吗？") == true) {
                    if (casenewslist.QxIszd(value).value == true) {
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
                    if (casenewslist.SZIszd(value).value == true) {
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="99%" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="30" align="center">
                                <img src="../images/listbiao.gif" width="13" height="27"></td>
                            <td width="130" class="fontzr15">产品列表</td>
                            <td>&nbsp;</td>
                            <td align="right">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        &nbsp;&nbsp;<b>名称：</b><asp:TextBox ID="txtTitle" runat="server" MaxLength="50">
                                        </asp:TextBox>&nbsp;&nbsp;<b>分类:</b><asp:DropDownList ID="ddlFLInfo" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlFLInfo_SelectedIndexChanged">
                                        </asp:DropDownList>&nbsp;<select id="ddlFLInfoclass" runat="server">
                                            <option value="0" selected="selected">---请选择---</option>
                                        </select>
                                        &nbsp;<b>添加时间：</b>
                                        <input id="txtTime1" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'});" />
                                        &nbsp;<b>至</b>&nbsp;<input id="txtTime2" runat="server" onclick="return WdatePicker({ dateFmt: 'yyyy-MM-dd HH :mm :ss' })" />
                                        <asp:Button ID="btnSearch" runat="server"
                                            CssClass="button" Text="查询" onMouseOver="onButton(this);"
                                            onMouseOut="offButton(this);" OnClick="btnSearch_Click"></asp:Button>
                                        &nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除" onMouseOver="onButton(this);" onMouseOut="offButton(this);" OnClick="btnDelete_Click" OnClientClick="javascript:return SubmitAll(this.form);"></asp:Button>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <img src="../images/listxian.gif" width="160" height="5"></td>
                            <td height="5" background="../images/listxian.gif" colspan="3"></td>
                        </tr>
                        <tr>
                            <td colspan="5" height="5" background="../images/blank.gif"></td>
                        </tr>
                    </table>
                    <table width="99%" border="0" align="center" cellpadding="2" cellspacing="1" class="td1">
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <HeaderTemplate>
                                <tr class="tr1">
                                    <td align="center" width="5%"><b>序号</b></td>
                                    <td align="center" width="8%"><b>缩略图</b></td>
                                    <td align="center" width="21%"><b>名称</b></td>
                                    <td align="center" width="15%"><b>分类名</b></td>
                                    <td align="center" width="10%"><b>置顶</b></td>
                                    <td align="center" width="10%"><b>添加时间</b></td>
                                    <td align="center" width="8%"><b>操作</b></td>
                                    <td align="center" width="5%">
                                        <input onclick="javascript: SelectAll(this.form);" type="checkbox" name="chkAll" title="全选"></td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr valign="middle" bgcolor="#FFFFFF" height="26" onmouseout="mOut(this,'#Ffffff');" onmouseover="mOvr(this,'#F0F1EF');">
                                    <td align="center"><%# Container.ItemIndex +1 %></td>
                                    <td align="center"><a href="<%#DataBinder.Eval(Container.DataItem, "ImgSrc")%>" target="_blank">
                                        <img src="<%#DataBinder.Eval(Container.DataItem, "ImgSrc")%>" height="27" alt="" width="35" /></a></td>
                                    <td align="center"><%#DataBinder.Eval(Container.DataItem, "CName")%></td>
                                    <%--<td align="center"><%#CTName(DataBinder.Eval(Container.DataItem, "CaseType.ID").ToString())%></td>--%>
                                    <td align="center"><%# CTName(Eval("CTID").ToString()) %></td>
                                    <td align="center"><a href="javascript:void(0)" onclick="QtcheckIszd(<%#DataBinder.Eval(Container.DataItem, "ID")%>)"><%#DataBinder.Eval(Container.DataItem, "IsTop").ToString() == "True" ? "取消置顶" : "置顶"%></a></td>
                                    <td align="center"><%#string.Format("{0:yyyy-MM-dd}",(DataBinder.Eval(Container.DataItem, "Addtime")))%></td>
                                    <td align="center"><a href="casenewsedit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "ID")%>">修改</a></td>
                                    <td align="center">
                                        <input type='checkbox' name='chkEleId' value="<%#DataBinder.Eval (Container.DataItem,"ID")%>"></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tr align="center" bgcolor="#FFFFFF">
                                    <td colspan="9" style="font-size: 12px;">
                                        <asp:HyperLink ID="hlfir" runat="server" Text="首页"></asp:HyperLink>
                                        <asp:HyperLink ID="hlp" runat="server" Text="上一页"></asp:HyperLink>
                                        <asp:HyperLink ID="hln" runat="server" Text="下一页"></asp:HyperLink>
                                        <asp:HyperLink ID="hlla" runat="server" Text="尾页"></asp:HyperLink>
                                        &nbsp;&nbsp;&nbsp;&nbsp;跳至
         <asp:DropDownList ID="ddlp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
         </asp:DropDownList>页
         共<asp:Label ID="lblpc" runat="server" Text="Label" ForeColor="red"></asp:Label>页  &nbsp;第
        <asp:Label ID="lblp" runat="server" Text="Label" ForeColor="red"></asp:Label>页
                                    </td>
                                </tr>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
