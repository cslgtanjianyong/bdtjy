<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="zhongSen.Login" %>

<%@ Register Assembly="VlidateCode" Namespace="VlidateCode" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #UserName{ font-size:16px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
	     <div id="top">
		      <div id="top_left"><img src="../images/login_03.gif" /></div>
			  <div id="top_center"></div>
		 </div>
		 
		 <div id="center">
		      <div id="center_left"></div>
			  <div id="center_middle">
			       <div id="user"><label class="lab">用户名：</label>
			         <input type="text"  id="UserName" runat="server" value="ksront"/>
			       </div>
				   <div id="password"><label class="lab">密码：</label>
				     <input type="password" id="UserPassWord" runat="server" value="123"/>
				   </div>
                   <div id="validate"><label class="lab" >验证码：</label>
				     <input type="password" id="validateText" runat="server"/>
                     <cc1:ValidateCodeImage ID="ValidateCode" runat="server" />
				   </div>
			  </div>
			  <div id="center_right"></div>		 
		 </div>
		 <div id="down">
		      <div id="down_left">
			      <div id="inf">
                       <span class="inf_text">版本信息</span>
					   <span class="copyright">博丹中国 Layout & Design  2012-2013</span>
			      </div>
			  </div>
			  <div id="down_center">
                 <div id="btn"><asp:Button ID="ToLogin" runat="server" Text="登陆"  Width="65" Height="27"
                           Border="#666666"  onclick="ToLogin_Click" />&nbsp;
                           <asp:Button ID="Button1" runat="server" Text="清空"  Width="65" Height="27"
                           Border="#666666"  />
                   </div>
              </div>		 
		 </div>

	</div>
    </form>
</body>
</html>
