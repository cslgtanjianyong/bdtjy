$(function () {
    $(".flashBanner1").each(function () {
        var timer;
        $(".flashBanner1 .mask1 img").click(function () {
            var index = $(".flashBanner1 .mask img").index($(this));
            changeImg(index);
        }).eq(0).click();
        $(this).find(".mask1").animate({
            "bottom": "0"
        }, 700);
        $(".flashBanner1").hover(function () {
            clearInterval(timer);
        }, function () {
            timer = setInterval(function () {
                var show = $(".flashBanner1 .mask1 img.show").index();
                if (show >= $(".flashBanner1 .mask1 img").length - 1)
                    show = 0;
                else
                    show++;
                changeImg(show);
            }, 3000);
        });
        function changeImg(index) {
            $(".flashBanner1 .mask1 img").removeClass("show").eq(index).addClass("show");
            $(".flashBanner1 .bigImg1").parents("a").attr("href", $(".flashBanner1 .mask1 img").eq(index).attr("link"));
            $(".flashBanner1 .bigImg1").hide().attr("src", $(".flashBanner1 .mask1 img").eq(index).attr("uri")).fadeIn("slow");
        }
        timer = setInterval(function () {
            var show = $(".flashBanner1 .mask1 img.show").index();
            if (show >= $(".flashBanner1 .mask1 img").length - 1)
                show = 0;
            else
                show++;
            changeImg(show);
        }, 3000);
    });
});