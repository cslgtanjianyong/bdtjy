$(document).ready(function () {
    //导航按下
    $("#navbar").find("ul").find("li").each(function () {
        $(this).mousemove(function () {
            $(this).css({ "background": "url(../Image/navbar_head.jpg) repeat-x" });
        });
        $(this).mouseout(function () {
            $(this).css({ "background": "" });
        });
    });
    ///名字
    var user = false;
    $("#lxUser").blur(function () {
        uname = $(this).val();
        if (uname.length == 0) {
            $(this).parent().parent().find("span").html("<span style='color:red;'>&nbsp;请输入联系人！</span>");
            user = false;
        }
        else if (uname.length > 20) {
            $(this).parent().parent().find("span").html("<span style='color:red;'>&nbsp;联系人过长！</span>");
            user = false;
        }
        else {
            $(this).parent().parent().find("span").html("<span style='color:green;'>&nbsp;√</span>");
            user = true;
        }
    });
    ///QQ
    var qq = false;
    $("#lxQQ").blur(function () {
        var reg = /^\d{5,10}$/;
        //var meg = new RegExp("[1-9][0-9]{4,}");
        if (reg.test($(this).val())) {
            $(this).parent().parent().find("span").html("<span style='color:green;'>&nbsp;√</span>");
            qq = true;
        } else {
            $(this).parent().parent().find("span").html("<span style='color:red;'>&nbsp;QQ格式不正确！</span>");
            qq = false;
        }
    });
    ///电话验证
    var tel = false;
    $("#lxTel").blur(function () {
        var phone = $(this).val();
        if (phone.length == 0) {
            $(this).parent().parent().find("span").html("<span style='color:red;'>&nbsp;请输入联系电话！</span>");
            tel = false;
        }
        else if (phone.length > 15) {
            $(this).parent().parent().find("span").html("<span style='color:red;'>&nbsp;联系电话格式错误！</span>");
            tel = false;
        }
        else {

            var patten = /^(((\(0\d{2,3}\)){1}|(0\d{2,3}[- ]?){1})?([1-9]{1}[0-9]{2,7}(\-\d{3,4})?))$/;
            var pat = /^(\b13[0-9]{9}\b)|(\b14[7-7]\d{8}\b)|(\b15[0-9]\d{8}\b)|(\b18[0-9]\d{8}\b)|\b1[1-9]{2,4}\b$/;
            var checkphone = phone.toString().split('-');
            if (checkphone.length > 2) {
                $(this).parent().parent().find("span").html("<span style='color:red;'>&nbsp;联系电话格式错误！</span>");
                tel = false;
            }
            if (phone != "" || phone.length != 0) {
                if (phone.substr(0, 3) == "+86") {
                    phone = phone.substr(3, phone.length);
                }
                if (phone.substr(0, 2) == "13" || phone.substr(0, 2) == "14" || phone.substr(0, 2) == "15" || phone.substr(0, 2) == "18") {
                    if (pat.test(phone)) {
                        $(this).parent().parent().find("span").html("<span style='color:green;'>&nbsp;√</span>");
                        tel = true;
                    }
                    else {
                        $(this).parent().parent().find("span").html("<span style='color:red;'>&nbsp;联系电话格式错误！</span>");
                        tel = false;
                    }
                }
                else {
                    if (patten.test(phone)) {
                        $(this).parent().parent().find("span").html("<span style='color:green;'>&nbsp;√</span>");
                        tel = true;
                    }
                    else {
                        $(this).parent().parent().find("span").html("<span style='color:red;'>&nbsp;联系电话格式错误！</span>");
                        tel = false;
                    }
                }
            }
            else {
                $(this).parent().parent().find("span").html("<span style='color:red;'>&nbsp;联系电话格式错误！</span>");
                tel = false;
            }
        }
    });
    //验证提交
    $("#toSubmit").click(function() {
        if (user == false || que == false || tel == false || qq == false) {
            alert("请填写以上信息！");
        } else {
            ToSubmint();
        }
    });
    ///内容验证
    var que = false;
    $("#lxQuest").blur(function () {
        var content = $("#lxQuest").val();
        if (content.length == 0) {
            $("#prompt_tx").html("<span style='color:red;'>&nbsp;请填写内容！</span>");
            que = false;
        } else {
            $("#prompt_tx").html("<span style='color:green;'>&nbsp;√</span>");
            que = true;
        }

    });

});
//重置
function toReset() {
    $("#lxchid").find(":text").each(function () {
        $(this).val(null);
    });
}

//提交
function ToSubmint() {
    $.ajax({
        type: "POST",
        contentType: "application/x-www-form-urlencoded",
        url: "../axhx/SubQuestionHandler.ashx",
        data: "lxName=" + $("#lxUser").val() + "&lxComp=" + $("#lxComp").val() + "&lxAddress=" + $("#lxAdd").val() + "&lxQQ=" + $("#lxQQ").val() + "&lxTel=" + $("#lxTel").val() + "&lxQuest=" + $("#lxQuest").val(),
        success: function (result) {
            alert(result);
            toReset();
        },
        Error: function (XMLHttpRequest, textStatus) {
            alert(textStatus);
        }
    });
}