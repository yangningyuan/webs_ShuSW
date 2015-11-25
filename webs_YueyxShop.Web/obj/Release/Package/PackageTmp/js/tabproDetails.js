function hasClass(obj, cls) {
    return obj.className.match(new RegExp('(\\s|^)' + cls + '(\\s|$)'));
}

function addClass(obj, cls) {
    if (!this.hasClass(obj, cls)) obj.className += " " + cls;
}

function removeClass(obj, cls) {
    if (hasClass(obj, cls)) {
        var reg = new RegExp('(\\s|^)' + cls + '(\\s|$)');
        obj.className = obj.className.replace(reg, ' ');
    }
}

function showThis(number, divName, divID,aID) {
    var tarArr = document.getElementsByTagName("div");
    var count = 0;
    for (var i = 0; i < tarArr.length; i++) {
        if (tarArr[i].getAttribute("name") != null) {
            if (tarArr[i].getAttribute("name") == divName) {
                count++;
            }
        }
    }
    //将所有的name=divNumber的div都加上hiddendiv
    for (var j = 1; j <= count; j++) {
        var divEle = document.getElementById(divID + j);
        if (!hasClass(divEle, "hide"))
        { addClass(divEle, "hide"); }
		var tabA = document.getElementById(aID+j);
		if(hasClass(tabA,"on"))
		{removeClass(tabA,"on");}
    }
    //给当前的div移除hiddendiv
    var divThis = document.getElementById(divID + number);
    removeClass(divThis, "hide");
	var AThis=document.getElementById(aID+number);
	addClass(AThis,"on");
}