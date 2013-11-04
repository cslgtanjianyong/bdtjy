<%@ Page Title="" Language="C#" MasterPageFile="~/template/MPCommon.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="zhongSen.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="耐酸碱泵|化工泵|自吸式磁力泵|气动双隔膜泵|ront|隆恩特" />
    <meta name="description" content="隆恩特专业提供污水处理水泵，化工处理水泵，不锈钢耐腐蚀泵等一些列污水处理设备，五金电镀表面处理设备一流，欢迎新来客户前来惠顾，咨询电话: 0512-50101606" />
    <link href="css/ibanner.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="container_main">
        <div class="container_main_sub1">
            <div class="container_main_sub1_show1">
                <a href="http://www.rontpump.com/message.html" title="在线留言">
                    <img border="0" src="images/index/qa_btn.png" alt="在线留言" title="在线留言" /></a>
            </div>
            <div class="container_main_sub1_show2">
                <a href="http://www.rontpump.com/products.html">
                    <img src="images/index/know_btn.png" /></a>
            </div>
        </div>
        <div class="container_main_sub2">
            <!-- index banner start -->
            <div class="indexCon fl">
                <div class="flashBanner">
                    <a href="http://www.lanrentuku.com/"><img class="bigImg" /></a>
                    <div class="mask">
                        <img src="images/banner/index/product_01.png" uri="images/banner/index/product_01_big.png" link="http://www.rontpump.com/products-14.html" />
                        <img src="images/banner/index/product_02.png" uri="images/banner/index/product_02_big.png" link="http://www.rontpump.com/products-28.html" />
                        <img src="images/banner/index/product_03.png" uri="images/banner/index/product_03_big.png" link="http://www.rontpump.com/products-31.html" />
                        <img src="images/banner/index/product_04.png" uri="images/banner/index/product_04_big.png" link="http://www.rontpump.com/products-38.html" />
                    </div>
                </div>
            </div>
            <script src="js/lrtk.js"></script>
            <!-- index banner end -->
        </div>
    </div>

    <div class="container_main">
        <div class="container_main_sub_search">
            <div class="container_main_sub_modelname">产品搜索</div>
            <div class="container_main_sub_search_showpnl">
                <asp:TextBox ID="txt_search_key" runat="server"></asp:TextBox>
                <asp:Button ID="btn_go_search" CssClass="btn_search" runat="server" Text="" OnClick="btn_go_search_Click" />
            </div>
        </div>
        <div class="container_main_sub_index_newscenter">
            <div class="container_main_sub_modelname">新闻中心<span><a href="http://www.rontpump.com/newscenter.html">更多&gt;&gt;</a></span></div>
            <ul>
                <!--start 新闻列表 start-->
                <asp:Repeater ID="rpt_index_news_list" runat="server">
                    <ItemTemplate>
                        <li><a href="http://www.rontpump.com/news-<%# Eval("ID") %>.html"><%# Eval("Title") %></a><span>[<%# Eval("AddTime","{0:MM-dd}") %>]</span></li>
                    </ItemTemplate>
                </asp:Repeater>
                <!--end 新闻列表 end-->
            </ul>
        </div>
        <div class="container_main_sub_index_notice">
            <div class="container_main_sub_modelname">企业公告</div>
            <p>我们既向您提供优质的产品，又提供一流的服务。我们在您期望与信赖的基础上建立起牢固的合作关系。这种策略真正体现了以消费者为中心的观念，把售出产品看作建立长期合作伙伴的开端，您会明白“我们产品的优异质量仅是冰山一角”。</p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_links" runat="server">
    <div class="clrH10"></div>
    <div id="links">
        <div class="links_top">
            <div class="links_top_modelname">友情链接</div>
        </div>
        <div class="links_center">
            <div class="clrH10"></div>
            <div class="clrH5"></div>
            <div class="links_center_pnl">
                <a href="http://www.rontpump.com">耐酸碱泵</a><span></span>
                <a href="http://www.rontpump.com">化工泵</a><span></span>
                <a href="http://www.rontpump.com">自吸式磁力泵</a><span></span>
                <a href="http://www.rontpump.com">气动双隔膜泵</a><span></span>
                <% for (int i = 0; i < links.Count; i++)
                   {
                       if (i < links.Count - 1)
                       {
                %>
                <a href="<%=links[i].FUrl%>" target="_blank"><%=links[i].Fword%></a><span></span>
                <%
                       }
                       else
                       {
                %>
                <a href="<%=links[i].FUrl%>" target="_blank"><%=links[i].Fword%></a>
                <% 
                       }
                   } 
                %>
            </div>
            <div class="clr"></div>
        </div>
        <div class="links_bottom"></div>
    </div>
    <script language="javascript" type="text/javascript">
        $("#nav .nav_subs .nav_subs_main a[databind=a_index]").addClass("hover");
    </script>
</asp:Content>
