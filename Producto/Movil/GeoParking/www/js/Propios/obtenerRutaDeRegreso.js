
var ubicacionAuto;
var cantClick=0;



function guardarUbicacion(){
    getlocal();
     intel.xdk.notification.confirm("Desea guardar la posición de su vehículo?", 'guardarVehiculo', "Recordar posición vehículo", "Si", "No");
        
        //Toma la respuesta brindada por el usuario
        function receiveConfirm(e){
                        if( e.id == 'guardarVehiculo' )
                        {
                                if( e.success == true && e.answer == true ) 
                                {
                                    ubicacionAuto = playaElegida; //NO ANDA
                                   // Mensaje de confirmación <NO ANDA>
                                    intel.xdk.notification.alert("Posición del vehículo guardada!","GeoParking - Éxito","Aceptar");  
                                }
                            
                        }
        } 
    //HARDCODEADO
ubicacionAuto = playaElegida;
	
	
}


function trazarRegreso(){
         intel.xdk.notification.confirm("Desea visualizar el camino hacia su vehículo?", 'volverAlVehiculo', "Desplazarse hacia posición vehículo", "Si", "No");

            //Toma la respuesta brindada por el usuario
            function receiveConfirm(e)
                    {
                            if( e.id == 'volverAlVehiculo' )
                            {
                                    if( e.success == true && e.answer == true ) 
                                    {
                                        obtenerPosicionActual();
                                        intel.xdk.notification.alert("Trazando ruta a                    vehículo","GeoParking","Aceptar");  
                                        ir(posicionActual,ubicacionAuto,"WALKING","METRIC");                                                       
                                    }
                            }
                    }
    //HARDCODEADO
        obtenerPosicionActual();
        ir(posicionActual,ubicacionAuto,"WALKING","METRIC");
}
function mostrarIndicaciones(){
    if(cantClick%2==0){
//        $('#modalTrazado').modal();
        
        
        $('.fullscreen').css('height','70%');
        $('#panel_ruta').removeClass('hidden');    
        
    }
    else{
        
        $('.fullscreen').css('height','100%');
        $('#panel_ruta').addClass('hidden');    
        
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