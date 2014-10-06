  /* Intel native bridge is available */
        var onDeviceReady=function(){
        //hide splash screen
        intel.xdk.device.hideSplashScreen();
        };
        document.addEventListener("intel.xdk.device.ready",onDeviceReady,false);
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