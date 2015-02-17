function validarEmail(email) {
    var patron = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (email.match(patron)) {
        return true;
    } else {
        return false;
    }
}

function validar(){
	var nombre= $("#txtNombre").val();
	var email= $("#txtEmail").val();
	var mensaje= $("#txtMensaje").val();

	if(nombre == "" || nombre==undefined){
		$("#txtNombre").focus();
		return;
	}
	else{
		if(validarEmail(email)){

			if(mensaje == "" || mensaje==undefined){
				$("#txtMensaje").focus();

			}
			else{
				return true;
			}
		}
		else{
			$("#txtEmail").focus();
			return;
		}
	}
}

function enviarEmail(){


if(validar()){
		
		var data = {
			Nombre:$("#txtNombre").val(),
			Email:$("#txtEmail").val(),
			Mensaje:$("#txtMensaje").val()
		}
			
		$.ajax({
			url:'http://ifrigerio-001-site1.smarterasp.net/api/Contacto/PostEnviarEmailDeContacto',
			data:data,
			type:'post',
			beforeSend:function(){
				
				$("#check").html("");
				$("#loading").html("");
				$("#check").hide();
				$("#loading").show();	
				$("#mensaje").removeClass("hidden");
				$("#formulario").addClass("hidden");				
				$("#textoMensaje").append("<strong>Enviando mensaje ...</strong>");
			
			},
			success: function(){
				$("#check").html("");
				$("#loading").html("");
				$("#check").show();
				$("#loading").hide();
				$("#textoMensaje").html("");
				$("#textoMensaje").append("<strong>Mensaje enviado !</strong>");			
				$("#txtNombre").val('');
				$("#txtEmail").val('');
				$("#txtMensaje").val('');	
				setTimeout(function(){
					$("#mensaje").addClass("hidden");
					$("#formulario").removeClass("hidden");				
				},2500);
					
				

			},
			error: function(){
	
				alert("Mensaje no enviado!");
			}
		});
		
	}
	else{
			alert("Completa los datos!");
		}
}