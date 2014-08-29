<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Precios.ascx.cs" Inherits="Web.Controles.PrecioControl" %>

<div id="divPanel">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:LinkButton ID="btnAgregarPrecio" runat="server" CssClass="btn btn-md btn-success pull-right" Text="<span class='glyphicon glyphicon-plus'></span>" OnClick="btnAgregarPrecio_Click" OnClientClick="mostrarPanel((this))" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Precios</h3>
        </div>
        <div class="panel-body">
            
            <asp:UpdatePanel runat="server" ID="upFormulario">
                
                <ContentTemplate>
                    <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                    <div id="divSeccionFormulario" runat="server" class=" ">
                        <div class="form-horizontal" role="form">

                            <div class="form-group">
                                <label for="ddlTipoVehiculo" class="col-sm-2 col-md-2 col-lg-2 control-label">Tipo de Vehiculo</label>

                                <div class="col-sm-10 col-md-10 col-lg-10">
                                    <asp:DropDownList runat="server" CssClass="form-control " ID="ddlTipoVehiculo" data-bv-notempty="true" data-bv-notempty-message="Seleccione un tipo de vehículo." />

                                </div>
                            </div>
                            <div class="form-group">
                                <label for="ddlTipoHorario" class="col-sm-2 col-md-2 col-lg-2 control-label">Tipo de Horario</label>

                                <div class="col-sm-10 col-md-10 col-lg-10">
                                    <asp:DropDownList runat="server" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione un tipo de horario." ID="ddlTipoHorario" />

                                </div>
                            </div>
                            <div class="form-group">
                                <label for="ddlDias" class="col-sm-2 col-md-2 col-lg-2 control-label">Dias</label>

                                <div class="col-sm-10 col-md-10 col-lg-10">
                                    <asp:DropDownList runat="server" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione el/los día/s." ID="ddlDias" />

                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtPrecio" class="col-sm-2 col-md-2 col-lg-2 control-label">Precio</label>
                                <div class="col-sm-10 col-md-10 col-lg-10">
                                    <asp:TextBox runat="server" CssClass="form-control " data-bv-numeric-separator="," data-bv-numeric-message="Ingrese un precio válido."  ID="txtPrecio"  data-bv-greaterThan-message="Ingrese un valor numérico"   data-bv-regexp-message="Ingrese un valor válido" pattern="[+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*)(?:[eE][+-]?\d+)?"/>
                                </div>
                            </div>
                            <div class="form-group pull-right">
                                <asp:LinkButton runat="server" ID="btnGuardar" Text="<span class='glyphicon glyphicon-ok-circle'></span>" CssClass="btn btn-lg" ForeColor="Green" BackColor="Transparent" OnClientClick="ocultarPanel()" OnClick="btnGuardar_Click" />
                                <span class='btn btn-lg glyphicon glyphicon-remove-circle' onclick="ocultarPanel((this))"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divSeccionGrillaPrecios" runat="server" class="">
                        <asp:GridView runat="server" ID="gvPrecios" AutoGenerateColumns="false" DataKeyNames="Id, TipoVehiculoId, TiempoId, DiaAtencionId"
                            OnRowCommand="OnRowCommandGvPrecios" CssClass="table table-hover table-responsive" AllowCustomPaging="False" AllowPaging="True">
                            <Columns>
                                <asp:BoundField HeaderText="Tipo de Vehiculo" DataField="TipoVehiculoStr" />
                                <asp:BoundField HeaderText="Tiempo" DataField="TiempoStr" />
                                <asp:BoundField HeaderText="Dias" DataField="DiaAtencionStr" />
                                <asp:BoundField HeaderText="Precio" DataField="Monto" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnQuitar" CommandName="Quitar" Text="&#9747;" CssClass="btn btn-danger eliminacion" CommandArgument="<% # Container.DataItemIndex%>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                        </div>
                </ContentTemplate>
                    
            </asp:UpdatePanel>
                </div>

        
    </div>
</div>
