<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="casetypelist.aspx.cs" Inherits="zhongSen.admin.CaseNewsBMS.casetypelist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/JScriptcony.js" type="text/javascript"></script>
    <link href="../images/Stylecony.css" rel="stylesheet" type="text/css" />
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="99%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td valign="top" bgcolor="#FFFFFF">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="30" align="center"><img src="../images/listbiao.gif" width="13" height="27"></td>
                        <td width="130" class="fontzr15" >产品分类</td>
                        <td>&nbsp;</td>
                        <td align="right" >
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
                          <asp:Repeater ID="rpt_casetype"  runat="server">
                                <HeaderTemplate>
                                    <tr  class="tr1">
                                    <td  align="center" width="5%"><b>序号</b></td>
                                    <td  align="center"  width="45%"><b>名称名</b></td>
                                    <td  align="center"  width="50%"><b>大分类</b></td>	
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr valign="middle" bgcolor="#FFFFFF" height="26" onmouseout="mOut(this,'#Ffffff');" onmouseover="mOvr(this,'#F0F1EF');">
                                    <td align="center"><%# Container.ItemIndex +1 %></td>  
                                    <td align="center"><%#DataBinder.Eval(Container.DataItem, "CTName")%></td>
                                    <td align="center"><%#GetModelName(DataBinder.Eval(Container.DataItem, "ModelID").ToString())%></td>
                                    </tr>
                                </ItemTemplate>
        </asp:Repeater>
           </td>
        </tr>
    </table>
    <div>
    </div>
    </form>
</body>
</html>