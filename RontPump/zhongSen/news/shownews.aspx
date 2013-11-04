<%@ Page Title="" Language="C#" MasterPageFile="~/template/MPCommon.Master" AutoEventWireup="true" CodeBehind="shownews.aspx.cs" Inherits="zhongSen.news.shownews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="<%=vp.MetaKey %>" />
    <meta name="description" content="<%=vp.MetaDesc %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="smp_postion"><span><a href="http://www.rontpump.com">首页</a>&nbsp;-&nbsp;<a href="http://www.rontpump.com/newscenter.html">新闻中心</a>&nbsp;-&nbsp;<a href="http://www.rontpump.com/news-<%=vp.TpId %>-1.html"><%=vp.TypeName %></a>&nbsp;-&nbsp;<a href="http://www.rontpump.com/news-<%=vp.ID %>.html"><%=vp.Title %></a></span></div>
    <div class="c_p_banner">
        <img src="../images/banner/banner_for_news.png" />
    </div>
    <div class="c_p_main">
        <div class="clrH5"></div>
        <div class="c_p_main_newslist">
            <!--左侧-->
            <div class="c_p_main_newslist_subL">
                <div class="c_p_main_newslist_subL_show1">
                    <span>新闻中心</span>
                </div>
                <div class="c_p_main_newslist_subL_show2">
                    <a href="http://www.rontpump.com/news-1-1.html">企业新闻</a>
                </div>
                <div class="c_p_main_newslist_subL_show2">
                    <a href="http://www.rontpump.com/news-2-1.html">行业新闻</a>
                </div>
                <div class="c_p_main_newslist_subL_show3">
                    <div class="c_p_main_newslist_subL_show3_subrname">推荐新闻</div>
                    <ul>
                        <asp:Repeater ID="rpt_news_list_for_rank" runat="server">
                            <ItemTemplate>
                                <li><a href="http://www.rontpump.com/news-<%# Eval("ID") %>.html" title="<%# Eval("Title") %>"><%# Eval("Title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!--右侧-->
            <div class="c_p_main_newslist_subR">
                <h1><%=vp.Title %></h1>
                <div class="c_p_main_news_addtime">发布时间：<%=vp.AddTime.ToString("yyyy-MM-dd") %></div>
                <div class="c_p_main_news_content"><%=vp.Article %></div>
            </div>
        </div>
        <div class="clrH3"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_links" runat="server">
    <script language="javascript" type="text/javascript">
        $("#nav .nav_subs .nav_subs_main a[databind=a_news]").addClass("hover");
    </script>
</asp:Content>
