// JavaScript Document

function process_newsletter()
{
	var newsname = document.getElementById('newsletter_name').value;	
	var newsemail = document.getElementById('newsletter_email').value;
	
	if (newsname == ""){
		document.getElementById('newsletter-error').innerHTML = 'Please fill in your name.';
		newsletter_form.newsletter_name.focus();
	}
	else if (newsemail == ""){
		document.getElementById('newsletter-error').innerHTML = 'Please fill in your email.';
		newsletter_form.newsletter_email.focus();
	}
	else 
	{
		if(!check_email(newsemail))
		{
			document.getElementById('newsletter-error').innerHTML = 'Invalid email format.';
			newsletter_form.newsletter_email.focus();
		}
		else
		{
			var ajaxRequest = getHTTPObject();
			
			// Create a function that will receive data sent from the server
			ajaxRequest.onreadystatechange = function()
			{				
				//0 = uninitialized
				//1 = loading
				//2 = loaded
				//3 = interactive
				//4 = complete
				
				if(ajaxRequest.readyState == 1){
					// Get the data from the server's response
					
				}
				
				if(ajaxRequest.readyState == 2){
					// Get the data from the server's response
					
				}
				
				if(ajaxRequest.readyState == 3){
					// Get the data from the server's response
					
				}
				
				if(ajaxRequest.readyState == 4){
					// Get the data from the server's response
					var ajaxDisplay = document.getElementById('newsletter');
					
					ajaxDisplay.innerHTML = ajaxRequest.responseText;						
				}
				
			}				
			var queryString = "?param=" + newsname + "&access=" + newsemail; 
			ajaxRequest.open("GET", "server.asp"+ queryString, true);
			
			ajaxRequest.send(null);				
		}
		
	}
}

function getHTTPObject(){
	
	try{
		// Opera 8.0+, Firefox, Safari
		return new XMLHttpRequest();
	} catch (e){
		// Internet Explorer Browsers
		try{
			return new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e) {
			try{
				return new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e){
				// Something went wrong
				alert("Your browser broke!");
				return false;
			}
		}
	}

}

function check_email(e) {
	ok = "1234567890qwertyuiop[]asdfghjklzxcvbnm.@-_QWERTYUIOPASDFGHJKLZXCVBNM";

	for(i=0; i < e.length ;i++){
	if(ok.indexOf(e.charAt(i))<0){ 
	return (false);
	}	
	} 

	if (document.images) {
		re = /(@.*@)|(\.\.)|(^\.)|(^@)|(@$)|(\.$)|(@\.)/;
		re_two = /^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
		if (!e.match(re) && e.match(re_two)) {
		return (-1);		
		} 

	}
}

function change_content(number)
{
	
	if(number=="two")	
	{
		document.getElementById("accom_bg1").style.display='none';
		document.getElementById("accom_bg2").style.display='block';
		document.getElementById("AccomodationboxTab1").setAttribute("class", "AccomodationboxTab");
		document.getElementById("AccomodationboxTab2").setAttribute("class", "AccomodationboxTab_selected");
	}	
	else
	{
		document.getElementById("accom_bg1").style.display='block';
		document.getElementById("accom_bg2").style.display='none';
		document.getElementById("AccomodationboxTab1").setAttribute("class", "AccomodationboxTab_selected");
		document.getElementById("AccomodationboxTab2").setAttribute("class", "AccomodationboxTab");
	}
	
}

