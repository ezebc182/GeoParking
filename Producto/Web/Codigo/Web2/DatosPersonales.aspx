<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="Web2.DatosPersonales" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/bootstrap-fileupload.min.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Usuario
                <asp:Label ID="lblUsuarioEditar" runat="server"></asp:Label>
                - Datos personales</h3>
        </div>
        <div class="panel-body">
            <div class="row-fluid">
                <div class="box black">
                    <div class="box-content">
                        <div class="alert alert-danger hidden" id="divAlertError" runat="server">
                            <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                        </div>

                        <div class="row col-lg-10">
                            <div class="col-lg-6">
                                <div class="form-group" id="valEmailEditar">
                                    <label for="ctl00$Main$txtEmailEditar" class="control-label">(*) E-mail:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                                        <asp:TextBox ID="txtEmailEditar" placeholder="Email"
                                            CssClass="form-control input-lg" runat="server" type="email"
                                            TabIndex="1"></asp:TextBox>
                                        <i id="icontxtEmailEditar" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtEmailEditar"></i>
                                    </div>
                                    <small id="smalltxtEmailEditar" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtEmailEditar" data-bv-result="INVALID">
                                        <label id="errortxtNombreRol"></label>
                                    </small>
                                </div>
                                <div class="form-group" id="valNombreEditar">
                                    <label for="ctl00$MaintxtNombreEditar" class="control-label">(*) Nombre:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-pencil-square-o"></i></span>
                                        <asp:TextBox ID="txtNombreEditar" placeholder="Nombre" CssClass="form-control input-lg"
                                            runat="server" TabIndex="2"></asp:TextBox>
                                        <i id="icontxtNombreEditar" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$MaintxtNombreEditar"></i>
                                    </div>
                                    <small id="smalltxtNombreEditar" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$MaintxtNombreEditar" data-bv-result="INVALID">
                                        <label id="errortxtNombreEditar"></label>
                                    </small>
                                </div>
                                <div class="form-group" id="valApellidoEditar">
                                    <label for="ctl00$Main$txtApellidoEditar" class="control-label">(*) Apellido:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-pencil-square-o"></i></span>
                                        <asp:TextBox ID="txtApellidoEditar" placeholder="Apellido" CssClass="form-control input-lg"
                                            runat="server" TabIndex="3"></asp:TextBox>
                                    <i id="icontxtApellidoEditar" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtApellidoEditar"></i>
                                    </div>
                                    <small id="smalltxtApellidoEditar" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtApellidoEditar" data-bv-result="INVALID">
                                        <label id="errortxtApellidoEditar"></label>
                                    </small>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class=" form-group" style="margin-bottom: 8px;">
                                    <label for="chSexo" class="control-label">
                                        Sexo:</label>
                                    <asp:RadioButtonList ID="chSexo" runat="server" TabIndex="4">
                                        <asp:ListItem Value="Mujer"></asp:ListItem>
                                        <asp:ListItem Value="Hombre"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label for="txtfechaNacimiento" class="control-label">Fecha de Nacimiento:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                        <asp:TextBox ID="txtfechaNacimiento" placeholder="dd/mm/yyyy" TabIndex="5" TextMode="Date" CssClass="form-control date-picker input-lg"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtDireccion" class="control-label">Direccion:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
                                        <asp:TextBox ID="txtDireccion" TabIndex="6" placeholder="Direccion" CssClass="form-control input-lg"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div id="valContraseñaVieja" class="form-group">
                                    <label for="ctl00$Main$txtContraseñaVieja" class="control-label">Ingrese su antigua Contraseña:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-unlock-alt"></i></span>
                                        <asp:TextBox ID="txtContraseñaVieja" placeholder="Contraseña" CssClass="form-control input-lg"
                                            runat="server" TextMode="Password" TabIndex="7"></asp:TextBox>
                                    <i id="icontxtContraseñaVieja" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtContraseñaVieja"></i>
                                    </div>
                                    <small id="smalltxtContraseñaVieja" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtContraseñaVieja" data-bv-result="INVALID">
                                        <label id="errortxtContraseñaVieja"></label>
                                    </small>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div id="valContraseñaNueva" class="form-group">
                                    <label for="ctl00$Main$txtContraseñaNueva" class="control-label">Contraseña Nueva:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                        <asp:TextBox ID="txtContraseñaNueva" placeholder="Contraseña" CssClass="form-control input-lg"
                                            runat="server" TextMode="Password" TabIndex="8"></asp:TextBox>
                                    <i id="icontxtContraseñaNueva" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtContraseñaNueva"></i>
                                    </div>
                                    <small id="smalltxtContraseñaNueva" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtContraseñaNueva" data-bv-result="INVALID">
                                        <label id="errortxtContraseñaNueva"></label>
                                    </small>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div id="valRepetirContraseñaNueva" class="form-group">
                                    <label for="ctl00$Main$txtRepetirContraseñaNueva" class="control-label">Repetir Contraseña Nueva:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                        <asp:TextBox ID="txtRepetirContraseñaNueva" placeholder="Contraseña" CssClass="form-control input-lg"
                                            runat="server" TextMode="Password" TabIndex="8"></asp:TextBox>
                                        <i id="icontxtRepetirContraseñaNueva" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtRepetirContraseñaNueva"></i>
                                    </div>
                                    <small id="smalltxtRepetirContraseñaNueva" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtRepetirContraseñaNueva" data-bv-result="INVALID">
                                        <label id="errortxtRepetirContraseñaNueva"></label>
                                    </small>
                                </div>
                            </div>
                        </div>
                        <div class="row col-lg-2">
                            <div class="form-group" style="text-align: center">
                                <label class="control-label">Foto de Perfil:</label>
                                <div class="fileupload fileupload-new" data-provides="fileupload">
                                    <div class="fileupload-new thumbnail" style="width: 180px; height: 180px;">
                                        <img src="../img/fotosPerfil/demoUpload.jpg" alt="">
                                    </div>
                                    <div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 180px; max-height: 180px; line-height: 20px;"></div>
                                    <div>
                                        <span class="btn btn-file btn-primary"><span class="fileupload-new">Seleccionar Imagen</span><span class="fileupload-exists">Cambiar</span><input type="file"></span>
                                        <a href="#" class="btn btn-danger fileupload-exists" data-dismiss="fileupload">Borrar</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="panelBotones" class="col-md-12" runat="server" Style="margin-top: 20px;">
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        //$(document).ready(new function () {
        //});

    </script>
</asp:Content>
