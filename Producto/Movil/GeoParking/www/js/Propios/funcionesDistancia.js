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