//Load all the markers on the map
//Markers need to have a time variable which holds the hour from timestamp
markerManager=(function(markers){
	return {
		prevMin:0,
		prevMax:100,
		slider:null,
		AVL:null,
		/*markers:markers,*/
		removeMarkers : function(min, max){
	  			console.log('removing markers %s => %s',min,max);
	  			for(var i = min; i < max; i++){
	  				map.removeOverlay(this.AVL.markers[i]);
	  				console.log("marker removed %s ", i);
  				}
  				console.log('removed markers %s => %s',min,max);
		},
  		addMarkers : function(min, max){
  				console.log('adding markers %s to %s',min,max);
	  			for(var i = min; i < max; i++){
	  				map.addOverlay(this.AVL.markers[i]);
  				}
		},
		sliderChangeHandler:function( slider, AVL /* Marker holder */ ){
			this.slider = slider;
			this.AVL = AVL;
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
		
			var min = $(slider).slider('values',0);
			var max = $(slider).slider('values',1);
			var prevMin = this.prevMin;
			var prevMax = this.prevMax;
			
			if( min !== prevMin ){
				if( min < prevMin ){
					this.addMarkers( min, prevMin );
					console.log("add markers from %s => %s ", min, prevMin );
				} else {
					this.removeMarkers( prevMin, min );
					console.log("remove markers from %s => %s ", prevMin, min );
				}
			}
			else if( max !== prevMax ){
				if( max < prevMax ){
					this.removeMarkers( max, prevMax );
					console.log("remove markers from %s => %s ", max, prevMax );
				} else {
					this.addMarkers( prevMax, max );
					console.log("add markers from %s => %s ", prevMax, max );
				}
			}
		
			this.prevMin = min;
			this.prevMax = max;
		}
	};
	}());

