<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="Web2.DatosPersonales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <script src="js/bootstrapValidator.min.js"></script>
    <script src="js/administracionUsuarios.js"></script>
    <script src="js/entidades.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Datos personales</h3>
        </div>
        <div class="panel-body">
            <div class="row-fluid">
                <div class="box black">
                    <div class="box-header">
                        <h2><i class=" "></i><span class="break"></span>Usuario
                            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                            - Datos Personales</h2>
                    </div>
                    <div class="box-content">
                        <div class="alert alert-danger hidden" id="divAlertError" runat="server">
                            <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                        </div>
                        <div class="formulario" data-bv-message="This value is not valid"
                            data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
                            data-bv-feedbackicons-invalid="glyphicon glyphicon-remove"
                            data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                            <div class="form-group">
                                <asp:TextBox ID="txtEmailRegistro" data-bv-notempty="true" data-bv-notempty-message="El email es requerido"
                                    data-bv-emailaddress-message="Ingrese un formato de email correcto." placeholder="Email"
                                    CssClass="form-control input-lg" runat="server" type="email"
                                    TabIndex="13" Enabled="false">
                                </asp:TextBox>
                            </div>
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
                            <div class="row">
                                <div class="col-xs-6 col-sm-6 col-md-6">
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
                                <div class="col-xs-6 col-sm-6 col-md-6">
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
