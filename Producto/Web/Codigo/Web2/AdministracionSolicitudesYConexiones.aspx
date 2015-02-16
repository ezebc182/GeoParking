<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdministracionSolicitudesYConexiones.aspx.cs" Inherits="Web2.AdministracionSolicitudesYConexiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="fa  fa-list"></span><span runat="server" id="t_solicitudes">Solicitudes</span>
            </h3>
        </div>
        <div class="panel-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="upSolicitud" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hfSolicitud" runat="server" />
                    <a data-toggle="modal" href="#modalSolicitud" id="btnModalSolicitud" class="btn btn-success btn-sm" style="margin-bottom: 10px;" runat="server">Crear Solicitud</a>
                    <asp:GridView ID="gvSolicitudes" runat="server" CssClass="table table-condensed table-bordered table-striped"
                        AutoGenerateColumns="False" ClientIDMode="Static" ShowHeaderWhenEmpty="true"
                        EmptyDataText="No hay solicitudes pendientes"
                        DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id Solicitud" />
                            <asp:BoundField DataField="NombrePlaya" HeaderText="Nombre de Playa" />
                            <asp:BoundField DataField="UsuarioResponsable" HeaderText="Responsable" />
                            <asp:BoundField DataField="EstadoId" HeaderText="Estado" HeaderStyle-Width="120px" />
                            <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                <ItemStyle CssClass="btn-group-table" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a data-toggle="modal" href="#modalCancelar" class="btn btn-danger" id="btnCancelarSolicitud" onclick="idSolicitud(<%# Eval("Id") %>)"><span class="fa fa-times"></span> Cancelar</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span class="fa  fa-list"></span><span runat="server" id="t_conexiones">Conexiones</span>
            </h3>
        </div>
        <div class="panel-body">
            <a data-toggle="modal" href="#modalConexion" id="btnModalConexion" class="btn btn-success btn-sm" style="margin-bottom: 10px;"  runat="server">Crear Conexion</a>
        </div>
    </div>

    <div class="modal fade" id="modalSolicitud">
        <div class="modal-dialog">
            <div class="modal-content" style="width: 500px; margin-right: 0px; margin-left: 50px; text-align: center; left: 0px; border-left-width: 0px; border-right-width: 0px;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title text-center"><span class="fa fa-plus-square"></span><strong> Crear Solicitud</strong></h4>
                </div>
                <div class="modal-body" style="height: 160px;">
                    <div class="form-group" id="valPlaya" style="text-align: -webkit-center;">
                        <div class="input-group">
                            <asp:TextBox ID="txtPlaya" TabIndex="1" Style="margin-bottom: 15px;" placeholder="Nombre de la Playa" CssClass="form-control input-lg"
                                runat="server" oninput="javascript: validar();"></asp:TextBox>
                            <i id="iconMain_txtPlaya" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtPlaya"></i>
                        </div>
                        <small id="smallMain_txtPlaya" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtPlaya" data-bv-result="INVALID">
                            <label id="errorMain_txtPlaya"></label>
                        </small>
                        <div id="divBotones" class="form-group" style="width: 200px;">
                            <asp:Button ID="btnCrearSolicitud" CssClass="btn btn-primary btn-md pull-left"  Width="83px"  OnClientClick="javascript: return validarSolicitud();"  runat="server" Text="Crear" OnClick="brnCrearSolicitud_Click" />
                            <%--<button type="button" class="btn btn-primary btn-md pull-left" style="width: 83px;" id="btnCrear">Crear</button>--%>
                            <button type="button" onclick="" data-dismiss="modal" class="btn btn-md pull-right" id="btnCancelar">Cancelar</button>
                        </div>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
    </div>
    <div class="modal fade" id="modalConexion">
        <div class="modal-dialog">
            <div class="modal-content" style="width: 500px; margin-right: 0px; margin-left: 50px; text-align: center; left: 0px; border-left-width: 0px; border-right-width: 0px;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title text-center"><span class="fa fa-plus-square"></span><strong> Crear conexion</strong></h4>
                </div>
                <div class="modal-body" style="height: 200px;">
                    <div class="form-group" id="Div4" style="text-align: -webkit-center;">
                        <div class="input-group">
                            <asp:TextBox ID="TextBox1" TabIndex="1" Style="margin-bottom: 15px;" placeholder="Nombre de la Playa" CssClass="form-control input-lg"
                                runat="server" oninput="javascript: validar();"></asp:TextBox>
                            <i id="i1" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtPlaya"></i>
                        </div>
                        <small id="small1" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtPlaya" data-bv-result="INVALID">
                            <label id="Label1"></label>
                        </small>
              
                        <div class="input-group">
                            <asp:TextBox ID="TextBox2" TabIndex="1" Style="margin-bottom: 15px;" placeholder="Mail o Nombre de Usuario" CssClass="form-control input-lg"
                                runat="server" oninput="javascript: validar();"></asp:TextBox>
                            <i id="i3" style="display: none" class="form-control-feedback" data-bv-icon-for="ctl00$Main$txtPlaya"></i>
                        </div>
                        <small id="small3" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="ctl00$Main$txtPlaya" data-bv-result="INVALID">
                            <label id="Label3"></label>
                        </small>
                        <div id="div5" class="form-group" style="width: 200px;">
                            <asp:Button ID="Button1" CssClass="btn btn-primary btn-md pull-left"  Width="83px"  OnClientClick="javascript: return validarSolicitud();"  runat="server" Text="Crear" OnClick="brnCrearSolicitud_Click" />
                            <button type="button" onclick="" data-dismiss="modal" class="btn btn-md pull-right" id="Button2">Cancelar</button>
                        </div>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
    </div>
    <div class="modal fade" id="modalCancelar">
        <div class="modal-dialog">
            <div class="modal-content" style="width: 500px; margin-right: 0px; margin-left: 50px; text-align: center; left: 0px; border-left-width: 0px; border-right-width: 0px;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title text-center"><span class="fa fa-times"></span><strong> Cancelar Solicitud</strong></h4>
                </div>
                <div class="modal-body" style="height: 100px">
                    <div class="form-group" id="Div2" style="text-align: -webkit-center;">
                        <label>¿Esta seguro de cancelar la solicitud?</label>
                        <div id="div3" class="form-group" style="width: 200px;  margin-top:15px;">
                            <asp:Button ID="btnSi" CssClass="btn btn-primary btn-md pull-left"  Width="83px"  runat="server" Text="Si" OnClick="btnSi_Click" />
                            <button type="button" onclick="" data-dismiss="modal" style="width:83px" class="btn btn-md pull-right" id="btnNo">No</button>
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
                if (valor == 6) {
                    $(this)[0].outerHTML = "<td align='center'><label class='label-table label-warning'>Pendiente</label></td>";
                }
                if (valor == 7) {
                    $(this)[0].outerHTML = "<td align='center'><label class='label-table label-success'>Aprobada</label></td>";
                }
                if (valor == 8) {
                    $(this)[0].outerHTML = "<td align='center'><label class='label-table label-default'>Cancelada</label></td>";
                }
                if (valor == 9) {
                    $(this)[0].outerHTML = "<td align='center'><label class='label-table label-important'>Rechazada</label></td>";
                }
            });
        });

        function idSolicitud(id) {
            $('[id=Main_hfSolicitud]').val(id);
        }

        $('#modalSolicitud').on('shown.bs.modal', function () {
            $("#txtNombrePlaya").focus();
        });

        $('#modalSolicitud').on('hidden.bs.modal', function () {
            limpiarValidaciones();
            $("#txtNombrePlaya").val();
        });

        $('[id=Main_btnCrearSolicitud]').click(function () {
            validarSolicitud();
        });

    </script>
    <script src="js/administrarSolicitudesyConexiones.js" type="text/javascript"></script>
</asp:Content>
