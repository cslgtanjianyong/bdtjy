<%@ Page Title="" Language="C#" MasterPageFile="~/template/MPCommon.Master" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="zhongSen.co.message" %>

<%@ Register Assembly="VlidateCode" Namespace="VlidateCode" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="keywords" content="污水处理水泵|污水处理设备|化工处理水泵|化工泵|不锈钢耐腐蚀泵|五金电镀表面处理" />
    <meta name="description" content="隆恩特专业提供污水处理水泵，化工处理水泵，不锈钢耐腐蚀泵等一些列污水处理设备，五金电镀表面处理设备一流，欢迎新来客户前来惠顾，咨询电话: 0512-50101606" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="smp_postion"><span><a href="http://www.rontpump.com">首页</a>&nbsp;-&nbsp;<a href="http://www.rontpump.com/message.html">在线留言</a></span></div>
    <div class="c_p_banner"><img src="../images/banner/banner_for_msg.png" />
    </div>
    <div class="c_p_main">
        <div class="c_p_main_msg">
            <ul>
                <li class="msg_li_w_155"><font style="color: #f00;">*</font>您的称谓：</li>
                <li class="msg_li_w_200">
                    <asp:TextBox ID="txt_name" runat="server" CssClass="border"></asp:TextBox></li>
                <li class="msg_li_w_155"><font style="color: #f00;">*</font>电子邮箱：</li>
                <li class="msg_li_w_200">
                    <asp:TextBox ID="txt_email" runat="server" CssClass="border"></asp:TextBox></li>
                <li class="msg_li_w_155 clr_L"><font style="color: #f00;">*</font>联系电话：</li>
                <li class="msg_li_w_200">
                    <asp:TextBox ID="txt_tel" runat="server" CssClass="border"></asp:TextBox></li>
                <li class="msg_li_w_155">&nbsp;公司名称：</li>
                <li class="msg_li_w_200">
                    <asp:TextBox ID="txt_coname" runat="server" CssClass="border"></asp:TextBox></li>
                <li class="msg_li_w_155 clr_L"><font style="color: #f00;">*</font>留言内容：</li>
                <li class="msg_li_w_555">
                    <asp:TextBox ID="txt_content" runat="server" TextMode="MultiLine"></asp:TextBox></li>
                <li class="msg_li_w_155"><font style="color: #f00;">*</font>验证码：</li>
                <li class="msg_li_w_200">
                    <asp:TextBox ID="txt_code" runat="server" CssClass="border"></asp:TextBox></li>
                <li class="msg_li_w_155">
                    <cc1:ValidateCodeImage ID="code_img" runat="server" />
                </li>
                <li class="msg_li_w_200 clr_R">&nbsp;</li>

                <li class="msg_li_w_155 clr_L">&nbsp;</li>
                <li class="msg_li_w_200">
                    <asp:Button ID="btn_msg_submit" runat="server" Text="提交留言" OnClick="btn_msg_submit_Click" />
                </li>
                <li class="msg_li_w_155">
                    <%--<asp:Button ID="btn_msg_reset" runat="server" Text="重新填写" />--%>
                    <input id="btn_msg_reset" type="reset" value="重新填写" />
                </li>
                <li class="msg_li_w_200">&nbsp;</li>
                <!--显示提示信息-->
                <li class="msg_li_w_155 clr_L"></li>
                <li class="msg_li_w_555">
                    <asp:Label ID="lbl_msg_result" runat="server" Text=""></asp:Label>
                </li>

                <li class="msg_li_w_155 green">温馨提示</li>
                <li class="msg_li_w_555 green">为了方便联系您，以上带*的部分必须如实填写</li>
                <li class="msg_li_w_155"></li>
                <li class="msg_li_w_555 green">请认真填写您的联系方式，我们在收到您的留言后24小时内会给您回复</li>
            </ul>
            <asp:Literal ID="ltl_js" runat="server"></asp:Literal>
            <div class="clrH3"></div>
            <script language="javascript" type="text/javascript">
                var CPH_MAIN_TXT_ = "#cph_main_txt_";
                //称谓
                $(CPH_MAIN_TXT_ + "name").blur(function () {
                    if ($(this).val().length == 0) {
                        $(this).attr("style", "border:1px solid #f00;");
                        return false;
                    }
                    else if ($(this).val().length > 20) {
                        $(this).attr("style", "border:1px solid #f00; color:#f00;");
                        $("#cph_main_lbl_msg_result").attr("style", "color:#f00;");
                        $("#cph_main_lbl_msg_result").html("称谓不能超过20个字符");
                        return false;
                    }
                    else {
                        $("#cph_main_lbl_msg_result").html("");
                        $(this).attr("style", "");
                        return true;
                    }
                }).focus(function () {
                    $("#cph_main_lbl_msg_result").html("");
                    $(this).attr("style", "");
                });
                //邮箱
                $(CPH_MAIN_TXT_ + "email").blur(function () {
                    if ($(this).val().length == 0) {
                        $(this).attr("style", "border:1px solid #f00;");
                        return false;
                    }
                    else if ($(this).val().length > 50) {
                        $(this).attr("style", "border:1px solid #f00; color:#f00;");
                        $("#cph_main_lbl_msg_result").attr("style", "color:#f00;");
                        $("#cph_main_lbl_msg_result").html("邮箱地址不能超过50个字符");
                        return false;
                    }
                    else {
                        var re = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
                        var objExp = new RegExp(re);
                        if (objExp.test($(this).val())) {
                            $("#cph_main_lbl_msg_result").html("");
                            $(this).attr("style", "");
                            return true;
                        } else {
                            $(this).attr("style", "border:1px solid #f00; color:#f00;");
                            $("#cph_main_lbl_msg_result").attr("style", "color:#f00;");
                            $("#cph_main_lbl_msg_result").html("邮箱地址错误");
                            return false;
                        }
                    }
                }).focus(function () {
                    $("#cph_main_lbl_msg_result").html("");
                    $(this).attr("style", "");
                });
                //电话
                $(CPH_MAIN_TXT_ + "tel").blur(function () {
                    if ($(this).val().length == 0) {
                        $(this).attr("style", "border:1px solid #f00;");
                        return false;
                    }
                    else if ($(this).val().length > 15) {
                        $(this).attr("style", "border:1px solid #f00; color:#f00;");
                        $("#cph_main_lbl_msg_result").attr("style", "color:#f00;");
                        $("#cph_main_lbl_msg_result").html("手机号码不超过15个字符");
                        return false;
                    }
                    else {
                        var regMobile = /^0?1(3|5|8)\d{9}$/;
                        var objExp = new RegExp(regMobile);
                        if (objExp.test($(this).val())) {
                            $("#cph_main_lbl_msg_result").html("");
                            $(this).attr("style", "");
                            return true;
                        }
                        else {
                            $(this).attr("style", "border:1px solid #f00; color:#f00;");
                            $("#cph_main_lbl_msg_result").attr("style", "color:#f00;");
                            $("#cph_main_lbl_msg_result").html("手机号码错误");
                            return false;
                        }
                    }
                }).focus(function () {
                    $("#cph_main_lbl_msg_result").html("");
                    $(this).attr("style", "");
                });
                //公司名 - 可以为空
                $(CPH_MAIN_TXT_ + "coname").blur(function () {
                    if ($(this).val().length == 0) {
                        $("#cph_main_lbl_msg_result").html("");
                        $(this).attr("style", "");
                        return true;
                    }
                    else if ($(this).val().length > 50) {
                        $(this).attr("style", "border:1px solid #f00; color:#f00;");
                        $("#cph_main_lbl_msg_result").attr("style", "color:#f00;");
                        $("#cph_main_lbl_msg_result").html("公司名称不超过50个字符");
                        return false;
                    }
                    else {
                        $("#cph_main_lbl_msg_result").html("");
                        $(this).attr("style", "");
                        return true;
                    }
                }).focus(function () {
                    $("#cph_main_lbl_msg_result").html("");
                    $(this).attr("style", "");
                });
                //留言内容
                $(CPH_MAIN_TXT_ + "content").blur(function () {
                    if ($(this).val().length == 0) {
                        $(this).attr("style", "border:1px solid #f00; color:#f00;");
                        $("#cph_main_lbl_msg_result").attr("style", "color:#f00;");
                        return false;
                    }
                    else if ($(this).val().length > 500) {
                        $(this).attr("style", "border:1px solid #f00; color:#f00;");
                        $("#cph_main_lbl_msg_result").attr("style", "color:#f00;");
                        $("#cph_main_lbl_msg_result").html("留言内容不超过500个字符");
                        return false;
                    }
                    else {
                        $("#cph_main_lbl_msg_result").html("");
                        $(this).attr("style", "");
                        return true;
                    }
                }).focus(function () {
                    $("#cph_main_lbl_msg_result").html("");
                    $(this).attr("style", "");
                });
                //验证码 - 4位
                $(CPH_MAIN_TXT_ + "code").blur(function () {
                    if ($(this).val().length != 4) {
                        $(this).attr("style", "border:1px solid #f00; color:#f00;");
                        $("#cph_main_lbl_msg_result").attr("style", "color:#f00;");
                        $("#cph_main_lbl_msg_result").html("验证码为4位");
                        return false;
                    }
                    else {
                        $("#cph_main_lbl_msg_result").html("");
                        $(this).attr("style", "");
                        return true;
                    }
                }).focus(function () {
                    $("#cph_main_lbl_msg_result").html("");
                    $(this).attr("style", "");
                });
                //提交
                $("#cph_main_btn_msg_submit").click(function () {
                    if ($(CPH_MAIN_TXT_ + "name").val() && $(CPH_MAIN_TXT_ + "email").val() && $(CPH_MAIN_TXT_ + "tel").val() && $(CPH_MAIN_TXT_ + "coname").val() && $(CPH_MAIN_TXT_ + "content").val() && $(CPH_MAIN_TXT_ + "code").val()) {
                        return true;
                    }
                    else {
                        $("#cph_main_lbl_msg_result").html("要提交的内容有误|请检查后重新提交");
                        return false;
                    }
                });
            </script>
        </div>
        <div class="clrH5"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_links" runat="server">
    <script language="javascript" type="text/javascript">
        $("#nav .nav_subs .nav_subs_main a[databind=a_msg]").addClass("hover");
    </script>
</asp:Content>
