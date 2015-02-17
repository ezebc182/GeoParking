var secondaryNav = $('.cd-secondary-nav'),
  secondaryNavTopPosition = secondaryNav.offset().top;
 
$(window).on('scroll', function(){
  
  if($(window).scrollTop() > secondaryNavTopPosition ) {
    secondaryNav.addClass('is-fixed');  
    setTimeout(function() {
            secondaryNav.addClass('animate-children');
            $('#cd-logo').addClass('slide-in');
      $('.cd-btn').addClass('slide-in');
        }, 50);
  } else {
    secondaryNav.removeClass('is-fixed');
    setTimeout(function() {
            secondaryNav.removeClass('animate-children');
            $('#cd-logo').removeClass('slide-in');
      $('.cd-btn').removeClass('slide-in');
        }, 50);
  }
});

/* Preloader */
$(window).load(function() {
	$(".loader").fadeOut("slow");
})
$(window).scroll(function(){
    if ($(this).scrollTop() > 600) {
      $('#scrollToTop').fadeIn();
    } else {
      $('#scrollToTop').fadeOut();
    }
  });
  
  //Click event to scroll to top
  $('#scrollToTop').click(function(){
    $('html, body').animate({scrollTop : 0},800);
    return false;
  });
/* Smooth Scrolling */
$(document).ready(function(){
  $('a[href*=#]').click(function() {
    if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'')
    && location.hostname == this.hostname) {
      var $target = $(this.hash);
      $target = $target.length && $target
      || $('[name=' + this.hash.slice(1) +']');
      if ($target.length) {
        var targetOffset = $target.offset().top;
        $('html,body')
		/* 1200 is scrolling duration in ms */
        .stop().animate({scrollTop: targetOffset}, 1200);
       return false;
      }
    }
  });
});

/* Smartphone slideshow */
$(function(){
    $('.slideshow img:gt(0)').hide();
    setInterval(function () { $('.slideshow > :first-child').fadeOut().next('img').fadeIn().end().appendTo('.slideshow'); }, 6000);
});
/*Principales características */
$(function(){
    $('.slideMobile img:gt(0)').hide();
    setInterval(function(){$('.slideMobile > :first-child').fadeOut().next('img').fadeIn().end().appendTo('.slideMobile');}, 6000);
});
/* Footer visible on click */
$('.dwn').click(function(){
	$(this).css({
   'opacity' : '.25',
   'margin-bottom' : '300px'
	});
});

/* Pie chart stats */
window.onload = function() {
	//  selecciono class
    var javascript = document.querySelector('.chart1');
    new EasyPieChart(javascript, {
			// animation duration
			animate: ({ duration: 9000, enabled: true }),
			//stength border lines 
			scaleLength:3,
			//piehcart size 
			size:150,
			//chart color 
			barColor:'#555',
			//Show data percent as text
			onStep: function(from, to, percent) {
				this.el.children[0].innerHTML = Math.round(percent);
			}
    });
	var html5 = document.querySelector('.chart2');
    new EasyPieChart(html5, {
			animate: ({ duration: 9000, enabled: true }),
			scaleLength:3,
			size:150,
			barColor:'#555',
			onStep: function(from, to, percent) {
				this.el.children[0].innerHTML = Math.round(percent);
			}
    });
	var html = document.querySelector('.chart3');
    new EasyPieChart(html, {
			animate: ({ duration: 9000, enabled: true }),
			scaleLength:3,
			size:150,
			barColor:'#555',
			onStep: function(from, to, percent) {
				this.el.children[0].innerHTML = Math.round(percent);
			}
    });
}

/* Testimonials */
$(function(){
  // vars for testimonials carousel
  var $txtcarousel = $('#testimonial-list');
  var txtcount = $txtcarousel.children().length;
  var wrapwidth = (txtcount * 415) + 415; // 400px width for each testimonial item
  $txtcarousel.css('width',wrapwidth);
  var animtime = 750; // milliseconds for clients carousel
 
  // next btn for testimonials  
  setInterval(function(){
  /*$('#nxt-testimonial').on('click', function(){*/
    var $first = $('#testimonial-list li:first');
    $first.animate({ 'margin-left': '-415px' }, animtime, function() {
      $first.remove().css({ 'margin-left': '0px' });
      $('#testimonial-list li:last').after($first);
    });  
  },6000);
$('#nxt-testimonial').on('click', function(){
  var $first = $('#testimonial-list li:first');
    $first.animate({ 'margin-left': '-415px' }, animtime, function() {
      $first.remove().css({ 'margin-left': '0px' });
      $('#testimonial-list li:last').after($first);
    });  
});

});

/* Rotating words */
(function(){
    var words = [
		'go',
        'meet',
        'share'
        ], i = 0;
    setInterval(function(){
        $('#word-change').slideUp(function(){
            $(this).html(words[i=(i+1)%words.length]).slideDown();
        });
    }, 1000);
        
})();