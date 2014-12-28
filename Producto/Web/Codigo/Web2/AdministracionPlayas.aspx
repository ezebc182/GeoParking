<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeBehind="AdministracionPlayas.aspx.cs" Inherits="Web2.AdministracionPlayas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap3-editable/css/bootstrap-editable.css" rel="stylesheet" />
    <link href="bootstrapformhelpers/css/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <link href="js/GoogleMapsAdministracionPlaya.js" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <%-- Id playa en edicion o viendo --%>
    <asp:HiddenField runat="server" ID="hfIdPlaya" />

    <%-- Modal Playa --%>

    <div class="modal fade" id="modificarPlaya">
        <div class="modal-dialog  modal-lg ">
            <div class=" modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h1 id="Titulo" class="modal-title">Registrar/Modificar playa</h1>
                </div>
                <div class="modal-body">
                    <div class="alert alert-danger hidden" id="divAlertError">
                        <p id="lblMensajeError">Error</p>
                    </div>
                    <div class="alert alert-success hidden" id="divAlertExito">
                        <p id="lblMensajeExito">Exito</p>
                    </div>




                    <div runat="server" id="divTabs">
                        <ul class="nav nav-tabs" id="myTab">
                            <li id="tabDatosGrales" class="active"><a href="#datosGrales" data-toggle="tab">Datos Generales</a></li>
                            <li id="tabDireccion"><a href="#direccion" data-toggle="tab">Direccion</a></li>
                        </ul>


                        <div class="tab-content" style="margin: 20px;">

                            <div class="tab-pane fade active in" id="datosGrales">
                                <div class="clearfix"></div>
                                <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">

                                    <%-- Nombre --%>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                            <div class="col-lg-8 col-md-8 col-sm-8">
                                                <div class="form-group">
                                                    <label for="txtNombre" class="control-label">Nombre:</label>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" data-bv-notempty="true" data-bv-notempty-message="El nombre es requerido." />
                                                </div>
                                            </div>
                                        </div>
                                        <%-- Tipo Playa --%>
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                            <div class="col-lg-8 col-md-8 col-sm-8">
                                                <div class="form-group">
                                                    <label for="ddlTipoPlaya" class="control-label">Tipo de Playa:</label>
                                                    <asp:DropDownList runat="server" ID="ddlTipoPlaya" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione un tipo." />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <%-- Telefono --%>
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                            <div class="col-lg-8 col-md-8 col-sm-8">
                                                <div class="form-group">
                                                    <label for="txtTelefono" class="control-label">Telefono:</label>
                                                    <asp:TextBox runat="server" CssClass="form-control" type="tel" ID="txtTelefono" data-bv-notempty="true" data-bv-notempty-message="El teléfono es requerido" data-bv-regexp="true" data-bv-regexp-regexp="\b\d{3,5}[-.]?\d{3}[-.]?\d*\b" data-bv-regexp-message="Ingrese un número telefónico correcto." />
                                                </div>
                                            </div>
                                        </div>
                                        <%-- Mail --%>
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-right">
                                            <div class="col-lg-8 col-md-8 col-sm-8 ">
                                                <div class="form-group">
                                                    <label for="txtMail" class="control-label">Email:</label>
                                                    <asp:TextBox runat="server" type="email" CssClass="form-control" ID="txtMail" data-bv-notempty="true" data-bv-notempty-message="El email es requerido" data-bv-emailaddress-message="Ingrese un formato de email correcto." />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- Horario --%>
                                    <h4>Horarios</h4>
                                    <div class="well">
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4 pull-left">
                                                <div class="form-group ">
                                                    <label for="ddlDias" class="control-label">Dias:</label>
                                                    <asp:DropDownList runat="server" ID="ddlDias" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione el dia" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group ">
                                                    <label for="bfhDesde" class="control-label">Desde:</label>
                                                    <div id="txtDesde" class="bfh-timepicker" data-time="08:00" style="background-color: white;"></div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4 pull-right">
                                                <div class="form-group ">
                                                    <label for="txtHasta" class="control-label">Hasta:</label>
                                                    <div id="txtHasta" class="bfh-timepicker" data-time="22:00" style="background-color: white;"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- Servicios --%>
                                    <asp:HiddenField ID="hfTiempos" runat="server" />
                                    <h4>Servicios</h4>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                            <div class="col-lg-6 col-md-6 col-sm-6 pull-left">
                                                <div class="form-group ">
                                                    <label for="ddlTipoVehiculo" class="control-label">Tipo Vehiculo:</label>
                                                    <asp:DropDownList runat="server" ID="ddlTipoVehiculo" CssClass="form-control" data-bv-notempty="true" data-bv-notempty-message="Seleccione el dia" />
                                                </div>
                                            </div>

                                            <div class="col-lg-6 col-md-6 col-sm-6 ">
                                                <div class="form-group ">
                                                    <label for="txtCapacidad" class="control-label">Capacidad:</label>
                                                    <div class="controls">
                                                        <div class="input-group">
                                                            <input class="form-control bfh-number" id="txtCapacidad" />
                                                            <div class="input-group-btn">
                                                                <button id="btnAgregarServicio" type="button" class="btn btn-success">Agregar</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <table id="tbServicios" class="table table-hover table-responsive">
                                            <thead id="tbServiciosHead">
                                            </thead>
                                            <tbody id="tbServiciosBody">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <%--<div class="form-group">
                                        <domicilios:domicilios runat="server" id="ucDomicilios" onerrorhandler="MostrarErrorDomicilio"></domicilios:domicilios>
                                        <div class="col-md-2 form-group pull-right">
                                            <button class="btn btn-primary pull-left disabled " id="btnPaso1_1"><span class='glyphicon glyphicon-chevron-left'></span></button>
                                            <button class="btn btn-primary pull-right" id="btnPaso1_2" data-toggle="tab" data-target="#horarios" onclick="javascript:abrirTab(this.id)"><span class='glyphicon glyphicon-chevron-right'></span></button>
                                        </div>

                                    </div>--%>
                            </div>

                            <div class="tab-pane fade" id="direccion">

                                <h4>Direcciones</h4>
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-4 pull-left">
                                        <div class="form-group ">
                                            <label for="txtBuscar" class="control-label">Ciudad:</label>
                                            <input id="txtBuscar" type="text" class="form-control autosuggest" />
                                        </div>
                                    </div>

                                    <div class="col-lg-8 col-md-8 col-sm-8">
                                        <div class="col-lg-5 col-md-5 col-sm-5">
                                            <div class="form-group ">
                                                <label for="txtCalle" class="control-label">Calle:</label>
                                                <input id="txtCalle" class="form-control" type="text" />
                                            </div>
                                        </div>

                                        <div class="col-lg-5 col-md-5 col-sm-5 ">
                                            <div class="form-group ">
                                                <label for="txtNumero" class="control-label">Número:</label>
                                                <div class="controls">
                                                    <div class="input-group">
                                                        <input class="form-control" type="number" id="txtNumero" />

                                                        <div class="input-group-btn">
                                                            <button id="btnBuscarEnMapa" type="button" class="glyphicon glyphicon-map-marker btn btn-warning"
                                                                onclick="codeAddress()">
                                                            </button>
                                                            <button id="btnAgregarDireccion" type="button"
                                                                class="glyphicon glyphicon-plus btn btn-success">
                                                            </button>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                                <div id="divMapa">
                                    <input id="latitud" type="hidden" />
                                    <input id="longitud" type="hidden" />
                                    <div class="form-group">
                                        <div id="pnlMapa">
                                            <div id="map-canvas" style="height: 300px"></div>
                                        </div>

                                    </div>
                                </div>
                                <div>
                                    <table id="tbDirecciones" class="table table-hover table-responsive">
                                        <thead>
                                            <tr>
                                                <th>Calle</th>
                                                <th>Numero</th>
                                                <th>Ciudad</th>
                                                <th style="display: none;">Latitud</th>
                                                <th style="display: none;">Longitud</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbDireccionesBody">
                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button id="btnCancelar" class="btn btn-lg" data-dismiss="modal">Cancelar</button>
                        <button id="btnGuardar" class="btn btn-success btn-lg">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div class="container-fluid">
        <div class="jumbotron" style="margin-top: 5%;">
            <div class="page-header">
                <h1>Administración de playas</h1>
            </div>

            <div class="col-lg-2 col-md-2 col-sm-2">
                <button class="btn-success btn btn-lg glyphicon glyphicon-plus" id="btnNuevaPlaya" type="button"> Nueva Playa</button>
            </div>
        </div>
    </div>


    
