<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="case_type_list.aspx.cs" Inherits="zhongSen.admin.CaseNewsBMS.case_type_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>产品分类</title>
    <link href="../images/Stylecony.css" rel="stylesheet" type="text/css" />
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/jquery-1.9.1.min.js"></script>
    <style type="text/css">
        .main {
            width: 100%;
            min-width: 800px;
            margin: 0 auto;
            padding: 0;
            clear: both;
        }

            .main .ct_hr {
                width: 100%;
                height: 35px;
                margin: 5px auto;
                padding: 0;
                clear: both;
                background: url(../images/listxian.gif) repeat-x bottom;
                position: relative;
            }

                .main .ct_hr img {
                    margin: 0 auto;
                    padding: 0;
                    margin-top: 3px;
                }

                .main .ct_hr span {
                    display: inline-block;
                    margin: 0 auto;
                    position: absolute;
                    margin-top: 5px;
                    margin-left: 5px;
                    font-size: 15px;
                }

            .main .left {
                width:70%;
                height:533px;
                border-right: 1px solid #e2e2e2;
                float: left;
                overflow-y:auto;
                white-space:nowrap;
                margin:10px auto;
            }

                .main .left .lv_1 {
                }

                .main .left .lv_2 {
                    margin: 1px auto;
                    padding: 0 0 0 30px;
                    clear: both;
                }

            .main .right {
                width: 29%;
                min-width: 200px;
                float: left;
            }

                .main .right .pnl {
                    width: 230px;
                    margin: 30px auto;
                    padding: 0;
                    clear: both;
                    text-align: center;
                }

                .main .right .menu {
                    width: 100%;
                    margin: 0 auto;
                    padding: 0;
                    text-align: center;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="ct_hr">
                <img src="../images/listbiao.gif" width="13" height="27">
                <span class="fontzr15">产品分类</span>
            </div>
            <div class="left">
                <% for (int i = 0; i < list.Count; i++)
                   {
                %>
                <div class="lv_1">
                    <%=list[i].CTName %>
                    <a href="javascript:;" data-menu="add" data-id="<%=list[i].ID %>" data-mid="<%=list[i].ID %>">添加</a>
                    <a href="javascript:;" data-menu="update" data-id="<%=list[i].ID %>" data-name="<%=list[i].CTName %>">修改</a>
                    <a href="javascript:;" data-menu="delete" data-id="<%=list[i].ID %>">删除</a>
                    <br />
                </div>
                <% 
                       if (InitLvSCaseType(list[i].ID) != null)
                       {
                           for (int j = 0; j < list2.Count; j++)
                           {
                %>
                <div class="lv_2">
                    <%=list2[j].CTName %>
                    <a href="javascript:;" data-menu="update" data-id="<%=list2[j].ID %>" data-name="<%=list2[j].CTName %>">修改</a>
                    <a href="javascript:;" data-menu="delete" data-id="<%=list2[j].ID %>">删除</a>
                    <br />
                </div>
                <%
                           }
                       }    
                %>
                <%
                   } %>
            </div>
            <div class="right">
                <div class="menu">
                    <a href="javascript:;" data-menu="add" data-mid="0">添加一级分类</a>
                </div>
                <div class="pnl">
                    分类名：<input id="txt_ctname" type="" />
                    <br />
                    <br />
                    <input id="btn_submit" type="button" data-menu="" data-id="" data-mid="" data-name="" value="提交" />
                </div>
                <div style="width:80%; height:320px; margin:0 auto; border:1px solid #e2e2e2;">
                    <div style="width:70px;height:24px; background:#fff; font-size:12px; margin-left:5px; margin-top:-8px; text-align:center;">操作提示</div>
                    <div style="width:95%; font-size:13px;  margin:0 auto; line-height:120%;">
                        <font style="color:#f00; margin-bottom:3px; display:block; clear:both; text-align:center;">请详细阅读</font>
                        1.本页面显示产品分类<br />
                        2.左侧分别为一级、二级分类<br />
                        3.二级分类相对一级分类左缩进约2个汉字宽<br />
                        4.操作提示相关：<br />
                            &nbsp;&nbsp;1)添加一级分类<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;A.点击文本框上方"添加一级分类"<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;B.填写分类名(1-20)个字符长度<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;C.点击按钮"添加"<br />
                            &nbsp;&nbsp;2)添加二级分类<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;A.每个一级分类右侧对应"添加"|"修改"|"删除"<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;A.a.此时添加的是当前大分类的小分类<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;B.a.点击添加、修改<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;B.b.填写分类名文本框<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;B.c.点击添加、修改按钮<br />
                            &nbsp;&nbsp;3)删除<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;A.点击分类后面的"删除"<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;B.删除确认 Y/N? Y：确认 N：取消
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                $(".main a").click(function () {
                    $("#txt_ctname").val("");

                    if ($(this).attr("data-menu") == "add") {
                       // $("#txt_ctname").val("");

                        $("#btn_submit").val("添加");

                        $("#btn_submit").attr("data-menu", $(this).attr("data-menu"));
                        $("#btn_submit").attr("data-mid", $(this).attr("data-mid"));
                    }
                    if ($(this).attr("data-menu") == "update") {
                        $("#btn_submit").val("修改");

                        $("#btn_submit").attr("data-menu", $(this).attr("data-menu"));
                        $("#btn_submit").attr("data-id", $(this).attr("data-id"));
                        $("#btn_submit").attr("data-mid", $(this).attr("data-mid"));
                        $("#txt_ctname").val($(this).attr("data-name"));
                    }
                    if ($(this).attr("data-menu") == "delete") {
                        //$("#txt_ctname").val("");

                        if (!confirm("确认要删除？")) {
                            window.event.returnValue = false;
                        }
                        if (case_type_list.DeleteCaseType($(this).attr("data-id"))) {
                            alert("已删除");
                        }
                        else {
                            alert("系统错误");
                        }
                        window.location.href = window.location.href;
                    }
                });

                $("#btn_submit").click(function () {
                    //alert($(this).attr("data-menu")+","+$(this).attr("data-mid"));
                    var cmd = $(this).attr("data-menu");

                    //输入验证
                    if ($("#txt_ctname").val().length == 0) {
                        alert("请输入分类名");
                        return false;
                    } else if ($("#txt_ctname").val().length > 20) {
                        alert("分类名不超过20个字符");
                        return false;
                    }
                    //add命令确认
                    if ($(this).attr("data-mid").length == 0) {
                        alert("未知操作命令\n如需添加一级分类(大分类)|请点击'添加一级分类'");
                        return false;
                    }

                    switch (cmd) {
                        case "add":
                            if (case_type_list.AddCaseType($("#txt_ctname").val().trim(), $(this).attr("data-mid"))) {
                                alert("新增分类成功");
                            }
                            else {
                                alert("系统错误");
                            }
                            break;
                        case "update":
                            break;
                        default:
                            alert("系统错误");
                            break;
                    }
                    window.location.href = window.location.href;
                });
            </script>
        </div>
    </form>
</body>
</html>
