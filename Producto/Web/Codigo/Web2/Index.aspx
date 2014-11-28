<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUsuario.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/index.css" rel="stylesheet" />
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="intro">
        <div class="intro-body">
            <div class="container">
                <div class="row">
                    <h1 class="brand-heading" style="text-shadow: 4px 4px 13px rgb(30, 28, 28);"><span style="color: red;">Geo</span>Parking</h1>
                    <p style="text-shadow: 4px 4px 13px rgba(30, 28, 28 ,1);" class="intro-text">Estacioná de manera fácil, rápida y efectiva.</p>
                    <div class="input-group col-lg-4 col-lg-offset-4">
                        <asp:TextBox ID="txtBuscar" CssClass="form-control input-lg autosuggest" runat="server"
                            ClientIDMode="Static" placeholder="Ingresá tu ciudad" autofocus></asp:TextBox>
                        <div class="input-group-btn">
                            <asp:Button ID="btnBuscar" CssClass="btn-primary btn btn-lg" runat="server" Text="Buscar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="caracteristicas">
        <div class="row-fluid">
            <div id="tituloCaracteristicas" class="span12">
                <h1>__________<span>Caracteristicas</span>__________</h1>
            </div>
            <div class="span11">
                <div id="caractIzq" class="span4">
                    <div class="span12">
                        <div class="span12">
                            <span class="glyphicons-icon tags"></span><b>FACILIDAD DE USO</b>
                        </div>
                        <div class="span12">
                            <p class="descripcionCaracteristica">
                                Aqui la descripcion de la caracteristica, que no debe ser extensa.
                            </p>
                        </div>
                    </div>
                    <div class="span12">
                        <div class="span12">
                            <span class="glyphicons-icon tags"></span><b>FACILIDAD DE USO</b>
                        </div>
                        <div class="span12">
                            <p class="descripcionCaracteristica">
                                Aqui la descripcion de la caracteristica, que no debe ser extensa.
                            </p>
                        </div>
                    </div>
                    <div class="span12">
                        <div class="span12">
                            <span class="glyphicons-icon tags"></span><b>FACILIDAD DE USO</b>
                        </div>
                        <div class="span12">
                            <p class="descripcionCaracteristica">
                                Aqui la descripcion de la caracteristica, que no debe ser extensa.
                            </p>
                        </div>
                    </div>
                </div>
                <div id="caractCen" class="span4">
                    <img src="img/index/divice.png" />

                </div>
                <div id="caractDer" class="span4">
                    <div class="span12">
                        <div class="span12">
                            <span class="glyphicons-icon tags"></span><b>FACILIDAD DE USO</b>
                        </div>
                        <div class="span12">
                            <p class="descripcionCaracteristica">
                                Aqui la descripcion de la caracteristica, que no debe ser extensa.
                            </p>
                        </div>
                    </div>
                    <div class="span12">
                        <div class="span12">
                            <span class="glyphicons-icon tags"></span><b>FACILIDAD DE USO</b>
                        </div>
                        <div class="span12">
                            <p class="descripcionCaracteristica">
                                Aqui la descripcion de la caracteristica, que no debe ser extensa.
                            </p>
                        </div>
                    </div>
                    <div class="span12">
                        <div class="span12">
                            <span class="glyphicons-icon tags"></span><b>FACILIDAD DE USO</b>
                        </div>
                        <div class="span12">
                            <p class="descripcionCaracteristica">
                                Aqui la descripcion de la caracteristica, que no debe ser extensa.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr></hr>
    <div class="galeria">
        <div class="row-fluid">
            <div id="tituloGaleria" class="span12">
                <h1>__________<span>Galeria</span>__________</h1>
            </div>
            <div class="span11">
                <div class="span4 fotoGaleria">
                    <img src="img/index/screen.png" />
                </div>
                <div class="span4 fotoGaleria">
                    <img src="img/index/screen.png" />
                </div>
                <div class="span4 fotoGaleria">
                    <img src="img/index/screen.png" />
                </div>
            </div>
        </div>
    </div>
    <div class="video"></div>
    <div class="equipo"></div>
    <div class="contacto"></div>
    <div class="footer"></div>

</asp:Content>

