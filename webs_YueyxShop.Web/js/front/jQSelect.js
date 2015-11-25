;(function($){
	$.fn.jQSelect = function(settings){
	
		var $div = this;
		var $cartes = $div.find(".cartes");
		var $lists = $div.find(".lists");
		var $cart = $div.find(".cart");
		var $lists1 = $div.find(".lists1");
		
		var listTxt1 = $cart.find(".listTxt1");
		var listVal1 = $cart.find(".listVal1");
		
		var listTxt = $cartes.find(".listTxt");
		var listVal = $cartes.find(".listVal");

		var items = $lists.find("ul > li");
		
		var items1 = $lists1.find("ul > li");
		
		$div.hover(function(){
			$(this).addClass("hover");
		},function(){
			$(this).removeClass("hover");	
		});
		
		
		
		//绑定点击事件
		items.click(function(){
			listVal.val($(this).attr("id"));
			listTxt.val($(this).text());
			$div.removeClass("hover");
		}).mouseover(function(){
			$(this).removeClass("cwhite");
			$(this).addClass("cgray");
		}).mouseout(function(){
			$(this).removeClass("cgray");
			$(this).addClass("cwhite");
		});
		//绑定点击事件
		items1.click(function(){
			listVal1.val($(this).attr("id"));
			listTxt1.val($(this).text());
			$div.removeClass("hover");
		}).mouseover(function(){
			$(this).removeClass("cwhite");
			$(this).addClass("cgray");
		}).mouseout(function(){
			$(this).removeClass("cgray");
			$(this).addClass("cwhite");
		});
		
	};
})(jQuery);