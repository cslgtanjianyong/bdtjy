function chongzhi() {
    document.getElementById("ContentPlaceHolder1_txtUserName").value = "";
    $("#ContentPlaceHolder1_lalUserName").attr("style", "color:red;")
    $("#ContentPlaceHolder1_lalUserName").html("*");
    document.getElementById("ContentPlaceHolder1_txtTel").value = "";
    $("#ContentPlaceHolder1_lalTel").attr("style", "color:red;")
    $("#ContentPlaceHolder1_lalTel").html("*");
    document.getElementById("ContentPlaceHolder1_txtEmail").value = "";
    $("#ContentPlaceHolder1_lalEmail").attr("style", "color:red;")
    $("#ContentPlaceHolder1_lalEmail").html("*");
    document.getElementById("ContentPlaceHolder1_txtCopName").value = "";
    document.getElementById("ContentPlaceHolder1_txtContent").value = "";
    $("#ContentPlaceHolder1_lalContent").attr("style", "color:red;")
    $("#ContentPlaceHolder1_lalContent").html("*");
 }
 function check_UserName() {
     if ($("#ContentPlaceHolder1_txtUserName").val().length == 0) {
         $("#ContentPlaceHolder1_lalUserName").html("<span style='color:red'>&nbsp;请输入您的称谓!</span>");
         return false;
     }
     if ($("#ContentPlaceHolder1_txtUserName").val().length > 6) {
         $("#ContentPlaceHolder1_lalUserName").html("<span style='color:red'>&nbsp;输入的称谓过长</span>");
         return false;
     }
     if ($("#ContentPlaceHolder1_txtUserName").val().length < 2) {
         $("#ContentPlaceHolder1_lalUserName").html("<span style='color:red'>&nbsp;输入的称谓过短</span>");
         return false;
     }
     else {
         $("#ContentPlaceHolder1_lalUserName").html("<span style='color:green'>&nbsp;称谓正确</span>");
         return true;
     }
 }
 //判断电话号码的
 function checkUserAddTel() {
     var phone = document.getElementById("ContentPlaceHolder1_txtTel").value.toString();
     if (phone.length == 0) {
         document.getElementById("ContentPlaceHolder1_lalTel").innerHTML = "<span style='color:red;'>请输入联系电话</span>";
         return false;
     }
     else if (phone.length > 15) {
         document.getElementById("ContentPlaceHolder1_lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
         return false;
     }
     else {

         var patten = /^(((\(0\d{2,3}\)){1}|(0\d{2,3}[- ]?){1})?([1-9]{1}[0-9]{2,7}(\-\d{3,4})?))$/;
         var pat = /^(\b13[0-9]{9}\b)|(\b14[7-7]\d{8}\b)|(\b15[0-9]\d{8}\b)|(\b18[0-9]\d{8}\b)|\b1[1-9]{2,4}\b$/;
         var checkphone = phone.toString().split('-');
         if (checkphone.length > 2) {
             document.getElementById("ContentPlaceHolder1_lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
             return false;
         }
         if (phone != "" || phone.length != 0) {
             if (phone.substr(0, 3) == "+86") {
                 phone = phone.substr(3, phone.length);
             }
             if (phone.substr(0, 2) == "13" || phone.substr(0, 2) == "14" || phone.substr(0, 2) == "15" || phone.substr(0, 2) == "18") {
                 if (pat.test(phone)) {
                     document.getElementById("ContentPlaceHolder1_lalTel").innerHTML = "<span style='color:green;'>联系方式可用</span>";
                     return true;
                 }
                 else {
                     document.getElementById("ContentPlaceHolder1_lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
                     return false;
                 }
             }
             else {
                 if (patten.test(phone)) {
                     document.getElementById("ContentPlaceHolder1_lalTel").innerHTML = "<span style='color:green;'>联系电话可用</span>";
                     return true;
                 }
                 else {
                     document.getElementById("ContentPlaceHolder1_lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
                     return false;
                 }
             }
         }
         else {
             document.getElementById("ContentPlaceHolder1_lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
             return false;
         }
     }
 }
 function check_txtTitle() {
     if ($("#txtTitle").val().length == 0) {
         $("#laltxtTitle").html("<span style='color:red'>&nbsp;请输入主题!</span>");
         return false;
     }
     if ($("#txtTitle").val().length > 20) {
         $("#laltxtTitle").html("<span style='color:red'>&nbsp;输入的主题过长</span>");
         return false;
     }
//     if ($("#txtTitle").val().length < 2) {
//         $("#laltxtTitle").html("<span style='color:red'>&nbsp;输入的姓名过短</span>");
//         return false;
//     }
     else {
         $("#laltxtTitle").html("<span style='color:green'>&nbsp;主题正确</span>");
         return true;
     }
 }
 function check_txtContent() {
     if ($("#ContentPlaceHolder1_txtContent").val().length == 0) {
         $("#ContentPlaceHolder1_lalContent").html("<span style='color:red'>&nbsp;请输入内容!</span>");
         return false;
     }
     if ($("#ContentPlaceHolder1_txtContent").val().length > 500) {
         $("#ContentPlaceHolder1_lalContent").html("<span style='color:red'>&nbsp;输入的内容过长</span>");
         return false;
     }
     //     if ($("#txtTitle").val().length < 2) {
     //         $("#laltxtTitle").html("<span style='color:red'>&nbsp;输入的姓名过短</span>");
     //         return false;
     //     }
     else {
         $("#ContentPlaceHolder1_lalContent").html("<span style='color:green'>&nbsp;内容正确</span>");
         return true;
     }
 }
 //邮箱
 function check_email() {
     if ($("#ContentPlaceHolder1_txtEmail").val().length == 0) {
         $("#ContentPlaceHolder1_lalEmail").attr("style", "color:red;");
         $("#ContentPlaceHolder1_lalEmail").html("请输入邮箱！");
         return false;
     }
     if ($("#ContentPlaceHolder1_txtEmail").val().length > 50) {
         $("#ContentPlaceHolder1_lalEmail").attr("style", "color:red;");
         $("#ContentPlaceHolder1_lalEmail").html("邮箱格式错误！");
         return false;
     }
     else {
         var re = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
         var objExp = new RegExp(re);
         if (objExp.test($("#ContentPlaceHolder1_txtEmail").val()) == true) {
   
                 $("#ContentPlaceHolder1_lalEmail").attr("style", "color:green;");
                 $("#ContentPlaceHolder1_lalEmail").html("正确！");
                 return true;
             } 
         else {
             $("#ContentPlaceHolder1_lalEmail").attr("style", "color:red;")
             $("#ContentPlaceHolder1_lalEmail").html("邮箱格式错误！");
             return false;
         }
     }
     return true;
 }

 function checkallinfo() {
     if (check_UserName() == true && checkUserAddTel() == true && check_email() == true && check_txtContent() == true) {
         return true;
     }
     else {
         alert("请检查所填信息!");
         return false;
     }
 }

 function onclicktis(idd) {
     $("#" + idd).attr("style", "color:red;")
     $("#" + idd).html("*");
 }