var usuarios = {
    cargar: function (usuario) {
        $('[id*=txtNombre]').val(usuario.Nombre);
        $('[id*=txtApellido]').val(usu.Apellido);
    }
};