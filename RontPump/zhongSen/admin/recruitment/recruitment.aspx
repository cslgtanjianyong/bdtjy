<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recruitment.aspx.cs" Inherits="zhongSen.admin.recruitment.recruitment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <link href="../images/Stylecony.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScriptcony.js" type="text/javascript"></script>
    <link href="../../UEditor/themes/default/ueditor.css" rel="stylesheet" type="text/css" />
    <script src="../../UEditor/editor_all.js" type="text/javascript"></script>
    <script src="../../UEditor/editor_config_1.js" type="text/javascript"></script>
    <link href="../../css/admins.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="99%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td valign="top" bgcolor="#FFFFFF">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="30" align="center">
                            <img src="../images/listbiao.gif" width="13" height="27">
                        </td>
                        <td width="130" class="fontzr15">
                            <b>公司招聘</b>
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <img src="../images/listxian.gif" width="160" height="5">
                        </td>
                        <td height="5" background="../images/listxian.gif">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="5" background="../images/blank.gif">
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" width="97%" align="center" bgcolor="#FBFAF9">
                    <tr>
                        <td>
                            <table border="0" cellspacing="1" cellpadding="4" width="100%">
                                <tr>
                                    <td colspan="3">
                                        <fieldset style="height:100%; width:98%; margin:0 auto;">
                                            <textarea name="UEditor1" id="UEditor1" rows="10" cols="30" wrap="virtual" runat="server"></textarea>
                                            <script type="text/javascript">
                                                var option = {};
                                                var UEditor1 = new baidu.editor.ui.Editor(option);
                                                UEditor1.render('UEditor1');
                                            </script>
                                            <div style="float: right;">
                                                <font color="red">&nbsp;* &nbsp;&nbsp;<asp:Label ID="lalContent" runat="server" Text=""></asp:Label></font>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td  width="50px" colspan="2" height="50px">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;<asp:Button ID="btnOK" runat="server" Text="确定" class="button" onmouseover="onButton(this);"
                                            onmouseout="offButton(this);" Style="cursor: hand" OnClick="btnOK_Click"/>&nbsp;&nbsp;<input
                                                style="cursor: hand" class="button" onmouseover="onButton(this);" onmouseout="offButton(this);"
                                                onclick="javascript:history.back()" value="返回" type="button">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>
    <asp:Literal ID="lblAlert" runat="server" />
    </form>
</body>
</html>
