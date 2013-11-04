$(document).ready(function () {
    $("table").eq(1).find(":text").css({ "width": "300" }, { "background": "#ffffff" }, { "padding-top": "2px" });
    $("#txIntro").focus(function () {
        if ($(this).val() == "*请在此填写内容...") {
            $(this).val("");
            $(this).removeClass("tx");
        }
    });
    $("#txIntro").blur(function () {
        if ($(this).val() == "") {
            $(this).val("*请在此填写内容...");
            $(this).addClass("tx");
        }
    });
    $("table").find(":text").each(function () {
        $(this).blur(function () {
            if ($(this).val() == "") {
                $(this).parent().parent().find(".td3").text("*此项不能为空！");
            } else {
                $(this).parent().parent().find(".td3").text("");
            }
        });

    });
    ///电话验证
    $("#txTelphone").blur(function () {
        var td3 = $(this).parent().parent().find("td[class='td3']");
        var phone = $(this).val();
        if (phone.length == 0) {
            td3.text("请输入联系电话!");
            td3.css("color", "red");
            isKong = false;
        } else if (phone.length > 15) {
            td3.text("联系电话格式错误!");
            td3.css("color", "red");
            isKong = false;
        } else {

            var patten = /^(((\(0\d{2,3}\)){1}|(0\d{2,3}[- ]?){1})?([1-9]{1}[0-9]{2,7}(\-\d{3,4})?))$/;
            var pat = /^(\b13[0-9]{9}\b)|(\b14[7-7]\d{8}\b)|(\b15[0-9]\d{8}\b)|(\b18[0-9]\d{8}\b)|\b1[1-9]{2,4}\b$/;
            var checkphone = phone.toString().split('-');
            if (checkphone.length > 2) {
                td3.text("*联系电话格式错误!");
                td3.css("color", "red");
                isKong = false;
            }
            if (phone != "" || phone.length != 0) {
                if (phone.substr(0, 3) == "+86") {
                    phone = phone.substr(3, phone.length);
                }
                if (phone.substr(0, 2) == "13" || phone.substr(0, 2) == "14" || phone.substr(0, 2) == "15" || phone.substr(0, 2) == "18") {
                    if (pat.test(phone)) {
                        td3.text("*联系方式可用!");
                        td3.css("color", "green");
                        isKong = true;
                    }
                    else {
                        td3.text("*联系电话格式错误!");
                        td3.css("color", "red");
                        isKong = false;
                    }
                }
                else {
                    if (patten.test(phone)) {
                        td3.text("*联系方式可用!");
                        td3.css("color", "green");
                        isKong = true;
                    }
                    else {
                        td3.text("*联系电话格式错误!");
                        td3.css("color", "red");
                        isKong = false;
                    }
                }
            }
            else {
                td3.text("*联系电话格式错误!");
                td3.css("color", "red");
                isKong = false;
            }
        }
    });
    ///传真验证
    $("#txCopFax").blur(function () {
        var td3 = $(this).parent().parent().find("td[class='td3']");
        var Fax = $(this).val();
        var patten = /^(((\(0\d{2,3}\)){1}|(0\d{2,3}[- ]?){1})?([1-9]{1}[0-9]{2,7}(\-\d{3,4})?))$/;
        if (Fax.length == 0) {
            td3.text("*请输入传真号!");
            td3.css("color", "red");
            isKong = false;
        } else if (Fax.length > 13) {
            td3.text("*传真号格式错误!");
            td3.css("color", "red");
            isKong = false;
        } else if (patten.test(Fax)) {
            td3.text("传真号可用!");
            td3.css("color", "green");
            isKong = true;
        } else {
            td3.text("*传真号格式错误!");
            td3.css("color", "red");
            isKong = false;
        }
    });
    ///QQ
    $("#txQQ").blur(function () {
        var reg = /^\d{5,10}$/;
        //var meg = new RegExp("[1-9][0-9]{4,}");
        var td3 = $(this).parent().parent().find("td[class='td3']");
        if (reg.test($(this).val())) {
            td3.text("有效QQ！");
            td3.css("color", "green");
            isKong = true;
        } else {
            td3.text("QQ格式不正确！");
            td3.css("color", "red");
            isKong = false;
        }
    });
    ///网址
    $("#txUrl").blur(function () {
        var strRegex = "^((https|http|ftp|rtsp|mms)?://)"
                + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@
                + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184
                + "|" // 允许IP和DOMAIN（域名）
                + "([0-9a-z_!~*'()-]+\.)*" // 域名- www.
                + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名
                + "[a-z]{2,6})" // first level domain- .com or .museum
                + "(:[0-9]{1,4})?" // 端口- :80
                + "((/?)|" // a slash isn't required if there is no file name
                + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
        var reg = new RegExp(strRegex);
        var td3 = $(this).parent().parent().find("td[class='td3']");
        var url = $(this).val();
        if (reg.test(url)) {
            td3.text("有效网址！");
            td3.css("color", "green");
            isKong = true;
        } else {
            td3.text("*网址格式不正确！");
            td3.css("color", "red");
            isKong = false;
        }
    });
    ///电子邮件
    $("#txEmail").blur(function () {
        var td3 = $(this).parent().parent().find("td[class='td3']");
        var email = $(this).val();
        var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
        if (myreg.test(email)) {
            td3.text("有效邮箱！");
            td3.css("color", "green");
            isKong = true;
        } else {
            td3.text("*邮箱格式错误！");
            td3.css("color", "red");
            isKong = false;
        }
    });
    ///验证密码是否相同
    $("#txReNewPwd").blur(function () {
        if ($("txNewPwd").val() != $(this).val()) {
            var td3 = $(this).parent().parent().find("td[class='td3']");
            td3.text("*密码不一致！");
            isKong = false;
        }
    });
    ///密码是否一致
    $("#txReNewPwd").blur(function () {
        if ($("txNewPwd").val() != $(this).val()) {
            var td3 = $(this).parent().parent().find("td[class='td3']");
            td3.text("*密码不一致！");
            isKong = false;
        }
    });
    $("tr[valign='middle']").mouseout(function () {
        $(this).css({ "color": "#Ffffff", "backgroundImage": "url(../images/button_b3.gif)" });
    });
    $("tr[valign='middle']").mouseover(function () {
        $(this).css({ "color": "#F0F1EF", "backgroundImage": "" });
    });
});
var isKong = true;
///验证
function com_validate() {
    $("table").eq(1).find(":text").each(function () {
        if ($(this).val() == "") {
            alert("请填写空项！");
            isKong = false;
            return false;
        }
    });
    if ($("txIntro").val() == "请在此填写内容...") {
        alert("请填写空项！");
        isKong = false;
    }
    return isKong;
};
//验证时间是否有效
function valiTime() {
    var toDa = new Date();
    var str = $("#txLoseTime").val();
    var sd = str.split("-");
    var selTime = new Date(sd[0], sd[1] - 1, sd[2]);
    if (selTime <= toDa) {
        alert("截止时间不能比当前时间小！");
        $("#txLoseTime").val("");
    }
};

