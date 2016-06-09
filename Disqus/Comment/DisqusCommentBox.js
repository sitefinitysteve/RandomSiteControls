var $sfsDisqus = {
    loaded: false,
    wrapper: null
};

$(document).ready(function () {
    $sfsDisqus.wrapper = $("#disqus_thread");

    disqusCheck();

    $(window).scroll(function () {
        disqusCheck();
    });


});

function disqusCheck() {
    if (disqusisScrolledIntoView($sfsDisqus.wrapper)) {
        if (!$sfsDisqus.loaded) {
            /* * * DON'T EDIT BELOW THIS LINE * * */
            (function () {
                var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
                dsq.src = window.location.protocol + '//' + disqus_shortname + '.disqus.com/embed.js';
                (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
                $sfsDisqus.loaded = true;
                $(window).unbind("scroll");
            })();
        }
    }
}

function disqusisScrolledIntoView(elem) {
    var docViewTop = $(window).scrollTop();
    var docViewBottom = docViewTop + $(window).height();

    var elemTop = $(elem).offset().top;
    var elemBottom = elemTop + $(elem).height();

    return ((elemBottom >= docViewTop) && (elemTop <= docViewBottom)
      && (elemBottom <= docViewBottom) && (elemTop >= docViewTop));
}

