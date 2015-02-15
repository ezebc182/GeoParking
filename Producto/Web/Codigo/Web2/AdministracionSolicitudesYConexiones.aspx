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
    </script>
</asp:Content>