</asp:Content>

<asp:Content runat="server" ID="Script" ContentPlaceHolderID="ScriptContent">
    <%--<script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>--%>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&libraries=places&sensor=false"></script>
    <script src="js/autocompleteCiudades.js"></script>
    <script src="bootstrap3-editable/js/bootstrap-editable.min.js"></script>
    <script src="bootstrapformhelpers/js/bootstrap-formhelpers.js"></script>
    <script src="js/GoogleMapsAdministracionPlaya.js"></script>
    <script type="text/javascript">

        //pasar a un archivo aparte "administracionPlayas.js"

        //playa que se esta viendo o editando. Formato JSON
        var playaCargada;

        var playa = {
            iniciar: function () {
                servicios.iniciar();
                direcciones.iniciar();
            },
            guardar: function () {
                var id;
                var nombre = $('[id*=txtNombre]').val();
                var mail = $('[id*=txtMail]').val();
                var telefono = $('[id*=txtTelefono]').val();
                var tipoPlayaId = $('[id*=ddlTipoPlaya]').find(':selected').val();
                var horarioTemp = new horario(0, $('[id*=txtDesde]').val(), $('[id*=txtHasta]').val(), $('[id*=ddlDias]').find(':selected').val());
                var direccionesTemp = direcciones.lista();
                var serviciosTemp = servicios.lista();

                playaTemp = new playaDeEstacionamiento(id, nombre, mail, telefono, tipoPlayaId, horarioTemp, direccionesTemp, serviciosTemp)

                $.ajax({
                    type: "POST",
                    url: "AdministracionPlayas.aspx/GuardarPlaya",
                    data: "{'playaJSON': '" + JSON.stringify(playaTemp) + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var resultado = response.d;
                        if (resultado == "true") {;
                            alert("la playa se registro con exito.")
                        }
                        else {
                            alert("Ocurrio un error");
                        }
                    },
                    error: function (result) {
                        alert('ERROR ' + result.status + ' ' + result.statusText, 'Error');
                    }
                });

            }
        };

        var servicios = {
            cantidad: 0,
            tiempos: $.parseJSON($('[id*=hfTiempos]').val()),

            agregar: function (servicio) {
                var $tableBody = $('[id*=tbServiciosBody]');
                var $tr = $('<tr idServicio="' + servicio.Id + '"> </tr>');

                $tr.append('<td tipoVehiculoId=' + '"' + servicio.TipoVehiculoId + '"' + '>' + $('[id*=ddlTipoVehiculo]').find('[value=' + servicio.TipoVehiculoId + ']').text(), +' </td>');
                $tr.append('<td> <a id="txtEditableCapacidad" data-type="text" data-title="Ingrese capacidad" data-value="' + servicio.Capacidad + '" ></a> </td>');
                $.each(this.tiempos, function (i, tiempo) {
                    var tiempoId = tiempo.Id//$tr.find('th[idTiempo]').eq(i).attr('idTiempo');
                    var precioEncontrado = false;
                    //$.each(servicio.Precios, function (j, precioServicio) {
                    //    if (servicio.id == precioServicio.servicioId && tiempoId == precioServicio.tiempoId) {
                    //        $tr.append('<td> ' + '<a href="#" id="editable-' + servicio.id + '-' + tiempoId + '" data-type="text" data-pk="' + precioServicio.id + '"data-value="' + precioServicio.monto + '" data-url="" data-title="Ingrese el precio"></a>' + '</td>');
                    //        precioEncontrado = true;
                    //        return false;
                    //    }
                    //});
                    if (!precioEncontrado) {
                        $tr.append('<td> <a id="txtEditablePrecio" data-type="text" data-emptytext="Ingrese Precio" data-title="Ingrese precio" data-pk="' + tiempoId + '"</a> </td>');
                    }
                });
                $tr.append('<td>X</td>'); //poner imagen de eliminar!
                $tableBody.append($tr);
                this.cantidad++;
                this.OcultarTipoVehiculoEnCombo(servicio.TipoVehiculoId);
                $('[id*=txtCapacidad]').val('');
                $('[id*=ddlTipoVehiculo] [value=0]').prop("selected", true);

                $('[id*=Editable]').editable({ mode: 'inline' })
            },
            Eliminar: function (servicioId) {
                var $tr = $('[id*=tbServicios][idServicio=' + servicioId + ']');
                var idTipoVehiculo = $tr.find('[tipoVehiculoId]').attr('tipoVehiculoId');
                this.MostrarTipoVehiculoEnCombo(idTipoVehiculo);
                $tr.remove();
                this.cantidad--;
            },
            MostrarTipoVehiculoEnCombo: function (id) {
                $('[id*=ddlTipoVehiculo] [value=' + id + ']').toggle();
            },
            OcultarTipoVehiculoEnCombo: function (id) {
                $('[id*=ddlTipoVehiculo] [value=' + id + ']').toggle();
            },
            iniciar: function () {
                //llenar la tabla con el head de hfPrecios y los servicios en el hfServicios
                var me = this;
                var $table = $('[id*=tbServicios]');
                var $tableHead = $('[id*=tbServiciosHead]');
                var $tr = $('<tr> </tr>');

                $tr.append('<th>Tipo de Vehiculo</th>');
                $tr.append('<th>Capacidad</th>');

                $.each(this.tiempos, function (i, tiempo) {
                    $tr.append('<th idTiempo="' + tiempo.Id + '"> $ x ' + tiempo.Nombre + '</th>');
                });


                $tableHead.append($tr);

                if (playaCargada !== undefined) {
                    //se esta editando una playa, cargar los servicios en la tabla
                    $.each(playaCargada.Servicios, function () {
                        me.agregar(this);
                    });
                }

                $('[id*=txtCapacidad]').val('');
                $('[id*=ddlTipoVehiculo] [value=0]').prop("selected", true);
            },
            lista: function () {
                //JSON de lista de servicios en la tabla
                var servicios = new Array();
                var $filas = $('#tbServicios>tBody>tr');
                $.each($filas, function (i, fila) {
                    var id = $(fila).attr('idServicio'),
                        playaId,
                        tipoVehiculoId = $(fila).find('[TipoVehiculoId]').first().attr('TipoVehiculoId'),
                        capacidadTemp = new capacidad(id, $(fila).find('[id*=txtEditableCapacidad]').text()),
                        precios = new Array(),
                        $celdasPrecio = $(fila).find('a[id*=txtEditablePrecio]');

                    $.each($celdasPrecio, function (j, celda) {
                        var monto = celda.innerHTML;
                        if (monto !== "Ingrese Precio") {
                            var precioTemp = new precio(id, $(celda).attr('data-pk'), monto);
                            precios.push(precioTemp);
                        }
                    });
                    var servicioTemp = new servicio(id, playaId, tipoVehiculoId, capacidadTemp, precios);

                    servicios.push(servicioTemp);
                });
                return servicios;
            }
        };

        var direcciones = {
            //parecido a servicios
            iniciar: function () {
                GoogleMaps.initialize();
            },
            agregar: function (direccion) {
                var $tableBody = $('[id*=tbDireccionesBody]');
                var $tr = $('<tr idDireccion="' + direccion.Id + '"> </tr>');

                $tr.append('<td>' + direccion.Calle + ' </td>');
                $tr.append('<td>' + direccion.Numero + ' </td>');
                $tr.append('<td>' + direccion.Ciudad + ' </td>');
                $tr.append('<td style="display:none;">' + direccion.Latitud + ' </td>');
                $tr.append('<td style="display:none;">' + direccion.Longitud + ' </td>');

                $tr.append('<td><a id="btnEditar" class="glyphicon glyphicon-edit"></a>   <a id="btnQuitar" class="glyphicon glyphicon-remove"></a></td>');

                $tableBody.append($tr);
                $('[id*=txtBuscar]').prop('disabled', true)
            },
            eliminar: function (id) {

            },
            lista: function () {
                //JSON de lista de direcciones en la tabla
                var direcciones = new Array();
                var $filas = $('#tbDirecciones>tBody>tr');
                $.each($filas, function (i, fila) {
                    var id = $(fila).attr('idDireccion');
                    var playaId;
                    var calle = $(fila).find('td').eq(0).text();
                    var numero = $(fila).find('td').eq(1).text();
                    var ciudad = $(fila).find('td').eq(2).text();
                    var latitud = $(fila).find('td').eq(3).text();
                    var longitud = $(fila).find('td').eq(4).text();

                    var direccionTemp = new direccion(id, calle, numero, ciudad, latitud, longitud);

                    direcciones.push(direccionTemp);
                });
                return direcciones;
            }
        };


        function capacidad(id, cantidad) {
            this.ServicioId = id;
            this.Cantidad = cantidad;
        }
        function precio(id, idTiempo, precio) {
            this.ServicioId = id;
            this.TiempoId = idTiempo;
            this.Monto = precio;
        }

        function horario(id, horaDesde, horaHasta, diaAtencionId) {
            this.PlayaDeEstacionamientoId = id;
            this.HoraDesde = horaDesde;
            this.HoraHasta = horaHasta;
            this.DiaAtencionId = diaAtencionId;
        };

        function servicio(id, playaId, tipoVehiculoId, capacidad, precios) {
            this.Id = id;
            this.PlayaDeEstacionamientoId = playaId;
            this.TipoVehiculoId = tipoVehiculoId;
            this.Capacidad = capacidad;
            this.Precios = precios;
        };

        function playaDeEstacionamiento(id, nombre, mail, telefono, tipoPlayaId, horario, direcciones, servicios) {
            this.Id = id;
            this.Nombre = nombre;
            this.Mail = mail;
            this.Telefono = telefono;
            this.TipoPlayaId = tipoPlayaId;
            this.Horario = horario;
            this.Direcciones = direcciones;
            this.Servicios = servicios;
        };
        function direccion(id, calle, numero, ciudad, latitud, longitud) {
            this.Id = id;
            this.Calle = calle;
            this.Numero = numero;
            this.Ciudad = ciudad;
            this.Latitud = latitud;
            this.Longitud = longitud;
        };

        $(document).ready(new function () {

            $('[id*=btnAgregarServicio]').on("click", function () {

                var servicioNuevo = new servicio(0, 0, $('[id*=ddlTipoVehiculo]').val(), $('[id*=txtCapacidad]').val(), {});

                servicios.agregar(servicioNuevo);
            });
            $('[id*=btnAgregarDireccion]').on("click", function () {
                var calle = $('[id*=txtCalle]').first().val();
                var numero = $('[id*=txtNumero]').first().val();
                var ciudad = $('[id*=txtBuscar]').first().val();
                var latitud = $('[id*=latitud]').first().val();
                var longitud = $('[id*=longitud]').first().val();
                var direccionNueva = new direccion(0, calle, numero, ciudad, latitud, longitud);

                direcciones.agregar(direccionNueva);
            });

            $('[id*=btnGuardar]').on("click", function () {
                playa.guardar();
            });

            $('[id*=btnNuevaPlaya]').on("click", function () {
                $('#modificarPlaya').modal({
                    backdrop: false,
                    keyboard: false,
                    show: true
                });
            });

            $('#tabDireccion').on("click", function () {
                setTimeout(function () { GoogleMaps.resize(); }, 200);
            });

            playa.iniciar();

        });

    </script>
</asp:Content>
