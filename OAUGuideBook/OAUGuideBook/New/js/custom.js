 jQuery(document).ready(function () {
     'use strict';
    /**=====================================
    * Mega Menu Active
    * =====================================*/
    $("#menuzord").menuzord({
       align: "right",
       effect: "fade",
       animation: "drop-up",
       indicatorFirstLevel: "<i class='fa fa-angle-down'></i>",
       indicatorSecondLevel: "<i class='fa fa-angle-down'></i>"
  });
  /**=====================================
  *  Partner Crousel
  * =====================================*/
  $('.partner-crousel').owlCarousel({
       autoPlay: true,
       pagination: false,
       loop:true,
       navigation:false,
       items: 6,
       itemsDesktop: [1024, 4],
       itemsDesktopSmall: [768,3],
       itemsTablet: [650, 2],
       itemsMobile: 1,
       navigationText: [
         "<i class='ion-ios-arrow-left'></i>",
         "<i class='ion-ios-arrow-right'></i>"
         ]
    });
  $('.blog-post-carousel').owlCarousel({
       autoPlay: true,
       pagination: false,
       loop:true,
       navigation:true,
       items: 1,
       itemsDesktop: [1024, 1],
       itemsDesktopSmall: [768,1],
       itemsTablet: [650,1],
       itemsMobile: 1,
       navigationText: [
         "<i class='fa fa-angle-left'></i>",
         "<i class='fa fa-angle-right'></i>"
         ]
    });
  $('.all-freecourse-carousel').owlCarousel({
       autoPlay: true,
       pagination: false,
       loop:true,
       navigation:true,
       items: 3,
       itemsDesktop: [1024, 3],
       itemsDesktopSmall: [768,2],
       itemsTablet: [650,1],
       itemsMobile: 1,
       navigationText: [
         "<i class='fa fa-angle-left'></i>",
         "<i class='fa fa-angle-right'></i>"
         ]
    });
    /**=====================================
    *  Partner Crousel
    * =====================================*/
    if($('.media').length){
        $(".media").fitVids();
    }
    // $("#offcanvas-toggler i").on('click', function(){
    //     $(".menu-area .course-search").toggleClass('visible sd-hide');
    //     $(this).toggleClass('fa-search fa-remove');
    // });

    /** =====================================
     *  Paralex
     * =====================================*/

    if( $('.parallax-bg').length ){
        $('.parallax-bg').parallax("80%", 0.4);
    }

    if( $('#round-appearance1').length ){
        $("#round-appearance1").roundSlider({
            radius: 70,
            width: 10,
            handleSize: "0",
            handleShape: "0",
            sliderType: "min-range",
            value: 89,
            readOnly:true,
            startAngle: 90,
        });
    }
    if( $('#round-appearance2').length ){
        $("#round-appearance2").roundSlider({
            radius: 70,
            width: 10,
            handleSize: "0",
            handleShape: "0",
            sliderType: "min-range",
            value: 89,
            readOnly:true,
            startAngle: 90,
        });
    }
    if( $('#round-appearance3').length ){
        $("#round-appearance3").roundSlider({
            radius: 70,
            width: 10,
            handleSize: "0",
            handleShape: "0",
            sliderType: "min-range",
            value: 89,
            readOnly:true,
            startAngle: 90,
        });
    }
    /**=====================================
    *  jQuery countdown
    * =====================================*/
    if($('#defaultCountdown').length){
        var austDay = new Date();
    	austDay = new Date(austDay.getFullYear() + 1, 1 - 1, 26);
    	$('#defaultCountdown').countdown({until: austDay});
    	$('#year').text(austDay.getFullYear());
    }


    $("#offcanvas-toggler").on("click", function(e) {
        e.preventDefault(), $(".top-search-input-wrap").addClass("show");
    });
    $(".top-search-input-wrap .top-search-overlay, .top-search-input-wrap .close-icon").on("click", function() {
        $(".top-search-input-wrap").removeClass("show");
    });

    $(window).on('load', function(){
		$('.preloader').fadeOut();
	});
});
