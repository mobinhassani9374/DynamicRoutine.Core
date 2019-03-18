$(function() {

    new WOW().init();

    $('.header__hide-sidebar').on('click',function(){
        if($('body').hasClass('hide-sidebar')) {
            $('body').removeClass('hide-sidebar');
            $('.menu').css('margin-right','0px')
            $('.main').css('margin-right','200px')
        }
        else {
            $('body').addClass('hide-sidebar');
            $('.menu').css('margin-right','-200px');
            $('.main').css('margin-right','0px');
        }
    })

    $(window).resize(function(){
        $('.main').removeAttr('style')
        $('.menu').removeAttr('style')        
        if (window.innerWidth < 992) {  
            $('body').addClass('page-small');
        }
        else {
            $('body').removeClass('page-small');
        }        
    })

    $(window).resize();

    
    // isotope

    $('.grid').isotope({
        // options
        itemSelector: '.grid-item', 
        isOriginLeft: false,               
    });
})