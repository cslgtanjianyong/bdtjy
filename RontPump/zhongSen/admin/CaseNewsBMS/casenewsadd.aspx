<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="casenewsadd.aspx.cs" Inherits="zhongSen.admin.CaseNewsBMS.casenewsadd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<script src="../../js/jquery.js" type="text/javascript"></script>--%>
    <script src="../js/jquery-1.9.1.min.js"></script>
    <link href="../images/Stylecony.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScriptcony.js" type="text/javascript"></script>
    <link href="../../UEditor/themes/default/ueditor.css" rel="stylesheet" type="text/css" />
    <script src="../../UEditor/editor_all.js" type="text/javascript"></script>
    <script src="../../UEditor/editor_config_1.js" type="text/javascript"></script>
    <style type="text/css">
        .cbo {
            width: 267px;
            height: 30px;
            margin: 3px auto;
            margin-right: 10px;
            padding: 0;
            float: left;
            border: 1px dashed #808080;
            position: relative;
            cursor: pointer;
            background: #fff;
        }

            .cbo i {
                width: 100%;
                height: 23px;
                font-style: normal;
                margin: 0 auto;
                padding: 0;
                padding-top: 7px;
                display: inline-block;
                text-align: center;
            }

        .std {
            border: 1px solid #f79948;
            background: #fb834f;
            color: #fff;
        }
    </style>
    <script type="text/javascript">
        function checkAddInfoContentnull() {
            document.getElementById("lalContent").innerHTML = "<span style='color:red;'>内容不能为空！</span>";
            return false;
        }
        function Tishi() {
            alert("请检查所填信息!");
        }
        function checkAddIndextxtCName() {
            var strTitle = document.getElementById("txtCName").value;
            if (strTitle == "") {
                document.getElementById("lalCName").innerHTML = "<span style='color:red;'>名称不能为空！</span>";
                return false;
            }
            else {
                document.getElementById("lalCName").innerHTML = "<span style='color:green;'>名称可用！</span>";
                //        checkclass();
                return true;
            }
        }
        //        function checkclass() {
        //            var _ddlFLInfo = document.getElementById("ddlFLInfo");
        //            if (_ddlFLInfo.value == "0") {
        //                document.getElementById("LblddlFLInfo").innerHTML = "<span style='color:red;'>分类不能为空！</span>";
        //                return false;
        //            }
        //            else {
        //                document.getElementById("LblddlFLInfo").innerHTML = "";
        //                return true;
        //            }
        //        }
        //        function checkupfiles() {
        //            var upf = document.getElementById("<% =Files.ClientID %>");
        //            var upfname = upf.value;
        //            if (upfname == "") {
        //                document.getElementById("LbRecUpload").innerHTML = "<span style='color:red;'>图片不能为空！</span>";
        //                return false;
        //            }
        //            else {
        //                document.getElementById("LbRecUpload").innerHTML = "<span style='color:green;'>图片可用！</span>";
        //                return true;
        //            }
        //        }
        function checkclass() {
            var _ddlFLInfoclass = document.getElementById("ddlFLInfoclass");
            var _ddlFLInfo = document.getElementById("ddlFLInfo");
            if (_ddlFLInfoclass.value == "0") {
                document.getElementById("lalclass").innerHTML = "<span style='color:red;'>分类不能为空！</span>";
                return false;
            }
            else {
                document.getElementById("lalclass").innerHTML = "";
                return true;
            }
        }
        function CasesTypeAddcheck() {
            checkAddIndextxtCName();
            checkclass();
            checkupfiles();

            if (checkAddIndextxtCName() == true && checkclass() == true && checkupfiles() == true) {

                return true;
            }
            else {
                alert("请检查所填信息");
                return false;
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
                                <img src="../images/listbiao.gif" width="13" height="27">
                            </td>
                            <td width="130" class="fontzr15">添加产品
                            </td>
                            <td align="right">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <img src="../images/listxian.gif" width="160" height="5">
                            </td>
                            <td height="5" background="../images/listxian.gif"></td>
                        </tr>
                        <tr>
                            <td colspan="3" height="5" background="../images/blank.gif"></td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="97%" align="center" bgcolor="#FBFAF9">
                        <tr>
                            <td>
                                <table border="0" cellspacing="1" cellpadding="4" width="100%">
                                    <tr>
                                        <td height="1" background="../images/dotlineh.gif" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td width="130px">&nbsp;
                                        </td>
                                        <td width="200px" align="left">名称：
                                        </td>
                                        <td>
                                            <input type="text" id="txtCName" class="input" runat="server" maxlength="50" onblur="return checkAddIndextxtCName();" />
                                            <font color="red">&nbsp;* &nbsp;&nbsp;<asp:Label ID="lalCName" runat="server" Text=""></asp:Label></font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" background="../images/dotlineh.gif" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td width="130px">&nbsp;
                                        </td>
                                        <td width="200px" align="left">类型：
                                        </td>
                                        <td>
                                            <asp:Repeater ID="rpt_case_type" runat="server">
                                                <ItemTemplate>
                                                    <div class="cbo" data-id="<%# Eval("ID") %>" data-mid="<%# Eval("ModelID") %>">
                                                        <i><%# Eval("CTName") %></i>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" background="../images/dotlineh.gif" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td width="130px">&nbsp;
                                        </td>
                                        <td width="200px" align="left">缩略图：
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="Files" runat="server" />
                                            <font color="red">&nbsp;* &nbsp;&nbsp;<asp:Label ID="LbRecUpload" runat="server"
                                            Text=""></asp:Label></font>
                                            <font style="color: #666;">首页</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" background="../images/dotlineh.gif" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td width="130px">&nbsp;
                                        </td>
                                        <td width="200px" align="left">产品图：
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fu_proimg" runat="server" />
                                            <font color="red">&nbsp;* &nbsp;&nbsp;<asp:Label ID="lbl_proimg" runat="server" Text=""></asp:Label></font>
                                            <font style="color: #666;">正常产品图-产品中心</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" background="../images/dotlineh.gif" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td width="130px">&nbsp;
                                        </td>
                                        <td width="200px" align="left">信息内容：
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td height="1" background="../images/dotlineh.gif" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <fieldset style="height: 100%; width: 98%; margin: 0 auto;">
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
                                        <td width="130px">&nbsp;
                                        </td>
                                        <td width="200px" align="left">置顶：
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkIsTop" runat="server" />启用
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" background="../images/dotlineh.gif" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td width="130px">&nbsp;
                                        </td>
                                        <td width="200px" align="left">添加时间：
                                        </td>
                                        <td>
                                            <input id="txtAddTime" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'});"
                                                class="input" readonly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" background="../images/dotlineh.gif" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td width="330px" colspan="2" height="50px">&nbsp;
                                        </td>
                                        <td align="left">&nbsp;&nbsp;<asp:Button ID="btnOK" runat="server" Text="确定" class="button" onmouseover="onButton(this);"
                                            onmouseout="offButton(this);" Style="cursor: hand" OnClick="btnOK_Click" OnClientClick="return CasesTypeAddcheck();" />&nbsp;<input
                                                style="cursor: hand" class="button" onmouseover="onButton(this);" onmouseout="offButton(this);"
                                                onclick="javascript: history.back()" value="返回" type="button">
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
        <script type="text/javascript">
            //$(".cbo").mouseover(function () {
            //    $(this).addClass("std");
            //}).mouseout(function () {
            //    $(this).removeClass("std");
            //});

            var ctid = new Array();
            var i = -1;

            $(".cbo").click(function () {
                //设置样式
                if ($(this).attr("class") == "cbo") {
                    $(this).addClass("std");
                    i = i + 1;
                    ctid.splice(i, 0, $(this).attr("data-id"));
                }
                else {
                    $(this).removeClass("std");
                    ctid.splice(i, 1);
                    i = i - 1;
                }
                ctid.join(',');
                casenewsadd.StdCaseType(ctid);
            });
        </script>
    </form>
</body>
</html>
