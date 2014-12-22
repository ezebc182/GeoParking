var db = getLocalStorage() || alert("Local Storage Not supported in this browser");
    
function getLocalStorage() {
	try {
		if(window.localStorage ) return window.localStorage;            
	}
	catch (e)
	{
		return undefined;
	}
}
function setlocal() {
	
	db.setItem("mi_posicion", posicionActual);
	getlocal();           
}

function ClearAll() {
	
	db.clear();
	getlocal();           
}
function getlocal() {
	var i=0;
	for (i=0; i<=db.length-1; i++) {
		key = db.key(i);             
		alert(db.getItem(key));
	  }
   }        
  
 function getopenDb() { 
	try {
		if (window.openDatabase) {                    
			return window.openDatabase;                    
		} else {
			alert('No HTML5 support');
			return undefined;
		}
	}
	catch (e) {
		alert(e);
		return undefined;
	}            
 }
 
function distanciaEntreDosPuntos(lat1, lon1, lat2, lon2){
	var R = 6371; // km
	var phi1 = toRad(lat1);
	var phi2 = toRad(lat2);
	var deltaPhi = toRad(lat2-lat1);
	var deltaLambda = toRad(lon2-lon1);
	var a = Math.sin(deltaPhi/2) * Math.sin(deltaPhi/2) +
			Math.cos(phi1) * Math.cos(phi2) *
			Math.sin(deltaLambda/2) * Math.sin(deltaLambda/2);
	var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
	var d = R * c;

	return d;
}

function toRad(value){
	return value * Math.PI / 180;
}

function obtenerURLServer(){
	return 'http://ifrigerio-001-site1.smarterasp.net/';
	//return 'http://localhost:33357/';
}