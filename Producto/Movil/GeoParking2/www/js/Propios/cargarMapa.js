//mapa de la pagina
var map;
//array de marcadores
var markers = [];
//contenido del marcador
var contenido = "";
//variable infoWindows que se seteara al marcador 
var infowindow = new google.maps.InfoWindow({
	content: ''
});

var marker;
var usuario;
var enviarDatosBandera = true;
var destino = null;

var directionsDisplay = new google.maps.DirectionsRenderer({
	suppressMarkers: true,
	polylineOptions: {
		strokeColor: "#61B2FE"
	}
});
var directionsService = new google.maps.DirectionsService();

var posicionActual;

var enRecorrido = false;

var actualizadorDePosicion;

var tipoDestino = null;

function mensajeErrorConexion(mensaje) {
	/*Setearlo con un opendialog*/

}



function ir(origen, destino, modoViaje, sistema) {
	$("#mostrarIndicaciones").removeClass("ui-state-disabled");
	directionsDisplay.setMap(null);
	var request = {
		origin: origen,
		destination: destino,
		travelMode: google.maps.DirectionsTravelMode[modoViaje],
		unitSystem: google.maps.DirectionsUnitSystem[sistema],
		provideRouteAlternatives: true
	};
	directionsService.route(request, function (response, status) {
		if (status == google.maps.DirectionsStatus.OK) {
			if (modoViaje === "WALKING") {
				directionsDisplay.polylineOptions.strokeColor = "#B01515";
				tipoDestino = "ubicacion";
			} else {
				directionsDisplay.polylineOptions.strokeColor = "#61B2FE";
				tipoDestino = "playa";
			}

			directionsDisplay.setMap(map);
			directionsDisplay.setPanel($("#panel_ruta").get(0));
			directionsDisplay.setDirections(response);
		} else {
			abrirPopup("Error al Calcular la ruta");
		}
	});
}

function mantenerPosicionActualActualizada() {
	var actualizarPosicion = function () {
		var functionSuccess = function (p) {
			posicionActual = new google.maps.LatLng(p.coords.latitude, p.coords.longitude);
			removeCarMarker();
			addCarMarker(posicionActual);
			if (tipoDestino === "playa") {
				var lat1 = parseFloat(posicionActual.k);
				var lon1 = parseFloat(posicionActual.D);
				var lat2 = parseFloat(destino.k);
				var lon2 = parseFloat(destino.D);
				if (distanciaEntreDosPuntos(lat1, lon1, lat2, lon2) >= 0.02) {
					directionsDisplay.setMap(null);
					ir(posicionActual, destino, "DRIVING", "METRIC");
				} else {
					tipoDestino = null;
					//clearInterval(actualizadorDePosicion);
					directionsDisplay.setMap(null);
				}

			} else if (tipoDestino === "ubicacion") {
				var lat1 = parseFloat(posicionActual.k);
				var lon1 = parseFloat(posicionActual.D);
				var lat2 = parseFloat(destino.k);
				var lon2 = parseFloat(destino.D);
				if (distanciaEntreDosPuntos(lat1, lon1, lat2, lon2) >= 0.02) {
					directionsDisplay.setMap(null);
					ir(posicionActual, destino, "WALKING", "METRIC");
				} else {
					tipoDestino = null;
					//clearInterval(actualizadorDePosicion);
					eliminarMarkadorPosicionAuto();
					directionsDisplay.setMap(null);
				}
			}
		};
		var funcionError = function (error) {

		};
		navigator.geolocation.getCurrentPosition(functionSuccess, funcionError);
	};
	actualizadorDePosicion = setInterval(actualizarPosicion, 3000);
}

function removeCarMarker() {
	for (var i = 0; i < markers.length; i++) {
		var marcadorActual = markers[i];
		if (marcadorActual.icon === './img/marcadorAuto22.png') {
			markers.splice(i, 1);
			marcadorActual.setMap(null);
		}
	}
}

function addCarMarker(location) {
	usuario = new google.maps.Marker({
		position: location,
		map: map,
		icon: './img/marcadorAuto22.png',
	});
	infoWindow = new google.maps.InfoWindow();
	google.maps.event.addListener(usuario, 'ready', function () {
		infoWindow.setContent("Tu posición");
	});
	markers.push(usuario);
}

