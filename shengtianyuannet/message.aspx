<%@ Page Language="C#" AutoEventWireup="true" CodeFile="message.aspx.cs" Inherits="message" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>����ʥ��Ե�Ҿ����޹�˾</title>
<link rel="stylesheet" type="text/css" href="css/css.css"/>
</head>
<body>
<div id="situation">
	<div class="headtop"><ul><a href="#">�����ղ�</a> | <a href="#">��Ϊ��ҳ</a></ul></div>
	<div class="head"><img src="images/head.jpg" /></div>
    <div class="nav">
    	<ul>         
        	<li><a href="index.aspx">��վ��ҳ</a></li>
            <li><a href="about.aspx">��ҵ��ò</a></li>
            <li><a href="news.aspx">���Ŷ�̬</a></li>
            <li><a href="product.aspx">��Ʒ����</a></li>
            <li><a href="knowledge.aspx">�Ҿ�֪ʶ</a></li>
            <li><a href="message.aspx">��������</a></li>
            <li style="background:none;"><a href="contact.aspx">��ϵ����</a></li>
        </ul>
    </div>
    <div class="banner">
    	<div class="banner-pic">
        	<ul>
            	<li>
                	<script type="text/javascript">
                	    imgUrl1 = "images/banner1.jpg";
                	    imgtext1 = ""
                	    imgLink1 = escape("#");
                	    imgUrl2 = "images/banner2.jpg";
                	    imgtext2 = "#"
                	    imgLink2 = escape("#");
                	    imgUrl3 = "images/banner3.jpg";
                	    imgtext3 = "#"
                	    imgLink3 = escape("#");
                	    imgUrl4 = "images/banner4.jpg";
                	    imgtext4 = "#"
                	    imgLink4 = escape("#");
                	    imgUrl5 = "images/banner5.jpg";
                	    imgtext5 = "#"
                	    imgLink5 = escape("#");

                	    var focus_width = 1004
                	    var focus_height = 260
                	    var text_height = 0
                	    var swf_height = focus_height + text_height

                	    var pics = imgUrl1 + "|" + imgUrl2 + "|" + imgUrl3 + "|" + imgUrl4 + "|" + imgUrl5
                	    var links = imgLink1 + "|" + imgLink2 + "|" + imgLink3 + "|" + imgLink4 + "|" + imgLink5
                	    var texts = imgtext1 + "|" + imgtext2 + "|" + imgtext3 + "|" + imgtext4 + "|" + imgtext5

                	    document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="' + focus_width + '" height="' + swf_height + '">');
                	    document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="images/focus1.swf"><param name="quality" value="high"><param name="bgcolor" value="#F0F0F0">');
                	    document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
                	    document.write('<param name="FlashVars" value="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '">');
                	    document.write('</object>');
					 </script></li>
        	</ul>
        </div>
    </div>
    <!-- middle star star-->
    <div class="middle">
        <div class="web_middle">
        	<div class="web_left">
            	<h3 class="every_h3"><span>��ϵ����</span></h3>
            	<ul>
                    <li style="height:30px; line-height:30px;"><strong>����ʥ��Ե�Ҿ����޹�˾</strong></li>
                    <li>��ַ:����ʡ�����������ŷ����ҵ��5��306��</li>
                    <li>�绰��4000757990</li>
                    <li>���棺0512-66189331</li>
                    <li>�ֻ���15995798885</li>
                    <li>���䣺1483469625@qq.com</li>
                    <li>��˾��ַ��www.shengtianyuan.cn</li>
                </ul>
            
            </div>
            <div class="web_right">
            	<div class="ly">
                	<h3 class="every_h3_nav"><span>��������</span></h3>
                	<script language='javascript'>function Checkmessage() { if (document.myform.pname.value.length == 0) { alert('��������Ϊ��'); document.myform.pname.focus(); return false; } if (document.myform.info.value.length == 0) { alert('������Ϣ����Ϊ��'); document.myform.info.focus(); return false; } }</script>
<form method='POST' name='myform' onSubmit='return Checkmessage();' action='sqbdo.asp' target='_self'>
<table width='90%' cellpadding='2' cellspacing='0' align='center' class='message_table'>
<tr class='message_tr'>
<td width='20%' height='25' align='right' bgcolor='#FFFFFF' class='message_td1'>����&nbsp;</td>
<td width='70%' bgcolor='#FFFFFF' class='message_input'><input name='contact' type='text' size='30' />
<span class='message_info'>*</span></td>
</tr>
<tr class='message_tr'>
<td align='right' bgcolor='#FFFFFF' class='message_td1'>�绰&nbsp;</td>
<td bgcolor='#FFFFFF' class='message_input'><input name='Tel' type='text' size='30' />
</td>
</tr>

<tr class='message_tr'>
<td align='right' bgcolor='#FFFFFF' class='message_td1'>������ϵ��ʽ&nbsp;</td>
<td bgcolor='#FFFFFF' class='message_input'><input name='other2' type='text' size='30' />��QQ���ֻ������
</td>
</tr>
<tr class='message_tr'>
<td align='right' bgcolor='#FFFFFF' class='message_td1'>��������&nbsp;</td>
<td bgcolor='#FFFFFF' class='message_text'><textarea name='sxrs' cols='50' rows='6'></textarea>
<span class='message_info'>*</span></td>
</tr>
<tr class='message_tr'><td colspan='3' bgcolor='#FFFFFF' class='message_submint' align='center'>
<input type='submit' name='Submit' value='�ύ����' class='tj'>
<input type='reset' name='Submit' value='������д' class='tj'></td></tr>
</table>
</form>    
        	</div>
     	 </div>
        </div>
        <div class="lianjie"> 
       		<h3><span>��������</span></h3>
                <ul>               
                    <li></li>
                </ul> 
       </div>
    </div>
    <!-- middle end end--> 
       <div class="footer">
    	<ul>
        	<p><a target= _self href=tencent://message/?uin=1483469625&Site=http://localhost/Default.aspx&Menu=yes><img border="0" SRC=http://wpa.qq.com/pa?p=1:1483469625:1 alt="���������ҷ���Ϣ"></a> <a target= _self href=tencent://message/?uin=1483469625&Site=http://localhost/Default.aspx&Menu=yes><img border="0" SRC=http://wpa.qq.com/pa?p=1:1483469625:1 alt="���������ҷ���Ϣ"></a></p></br>
        	<li>��Ȩ���У�����ʥ��Ե�Ҿ����޹�˾&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��˾��ַ������ʡ�����������ŷ����ҵ��5��306��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ʥ��Ե�ܾ�����Т��</li>
            <li>�̶��绰��0512-66189331  &nbsp;&nbsp;&nbsp;��ϵ�绰��4000757990&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��   �棺0512-66189331&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��  �䣺1483469625@qq.com</li>
<content>����֧�֣�<a href="http://www.ibodan.cn">�����й�</a>&nbsp;&nbsp;</br></content>
        </ul>
    
    
    </div>
</div>
</body>
</html>
