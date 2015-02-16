<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdministracionSolicitudesYConexiones.aspx.cs" Inherits="Web2.AdministracionSolicitudesYConexiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="fa  fa-list"></span><span runat="server" id="t_solicitudes"> Solicitudes</span>
            </h3>
        </div>
        <div class="panel-body">
            <a data-toggle="modal" href="#modalSolicitud" id="btnCrearSolicitud" class="btn btn-success btn-sm" style="margin-bottom: 10px;"> Crear Solicitud</a>
            <asp:GridView ID="gvSolicitudes" runat="server" CssClass="table table-condensed table-bordered table-striped"
                AutoGenerateColumns="False" ClientIDMode="Static"
                EmptyDataText="No hay solicitudes pendientes"
                DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id Solicitud" />
                    <asp:BoundField DataField="NombrePlaya" HeaderText="Nombre de Playa" />
                    <asp:BoundField DataField="UsuarioResponsable" HeaderText="Responsable" />
                    <asp:BoundField DataField="EstadoId" HeaderText="Estado" HeaderStyle-Width="120px"/>
                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="btn-group-table"  HorizontalAlign="Center"/>
                        <ItemTemplate>
                            <button class="btn btn-danger" id="btnCancelarSolicitud" fila="<%# Container.DataItemIndex %>" index="<%# Eval("Id") %>" > <span class="fa fa-times"></span> Cancelar</button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="fa  fa-list"></span><span runat="server" id="t_conexiones"> Conexiones</span>
            </h3>
        </div>
        <div class="panel-body">
            <a data-toggle="modal" href="#" id="btnCrearConexion" class="btn btn-success btn-sm" style="margin-bottom: 10px;"> Crear Conexion</a>
        </div>
    </div>

     <div class="modal fade" id="modalSolicitud">
                <div class="modal-dialog">
                    <div class="modal-content" style="width: 500px;margin-right: 0px;margin-left: 50px;text-align: center;left: 0px;border-left-width: 0px;border-right-width: 0px;">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" onclick="">
                                <span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title text-center"><span class="fa fa-plus-square"></span><strong> Crear Solicitud</strong></h4>
                        </div>
                        <div class="modal-body" style="height:160px;">
                            <div class="form-group" id="valPlaya" style="text-align: -webkit-center;">
                                <div class="input-group">
                                    <asp:TextBox ID="txtPlaya" TabIndex="1" style="margin-bottom: 15px;" placeholder="Nombre de la Playa" CssClass="form-control input-lg"
                                        runat="server" oninput="javascript: validar();"></asp:TextBox>
                                    <i id="iconMain_txtPlaya" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtPlaya"></i>
                                </div>
                                <small id="smallMain_txtPlaya" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtPlaya" data-bv-result="INVALID">
                                    <label id="errorMain_txtPlaya"></label>
                                </small>
                                <div id="divBotones" class="form-group" style="width: 200px;">
                                    <button type="button" class="btn btn-primary btn-md pull-left" style="width: 83px;" id="btnCrear">Crear</button>
                                    <button type="button" onclick="" data-dismiss="modal" class="btn btn-md pull-right" id="btnCancelar">Cancelar</button>
                                </div>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(new function () {
            $('[id=li_Solicitudes]').attr("class", "active");
            $("#gvSolicitudes tr").find('td:eq(3)').each(function () {

                //obtenemos el valor de la celda
                var valor = $(this).html();
                if (valor == 2) {
                    $(this)[0].outerHTML = "<td align='center'><label class='label-table label-warning'>Pendiente</label></td>";
                }
            });
        });

        $('#modalSolicitud').on('shown.bs.modal', function () {
            $("#txtNombrePlaya").focus();
        });

        $('#modalSolicitud').on('hidden.bs.modal', function () {
            limpiarValidaciones();
            $("#txtNombrePlaya").val();
        });

        $('[id=btnCrear]').click(function () {
            validarSolicitud();
        });

    </script>
    <script src="js/administrarSolicitudesyConexiones.js" type="text/javascript"></script>
</asp:Content>
