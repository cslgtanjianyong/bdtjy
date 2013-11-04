<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>苏州圣天缘家具有限公司</title>
<link rel="stylesheet" type="text/css" href="css/css.css"/>
</head>
<body>
<div id="situation">
	<div class="headtop"><ul><a href="#">加入收藏</a> | <a href="#">设为首页</a></ul></div>
	<div class="head"><img src="images/head.jpg" /></div>
    <div class="nav">
    	<ul>         
        	<li><a href="index.aspx">网站首页</a></li>
            <li><a href="about.aspx">企业风貌</a></li>
            <li><a href="news.aspx">新闻动态</a></li>
            <li><a href="product.aspx">产品世界</a></li>
            <li><a href="knowledge.aspx">家具知识</a></li>
            <li><a href="message.aspx">给我留言</a></li>
            <li style="background:none;"><a href="contact.aspx">联系我们</a></li>
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
            <div class="gsjj">
               <h3 class="every_h3_nav"><span>公司简介</span></h3>
            	<ul>
                <span><img src="images/qi.jpg" /></span>
                <li>&nbsp;&nbsp;&nbsp;&nbsp;苏州圣天缘家具有限公司创建于2012年5月17日，座落于苏州市相城区欧风商业街，是一家集家具设计研发、生产销售及售后服务为一体的大型家具企业；现有专项流程技术工人2000多名，其中高级企业管理人员、产品研发人员300多人。</li> 
　  <li>&nbsp;&nbsp;&nbsp;&nbsp;圣天缘家具有限公司自创办以来，一直秉承专业制造一流产品的经营宗旨，按人体工学原理设计每一件产品，开发出一系列款式新颖，精湛绝伦的家具。</li> 
    <li>圣天缘家具有限公司主要的服务有：</li>	 	
    <li>售前服务：我们免费上门实测场地，免费提供专业的家具平面设计，帮您策划最节省空间及经济实用的家具布置。</li>
    <li>售中服务：由圣天缘家具的专业工程师跟进与装修单位的协调工作，确保家具的及时运送及正确安装。</li>
    <li>售后服务： 圣天缘家具所售产品均享有2年的免费保修、5年保养服务。</li>
    <li>苏州圣天缘家具有限公司秉承为用户提供优质产品、人性化服务、优势价格、高效维修的经营方针，以优质的服务回报广大客户！</li>  
                </ul>
            </div>
            <div class="hangye">
                <h3 class="every_h3"><span>行业动态</span></h3>
            	<ul class="xinwenmulu">
               
                	
                   
                </ul> 
            </div>
        </div>
        <!--企业风采-->
        <div class="qyfc">
        	<div class="fc">
            	<h3 class="every_h3_nav"><span>企业风采</span></h3>
            	<ul class="chenpinmulu">
                	<li><span><a href="#"><img src="lodimg/1.jpg" /></a><br /><a href="#">办公司一角</a></span></li>
                    <li><span><a href="#"><img src="lodimg/2.jpg" /></a><br /><a href="#">工厂全景图</a></span></li>
                    <li><span><a href="#"><img src="lodimg/3.jpg" /></a><br /><a href="#">公司总部</a></span></li>
                    <li><span><a href="#"><img src="lodimg/4.jpg" /></a><br /><a href="#">员工培训</a></span></li>
                </ul>
            </div>
            <div class="zp">
            	<h3 class="every_h3"><span>人才招聘</span></h3>
                <ul class="xinwenmulu">
                
                </ul>
            
            </div>
        </div>
        <!--滚动产品-->
        <div class="cp">
        	<h3><span>最新产品</span></h3>
        	<ul>
            	<div id="colee_left" style="overflow:hidden;width:982px;">
                    <table cellpadding="0" cellspacing="0" border="0">
                    <tr><td id="colee_left1" valign="top" align="center">
                    <table cellpadding="2" cellspacing="0" border="0">
                    <tr align="center">
                    
                                    
                          
                      
                    
  <!--<td><li><span><a href="#"><img src="images/1.jpg" width="218" height="148"/></a><br /><a href="#">家具家具家具</a></span></li></td>-->

        
                  
                    </tr>
                    </table>
                    </td>
                    <td id="colee_left2" valign="top"></td>
                    </tr>
                    </table>
                    </div>
                    <script>
                        //使用div时，请保证colee_left2与colee_left1是在同一行上.
                        var speed = 10//速度数值越大速度越慢
                        var colee_left2 = document.getElementById("colee_left2");
                        var colee_left1 = document.getElementById("colee_left1");
                        var colee_left = document.getElementById("colee_left");
                        colee_left2.innerHTML = colee_left1.innerHTML
                        function Marquee3() {
                            if (colee_left2.offsetWidth - colee_left.scrollLeft <= 0)//offsetWidth 是对象的可见宽度
                                colee_left.scrollLeft -= colee_left1.offsetWidth//scrollWidth 是对象的实际内容的宽，不包边线宽度
                            else {
                                colee_left.scrollLeft++
                            }
                        }
                        var MyMar3 = setInterval(Marquee3, speed)
                        colee_left.onmouseover = function () { clearInterval(MyMar3) }
                        colee_left.onmouseout = function () { MyMar3 = setInterval(Marquee3, speed) }
                    </script>
             </ul>
        </div>
        <!--友情链接-->
        <div class="lianjie"> 
       		<h3><span>友情链接</span></h3>
                <ul>               
                    <li>
                        

                    </li>
                </ul> 
       </div>
        
    </div>
    <!-- middle end end--> 
     <div class="footer">
    	<ul>
        	<p><a target= _self href=tencent://message/?uin=1483469625&Site=http://localhost/Default.aspx&Menu=yes><img border="0" SRC=http://wpa.qq.com/pa?p=1:1483469625:1 alt="点击这里给我发消息"></a> <a target= _self href=tencent://message/?uin=1483469625&Site=http://localhost/Default.aspx&Menu=yes><img border="0" SRC=http://wpa.qq.com/pa?p=1:1483469625:1 alt="点击这里给我发消息"></a></p></br>
        	<li>版权所有：苏州圣天缘家具有限公司&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;公司地址：江苏省苏州市相城区欧风商业街5栋306号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;圣天缘总经理：程孝军</li>
            <li>固定电话：0512-66189331  &nbsp;&nbsp;&nbsp;联系电话：4000757990&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;传   真：0512-66189331&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;邮  箱：1483469625@qq.com</li>
<content>技术支持：<a href="http://www.ibodan.cn">博丹中国</a>&nbsp;&nbsp;</br></content>
        </ul>
    
    
    </div>
    
</div>
</body>
</html>

