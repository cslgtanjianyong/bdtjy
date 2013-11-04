<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewpointAdd.aspx.cs" Inherits="zhongSen.admin.GuanPoint.ViewpointAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <link href="../images/Stylecony.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScriptcony.js" type="text/javascript"></script>
    <link href="../../UEditor/themes/default/ueditor.css" rel="stylesheet" type="text/css" />
    <script src="../../UEditor/editor_all.js" type="text/javascript"></script>
    <script src="../../UEditor/editor_config_1.js" type="text/javascript"></script>
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
                            <img src="../images/listbiao.gif" width="13" height="27">
                        </td>
                        <td width="130" class="fontzr15">
                            添加新闻
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
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="130px">
                                        &nbsp;
                                    </td>
                                    <td width="200px" align="left">
                                        标题：
                                    </td>
                                    <td>
                                        <input type="text" id="txtTitle" class="input" runat="server" maxlength="50" onblur="return checkAddInfoTitle();" />
                                        <font color="red">&nbsp;* &nbsp;&nbsp;<asp:Label ID="lalTitle" runat="server" Text=""></asp:Label></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td width="130px">
                                        &nbsp;
                                    </td>
                                    <td width="200px" align="left">
                                        信息分类：
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFLInfoclass" runat="server" >
                                        </asp:DropDownList>
                                            <font color="red">&nbsp;* &nbsp;&nbsp;
                                        <asp:Label ID="lalclass" runat="server" ></asp:Label></font>
                                    </td>
                                </tr>
                                                               <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="130px">
                                        &nbsp;
                                    </td>
                                    <td width="200px" align="left">
                                       标签(tag):
                                    </td>
                                    <td>
                                 <asp:TextBox ID="txt_tag" runat="server" CssClass="input" Width="600px"></asp:TextBox>
                                    </td>
                                </tr>
                                                               <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="130px">
                                        &nbsp;
                                    </td>
                                    <td width="200px" align="left">
                                      关键词：<br />(meta-keywords):
                                    </td>
                                    <td>
                          <asp:TextBox ID="txt_metakey" runat="server" TextMode="MultiLine" Width="600px" Height="85px"
                        CssClass="input" onblur="return check_keyword()" ></asp:TextBox><font color="red">&nbsp;* &nbsp;&nbsp;<asp:Label ID="lbkey" runat="server" Text=""></asp:Label></font>
                                    </td>
                                </tr>
                                                               <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="130px">
                                        &nbsp;
                                    </td>
                                    <td width="200px" align="left">
                                       描述：<br />(meta-description)
                                    </td>
                                    <td>
 <asp:TextBox ID="txt_metadesc" runat="server" TextMode="MultiLine" Width="600px"
                        Height="85px" CssClass="input" onblur="return check_description()"></asp:TextBox><font color="red">&nbsp;* &nbsp;&nbsp;<asp:Label ID="lbdescript" runat="server" Text=""></asp:Label></font>
                                    </td>
                                </tr>
                                                               <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="130px">
                                        &nbsp;
                                    </td>
                                    <td width="200px" align="left">
                                      简介（导读）:
                                    </td>
                                    <td>
 <asp:TextBox ID="txt_shortdes" runat="server" TextMode="MultiLine" Width="600px"
                        Height="85px" CssClass="input" onblur="return check_introduction()" ></asp:TextBox><font color="red">&nbsp;* &nbsp;&nbsp;<asp:Label ID="Lbinstruct" runat="server" Text=""></asp:Label></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="130px">
                                        &nbsp;
                                    </td>
                                    <td width="200px" align="left">
                                        信息内容：
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <fieldset style=" width: 98%; margin: 0 auto; min-height:400px;">
                                            <textarea name="UEditor1" id="UEditor1" rows="4" cols="30" wrap="virtual" runat="server"></textarea>
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
                                    <td width="130px">
                                        &nbsp;
                                    </td>
                                    <td width="200px" align="left">
                                        置顶：
                                    </td>
                                    <td>
                                    <asp:CheckBox ID="chkIsTop" runat="server" />启用
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="330px" colspan="2" height="50px">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;<asp:Button ID="btnOK" runat="server" Text="确定" class="button" onmouseover="onButton(this);"
                                            onmouseout="offButton(this);" Style="cursor: hand" OnClick="btnOK_Click" OnClientClick="return checkInfo();"/>&nbsp;&nbsp;<input
                                                style="cursor: hand" class="button" onmouseover="onButton(this);" onmouseout="offButton(this);"
                                                onclick="javascript:history.back()" value="返回" type="button" >
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" background="../images/dotlineh.gif" colspan="3">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function checkInfo() {
            
            if ($(":text").val() == "") {
                alert("请填写以上内容！");
                return false;
            }
            if ($("#ddlFLInfoclass").val() == 0) {
                alert("请选择信息分类！");
                return false;
            }
            return true;
        }



        function onclicktis(idd) {
            $("#" + idd).attr("style", "color:red;")
            $("#" + idd).html("*");
        }
        function check_keyword() {
            var strTitle = document.getElementById("txt_metakey").value;
            if (strTitle == "") {
                document.getElementById("lbkey").innerHTML = "<span style='color:red;'>关键字不能为空！</span>";
                return false;
            }
            if (strTitle.length > 200) {
                document.getElementById("lbkey").innerHTML = "<span style='color:red;'>输入的内容过长！</span>";
                return false;
            }
            else {
                document.getElementById("lbkey").innerHTML = "<span style='color:green;'>名称可用！</span>";
                //        checkclass();
                return true;
            }
        }
        function check_description() {
            var description = document.getElementById("txt_metadesc").value;
            if (description == "") {
                document.getElementById("lbdescript").innerHTML = "<span style='color:red;'>内容不能为空！</span>";
                return false;
            }
            if (description.length > 200) {
                document.getElementById("lbdescript").innerHTML = "<span style='color:red;'>输入的内容过长！</span>";
                return false;
            }
            else {
                document.getElementById("lbdescript").innerHTML = "<span style='color:green;'>名称可用！</span>";
                //        checkclass();
                return true;
            }
        }
        function check_introduction() {
            var introduction = document.getElementById("txt_shortdes").value;
            if (introduction == "") {
                document.getElementById("Lbinstruct").innerHTML = "<span style='color:red;'>内容不能为空！</span>";
                return false;
            }
            if (introduction.length > 200) {
                document.getElementById("Lbinstruct").innerHTML = "<span style='color:red;'>输入的内容过长！</span>";
                return false;
            }

            else {
                document.getElementById("Lbinstruct").innerHTML = "<span style='color:green;'>名称可用！</span>";
                //        checkclass();
                return true;
            }
        }
    </script>
    <asp:Literal ID="lblAlert" runat="server" />
    </form>
</body>
</html>
