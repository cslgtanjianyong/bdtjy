<%@ Page Title="" Language="C#" MasterPageFile="~/template/MPCommon.Master" AutoEventWireup="true" CodeBehind="newslist.aspx.cs" Inherits="zhongSen.news.newslist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="污水处理水泵|污水处理设备|化工处理水泵|化工泵|不锈钢耐腐蚀泵|五金电镀表面处理" />
    <meta name="description" content="隆恩特专业提供污水处理水泵，化工处理水泵，不锈钢耐腐蚀泵等一些列污水处理设备，五金电镀表面处理设备一流，欢迎新来客户前来惠顾，咨询电话: 0512-50101606" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="smp_postion"><span><a href="http://www.rontpump.com">首页</a>&nbsp;-&nbsp;<a href="http://www.rontpump.com/newscenter.html">新闻中心</a><% if (pointT!=null) { %>&nbsp;-&nbsp;<a href="http://www.rontpump.com/news-<%=pointT.ID %>-1.html"><%=pointT.TypeName %></a><% } %></span></div>
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
                <ul>
                    <asp:Repeater ID="rpt_news_list_for_page" runat="server">
                        <ItemTemplate>
                            <li><i><a href="http://www.rontpump.com/news-<%# Eval("ID") %>.html" title="<%# Eval("Title") %>"><%# Eval("Title") %></a></i><span><%# Eval("AddTime") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div id="div_showpage" runat="server">
                </div>
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
