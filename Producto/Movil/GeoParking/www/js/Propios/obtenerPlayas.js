function obtenerPlayasDeCiudad(ciudad){
    if(ciudad === "Capital") ciudad = "cordoba";
    //var uri = 'http://ifrigerio-001-site1.smarterasp.net/api/playas/getPlayas?ciudad=' + ciudad;
    //var uri = 'http://localhost:5027/api/playas/getPlayas?ciudad=' + ciudad;
    var uri = 'http://localhost:33357/api/playas/getPlayas?ciudad=' + ciudad;
    $.ajax({
			type: "GET",
			url: uri,
			success : function(data){
				playas = (typeof data) == 'string' ?
							   eval('(' + data + ')') :
							   data;
                agregarPlayasAMapa(playas);
                showMarkers();
                
			},
			error: function(jqXHR, textStatus, errorThrown ){
				alert("Error de conexión con el servidor, por favor inténtelo nuevamente más tarde.");
			}
		});
}