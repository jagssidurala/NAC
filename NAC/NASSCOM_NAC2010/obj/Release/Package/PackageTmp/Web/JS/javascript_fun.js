$(document).ready(function(){
  
  // Gestion du tableau avec les onglets
  
 
  
   $(function() {
	
		
		$('#slideshow').cycle({
			speed:       500,
			timeout:     5000,
			startingSlide: 0,
			pager:      '#nav',
			pagerEvent: 'mouseover',
			allowPagerClickBubble: true,
			pauseOnPagerHover: true,		
			pagerAnchorBuilder: function(idx, slide) {
					   // return sel string for existing anchor
			
				return '#nav td.bloc:eq(' + (idx) + ')';
			},
			updateActivePagerLink: function(pager, activeIndex) 
			{ 
				 $(pager).find('td.bloc').removeClass('bloc_spe');
				 $(pager).find('td.bloc:eq('+activeIndex+')').addClass('bloc_spe').siblings().removeClass('bloc_spe'); 
			}
		});
		
	});
    
   
   	
	$("ul.websites li a").hover(function()  //When trigger is clicked...
	{
		//Following events are applied to the subnav itself (moving subnav up and down)
		$(this).parent().find("ul.websites_subnav").slideDown('normal').show(); //Drop down the subnav on click
		

		$(this).parent().hover(function() {
		}, function(){
			$(this).parent().find("ul.websites_subnav").slideUp('normal'); //When the mouse hovers out of the subnav, move it back up
		});

		//Following events are applied to the trigger (Hover events for the trigger)
		}).hover(function() {
			$(this).addClass("subhover"); //On hover over, add class "subhover"
		}, function(){	//On Hover Out
			$(this).removeClass("subhover"); //On hover out, remove class "subhover"
	});
		
		
		
			
			
			
			
	// A EFFACER EN DESSOUS !!



	 $('.parent').hover(	
		
        function ()
		{
            //show its submenu
//            $('div.menu', this).slideDown();
            $('div.menu', this).stop(true, true).slideDown(); // Mathieu
			
			$(this).find("a.parent_link").css("color","#DF1E19");
 
        },
        function () {
            //hide its submenu
    //        $('div.menu', this).slideUp();
	        $('div.menu', this).stop(true, true).slideUp();                // Mathieu
			if($(this).attr("id")!="selected")
			$(this).find("a.parent_link").css("color","#79777C");			
        }
    );
	
	 $('.sous_parent').hover(
	
		
        function ()
		{
			$(this).css("background","url('resources/images/fleche_menu_opened.gif')  75% 0% no-repeat");
            //show its submenu
			
//			 $('div.sous_menu', this).slideDown();        
			 
             $('div.sous_menu', this).stop(true, true).slideDown();        // Mathieu

			//$(this).find(".sous_menu").animate({"margin-left": "+=190px"}, "normal");

			
 
        },
		
        function () {
			
            //hide its submenu
//            $('div.sous_menu', this).slideUp();  

            $('div.sous_menu', this).stop(true, true).slideUp();        // Mathieu
			     
			//$(this).find(".sous_menu").animate({"margin-left": "-=190px"}, "normal");		  
			$(this).css("background","url('resources/images/fleche_menu.gif')  75% 0% no-repeat");			
			
        }
    );
			
			
	///////// JUSQUE LA			
			
																				
   
});

