// JavaScript Document
$(function(){//JS開頭

$(".navbar-toggle.collapsed").click(function() {
	$(".sidebar").slideToggle(300);
});


//瀏覽器改寬度時
RESIZE();

$(window).resize(function(){
	RESIZE();
})

function RESIZE(){
	var WINDOW=$(window).width();
	if(WINDOW>767){
		$(".sidebar").css('display', 'block');
	}else{
		$(".sidebar").css('display', 'none');
	}
}

})//JS尾端	