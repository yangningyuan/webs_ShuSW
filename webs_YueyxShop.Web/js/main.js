// JavaScript Document

//头部搜索框文本聚焦消失JS
$(document).ready(function(){
	//第一种
	$("#form1 input[type='text']").each(function(){
		var thisVal=$(this).val();
		//判断文本框的值是否为空，有值的情况就隐藏提示语，没有值就显示
		if(thisVal!=""){
			$(this).siblings("span").hide();
		}else{
			$(this).siblings("span").show();
		}
		//聚焦型输入框验证 
		$(this).focus(function(){
			$(this).siblings("span").hide();
		}).blur(function(){
			var val=$(this).val();
			if(val!=""){
				$(this).siblings("span").hide();
			}else{
				$(this).siblings("span").show();
			} 
		});
	});
	
		//第一种
	$("#form2 input[type='text'],#form2 input[type='password']").each(function(){
		var thisVal=$(this).val();
		//判断文本框的值是否为空，有值的情况就隐藏提示语，没有值就显示
		if(thisVal!=""){
			$(this).siblings("span").hide();
		}else{
			$(this).siblings("span").show();
		}
		//聚焦型输入框验证 
		$(this).focus(function(){
			$(this).siblings("span").hide();
		}).blur(function(){
			var val=$(this).val();
			if(val!=""){
				$(this).siblings("span").hide();
			}else{
				$(this).siblings("span").show();
			} 
		});
	});
	
		//第一种
	$("#form3 input[type='text'],#form3 input[type='password']").each(function(){
		var thisVal=$(this).val();
		//判断文本框的值是否为空，有值的情况就隐藏提示语，没有值就显示
		if(thisVal!=""){
			$(this).siblings("span").hide();
		}else{
			$(this).siblings("span").show();
		}
		//聚焦型输入框验证 
		$(this).focus(function(){
			$(this).siblings("span").hide();
		}).blur(function(){
			var val=$(this).val();
			if(val!=""){
				$(this).siblings("span").hide();
			}else{
				$(this).siblings("span").show();
			} 
		});
	});
		//第一种
	$("#form4 input[type='text'],#form4 input[type='password']").each(function(){
		var thisVal=$(this).val();
		//判断文本框的值是否为空，有值的情况就隐藏提示语，没有值就显示
		if(thisVal!=""){
			$(this).siblings("span").hide();
		}else{
			$(this).siblings("span").show();
		}
		//聚焦型输入框验证 
		$(this).focus(function(){
			$(this).siblings("span").hide();
		}).blur(function(){
			var val=$(this).val();
			if(val!=""){
				$(this).siblings("span").hide();
			}else{
				$(this).siblings("span").show();
			} 
		});
	});
	
	
	
	//第二种
	$("#keydown .input_txt").each(function(){
		var thisVal=$(this).val();
		//判断文本框的值是否为空，有值的情况就隐藏提示语，没有值就显示
		if(thisVal!=""){
			$(this).siblings("span").hide();
		}else{
			$(this).siblings("span").show();
		}
		$(this).keyup(function(){
			var val=$(this).val();
			$(this).siblings("span").hide();
		}).blur(function(){
			var val=$(this).val();
			if(val!=""){
				$(this).siblings("span").hide();
			}else{
				$(this).siblings("span").show();
			}
		})
	});
	 
})




//分类搜索JS
$(function(){ 

	$("#searchSelected").click(function(){ 
		$("#searchTab").show();
		$(this).addClass("searchOpen");
	}); 

	$("#searchTab li").hover(function(){
		$(this).addClass("selected");
	},function(){
		$(this).removeClass("selected");
	});
	 
	$("#searchTab li").click(function(){
		$("#searchSelected").html($(this).html());
		$("#searchTab").hide();
		$("#searchSelected").removeClass("searchOpen");
	});
	
});



/*返回顶部JS*/
$(document).ready(function(){

	$(window).scroll(function() {
		if ($(window).scrollTop() > 300) {
			$('#jump li:eq(2)').fadeIn(800);
		} else {
			$('#jump li:eq(2)').fadeOut(800);
		}
	});
	
	$("#top").click(function() {
		$('body,html').animate({
			scrollTop: 0
		},
		1000);
		return false;
	});
	
});


//星级评分产品详细页发表评论评分JS
window.onload = function (){

	var oStar = document.getElementById("star");
	var aLi = oStar.getElementsByTagName("dt");
	var oUl = oStar.getElementsByTagName("ul")[0];
	var oSpan = oStar.getElementsByTagName("span")[1];
	var oP = oStar.getElementsByTagName("p")[0];
	var i = iScore = iStar = 0;
	
	for (i = 1; i <= aLi.length; i++){
		aLi[i - 1].index = i;
		
		//鼠标移过显示分数
		aLi[i - 1].onmouseover = function (){
			fnPoint(this.index);
			//浮动层显示
			oP.style.display = "block";
			//计算浮动层位置
			oP.style.left = oUl.offsetLeft + this.index * this.offsetWidth - 104 + "px";
			//匹配浮动层文字内容
			oP.innerHTML = "<em><b>" + this.index + "</b> 分 " + aMsg[this.index - 1].match(/(.+)\|/)[1] + "</em>" + aMsg[this.index - 1].match(/\|(.+)/)[1]
		};
		
		//鼠标离开后恢复上次评分
		aLi[i - 1].onmouseout = function (){
			fnPoint();
			//关闭浮动层
			oP.style.display = "none"
		};
		
		//点击后进行评分处理
		aLi[i - 1].onclick = function (){
			iStar = this.index;
			oP.style.display = "none";
			oSpan.innerHTML = "<strong>" + (this.index) + " 分</strong> (" + aMsg[this.index - 1].match(/\|(.+)/)[1] + ")"
		}
	}
	
	//评分处理
	function fnPoint(iArg){
		//分数赋值
		iScore = iArg || iStar;
		for (i = 0; i < aLi.length; i++) aLi[i].className = i < iScore ? "on" : "";	
	}
	
};


//表单美化JS
$(function(){
	
	$('input').customInput();
	
	$('.pj-input').each(function(){
		$('div:first',this).addClass('first');
		$('div:last',this).addClass('last');	
	}); 
});