<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type">	
		<link rel="stylesheet" type="text/css" href="css/css.css"></link>
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
    <div class="middle">
    <!--middle1部分-->
        <div class="middle1">
            <div class="middle-left">
            	<h3><span>产品展示</span></h3>
                <ul>
        
                   
                </ul>	
            </div>
            <div class="middle-right">
            	<div class="jianjie">
                	<h3><span>公司简介</span></h3>
                	<ul>
                    	<span><img src="images/jianjiepic.jpg" /></span>
                    	<li>苏州圣天缘家具有限公司是以家具生产、家具销售、服务为一体的家具有限公司。公司以顾客缔造一个既舒适又极富个性化的人性化精神、及时完善售后，为客户提供轻松舒适的</li><li>服务。圣天缘家具以需求为导向，生产高档星级酒店、高级行政办公楼、精装精品公寓、及住房楼盘的酒店家具等百种近千款色的产品；产品采用优质的家具配件，使产品的品质得到保证。现状经济的蓬勃发展，人们的日常生活水平的提高，对工作、生
活休闲环境的要求越来越一体化【<a href="about.aspx">查看详情</a>】</li>
                    </ul>
                    <div class="qq">
                        <ul>
                        <li><a target=blank href=http://wpa.qq.com/msgrd?V=1&Uin=1483469625&Site=&Menu=yes><img border="0" SRC=http://wpa.qq.com/pa?p=1:1483469625:13 alt="点击这里给我发消息"></a> </li>
                        </ul>
                    </div>
                </div>
                <div class="contenct">
                	<h3><span>联系我们</span></h3>
                	<ul>
                    	<li><strong>苏州圣天缘家具有限公司</strong></li>
                        <li>地址:江苏省苏州市相城区欧风商业街5栋306号
                        <li>圣天缘总经理：程孝军</li>
<li>固定电话：0512-66189331</li>
                        <li>电话：4000757990 手机：15995798885</li>
                        <li>传真：0512-66189331</li>
               
                        <li>邮箱：1483469625@qq.com</li>
                        <li>公司网址：www.shengtianyuan.cn</li>
                    </ul>
                </div>
            </div>
        </div>
    <!--三段新闻--> 
        <div class="middle2">
            <div class="upkeep">
                <h3><span>家具保养攻略&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="knowledge.aspx?class=家具保养" style="padding-left:20px; color:#FFFFFF; font-size:16px;">查看更多</a></span></h3>
                <ul>
                 
                </ul>
            </div>
            <div class="upkeep">
                <h3><span>新闻动态&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="news.aspx" style="padding-left:20px; color:#FFFFFF; font-size:16px;">查看更多</a></span></h3>
                <ul>
                  
                </ul>
            </div>
            <div class="upkeep" style="margin-right:0px;">
                <h3><span>家具知识&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="knowledge.aspx?class=家具知识" style="padding-left:20px; color:#FFFFFF; font-size:16px;">查看更多</a></span></h3>
                <ul>
             
                
                   
                 
                </ul>
            </div>
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
<div class="bottomnav">
    	<ul>       
        	<li><a href="index.aspx">网站首页</a> | <a href="about.aspx">企业风貌</a> | <a href="news.aspx">新闻动态</a> | <a href="product.aspx">产品世界</a> | <a href="knowledge.aspx">家具知识</a> | <a href="message.aspx">在线留言</a> | <a href="contact.aspx">联系我们</a> </li>
        </ul>
    </div>
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
