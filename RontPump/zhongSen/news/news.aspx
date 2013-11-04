<%@ Page Title="" Language="C#" MasterPageFile="~/template/MPCommon.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="zhongSen.news.news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="污水处理水泵|污水处理设备|化工处理水泵|化工泵|不锈钢耐腐蚀泵|五金电镀表面处理" />
    <meta name="description" content="隆恩特专业提供污水处理水泵，化工处理水泵，不锈钢耐腐蚀泵等一些列污水处理设备，五金电镀表面处理设备一流，欢迎新来客户前来惠顾，咨询电话: 0512-50101606" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="smp_postion"><span><a href="http://www.rontpump.com">首页</a>&nbsp;-&nbsp;<a href="http://www.rontpump.com/newscenter.html">新闻中心</a></span></div>
    <div class="c_p_banner">
        <img src="../images/banner/banner_for_news.png" />
    </div>
    <div class="c_p_main">
        <div class="c_p_main_newscenter1">
            <div class="c_p_main_newscenter1_sub1">
                <div class="c_p_main_newscenter1_sub1_show1">
                    <div class="c_p_main_newscenter1_sub1_show1_subshow1">行业动态</div>
                    <a href="http://www.rontpump.com/news-2-1.html">
                        <img src="../images/news/more.png" /></a>
                </div>
                <ul>
                    <asp:Repeater ID="rpt_news_list_for_hangye" runat="server">
                        <ItemTemplate>
                            <li><a href="http://www.rontpump.com/news-<%# Eval("ID") %>.html" target="_blank"><i><%# Eval("Title") %></i><%# System.DateTime.Now.CompareTo(Convert.ToDateTime(Eval("AddTime")).AddHours(24))<0?"<img src='../images/news/new.png' />":""  %></a><span>[<%# Eval("AddTime", "{0:MM-dd}")%>]</span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="c_p_main_newscenter1_subline"></div>
            <div class="c_p_main_newscenter1_sub1">
                <div class="c_p_main_newscenter1_sub1_show1">
                    <div class="c_p_main_newscenter1_sub1_show1_subshow1">新闻中心</div>
                    <a href="http://www.rontpump.com/news-1-1.html">
                        <img src="../images/news/more.png" /></a>
                </div>
                <ul>
                    <asp:Repeater ID="rpt_news_list_for_co" runat="server">
                        <ItemTemplate>
                            <%--<li><i><%# Eval("Title") %></i><%# System.DateTime.Now.CompareTo(Convert.ToDateTime(Eval("AddTime")).AddHours(24))<0?"<img src='../images/news/new.png' />":""  %><span>[<%# Eval("AddTime", "{0:MM-dd}")%>]</span></li>--%>
                            <li><a href="http://www.rontpump.com/news-<%# Eval("ID") %>.html" target="_blank"><i><%# Eval("Title") %></i><%# System.DateTime.Now.CompareTo(Convert.ToDateTime(Eval("AddTime")).AddHours(24))<0?"<img src='../images/news/new.png' />":""  %></a><span>[<%# Eval("AddTime", "{0:MM-dd}")%>]</span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_links" runat="server">
    <script language="javascript" type="text/javascript">
        $("#nav .nav_subs .nav_subs_main a[databind=a_news]").addClass("hover");
    </script>
</asp:Content>
