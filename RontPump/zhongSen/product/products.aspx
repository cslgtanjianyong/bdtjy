<%@ Page Title="" Language="C#" MasterPageFile="~/template/MPCommon.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="zhongSen.product.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="污水处理水泵|污水处理设备|化工处理水泵|化工泵|不锈钢耐腐蚀泵|五金电镀表面处理" />
    <meta name="description" content="隆恩特专业提供污水处理水泵，化工处理水泵，不锈钢耐腐蚀泵等一些列污水处理设备，五金电镀表面处理设备一流，欢迎新来客户前来惠顾，咨询电话: 0512-50101606" />
    <link href="../css/proctmarquee.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="smp_postion">
        <span><a href="http://www.rontpump.com">首页</a>&nbsp;-&nbsp;<a href="http://www.rontpump.com/products.html">产品中心</a><% if (caseT != null)
                                                                                                                              { %>&nbsp;-&nbsp;<a href="http://www.rontpump.com/products-<%=caseT.ID %>-1.html"><%=caseT.CTName %></a><% } %></span>
    </div>
    <div class="c_p_main">
        <div class="c_p_main_product">
            <!--产品左侧-->
            <div class="c_p_main_product_subL">
                <% for (int i = 0; i < list.Count; i++)
                   {
                %>
                <!--<%=list[i].CTName %>-->
                <div class="c_p_main_product_subL_subm1"><span><%=list[i].CTName %></span></div>
                <% if (InitCaseTypeLvS(list[i].ID) != null)
                   {
                       for (int j = 0; j < list2.Count; j++)
                       {
                           if (j < list2.Count - 1)
                           {
                %>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-<%=list2[j].ID %>-1.html"><%=list2[j].CTName %></a></div>
                <%
                           }
                           else
                           {
                %>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-<%=list2[j].ID %>-1.html"><%=list2[j].CTName %></a></div>
                <!--clr-->
                <div class="clrH3"></div>
                <!--clr-->
                <%
                           }
                       }
                   } %>
                <%
                   } %>
                <%--<!--化工泵浦-->
                <div class="c_p_main_product_subL_subm1"><span>化工泵浦</span></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-5-1.html">自吸泵</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-6-1.html">耐酸碱泵</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-7-1.html">离心泵</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-8-1.html">磁力泵</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-9-1.html">立式泵</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-10-1.html">潜水泵</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-11-1.html">计量泵</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-12-1.html">气动泵</a></div>
                <!--clr-->
                <div class="clrH3"></div>
                <!--clr-->
                <!--过滤设备-->
                <div class="c_p_main_product_subL_subm1"><span>过滤设备</span></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-13-1.html">单枚过滤器</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-14-1.html">PP化学药液过滤器</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-15-1.html">化学药液过滤机</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-16-1.html">槽内过滤机</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-17-1.html">不锈钢精密过滤器</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-18-1.html">不锈钢耐高压精密过滤器</a></div>
                <!--clr-->
                <div class="clrH3"></div>
                <!--clr-->
                <!--过滤材料-->
                <div class="c_p_main_product_subL_subm1"><span>过滤材料</span></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-19-1.html">PP熔喷式过滤芯</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-20-1.html">PP线绕式过滤芯</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-21-1.html">高效活性炭过滤芯</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-22-1.html">滤袋</a></div>
                <div class="clrH3"></div>
                <!--clr-->
                <!--电镀周边设备-->
                <div class="c_p_main_product_subL_subm1"><span>电镀周边设备</span></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-23-1.html">手提式桶泵</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-24-1.html">液体搅拌机</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-25-1.html">高压环形鼓风机</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-26-1.html">PP控制器/电导率控制器</a></div>
                <div class="c_p_main_product_subL_subm2"><a href="http://www.rontpump.com/products-27-1.html">PP控制器/电导率控制器附件</a></div>--%>
                <!--推荐新闻-->
                <div class="c_p_main_product_subL_sub3">
                    <div class="c_p_main_product_subL_sub3_subrname">推荐新闻</div>
                    <ul>
                        <asp:Repeater ID="rpt_news_list_for_rank" runat="server">
                            <ItemTemplate>
                                <li><a href="http://www.rontpump.com/news-<%# Eval("ID") %>.html" title="<%# Eval("Title") %>"><%# Eval("Title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!--产品右侧-->
            <div class="c_p_main_product_subR">
                <div class="c_p_main_product_subR_banner">
                    <!--start proct marquee start-->
                    <div id="proct_marq">
                        <!--轮播-->
                        <div id="lunbo">
                            <div id="period_down">
                                <div class="rollBox">
                                    <div class="Cont" id="ISL_Cont">
                                        <div class="ScrCont">
                                            <div id="List1">
                                                <!-- 图片列表  -->

                                                <asp:Repeater ID="rpt_prct_for_marq" runat="server">
                                                    <ItemTemplate>
                                                        <div class="pic">
                                                            <a href="http://www.rontpump.com/products-<%# Eval("ID") %>.html" title="<%# Eval("Cname") %>" target="_blank">
                                                                <img src="http://www.rontpump.com<%# Eval("ImgSrc") %>" alt="<%# Eval("Cname") %>" width="134" height="99" /></a>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <!-- 图片列表 end -->
                                            </div>
                                            <div id="List2">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <script src="../js/scrollPic.js"></script>
                            <script src="../js/zoomermarq.js"></script>
                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $('.ScrCont .pic').ZoomerMarq({ speedView: 200, speedRemove: 400, altAnim: true, speedTitle: 400, debug: false });
                                });
                            </script>
                        </div>
                        <!--end 轮播 end-->
                    </div>
                    <!--end proct marquee end-->
                </div>
                <div class="c_p_main_product_subR_hr">
                    <img src="../images/img/arrow_02.png" />
                    <span>产品中心</span>
                </div>
                <div class="c_p_main_product_subR_list">
                    <ul class="thumb">
                        <asp:Repeater ID="rpt_product_list" runat="server">
                            <ItemTemplate>
                                <li><a href="http://www.rontpump.com/products-<%# Eval("ID") %>.html">
                                    <img src="http://www.rontpump.com/<%# Eval("ImgSrc") %>" alt="<%# Eval("CName") %>" /></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div id="div_showpage" runat="server"></div>
                    <script src="../js/zoomer.js"></script>
                    <script type="text/javascript">
                        $(document).ready(function () {
                            $('ul.thumb li').Zoomer({ speedView: 200, speedRemove: 400, altAnim: true, speedTitle: 400, debug: false });
                        });
                    </script>
                </div>
            </div>
        </div>

        <div class="clrH3"></div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_links" runat="server">
    <script language="javascript" type="text/javascript">
        $("#nav .nav_subs .nav_subs_main a[databind=a_proct]").addClass("hover");
    </script>
</asp:Content>
