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
//            var res = document.getElementById("r");
//            var pairs;            
//            var i=0;
//            res.innerHTML  = "";
//            for (i=0; i<=db.length-1; i++) {
//            key = db.key(i);             
//            res.innerHTML += "<div>"+ "key: "+ key +" value: "+db.getItem(key)+"</div>";;
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