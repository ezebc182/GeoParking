<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="Web2.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="alert alert-danger hidden" id="divAlertError" runat="server">
        <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
    </div>
    <div class="formulario" data-bv-message="This value is not valid"
        data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
        data-bv-feedbackicons-invalid="glyphicon glyphicon-remove"
        data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
        <div class="row">
            <div class="col-xs-6 col-sm-6 col-md-6">
                <div class="form-group">
                    <asp:TextBox ID="txtNombre" placeholder="Nombre" CssClass="form-control input-lg"
                        runat="server" TabIndex="10" data-bv-notempty="true"
                        data-bv-notempty-message="El nombre es requerido"></asp:TextBox>
                </div>
            </div>
            <div class="col-xs-6 col-sm-6 col-md-6">
                <div class="form-group">
                    <asp:TextBox ID="txtApellido" placeholder="Apellido" CssClass="form-control input-lg"
                        runat="server" TabIndex="11" data-bv-notempty="true"
                        data-bv-notempty-message="El apellido es requerido"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="divUsuarioRegistro" class="form-group">
            <asp:TextBox ID="txtUsuarioRegistro" placeholder="Usuario" CssClass="form-control input-lg"
                runat="server" TabIndex="12"
                data-bv-message="El usuario no es válido" name="username"
                data-bv-notempty="true"
                data-bv-notempty-message="El nombre de usuario es requerido"
                data-bv-regexp="true"
                data-bv-regexp-regexp="^[a-zA-Z0-9_\.]+$"
                data-bv-regexp-message="El nombre de usuario puede estar compuesto por letras, número"
                data-bv-stringlength="true"
                data-bv-stringlength-min="6"
                data-bv-stringlength-max="30"
                data-bv-stringlength-message="El nombre de usuario debe contener al menos 6 caracteres y hasta un máximo de 30"
                data-bv-different="true"
                data-bv-different-field="ctl00$txtContraseñaRepetir"
                data-bv-different-message="El usuario y la contraseña no pueden ser iguales">

            </asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtEmailRegistro" data-bv-notempty="true" data-bv-notempty-message="El email es requerido"
                data-bv-emailaddress-message="Ingrese un formato de email correcto." placeholder="Email"
                CssClass="form-control input-lg" runat="server" type="email"
                TabIndex="13">
            </asp:TextBox>
        </div>
        <div class="row">
            <div class="col-xs-6 col-sm-6 col-md-6">
                <div id="pass1" class="form-group">
                    <asp:TextBox ID="txtContraseña" placeholder="Contraseña" CssClass="form-control input-lg"
                        runat="server" TextMode="Password" TabIndex="14" data-bv-notempty="true" name="contraseña1"
                        data-bv-notempty-message="La contraseña es requerida"
                        data-bv-identical="true"
                        data-bv-identical-field="ctl00$txtContraseñaRepetir"
                        data-bv-identical-message="Las contraseñas no son iguales"
                        data-bv-different="true"
                        data-bv-different-field="ctl00$txtUsuarioRegistro"
                        data-bv-different-message="La contraseña no puede ser igual que el nombre de usuario"
                        data-bv-stringlength="true"
                        data-bv-stringlength-min="6"
                        data-bv-stringlength-max="30"
                        data-bv-stringlength-message="El nombre de usuario debe contener al menos 6 caracteres y hasta un máximo de 30">

                    </asp:TextBox>
                </div>
            </div>
            <div class="col-xs-6 col-sm-6 col-md-6">
                <div id="pass2" class="form-group">
                    <asp:TextBox ID="txtContraseñaRepetir" name="contraseña2" placeholder="Repetir Contraseña"
                        CssClass="form-control input-lg"
                        runat="server" TextMode="Password" TabIndex="15"
                        data-bv-notempty="true"
                        data-bv-notempty-message="Confirme la contraseña"
                        data-bv-identical="true"
                        data-bv-identical-field="ctl00$txtContraseña"
                        data-bv-stringlength="true"
                        data-bv-stringlength-min="6"
                        data-bv-stringlength-max="30"
                        data-bv-stringlength-message="El nombre de usuario debe contener al menos 6 caracteres y hasta un máximo de 30"
                        data-bv-identical-message="Las contraseñas no son iguales"
                        data-bv-different="true"
                        data-bv-different-field="ctl00$txtUsuarioRegistro"
                        data-bv-different-message="La contraseña no puede ser igual que el nombre de usuario"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
