
var ubicacionAuto;
var cantClick=0;
function guardarUbicacion(){
    
     intel.xdk.notification.confirm("Desea guardar la posición de su vehículo?", 'guardarVehiculo', "Recordar posición vehículo", "Si", "No");
        
        //Process the event for the confirmed message
        function receiveConfirm(e)
                {
                        if( e.id == 'guardarVehiculo' )
                        {
                                if( e.success == true && e.answer == true ) 
                                {
                                    
                                    ubicacionAuto = playaElegida;
                                    
                                    intel.xdk.notification.alert("Posición vehículo guardada!","GeoParking - Éxito","Aceptar");  
                                }
                            
                        }
                } 
    ubicacionAuto = playaElegida;
	
	
}
function trazarRegreso(){
     intel.xdk.notification.confirm("Desea visualizar el camino hacia su vehículo?", 'volverAlVehiculo', "Desplazarse hacia posición vehículo", "Si", "No");
        
        //Process the event for the confirmed message
        function receiveConfirm(e)
                {
                        if( e.id == 'volverAlVehiculo' )
                        {
                                if( e.success == true && e.answer == true ) 
                                {
	obtenerPosicionActual();
	ir(posicionActual,ubicacionAuto,"WALKING","METRIC");
                                }
                        }
                }
    obtenerPosicionActual();
	ir(posicionActual,ubicacionAuto,"WALKING","METRIC");
}
function mostrarIndicaciones(){
    if(cantClick%2==0){
        $('.fullscreen').css('height','70%');
        $('#panel_ruta').removeClass('hidden');    
        $('#panel_ruta').attr('title','Ocultar navegación');   
    }
    else{
        $('.fullscreen').css('height','100%');
        $('#panel_ruta').addClass('hidden');    
        $('#panel_ruta').attr('title','Mostrar navegación');   
    }
    cantClick++;
    
    
}
// function aCuantoEstoy(){
//
//
//    
//        var latlngA = new google.maps.LatLng("-31.400733", "-64.197416");
//        var latlngB = new google.maps.LatLng("-31.396777", "-64.170122");
//            
//            
//    var calculo = google.maps.geometry.spherical.computeDistanceBetween(latlngA, latlngB);
//        alert((calculo/1000).toFix(2) + " metros"
//            );    
//    }