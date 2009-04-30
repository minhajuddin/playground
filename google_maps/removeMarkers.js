//Function to remove markers hour wise
//loop through all the markers
// remove a marker if the marker's hour lies between min and max



var removeMarkers = function(min, max){
	for( var i = 0; i < points.length; i++ ){
		if(isInRange( min, max, points[i].hour )){
			map.removeOverlay( points[i].marker );
		}
	}
}

var isInRange = function( min, max, i ){
	if(i < min && i > max ){
		return true;
	} else {
		return false;
	}
}


isInRange : function( i, min, max ){
	if(i < min && i > max ){
		return true;
	} else {
		return false;
	}
},
                removeMarkers: function(min, max) {
                    console.log('removing markers %s => %s', min, max);
                    for( var i = 0; i < points.length; i++ ){
		if(isInRange( min, max, points[i].hour )){
			AVL.map.removeOverlay(this.AVL.points[i].marker);
		}
	}
                    
                    for (var i = min; i < max; i++) {
                        AVL.map.removeOverlay(this.AVL.points[i].marker);
                        console.log("marker removed %s ", i);
                    }
                    console.log('removed markers %s => %s', min, max);
                },