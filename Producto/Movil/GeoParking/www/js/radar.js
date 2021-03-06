//<script type="text/javascript" src="http://maps.google.com/maps/api/js?libraries=geometry&sensor=false"></script><script src="http://maps.gstatic.com/cat_js/maps-api-v3/api/js/18/6/intl/es_419/%7Bmain,geometry%7D.js" type="text/javascript"></script>


function createGoogleRadar(punto) {
  var opts = {
    lat : punto.latitude,
    lng : punto.longitude
  }
  if( typeof (myGoogleRadar) == 'undefined') {
    if( typeof (map) != 'undefined') {
      myGoogleRadar = new GoogleRadar(map, opts);
    }
  }
};
 
function loadAxis() {
  var opts = {
    circleColor : "#4f85bb",
    radius : "50",
    n : 11
  };
 
  if( typeof (myGoogleRadar) != 'undefined')
    myGoogleRadar.drawAxis(opts);
 
};
 
function unloadAxis() {
  if( typeof (myGoogleRadar) != 'undefined')
    myGoogleRadar.undrawAxis();
};
 
oPictoInit = {};
function addMarker() {
 
  oPictoInit = {
    lat : oPicto.latitude,
    lng : oPicto.longitude,
    iconUrl : "./img/multi-agents.png",
    id : "meeting",
    name : "The Meeting Point",
    content : "Hachiko, the most famous meeting point in Tokyo"
  };
 
  if( typeof (myGoogleRadar) != 'undefined')
    myGoogleRadar.addMarker(oPictoInit);
};
 
function removeMarker() {
  if( typeof (myGoogleRadar) != 'undefined')
    myGoogleRadar.removeMarker(oPictoInit);
};
 
function addRadar() {
  if( typeof (myGoogleRadar) != 'undefined') {
    opts = {
      time : 100,
      zIndex : 5,
    };
    myGoogleRadar.addRadarLine(opts);
  }
};
 
function stopRadar() {
  if( typeof (myGoogleRadar) != 'undefined') {
    myGoogleRadar.stopLine();
  }
};
 
function hideRadar() {
  if( typeof (myGoogleRadar) != 'undefined') {
    myGoogleRadar.hideLine();
  }
};
 
function showRadar() {
  if( typeof (myGoogleRadar) != 'undefined') {
    myGoogleRadar.showLine();
  }
};
 
function addRadarPolygon() {
  if( typeof (myGoogleRadar) != 'undefined') {
    opts = {
      angle : 5,
      time : 50
    };
    myGoogleRadar.addRadarPolygon(opts);
  }
};
 
function stopRadarPolygon() {
  if( typeof (myGoogleRadar) != 'undefined') {
    myGoogleRadar.stopRotatePolygon();
  }
};
 
function hideRadarPolygon() {
  if( typeof (myGoogleRadar) != 'undefined') {
    myGoogleRadar.hidePolygon();
  }
};
function showRadarPolygon() {
  if( typeof (myGoogleRadar) != 'undefined') {
    myGoogleRadar.showPolygon();
  }
};
 
var oPicto0 = {
  lat : 35.662872,
  lng : 139.700448,
  iconUrl : "./img/jack_32.png",
  id : "trump",
  handle : function() {
    Notifier.success("One of the Best Club in Tokyo", "The Trump Room");
    this.setAnimation(google.maps.Animation.BOUNCE);
    thisObject = this;
 
    setTimeout(function() {
      thisObject.setAnimation()
    }, 2000, this);
  }
};
 
var oPicto1 = {
  lat : 35.65920,
  lng : 139.70080,
  iconUrl : "./img/male-user.png",
  id : "male-user",
  handle : function() {
    Notifier.info("Several Floors of Shopping for him", "Shopping for him");
    this.setAnimation(google.maps.Animation.BOUNCE);
    thisObject1 = this;
 
    setTimeout(function() {
      thisObject1.setAnimation()
    }, 2000, this);
  }
};
 
var oPicto2 = {
  lat : 35.66147,
  lng : 139.70045,
  iconUrl : "./img/female-user.png",
  id : "female-user",
  visible : false,
  handle : function() {
    Notifier.info("A lot of shopping for Her", "Shopping for Her");
    this.setVisible(true);
    thisObject4 = this;
    setTimeout(function() {
      thisObject4.setVisible(false);
    }, 2000, this);
  }
};
 
var oPicto3 = {
  lat : 35.66111,
  lng : 139.69786,
  iconUrl : "./img/star.png",
  id : "bar",
  handle : function() {
    Notifier.success("Nice DJs, Good drinks, but a bit expensive", "Nice Bar, Rock 'n roll!");
    this.setAnimation(google.maps.Animation.DROP);
    thisObject3 = this;
    /*setTimeout(function() {
     thisObject3.setAnimation()
     }, 2000, this);*/
  }
};
 
var oPicto4 = {
  lat : 35.660733,
  lng : 139.698608,
  iconUrl : "./img/recycle-full.png",
  id : "stupid",
  handle : function() {
    Notifier.warning("Hey bro, wanna come to my bar and meet my girlz?", "Bar for stupid");
    this.setAnimation(google.maps.Animation.BOUNCE);
    thisObject2 = this;
    setTimeout(function() {
      thisObject2.setAnimation()
    }, 2000, this);
  }
};
 
var oPicto5 = {
  lat : 35.65941,
  lng : 139.70800,
  iconUrl : "./img/lock.png",
  id : "unknown1",
  visible : false,
  handle : function() {
    Notifier.warning("Never Been there!");
    this.setVisible(true);
 
    this.setAnimation(google.maps.Animation.BOUNCE);
    thisObject5 = this;
    setTimeout(function() {
      thisObject5.setAnimation();
      thisObject5.setVisible(false);
    }, 2000, this);
  }
};
 
var oPicto6 = {
  lat : 35.6485,
  lng : 139.7045,
  iconUrl : "./img/line-globe.png",
  id : "unknown2",
  handle : function() {
    Notifier.info("Too far away to be triggered");
    this.setAnimation(google.maps.Animation.BOUNCE);
    thisObject6 = this;
    setTimeout(function() {
      thisObject6.setAnimation();
    }, 2000, this);
  }
};
 
var oPicto7 = {
  lat : 35.6567,
  lng : 139.6954,
  iconUrl : "./img/heart.png",
  id : "love",
  visible : false,
  handle : function() {
    Notifier.info("Love hotel and night clubs over there");
    this.setVisible(true);
 
    this.setAnimation(google.maps.Animation.BOUNCE);
    thisObject7 = this;
    setTimeout(function() {
      thisObject7.setAnimation()
      thisObject7.setVisible(false);
    }, 2000, this);
  }
};
 
var oPicto8 = {
  lat : 35.6564,
  lng : 139.7009,
  iconUrl : "./img/lookup.png",
  id : "unknow3",
  visible : false,
  handle : function() {
    Notifier.info("Never Been there either.");
    this.setVisible(true);
 
    this.setAnimation(google.maps.Animation.BOUNCE);
    thisObject8 = this;
    setTimeout(function() {
      thisObject8.setAnimation()
      thisObject8.setVisible(false);
    }, 2000, this);
  }
};
 
function addSpots() {
  myGoogleRadar.addSetOfMarkersToDetect([oPicto0, oPicto1, oPicto2, oPicto3, oPicto4, oPicto5, oPicto6, oPicto7, oPicto8]);
};
 
function removeSpots() {
  myGoogleRadar.removeSetOfMarkersToDetect([oPicto0, oPicto1, oPicto2, oPicto3, oPicto4, oPicto5, oPicto6, oPicto7, oPicto8]);
};
 