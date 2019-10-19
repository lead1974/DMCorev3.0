jQuery(function ($) {

    //#main-slider
    //$(function () {
    //    $('#main-slider.carousel').carousel({
    //        interval: 8000
    //    });
    //});

    //$('.centered').each(function (e) {
    //    $(this).css('margin-top', ($('#main-slider').height() - $(this).height()) / 2);
    //});

    //$(window).resize(function () {
    //    $('.centered').each(function (e) {
    //        $(this).css('margin-top', ($('#main-slider').height() - $(this).height()) / 2);
    //    });
    //});

    ////portfolio
    //$(window).on('load', function () {
    //    $portfolio_selectors = $('.portfolio-filter >li>a');
    //    if ($portfolio_selectors != 'undefined') {
    //        $portfolio = $('.portfolio-items');
    //        $portfolio.isotope({
    //            itemSelector: 'li',
    //            layoutMode: 'fitRows'
    //        });
    //        $portfolio_selectors.on('click', function () {
    //            $portfolio_selectors.removeClass('active');
    //            $(this).addClass('active');
    //            var selector = $(this).attr('data-filter');
    //            $portfolio.isotope({ filter: selector });
    //            return false;
    //        });
    //    }
    //});
    //$(window).on('load', function () {
    //    $portfolio_selectors = $('.portfolio-filter >li>a');
    //    if ($portfolio_selectors != 'undefined') {
    //        $portfolio = $('.portfolio-items');
    //        $portfolio.isotope({
    //            itemSelector: 'li',
    //            layoutMode: 'fitRows'
    //        });
    //        $portfolio_selectors.on('click', function () {
    //            $portfolio_selectors.removeClass('active');
    //            $(this).addClass('active');
    //            var selector = $(this).attr('data-filter');
    //            $portfolio.isotope({ filter: selector });
    //            return false;
    //        });
    //    }
    //});

    //contact form
    var form = $('.contact-form');
    form.submit(function () {
        $this = $(this);
        $.post($(this).attr('action'), function (data) {
            $this.prev().text(data.message).fadeIn().delay(3000).fadeOut();
        }, 'json');
        return false;
    });

    //goto top
    $('.gototop').click(function (event) {
        event.preventDefault();
        $('html, body').animate({
            scrollTop: $("body").offset().top
        }, 500);
    });

    //Pretty Photo
    $("a[rel^='prettyPhoto']").prettyPhoto({
        social_tools: false
    });

    $(window).on('load', function () {
        var $grid = $('.grid').isotope({
            // options
        });
        $('.filter-button-group').on('click', 'button', function () {
            var filterValue = $(this).attr('data-filter');
            $grid.isotope({ filter: filterValue });
            return false;
        });

        // bind sort button click
        $('#sorts').on('click', 'button', function () {
        var sortByValue = $(this).attr('data-sort-by');
        $grid.isotope({ sortBy: sortByValue });
        });

        // change is-checked class on buttons
        $('.button-group').each(function (i, buttonGroup) {
            var $buttonGroup = $(buttonGroup);
            $buttonGroup.on('click', 'button', function () {
                $buttonGroup.find('.active').removeClass('active');
                $(this).addClass('active');
            });
        });
    });
});
