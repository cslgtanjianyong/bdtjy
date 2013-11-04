<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
            <li style="background:none;"><a href="contact.asp">联系我们</a></li>
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
        	<div class="web_news_fenlei">
            	<div class="news_fenlei">
           		  <h3 class="every_h3"><span>新闻中心</span></h3>
                    <ul>
                   
                    </ul>
           	     </div>
                <div class="product_gundong">
                    <h3 class="every_h3"><span>产品推荐</span></h3>
                        <ul>
                            <div id="colee" style="overflow:hidden;height:480px;width:220px; margin:0 auto;">
                                <div id="colee1" style=" width:220px; margin:0 auto;">
                              <li></li>
						
                                </div>
                                <div id="colee2"></div>
                                </div>
                                <script>
                                    var speed = 30;
                                    var colee2 = document.getElementById("colee2");
                                    var colee1 = document.getElementById("colee1");
                                    var colee = document.getElementById("colee");
                                    colee2.innerHTML = colee1.innerHTML; //克隆colee1为colee2
                                    function Marquee1() {
                                        //当滚动至colee1与colee2交界时
                                        if (colee2.offsetTop - colee.scrollTop <= 0) {
                                            colee.scrollTop -= colee1.offsetHeight; //colee跳到最顶端
                                        } else {
                                            colee.scrollTop++
                                        }
                                    }
                                    var MyMar1 = setInterval(Marquee1, speed)//设置定时器
                                    //鼠标移上时清除定时器达到滚动停止的目的
                                    colee.onmouseover = function () { clearInterval(MyMar1) }
                                    //鼠标移开时重设定时器
                                    colee.onmouseout = function () { MyMar1 = setInterval(Marquee1, speed) }
                                </script>
                                
                                <!--向上滚动代码结束-->
                        </ul>
                </div>
          	</div> 
            <div class="web_right">
              <div class="lxus">
            	<h3 class="every_h3_nav"><span>联系我们</span></h3>
            		<ul>
                    	<li style="padding-top:100px;">联系人：程经理</li>
                        <li>联系电话：4000757990</li>
                        <li>联系QQ：1483469625</li>
                        <li>公司地址：：江苏省苏州市相城区欧风商业街5栋306号</li>
                        <li>公司传真：0512-66189331</li>
                        <li>公司邮箱：1483469625@qq.com</li>
                    
                    </ul>
              </div>
           </div>
        </div> 
       <div class="lianjie"> 
       		<h3><span>友情链接</span></h3>
                <ul>               
                    <li></li>
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
    
</div>
</body>

