<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Skiyo 后台管理工作平台 by Jessica</title>
<link rel="stylesheet" type="text/css" href="css/style.css"/>
<script type="text/javascript" src="js/js.js"></script>
 <script type="text/javascript">
     //创建XHLHttpRequest
     function creatXMLHttpRequest() {
         if (window.ActiveXObject) {//IE浏览器
             return new ActiveXObject("Microsoft.XMLHTTP");
         } else { //非IE浏览器
             return new XMLHttpRequest();
         }
     }
     //按钮的单击事件
     function reset_Click() {
         alert(1);
         document.getElementById("user").value = "";
         document.getElementById("pwd").value = "";
     }
     function submit_Click() {
         var xhr = creatXMLHttpRequest();
         
         //提交到后台处理程序，这里的GetData.ashx是一个一般处理程序
         var url = "ProductInfo.ashx?Name=123&Password=123";
         //获得界面控件的值

         var name = document.getElementById("user").value;

         var Password = document.getElementById("pwd").value;

         //拼接字符串用于传到后台处理程序，必须用escape转码，否则会出现乱码
         var userInfo = "name=" + escape(name) + "&Password=" + escape(Password);
         //处理成功后执行的方法

         xhr.onreadystatechange = function () {

             if (xhr.readyState == 4 && xhr.status == 200) {
                 alert(xhr.responseText);
             }
         }

         xhr.open("GET", url, false);
         //设置头部信息才能被服务器通过Post方式调用        
         xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")


         //发送请求

         xhr.send();
         alert("发送完毕");


     }
    </script>
</head>
<body>
<div id="top"> </div> <form id="form1" >
<form id="login" name="login" runat="server">
  <div id="center">
    <div id="center_left"></div>
    <div id="center_middle">
      <div class="user">
        <label>用户名：
        <input type="text" name="user" id="user" />
        </label>
      </div>
      <div class="user">
        <label>密　码：
        <input type="password" name="pwd" id="pwd" />
        </label>
      </div>
      <div class="chknumber">
        <label>验证码：
        <input name="chknumber" type="text" id="chknumber" maxlength="4" class="chknumber_input" />
        </label>
        <img src="images/checkcode.png" id="safecode" />
      </div>
    </div>
    <div id="center_middle_right"></div>
    <div id="center_submit">
       <ContentTemplate> <div class="button"> <img src="images/dl.gif" width="57" height="20" onclick="submit_Click();" > </div>  </ContentTemplate>
       <ContentTemplate><div class="button"> <img src="images/cz.gif" width="57" height="20" onclick="reset_Click();"> </div>  </ContentTemplate>
    </div>
    <div id="center_right"></div>
  </div>
</form>
<div id="footer"></div>
</body>
</html>
