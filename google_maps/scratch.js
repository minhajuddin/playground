var removeMarkers = function(min, max){
	  			console.log('removing markers %s => %s',min,max);
	  			for(var i = min; i < max; i++){
	  				map.removeOverlay(markers[i]);
	  				console.log("marker removed %s ", i);
  				}
  				console.log('removed markers %s => %s',min,max);
  			};
  			var addMarkers = function(min, max){
  				console.log('adding markers %s to %s',min,max);
	  			for(var i = min; i < max; i++){
	  				map.addOverlay(markers[i]);
  				}
  			};

			var sliderChangeHandler = function( event, ui ){
			//Slider Value Change function algorithm
				//Check if min/max changed
				// if min !== prevMin
					//handle the min change
						// if min < prevMin
						//	add markers from min => prevMin
						// else
						//	remove markers from prevMin => min
				// else if max !== prevMax
					//handle the max change
						// if max < prevMax
						//	remove markers from max => prevMax
						// else
						//	add markers from prevMax => max
				//set the values of prevMin and prevMax
			
				var min = $(this).slider('values',0);
				var max = $(this).slider('values',1);
				
				if( min !== prevMin ){
					if( min < prevMin ){
						addMarkers( min, prevMin );
						console.log("add markers from %s => %s ", min, prevMin );
					} else {
						removeMarkers( prevMin, min );
						console.log("remove markers from %s => %s ", prevMin, min );
					}
				}
				else if( max !== prevMax ){
					if( max < prevMax ){
						removeMarkers( max, prevMax );
						console.log("remove markers from %s => %s ", max, prevMax );
					} else {
						addMarkers( prevMax, max );
						console.log("add markers from %s => %s ", prevMax, max );
					}
				}
			
				prevMin = min;
				prevMax = max;
			};
	  		var sliderValueChanged=function(event, ui){
				var min = $(this).slider('values',0);
				var max = $(this).slider('values',1);
				console.log("Min %s Max %s Diff %s", min, max, (+max) - (+min));
				
				//clear map and add points in the range
				//map.clearOverlays();
				//for(var i = first; i < second; i++){
				//	map.addOverlay(markers[i]);
				//}
				//if min is greater than previous min remove markers else add
				if(min > prevMin){
					removeMarkers(prevMin,min);
				} else if(min < prevMin){
					addMarkers(min,prevMin);
				}
				prevMin = min;
				//if max less than previous max remove markers else add
				if(max < prevMax){
					removeMarkers(max,prevMax);
				} else if(max > prevMax){
					addMarkers(prevMax,max);
				}
				prevMax = max;
			};