
	
function jzClick(idv){
		$("#jz0").removeClass("hover");
		$("#jz"+idv).addClass("hover");
	}
	function chClick(idv){
		$("#o0").removeClass("hover");
		$("#o"+idv).addClass("hover");
	}
	function jgClick(idv){
		$("#jg0").removeClass("hover");
		$("#jg"+idv).addClass("hover");
	}
	$(function(){
		var jzmark = $("#jz_mark").val();
		var chmark = $("#ch_mark").val();
		var pricemark = $("#price_mark").val();
		jzClick(jzmark);
		chClick(chmark);
		jgClick(pricemark);
	})
$(function(){
	var bStop=true;
	$('.closeInfo').live('click',function(){
		if(!bStop)
		{
			$('.price_box').stop().animate({'height':'97px'});
			$('.closeInfo').html('收起');
			$('.closeInfo').css('backgroundImage','url(http://img01.jiuxian.com/img1/tit/open.gif)');
			bStop=true;
		}
		else
		{
			$('.price_box').stop().animate({'height':'0px'});
			$('.closeInfo').html('展开');
			$('.closeInfo').css('backgroundImage','url(http://img01.jiuxian.com/img1/tit/close.gif)');
			bStop=false;
		}
		
	})
	
$('.groupBuy-list li').live('mouseover',function(){
	
		$(this).find('.cover.lasttime').stop().animate({'top':'212px'});
		$(this).find('.m').css('background','#cf010e');
		$(this).find('h2').css({
			'background' : '#cf010e',
			'color' : '#fff'
		})
		$(this).find('em').css({
			'background' : '#cf010e',
			'color' : '#fff'
		})
			})
	var timer=null;
	$('.groupBuy-list li').live('mouseout',function(){
	
		$(this).find('.cover.lasttime').stop().animate({'top':'237px'});
		$(this).find('.m').css('background','#fff');
		$(this).find('h2').css({
					'background' : '#fff',
					'color' : '#585858'
				})
		$(this).find('em').css({
					'background' : '#fff',
					'color' : '#585858'
				})				
	})
	
	$('.groupBuy-cont li').live('mouseover',function(){
	
		$(this).find('.cover.lasttime').stop().animate({'top':'212px'});
		$(this).find('.m').css('background','#cf010e');
		$(this).find('h2').css({
			'background' : '#cf010e',
			'color' : '#fff'
		})
		$(this).find('em').css({
			'background' : '#cf010e',
			'color' : '#fff'
		})
			})
	var timer=null;
	$('.groupBuy-cont li').live('mouseout',function(){
	
		$(this).find('.cover.lasttime').stop().animate({'top':'237px'});
		$(this).find('.m').css('background','#fff');
		$(this).find('h2').css({
					'background' : '#fff',
					'color' : '#585858'
				})
		$(this).find('em').css({
					'background' : '#fff',
					'color' : '#585858'
				})				
	})

	$('.top_show_box').hide();
	$('.top .top_show_box:eq(0)').show();
	$('.top .top_hide_box:eq(0)').hide();
	$('.top li').mouseover(function(mevent){		
		var ev=mevent.currentTarget;
		$('.top_hide_box').show();
		$('.top_show_box').hide();
		$(ev).children('.top_show_box').show();
		$(ev).find('.top_hide_box').hide();
	})
})

var protuanIds = $("#tuanId").val();
	var proHotTuanIds = $("#proHotTuanIds").val();
	function GetRandomNum(Min,Max){   
    	var Range = Max - Min;   
    	var Rand = Math.random();   
    	return(Min + Math.round(Rand * Range));   
	}
	$(function(){
		if(protuanIds != ''){
    		jQuery.ajax({ // 获取列表页商品的最新价格
                 type: "POST",
                 url:"/ajaxGetProductPrice.htm?t="+GetRandomNum(1,100),
                 data: {'tuanIds':protuanIds},
                 dataType:"json",
                 success:function(data){
        		 	for(var obj in data){ // 设置商品的价格
    					$("#tuanPrice"+obj).html(+data[obj]);
        			}	
                 }
             }); 
		 }
	});
	$(function(){
		if(proHotTuanIds != ''){
    		jQuery.ajax({ //获取顶部热卖推荐商品价格
                 type: "POST",
                 url:"/ajaxGetHotProductPrice.htm?t="+GetRandomNum(1,100),
                 data: {'tuanIds':proHotTuanIds},
                 dataType:"json",
                 success:function(data){
        		 	for(var obj in data){ // 设置商品的价格
    					$("#hotProPrice"+obj).html("<span>¥</span>"+data[obj].t_price)
        				$("#markPrice"+obj).html("市场价：¥"+data[obj].m_price)
						$("#result"+obj).html("您节省：¥"+data[obj].result);
					}	
                 }
             }); 
		 }
	});
	
	
$(".groupBuy-list").find("img").lazyload({effect : "fadeIn",placeholder : "images/color3.gif" });	