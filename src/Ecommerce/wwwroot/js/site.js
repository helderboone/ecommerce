    $(function () {
    $("[data-select]").each(function () {
        var e = $(this),
            t = $("#" + e.data("select")),
            i = e.parent().find(".dropdown-toggle"),
            a = e.find(".dropdown-item"),
            n = e.find('[data-value="' + t.val() + '"]');
        i.html(n.html()), a.click(function () {
            $(this).data("value") != t.val() && (i.html($(this).html()), t.val($(this).data("value")).trigger("change")), i.focus()
        }), e.parent().on("shown.bs.dropdown", function () {
            e.find('[data-value="' + t.val() + '"]').trigger("focus")
        })
    });
    var e = $(".middle-header"),
        t = $('<div id="wrapper"></div>');
    e.before(t);
    var i = t.offset().top,
        a = "fixed-top",
        n = $(window).scrollTop();
    $(window).on("load scroll resize", function () {
        var r = e.outerHeight(),
            o = $(this).scrollTop();
        o < n ? o <= i && (e.hasClass(a) && e.removeClass(a), t.height(0)) : o >= i + r + 20 && (e.addClass(a), t.height(r)), n = o
    }), $(".main-nav .nav-item.dropdown").hover(function () {
        $(this).addClass("show").find("> .dropdown-menu").addClass("show")
    }, function () {
        $(this).removeClass("show").find("> .dropdown-menu").removeClass("show")
    })
});
