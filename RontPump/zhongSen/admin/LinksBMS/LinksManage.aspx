<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinksManage.aspx.cs" Inherits="zhongSen.admin.LinksBMS.LinksManage" %>

<%@ Register src="../../UsersControls/fen_pages.ascx" tagname="fen_pages" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>友链管理</title>
    <script src="../../js/JScriptcony.js" type="text/javascript"></script>
    <link href="../images/Stylecony.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .pgFenye
        {
            border-top: 0px;
            border: 1px #AECCEB solid;
            width: 97.9%;
            height: 30px;
            margin: 0 auto;
            border-top:0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td valign="top" bgcolor="#FFFFFF">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="30" align="center"><img src="../images/listbiao.gif" width="13" height="27"></td>
                        <td width="130" class="fontzr15" ><b>友链管理</b></td>
                        <td>&nbsp;</td>
                        <td align="right" >
                     &nbsp;&nbsp;<b>链接名称：</b><asp:TextBox ID="txtTitle" runat="server" CssClass="inputTime" MaxLength="50" Height="18">
                     </asp:TextBox>
                                             <asp:Button ID="btnSearch" runat="server" 
                                CssClass="button" Text="查询" onclick="btnSearch_Click"></asp:Button>
                                &nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除" 
                                  OnClick="btnDelete_Click" OnClientClick="javascript:return SubmitAll(this.form);"></asp:Button>
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
                <table width="99%" border="0" align="center" cellpadding="2" cellspacing="1" class="td1">
                          <asp:Repeater ID="RepeaterLinks"  runat="server">
                                <HeaderTemplate>
                                    <tr  class="tr1">
                                    <td align="center" width="5%"><b>序号</b></td>
                                     <td  align="center"  width="25%"><b>链接名称</b></td>
                                    <td  align="center"  width="20%"><b>链接网址</b></td>
                                    <td  align="center" width="20%" ><b>添加时间</b></td>
                                    <td  align="center"  ><b>操作</b></td>	
                                    <td  align="center" width="10%" ><input onclick="javascript:SelectAll(this.form);" type="checkbox" name="chkAll" title="全选">全选</td>			
                                    </tr>
                                </HeaderTemplate>
                              
                                <ItemTemplate>
                                    <tr valign="middle" bgcolor="#FFFFFF" height="26" onmouseout="mOut(this,'#Ffffff');" onmouseover="mOvr(this,'#F0F1EF');">
                                        <td align="center"><%# Container.ItemIndex +1 %></td>
                                        <td align="center"><%#DataBinder.Eval(Container.DataItem, "Fword")%></td>
                                        <td align="center"><%#DataBinder.Eval(Container.DataItem, "FUrl")%></td> 
                                        <td align="center"><%#DataBinder.Eval(Container.DataItem, "AddTime")%></td> 
                                        <td align="center"><a href="LinksAdd.aspx?id=<%#DataBinder.Eval(Container.DataItem, "ID")%>" >操作</a></td>
                                        <td align="center"><input type='checkbox' name='chkEleId' value='<%#DataBinder.Eval (Container.DataItem,"ID")%>'></td>
                                    </tr>
                                </ItemTemplate>
                        </asp:Repeater>
                </table>
           </td>
        </tr>
    </table>

    <div class="pgFenye">

        <uc1:fen_pages ID="fen_pages1" runat="server" />

    </div>
    </form>
</body>
</html>
