function onButton(td) {
    td.style.backgroundImage = 'url(../images/button_b3.gif)';
    td.style.color = '#022000';
}

function offButton(td) {
    td.style.backgroundImage = '';
    td.style.color = '#022000';
}
function mOvr(src, clrOver) {
    if (!src.contains(event.fromElement)) {
        // src.style.cursor = 'hand';
        src.bgColor = clrOver;
    }
}
function mOut(src, clrIn) {
    if (!src.contains(event.toElement)) {
        src.style.cursor = 'default';
        src.bgColor = clrIn;
    }
}
function SelectAll(objFrm) {
    for (var i = 0; i < objFrm.elements.length; i++) {
        var ele = objFrm.elements[i];
        if (ele.name != "chkStatus" && ele.name == "chkEleId" && ele.disabled == 0) {
            ele.checked = objFrm.chkAll.checked;
        }
    }
}

function SubmitAll(objFrm) {
    var flag = false;
    for (var i = 0; i < objFrm.elements.length; i++) {
        var ele = objFrm.elements[i];
        if (ele.name == "chkEleId" && ele.checked == true) {
            flag = true;
            break;
        }
    }
    if (flag) {
        if (confirm("确定要删除么?"))
            return true;
        else
            return false;
    }
    else {
        alert("请选择要删除项!");
        return false;
    }
}
//新增页面js
String.prototype.Trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
function checkInfo() {
    checkAddInfoTitle();
    checkclass();
    checkAddInfoAddAuthor();
    if (checkAddInfoTitle() == false || checkclass() == false || checkAddInfoAddAuthor() == false) {
        alert("请检查所填信息");
        return false;
    }
}
function checkInfo1() {
    checkAddInfoTitle();
    checkclass1();
    checkAddInfoAddAuthor1();
    if (checkAddInfoTitle() == false || checkclass1() == false || checkAddInfoAddAuthor1() == false) {
        alert("请检查所填信息");
        return false;
    }
}
function checkAddInfoTitle() {
    var strTitle = document.getElementById("txtTitle").value;
    if (strTitle == "") {
        document.getElementById("lalTitle").innerHTML = "<span style='color:red;'>名称不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalTitle").innerHTML = "<span style='color:green;'>名称可用！</span>";
//        checkclass();
        return true;
    }
}
function checkclass() {
    var _ddlFLInfoclass = document.getElementById("ddlFLInfoclass");
    var _ddlFLInfo = document.getElementById("ddlFLInfo");
    if (_ddlFLInfo.value == "10000") {
        document.getElementById("lalclass").innerHTML = "<span style='color:red;'>分类不能为空！</span>";
        return false;
    }
    if (_ddlFLInfoclass.value == "0") {
        document.getElementById("lalclass").innerHTML = "<span style='color:red;'>分类不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalclass").innerHTML = "";
        return true;
    }
}

function checkclass1() {
    var _ddlFLInfoclass = document.getElementById("FLddlFLInfo");
    if (_ddlFLInfoclass.value == "0") {
        document.getElementById("lalclass").innerHTML = "<span style='color:red;'>分类不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalclass").innerHTML = "";
        return true;
    }
}
function checkAddInfoAddAuthor() {
    var strAddAuthor = document.getElementById("txtAddAuthor").value;
    if (strAddAuthor == "") {
        document.getElementById("lalAddAuthor").innerHTML = "<span style='color:red;'>作者不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalAddAuthor").innerHTML = "<span style='color:green;'>作者名可用！</span>";
        checkclass();
        return true;
    }
}
function checkAddInfoAddAuthor1() {
    var strAddAuthor = document.getElementById("txtAddAuthor").value;
    if (strAddAuthor == "") {
        document.getElementById("lalAddAuthor").innerHTML = "<span style='color:red;'>作者不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalAddAuthor").innerHTML = "<span style='color:green;'>作者名可用！</span>";
        checkclass1();
        return true;
    }
}


function checkAddPCName() {
    var strPClassName = document.getElementById("txtPClassName").value;
    if (strPClassName == "") {
        document.getElementById("lalPClassName").innerHTML = "<span style='color:red;'>名称不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalPClassName").innerHTML = "<span style='color:green;'>名称可用！</span>";
        //        checkclass();
        return true;
    }
}

function checkAddPClassRefName() {
    var strPClassRefName = document.getElementById("txtPClassRefName").value;
    if (strPClassRefName == "") {
        document.getElementById("lalPClassRefName").innerHTML = "<span style='color:red;'>别名不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalPClassRefName").innerHTML = "<span style='color:green;'>别名可用！</span>";
        //        checkclass();
        return true;
    }
}
function checkAddPC() {
    checkAddPCName();
    checkAddPClassRefName();
    if (checkAddPCName() == false || checkAddPClassRefName() == false) {
        alert("请检查所填信息");
        return false;
    }
}

function checkAddPC1() {
    checkAddPCName();
   // checkAddPClassRefName();
    if (checkAddPCName() == false) {
        alert("请检查所填信息");
        return false;
    }
}

