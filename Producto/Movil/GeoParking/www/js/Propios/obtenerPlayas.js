function obtenerPlayasDeCiudad(ciudad){
    if(ciudad === "Córdoba" || ciudad === "Capital"){
        return playasDeCordoba;
    }
    if(ciudad === "Río Cuarto"){
        return playasDeRioCuarto;
    }
    else{
        return playasDeCordoba;
    }
}
var playasDeCordoba = [
    {
        "Id": 25, 
        "Nombre": "24 hs",
        "Mail": "24hs@gmail.com",
        "Telefono": "4225555",
        "TipoPlaya": "Techada",
        "Latitud":"-31.414432",
        "Longitud": "-64.193366",
        "Direcciones": [ {
            "Calle": "27 de Abril",
            "Numero": 650 
        } ],
        "Servicios": [ {
            "TipoVehiculo": "Auto",
            "Capacidad": 40 
        } ],
        "Horarios": [ {
            "Dia": "Lunes-Viernes",
            "HoraDesde": "09:00",
            "HoraHasta": "22:30" 
        }],
        "Precios": [ { 
            "TipoVehiculo": "Auto",
            "Dia": "Lunes-Viernes",
            "Tiempo": "", 
            "Monto": 22.0000 } 
                   ]
    },
    { "Id": 26, "Nombre": "Playa Dean Funes", "Mail": "deanfunes-playa@gmail.com", "Telefono": "4235489", "TipoPlaya": "Techada", "Latitud": "-31.412051", "Longitud": "-64.197003", "Direcciones": [ { "Calle": "Dean Funes", "Numero": 942 } ], "Servicios": [ { "TipoVehiculo": "Auto", "Capacidad": 60 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "07:00", "HoraHasta": "20:30" } ], "Precios": [ { "TipoVehiculo": "Auto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 18.0000 } ] },{ "Id": 27, "Nombre": "Playa Duarte Quirós I", "Mail": "duartequiros-playa@gmail.com", "Telefono": "155220032", "TipoPlaya": "Subterranea", "Latitud": "-31.415192", "Longitud": "-64.199502", "Direcciones": [ { "Calle": "Av Duarte Quirós", "Numero": 1022 } ], "Servicios": [ { "TipoVehiculo": "Moto", "Capacidad": 25 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "09:00", "HoraHasta": "21:30" } ], "Precios": [ { "TipoVehiculo": "Moto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 9.0000 } ] },{ "Id": 28, "Nombre": "Estacionamiento Caseros", "Mail": "estacionamiento-caseros@hotmail.com", "Telefono": "4243300", "TipoPlaya": "Techada", "Latitud": "-31.416126", "Longitud": "-64.192421", "Direcciones": [ { "Calle": "Caseros", "Numero": 502 } ], "Servicios": [ { "TipoVehiculo": "Bicicleta", "Capacidad": 25 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "09:00", "HoraHasta": "21:30" } ], "Precios": [ { "TipoVehiculo": "Bicicleta", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 9.0000 } ] },{ "Id": 29, "Nombre": "Buenos Aires Park", "Mail": "bsaspark@hotmail.com", "Telefono": "4662288", "TipoPlaya": "Techada", "Latitud": "-31.419376", "Longitud": "-64.184192", "Direcciones": [ { "Calle": "Buenos Aires", "Numero": 220 } ], "Servicios": [ { "TipoVehiculo": "Bicicleta", "Capacidad": 30 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "08:00", "HoraHasta": "23:30" } ], "Precios": [ { "TipoVehiculo": "Bicicleta", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 12.0000 } ] },{ "Id": 30, "Nombre": "Playas Velez", "Mail": "velezparking@hotmail.com", "Telefono": "155220033", "TipoPlaya": "Techada", "Latitud": "-31.423907", "Longitud": "-64.190613", "Direcciones": [ { "Calle": "Av Vélez Sarsfield", "Numero": 699 } ], "Servicios": [ { "TipoVehiculo": "Auto", "Capacidad": 30 }, { "TipoVehiculo": "Bicicleta", "Capacidad": 10 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "08:00", "HoraHasta": "23:30" } ], "Precios": [ { "TipoVehiculo": "Auto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 23.0000 }, { "TipoVehiculo": "Bicicleta", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 12.0000 } ] },{ "Id": 31, "Nombre": "Playas Illia", "Mail": "playaillia@hotmail.com", "Telefono": "4231212", "TipoPlaya": "Techada", "Latitud": "-31.419196", "Longitud": "-64.192354", "Direcciones": [ { "Calle": "Bv. San Juan", "Numero": 400 } ], "Servicios": [ { "TipoVehiculo": "Auto", "Capacidad": 30 }, { "TipoVehiculo": "Moto", "Capacidad": 20 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "08:00", "HoraHasta": "23:30" } ], "Precios": [ { "TipoVehiculo": "Auto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 23.0000 }, { "TipoVehiculo": "Moto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 30.0000 } ] },{ "Id": 32, "Nombre": "Playas Illia", "Mail": "playasillia@hotmail.com", "Telefono": "4200333", "TipoPlaya": "Techada", "Latitud": "-31.421503", "Longitud": "-64.182949", "Direcciones": [ { "Calle": "Bv. Arturo Illia", "Numero": 202 } ], "Servicios": [ { "TipoVehiculo": "Auto", "Capacidad": 22 }, { "TipoVehiculo": "Moto", "Capacidad": 12 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "08:00", "HoraHasta": "23:30" } ], "Precios": [ { "TipoVehiculo": "Auto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 26.0000 }, { "TipoVehiculo": "Moto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 40.0000 } ] },{ "Id": 33, "Nombre": "Aparcamiento Sarmiento", "Mail": "playa-sarmiento@gmail.com", "Telefono": "4779922", "TipoPlaya": "Techada", "Latitud": "-31.410652", "Longitud": "-64.179460", "Direcciones": [ { "Calle": "Sarmiento", "Numero": 100 } ], "Servicios": [ { "TipoVehiculo": "Auto", "Capacidad": 30 }, { "TipoVehiculo": "Bicicleta", "Capacidad": 40 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "08:00", "HoraHasta": "23:30" } ], "Precios": [ { "TipoVehiculo": "Auto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 16.0000 }, { "TipoVehiculo": "Bicicleta", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 10.0000 } ] },{ "Id": 34, "Nombre": "Estrada Parking", "Mail": "playa-estrada@gmail.com", "Telefono": "4334400", "TipoPlaya": "Techada", "Latitud": "-31.427371", "Longitud": "-64.188308", "Direcciones": [ { "Calle": "José Manuel Estrada", "Numero": 100 } ], "Servicios": [ { "TipoVehiculo": "Auto", "Capacidad": 30 }, { "TipoVehiculo": "Bicicleta", "Capacidad": 40 }, { "TipoVehiculo": "Moto", "Capacidad": 30 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "08:00", "HoraHasta": "23:30" } ], "Precios": [ { "TipoVehiculo": "Auto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 20.0000 }, { "TipoVehiculo": "Bicicleta", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 10.0000 }, { "TipoVehiculo": "Moto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 15.0000 } ] }];

var playasDeRioCuarto = [{ "Id": 36, "Nombre": "Rio IV Parking", "Mail": "playa-rioiv@gmail.com", "Telefono": "4554302", "TipoPlaya": "Techada", "Latitud": "-33.123056", "Longitud": "-64.353331", "Direcciones": [ { "Calle": "Mendoza", "Numero": 699 } ], "Servicios": [ { "TipoVehiculo": "Auto", "Capacidad": 30 }, { "TipoVehiculo": "Bicicleta", "Capacidad": 40 }, { "TipoVehiculo": "Moto", "Capacidad": 30 } ], "Horarios": [ { "Dia": "Lunes-Viernes", "HoraDesde": "08:00", "HoraHasta": "23:30" } ], "Precios": [ { "TipoVehiculo": "Auto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 20.0000 }, { "TipoVehiculo": "Bicicleta", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 10.0000 }, { "TipoVehiculo": "Moto", "Dia": "Lunes-Viernes", "Tiempo": "", "Monto": 15.0000 } ] }];

