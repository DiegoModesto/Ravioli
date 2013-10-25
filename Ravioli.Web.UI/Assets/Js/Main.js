/*Render Webfont*/
$.ready(function () {
    WebFontConfig = {
        google: { families: ['Lato:300,400,700:latin'] }
    };
    (function () {
        var wf = document.createElement('script');
        wf.src = ('https:' == document.location.protocol ? 'https' : 'http') +
          '://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
        wf.type = 'text/javascript';
        wf.async = 'true';
        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(wf, s);
    })();
});

$(document).ready(function () {
    //Itens do Login
    $("#frm-login #email").focusin(function () { $(this).prev().addClass("input-with-focus"); });
    $("#frm-login #email").focusout(function () { $(this).prev().removeClass("input-with-focus"); });
    $("#frm-login #senha").focusin(function () { $(this).prev().addClass("input-with-focus"); });
    $("#frm-login #senha").focusout(function () { $(this).prev().removeClass("input-with-focus"); });
    
    //Tooltip geral
    $('li').each(function (e, f) { if ($(f).data("toggle") == "tooltip") $(f).tooltip(); });
    $('a').each(function (e, f) { if ($(f).data("toggle") == "tooltip") $(f).tooltip(); });

    //Popover geral
    $('li').each(function (e, f) { if ($(f).data("toggle") == "popover") { $(f).popover({ html: true }).find('a').click(function (e) { e.preventDefault(); }); } });
    $('a').each(function (e, f) { if ($(f).data("toggle") == "popover") { $(f).popover({ html: true }).click(function (e) { e.preventDefault(); }); } });
   
    //$(':not(#anything)').on('click', function (e) {
    //$('html').on('click', function (e) {
    $('html').on('click.popover.data-api', function (e) {
        $('.me-popover').each(function () {
            /*if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
                $(this).popover('hide');
                return;
            }*/
            if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
                $(this).popover('hide');
                return;
            }
        });
    });

    //Tabs geral
    $('ul').each(function(e, f) { if ($(f).data("toggle") == "navtab") { $(f).find('a').click(function (e) { e.preventDefault(); $(this).tab('show'); }); } });
});