function checkAddIndexImageIIName() {
    var strTitle = document.getElementById("txtIIName").value;
    if (strTitle == "") {
        document.getElementById("lalIIName").innerHTML = "<span style='color:red;'>名称不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalIIName").innerHTML = "<span style='color:green;'>名称可用！</span>";
        //        checkclass();
        return true;
    }
}





function checkUserAddInfo() {
    if (checkUserAddUserName() != true) {
        alert("请检查所填信息！");
        return false;

    }
    if (checkUserAddLoginName() != true) {
        alert("请检查所填信息！");
        return false;
    }
    if (checkUserAddPWDOne() != true) {
        alert("请检查所填信息！");
        return false;
    }
    if (checkUserAddPWDTwo() != true) {
        alert("请检查所填信息！");
        return false;
    }
    if (checkUserAddTel() != true) {
        alert("请检查所填信息！");
        return false;
    }
    if (checkUserAddUserName() != true && checkUserAddLoginName() != true && checkUserAddPWDOne() != true && checkUserAddPWDTwo() != true && checkUserAddTel() != true) {
        return true;
    }
}
function checkUserAddLoginName() {
    var strLoginName = document.getElementById("txtLoginName").value;
    if (strLoginName == "") {
        document.getElementById("lalLoginName").innerHTML = "<span style='color:red;'>登录名不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalLoginName").innerHTML = "<span style='color:green;'>名登录名可用！</span>";
        //        checkclass();
        return true;
    }
}
function checkUserAddUserName() {
    var strUserName = document.getElementById("txtUserName").value;
    if (strUserName == "") {
        document.getElementById("lalUserName").innerHTML = "<span style='color:red;'>用户名不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalUserName").innerHTML = "<span style='color:green;'>名登录名可用！</span>";
        //        checkclass();
        return true;
    }
}

function checkUserAddPWDOne() {
    var strPWDOne = document.getElementById("txtPWDOne").value;
    if (strPWDOne == "") {
        document.getElementById("lalPWDOne").innerHTML = "<span style='color:red;'>密码不能为空！</span>";
        return false;
    }
    else {
        document.getElementById("lalPWDOne").innerHTML = "<span style='color:green;'>密码可用！</span>";
        //        checkclass();
        return true;
    }
}
function checkUserAddPWDTwo() {
    var strPWDOne = document.getElementById("txtPWDOne").value;
    var strPWDTwo = document.getElementById("txtPWDTwo").value;
    //            if (strPWDTwo == "") {
    //                document.getElementById("lalPWDTwo").innerHTML = "<span style='color:red;'>密码不能为空！</span>";
    //                return false;
    //            }
    if (strPWDOne != strPWDTwo) {
        document.getElementById("lalPWDTwo").innerHTML = "<span style='color:red;'>两次密码输入不一样！</span>";
        return false;
    }
    else {
        document.getElementById("lalPWDTwo").innerHTML = "<span style='color:green;'></span>";
        return true;
    }
}
//判断电话号码的
function checkUserAddTel() {
    var phone = document.getElementById("txtTel").value.toString();
    if (phone.length == 0) {
        document.getElementById("lalTel").innerHTML = "<span style='color:red;'>请输入联系电话</span>";
        return false;
    }
    else if (phone.length > 15) {
        document.getElementById("lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
        return false;
    }
    else {

        var patten = /^(((\(0\d{2,3}\)){1}|(0\d{2,3}[- ]?){1})?([1-9]{1}[0-9]{2,7}(\-\d{3,4})?))$/;
        var pat = /^(\b13[0-9]{9}\b)|(\b14[7-7]\d{8}\b)|(\b15[0-9]\d{8}\b)|(\b18[0-9]\d{8}\b)|\b1[1-9]{2,4}\b$/;
        var checkphone = phone.toString().split('-');
        if (checkphone.length > 2) {
            document.getElementById("lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
            return false;
        }
        if (phone != "" || phone.length != 0) {
            if (phone.substr(0, 3) == "+86") {
                phone = phone.substr(3, phone.length);
            }
            if (phone.substr(0, 2) == "13" || phone.substr(0, 2) == "14" || phone.substr(0, 2) == "15" || phone.substr(0, 2) == "18") {
                if (pat.test(phone)) {
                    document.getElementById("lalTel").innerHTML = "<span style='color:green;'>联系方式可用</span>";
                    return true;
                }
                else {
                    document.getElementById("lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
                    return false;
                }
            }
            else {
                if (patten.test(phone)) {
                    document.getElementById("lalTel").innerHTML = "<span style='color:green;'>联系电话可用</span>";
                    return true;
                }
                else {
                    document.getElementById("lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
                    return false;
                }
            }
        }
        else {
            document.getElementById("lalTel").innerHTML = "<span style='color:red;'>联系电话格式错误</span>";
            return false;
        }
    }
}
//内容修改页