function addCarMarkerFirstTime(location) {
	usuario = new google.maps.Marker({
		position: location,
		map: map,
		icon: './img/marcadorAuto22.png',
		animation: google.maps.Animation.DROP,


	});
	infoWindow = new google.maps.InfoWindow();
	google.maps.event.addListener(usuario, 'ready', function () {
		infoWindow.setContent("Tu posición");
	});
	markers.push(usuario);
}

function addUserMarker(location) {
	marker = new google.maps.Marker({
		position: location,
		map: map,
		icon: './img/usuario2.png'
	});
	markers.push(marker);
	marker.setMap(map);
	//showMarkers();
}

function ubicarMiPosicion() {
	map.setCenter(usuario.getPosition());
	usuario.setAnimation(google.maps.Animation.BOUNCE);
	setTimeout(function stopBouncing() {
		usuario.setAnimation(null);
	}, 2000);


}

function addMarker(location, playa) {
	var marker = new google.maps.Marker({
		position: location,
		map: map,
		icon: './img/marcadorParking2.png'
	});
	(function (marker, origen, playa) {
		google.maps.event.addListener(marker, 'click', function () {
			destino = marker.getPosition();
			tipoDestino = "playa";
			enviarConsultaAEstadisticas(playa);
			regresoAVehiculo = false;
			ir(posicionActual, destino, "DRIVING", "METRIC");

			/*ACA TIENE QUE IR EL GUARDAR HISTORIAL*/
			guardarPlayaConsultada(playa);
		});
		enRecorrido = true;
		regresoAVehiculo = false;
	})(marker, posicionActual, playa);
	markers.push(marker);
}

function setAllMap(map) {
	for (var i = 0; i < markers.length; i++) {
		markers[i].setMap(map);
	}
}
/*Borrar marcadores */
function clearMarkers() {
	for (var i = 0; i < markers.length; i++) {
		markers[i].setMap(null);
	}
}


function showMarkers() {
	setAllMap(map);
}

function obtenerPosicionActual() {
	var successFunction = function (p) {
		if (p.coords.latitude !== undefined && p.coords.longitude !== undefined) {
			var posicionGoogle = new google.maps.LatLng(p.coords.latitude, p.coords.longitude);
			posicionActual = posicionGoogle;

			map.setCenter(posicionGoogle);
			/* Pregunto sobre el modo si es consultar playa o consultar vehiculo */
			if (modo === '2') {
				addUserMarker(posicionGoogle);
			} else {
				addCarMarkerFirstTime(posicionGoogle);

			}
			var posicionInterna = {
				latitud: p.coords.latitude,
				longitud: p.coords.longitude
			};
			obtenerPlayasPorPosicion(posicionInterna);
			loading($("#map-canvas"), false);
		}
		mantenerPosicionActualActualizada();

	};
	var errorFunction = function () {
		abrirPopup("Error de conexion, Por favor habilite la localizacion para continuar");
	};
	navigator.geolocation.getCurrentPosition(successFunction, errorFunction);
}

function agregarPlayasAMapa(playas) {
	for (var i = 0; i < playas.length; i++) {
		agregarPlayaAMapa(playas[i]);
	}
}


function agregarPlayaAMapa(playa) {
	var posicionDePlaya = new google.maps.LatLng(playa.Latitud, playa.Longitud);
	addMarker(posicionDePlaya, playa);
}

function loading(componente, on) {
	if (on) {
		componente.addClass("loadingOn");
	} else {
		componente.removeClass("loadingOn");
	}
}

function mostrarBotones() {
	$('#grupoDeBotones').removeClass('hidden');
}

function initialize() {
	loading($("#map-canvas"), true);
	//variable para la busqueda con una direccion
	/*geocoder = new google.maps.Geocoder();*/
	//opciones basicas del mapa

	var mapOptions = {
		zoom: 15,
		mapTypeId: google.maps.MapTypeId.ROADMAP,
		zoomControl: true,
		zoomControlOptions: {
			style: google.maps.ZoomControlStyle.DEFAULT,
			position: google.maps.ControlPosition.LEFT_BOTTOM
		},

	};
	//crea el mapa en el div "map-canvas" y le setea las opciones
	map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
	//centro el mapa en la posicion actual del movil.
	setTimeout(function () {
		obtenerPosicionActual();
		mostrarBotones();
	}, 1000);
	google.maps.event.addDomListener(window, 'load', initialize);
}