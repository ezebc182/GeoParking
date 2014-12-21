   /* Intel native bridge is available */
  var onDeviceReady = function () {
      //hide splash screen
      intel.xdk.device.hideSplashScreen();
  };
  document.addEventListener("intel.xdk.device.ready", onDeviceReady, false);