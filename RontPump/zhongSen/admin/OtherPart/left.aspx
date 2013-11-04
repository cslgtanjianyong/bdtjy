<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="Enterprise.Admin_bs.OtherPart.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题文档</title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("a[class='head']").parent().find("ul").css("display", "none");
            $("a[class='head']").click(function () {
                $("#navigation").find("ul").css("display", "none");
                $(this).parent().find("ul").css("display", "block");

            });

        });
    </script>
<style type="text/css">
<!--
body {
	margin:0px;
	padding:0px;
	font-size: 12px;
}
#navigation {
	margin:0px;
	padding:0px;
	width:147px;
}
#navigation a.head {
	cursor:pointer;
	background:url(../images/main_34.gif) no-repeat scroll;
	display:block;
	font-weight:bold;
	margin:0px;
	padding:5px 0 5px;
	text-align:center;
	font-size:12px;
	text-decoration:none;
}
#navigation ul {
	border-width:0px;
	margin:0px;
	padding:0px;
	text-indent:0px;
}
#navigation li {
	list-style:none; display:inline;
}
#navigation li li a {
	display:block;
	font-size:12px;
	text-decoration: none;
	text-align:center;
	padding:3px;
}
#navigation li li a:hover {
	background:url(../images/tab_bg.gif) repeat-x;

}
-->
</style>
</head>
<body>
 <div  style="height:50%; ">
  <ul id="navigation">
   <li> <a class="head">产品管理</a>
      <ul>
        <li><a href="../CaseNewsBMS/casenewsadd.aspx" target="rightFrame">添加产品</a></li>
        <li><a href="../CaseNewsBMS/casenewslist.aspx" target="rightFrame">产品管理</a></li>
        <li><a href="../CaseNewsBMS/casetypelist.aspx" target="rightFrame">产品分类</a></li>
          <li><a href="../CaseNewsBMS/case_type_list.aspx" target="rightFrame">管理分类</a></li>
        <li>&nbsp;</li>
      </ul>
    </li>
<%--    <li> <a class="head">中森案例</a>
      <ul>
        <li><a href="../NiceCase/AddCase.aspx" target="rightFrame">添加新内容</a></li>
        <li><a href="../NiceCase/CaseMsg.aspx" target="rightFrame">案例管理</a></li>
        <li>&nbsp;</li>
      </ul>
    </li>--%>
    <li> <a class="head">新闻中心</a>
      <ul>
        <li><a href="../GuanPoint/ViewpointAdd.aspx" target="rightFrame">添加新闻</a></li>
        <li><a href="../GuanPoint/ViewPointMsg.aspx" target="rightFrame">新闻管理</a></li>
        <li>&nbsp;</li>
      </ul>
    </li>
    <li> <a class="head">友情链接</a>
      <ul>
        <li><a href="../LinksBMS/LinksAdd.aspx" target="rightFrame">添加友链</a></li>
        <li><a href="../LinksBMS/LinksManage.aspx" target="rightFrame">友链管理</a></li>
      
        <li>&nbsp;</li>
      </ul>
    </li>
<%--    <li> <a class="head">中森动态</a>
      <ul>
        <li><a href="../NsyXingWen/NewMsg.aspx" target="rightFrame">动态管理</a></li>
        <li><a href="../NsyXingWen/NsyNewAdd.aspx" target="rightFrame">添加动态</a></li>
        <li>&nbsp;</li>
      </ul>
    </li>--%>
        <li> <a class="head">公司招聘</a>
      <ul>
        <li><a href="../recruitment/recruitment.aspx" target="rightFrame">公司招聘</a></li>
        <li>&nbsp;</li>
      </ul>
    </li>
    <li> <a class="head">系统管理</a>
      <ul>
        <%--<li><a href="../SystemBMS/EditOwnInfo.aspx" target="rightFrame">修改信息</a></li>--%>
        <li><a href="../SystemBMS/EditPassWord.aspx" target="rightFrame">修改密码</a></li>
        <li>&nbsp;</li>
      </ul>
    </li>
  </ul>

</div>
</body>
</html>
