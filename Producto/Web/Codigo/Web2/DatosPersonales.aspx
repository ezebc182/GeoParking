<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="Web2.DatosPersonales" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/bootstrap-fileupload.min.css" type="text/css" />
    <%--    <script src="js/bootstrapValidator.min.js"></script>
    <script src="js/administracionUsuarios.js"></script>
    <script src="js/entidades.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Usuario
                <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                - Datos personales</h3>
        </div>
        <div class="panel-body">
            <div class="row-fluid">
                <div class="box black">
                    <div class="box-content">
                        <div class="alert alert-danger hidden" id="divAlertError" runat="server">
                            <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-12 formulario" data-bv-message="This value is not valid"
                            data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
                            data-bv-feedbackicons-invalid="glyphicon glyphicon-remove"
                            data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="txtEmailRegistro" class="control-label">E-mail:</label>
                                        <asp:TextBox ID="txtEmailRegistro" data-bv-notempty="true" data-bv-notempty-message="El email es requerido"
                                            data-bv-emailaddress-message="Ingrese un formato de email correcto." placeholder="Email"
                                            CssClass="form-control input-lg" runat="server" type="email"
                                            TabIndex="13">
                                        </asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtNombre" class="control-label">Nombre:</label>
                                        <asp:TextBox ID="txtNombre" placeholder="Nombre" CssClass="form-control input-lg"
                                            runat="server" TabIndex="10" data-bv-notempty="true"
                                            data-bv-notempty-message="El nombre es requerido"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtApellido" class="control-label">Apellido:</label>
                                        <asp:TextBox ID="txtApellido" placeholder="Apellido" CssClass="form-control input-lg"
                                            runat="server" TabIndex="11" data-bv-notempty="true"
                                            data-bv-notempty-message="El apellido es requerido"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="chSexo" class="control-label">Sexo:</label>
                                        <asp:RadioButtonList ID="chSexo" runat="server">
                                            <asp:ListItem Value="Mujer"></asp:ListItem>
                                            <asp:ListItem Value="Hombre"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtfechaNacimiento" class="control-label">Fecha de Nacimiento:</label>
                                        <asp:TextBox ID="txtfechaNacimiento" placeholder="dd/mm/yyyy" TextMode="Date" CssClass="form-control input-lg"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtDireccion" class="control-label">Direccion:</label>
                                        <asp:TextBox ID="txtDireccion" placeholder="Direccion" CssClass="form-control input-lg"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group" style="text-align: center">
                                        <label for="txtApellido" class="control-label">Foto de Perfil:</label>
                                        <div class="fileupload fileupload-new" data-provides="fileupload">
                                            <div class="fileupload-new thumbnail" style="width: 180px; height: 180px;">
                                                <img src="./img/fotosPerfil/demoUpload.jpg" alt="">
                                            </div>
                                            <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 180px; max-height: 180px; line-height: 20px;"></div>
                                            <div>
                                                <span class="btn btn-file btn-primary"><span class="fileupload-new">Select image</span><span class="fileupload-exists">Change</span><input type="file"></span>
                                                <a href="#" class="btn btn-danger fileupload-exists" data-dismiss="fileupload">Remove</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4">
                                    <div id="pass1" class="form-group">
                                        <asp:TextBox ID="txtContraseñaDatos" placeholder="Contraseña" CssClass="form-control input-lg"
                                            runat="server" TextMode="Password" TabIndex="14" data-bv-notempty="true" name="contraseña1"
                                            data-bv-notempty-message="La contraseña es requerida"
                                            data-bv-identical="true"
                                            data-bv-identical-field="ctl00$txtContraseñaDatosRepetir"
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
                                <div class="col-lg-4">
                                    <div id="pass2" class="form-group">
                                        <asp:TextBox ID="txtContraseñaDatosRepetir" name="contraseña2" placeholder="Repetir Contraseña"
                                            CssClass="form-control input-lg"
                                            runat="server" TextMode="Password" TabIndex="15"
                                            data-bv-notempty="true"
                                            data-bv-notempty-message="Confirme la contraseña"
                                            data-bv-identical="true"
                                            data-bv-identical-field="ctl00$txtContraseñaDatos"
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
                            <asp:Panel ID="panelBotones" class="col-md-12" runat="server">
                                <div id="divBotones" class="form-group col-md-4 col-md-offset-4">
                                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success btn-md pull-left" Text="Guardar" />
                                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-md pull-right" Text="Cancelar"
                                        AutoPostBack="True" />
                                </div>

                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        //$(document).ready(new function () {
        //});

    </script>
</asp:Content>