function change_spring(number)
{
	if(number=="two")	
	{
		document.getElementById("spring_bg1").style.display='none';
		document.getElementById("spring_bg2").style.display='block';
		document.getElementById("spring_bg3").style.display='none';
		document.getElementById("spring_bg4").style.display='none';
		document.getElementById("spring_bg5").style.display='none';
		document.getElementById("spring_bg6").style.display='none';
		document.getElementById("spring_bg7").style.display='none';
		document.getElementById("spring_bg8").style.display='none';		
	}
	else if(number=="three")	
	{
		document.getElementById("spring_bg1").style.display='none';
		document.getElementById("spring_bg2").style.display='none';
		document.getElementById("spring_bg3").style.display='block';
		document.getElementById("spring_bg4").style.display='none';
		document.getElementById("spring_bg5").style.display='none';
		document.getElementById("spring_bg6").style.display='none';
		document.getElementById("spring_bg7").style.display='none';
		document.getElementById("spring_bg8").style.display='none';
	}
	else if(number=="four")	
	{
		document.getElementById("spring_bg1").style.display='none';
		document.getElementById("spring_bg2").style.display='none';
		document.getElementById("spring_bg3").style.display='none';
		document.getElementById("spring_bg4").style.display='block';
		document.getElementById("spring_bg5").style.display='none';
		document.getElementById("spring_bg6").style.display='none';
		document.getElementById("spring_bg7").style.display='none';
		document.getElementById("spring_bg8").style.display='none';		
	}
	else if(number=="five")	
	{
		document.getElementById("spring_bg1").style.display='none';
		document.getElementById("spring_bg2").style.display='none';
		document.getElementById("spring_bg3").style.display='none';
		document.getElementById("spring_bg4").style.display='none';
		document.getElementById("spring_bg5").style.display='block';
		document.getElementById("spring_bg6").style.display='none';
		document.getElementById("spring_bg7").style.display='none';
		document.getElementById("spring_bg8").style.display='none';
	}
	else if(number=="six")	
	{
		document.getElementById("spring_bg1").style.display='none';
		document.getElementById("spring_bg2").style.display='none';
		document.getElementById("spring_bg3").style.display='none';
		document.getElementById("spring_bg4").style.display='none';
		document.getElementById("spring_bg5").style.display='none';
		document.getElementById("spring_bg6").style.display='block';
		document.getElementById("spring_bg7").style.display='none';
		document.getElementById("spring_bg8").style.display='none';
	}
	else if(number=="seven")	
	{
		document.getElementById("spring_bg1").style.display='none';
		document.getElementById("spring_bg2").style.display='none';
		document.getElementById("spring_bg3").style.display='none';
		document.getElementById("spring_bg4").style.display='none';
		document.getElementById("spring_bg5").style.display='none';
		document.getElementById("spring_bg6").style.display='none';
		document.getElementById("spring_bg7").style.display='block';
		document.getElementById("spring_bg8").style.display='none';
	}
	else if(number=="eight")	
	{
		document.getElementById("spring_bg1").style.display='none';
		document.getElementById("spring_bg2").style.display='none';
		document.getElementById("spring_bg3").style.display='none';
		document.getElementById("spring_bg4").style.display='none';
		document.getElementById("spring_bg5").style.display='none';
		document.getElementById("spring_bg6").style.display='none';
		document.getElementById("spring_bg7").style.display='none';
		document.getElementById("spring_bg8").style.display='block';
	}
	else
	{
		document.getElementById("spring_bg1").style.display='block';
		document.getElementById("spring_bg2").style.display='none';
		document.getElementById("spring_bg3").style.display='none';
		document.getElementById("spring_bg4").style.display='none';
		document.getElementById("spring_bg5").style.display='none';
		document.getElementById("spring_bg6").style.display='none';
		document.getElementById("spring_bg7").style.display='none';
		document.getElementById("spring_bg8").style.display='none';
	}
}

function change_spa(number)
{
	if(number=="two")	
	{
		document.getElementById("spa_bg1").style.display='none';
		document.getElementById("spa_bg2").style.display='block';
		document.getElementById("spa_bg3").style.display='none';
		document.getElementById("spa_bg4").style.display='none';
	}
	else if(number=="three")	
	{
		document.getElementById("spa_bg1").style.display='none';
		document.getElementById("spa_bg2").style.display='none';
		document.getElementById("spa_bg3").style.display='block';
		document.getElementById("spa_bg4").style.display='none';
	}
	else if(number=="four")	
	{
		document.getElementById("spa_bg1").style.display='none';
		document.getElementById("spa_bg2").style.display='none';
		document.getElementById("spa_bg3").style.display='none';
		document.getElementById("spa_bg4").style.display='block';
	}
	else
	{
		document.getElementById("spa_bg1").style.display='block';
		document.getElementById("spa_bg2").style.display='none';
		document.getElementById("spa_bg3").style.display='none';
		document.getElementById("spa_bg4").style.display='none';	
	}
}

function change_elite(number)
{
	if(number=="two")	
	{
		document.getElementById("elite_bg1").style.display='none';
		document.getElementById("elite_bg2").style.display='block';
		document.getElementById("elite_bg3").style.display='none';
		document.getElementById("elite_bg4").style.display='none';
	}
	else if(number=="three")	
	{
		document.getElementById("elite_bg1").style.display='none';
		document.getElementById("elite_bg2").style.display='none';
		document.getElementById("elite_bg3").style.display='block';
		document.getElementById("elite_bg4").style.display='none';
	}
	else if(number=="four")	
	{
		document.getElementById("elite_bg1").style.display='none';
		document.getElementById("elite_bg2").style.display='none';
		document.getElementById("elite_bg3").style.display='none';
		document.getElementById("elite_bg4").style.display='block';
	}
	else
	{
		document.getElementById("elite_bg1").style.display='block';
		document.getElementById("elite_bg2").style.display='none';
		document.getElementById("elite_bg3").style.display='none';
		document.getElementById("elite_bg4").style.display='none';	
	}
}