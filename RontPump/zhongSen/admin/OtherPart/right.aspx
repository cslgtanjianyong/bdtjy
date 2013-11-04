<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="right.aspx.cs" Inherits="Enterprise.Admin_bs.OtherPart.right" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../images/Stylecony.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScriptcony.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td valign="top" bgcolor="#FFFFFF">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="30" align="center"><img src="../images/listbiao.gif" width="13" height="27"></td>
                        <td width="130" class="fontzr15" >客户留言</td>
                        <td>&nbsp;</td>
                        <td align="right" >
                        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList_SelectedIndexChanged">
                            <asp:ListItem Value="0">未读留言</asp:ListItem>
                            <asp:ListItem Value="1">已读留言</asp:ListItem>
                            <asp:ListItem Value="2">全部留言</asp:ListItem>
                        </asp:DropDownList>
                     &nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除" 
                                  OnClick="btnDelete_Click" OnClientClick="javascript:return SubmitAll(this.form);"></asp:Button>
                     <%--<asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>今天内</asp:ListItem>
                            <asp:ListItem>三天内</asp:ListItem>
                            <asp:ListItem>一周内</asp:ListItem>
                            <asp:ListItem>全部</asp:ListItem>
                        </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><img src="../images/listxian.gif" width="160" height="5"></td>
                            <td height="5" background="../images/listxian.gif" colspan="3"></td>
                    </tr>
                    <tr>
                        <td colspan="5" height="5" background="../images/blank.gif"></td>
                    </tr>
                </table>
                            
                <table width="96%" border="0" align="center" cellpadding="2" cellspacing="1" class="td1">
                    <asp:Repeater ID="RepeaterLy"  runat="server">
                        <HeaderTemplate>
                            <tr  class="tr1">
                                <td  align="center" width="8%" ><b>序号</b></td>	
                                <td  align="center"  width="19%"><b>用户名</b></td>
                   <%--         <td  align="center" width="10%" ><b>联系电话</b></td>--%>
                                <td  align="center"  width="15%"><b>联系电话</b></td>
                                <td  align="center"  width="15%"><b>邮箱</b></td>
                                <td  align="center"  width="15%"><b>公司名称</b></td>
                            <td  align="center" width="10%" ><b>提交时间</b></td>
                            <td  align="center" width="10%" ><b>操作</b></td>
                            <td  align="center" width="8%" ><input onclick="javascript:SelectAll(this.form);" type="checkbox" name="chkAll" title="全选"></td>				
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr valign="middle" bgcolor="#FFFFFF" height="26" onmouseout="mOut(this,'#Ffffff');" onmouseover="mOvr(this,'#F0F1EF');">
                            <td align="center"><%# Container.ItemIndex +1 %></td>  
                                <td align="center"><%#DataBinder.Eval(Container.DataItem, "UserName")%></td> 
                               <%-- <td align="center"><%#DataBinder.Eval(Container.DataItem, "TelPhone")%></td>--%>
                                <td align="center"><%#DataBinder.Eval(Container.DataItem, "TelPhone")%></td> 
                                <td align="center"><%#DataBinder.Eval(Container.DataItem, "Email")%></td>
                                 <td align="center"><%#DataBinder.Eval(Container.DataItem, "Cop")%></td>
                                <td align="center"><%#string.Format("{0:yyyy-MM-dd}",DataBinder.Eval(Container.DataItem, "SubTime"))%></td> 
                                <td align="center"><a href="../MemosBMS/MemosMsg.aspx?id=<%#DataBinder.Eval(Container.DataItem, "ID")%>" >查看详细</a></td>
                                <td align="center"><input type='checkbox' name='chkEleId' value='<%#DataBinder.Eval (Container.DataItem,"ID")%>'></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
           </td>
        </tr>
    </table>
    </form>
</body>

</html>
