/// <reference path="jquery.js" />



//$("#rank_vp_list p").after("a");
//alert($("#rank_vp_list").html());
//alert(document.getElementById("rank_vp_list").innerHTML);


$.ajax({
    type: "post",
    url: "../../Axhx/getArtList.ashx",
    dataType: "xml",
    success: function (result) {
        $(result).find("ViewPoint").each(function () {
            $("#rank_vp_list p").after("<li style='margin-top:4px'><span style='font-size: 9px;'>>></span>&nbsp;<a href='http://www.zhongsencehua.com/article/" + $(this).children("ID").text() + ".html' title='" + $(this).children("Title").text() + "'>" + $(this).children("Title").text() + "</a></li>")
        });
    }
});


//alert($("#rank_vp_list").html());




