﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Domicilio.ascx.cs" Inherits="Web2.Controles.DomicilioControl" %>
<div id="divPanel">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:LinkButton ID="btnAgregarDomicilio" runat="server" CssClass="btn btn-md btn-success pull-right" Text="<span class='glyphicon glyphicon-plus'></span>" OnClick="btnAgregarDomicilio_Click" OnClientClick="mostrarPanel((this))" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Domicilios</h3>
        </div>
        <div class="panel-body">

            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>
                    <div id="divSeccionFormulario1" runat="server" class="hidden ">
                        <div class="form-group">
                            <label for="ddlProvincia" class="col-sm-2 col-md-2 col-lg-2 control-label">Provincia</label>
                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control required" ID="ddlProvincia" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ddlDepartamento" class="col-sm-2 col-md-2 col-lg-2 control-label">Departamento</label>
                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control required" ID="ddlDepartamento"
                                    OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ddlCiudad" class="col-sm-2 col-md-2 col-lg-2 control-label">Ciudad</label>
                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <asp:DropDownList runat="server" AutoPostBack="false" CssClass="form-control required" ID="ddlCiudad" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>
            <asp:TextBox ID="latitud" class="hidden" runat="server" />
            <asp:TextBox ID="longitud" class="hidden" runat="server" />


            <asp:UpdatePanel runat="server" ID="upFormulario">
                <ContentTemplate>
                    <div id="divSeccionFormulario2" runat="server" class=" hidden formulario " data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                        <div class="form-group">
                            <label for="txtCalle" class="col-sm-2 col-md-2 col-lg-2 control-label">Calle</label>
                            <div class="col-sm-6 col-md-6 col-lg-6">
                                <asp:TextBox runat="server" type="text" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="La calle es requerida." ID="txtCalle" />
                            </div>
                            <label for="txtNumero" class="col-sm-1 col-md-1 col-lg-1 control-label">Número</label>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <asp:TextBox runat="server" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="La altura es requerida." ID="txtNumero" min="0" data-bv-greaterThan-message="Ingrese un valor numérico" />
                            </div>
                            <div class="col-sm-1 col-md-1 col-lg-1">
                                <button id="btnBuscarEnMapa" runat="server" class="glyphicon glyphicon-map-marker btn btn-warning pull-right"
                                    tooltip="Buscar en mapa" onclick="codeAddress()"  style="height:34px;"/>
                                <asp:TextBox runat="server" ID="txtDireccion" CssClass="hidden" />
                            </div>
                            <div class="form-group">
                                <div class="col-sm-2 col-md-2 col-lg-2"></div>
                                <div id="pnlMapa" class="col-sm-10 col-md-10 col-lg-10">
                                    <div id="map-canvas"></div>
                                </div>

                            </div>

                            <div class="form-group pull-right">
                                <asp:LinkButton runat="server" ID="btnGuardar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-ok-circle'></span>" ForeColor="Green" BackColor="Transparent" OnClick="btnGuardar_Click" OnClientClick="ocultarPanel()" />
                                <asp:LinkButton runat="server" ID="btnCancelar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-remove-circle'></span>" ForeColor="Red" BackColor="Transparent" OnClick="btnCancelar_Click" OnClientClick="ocultarPanel()" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
            <ContentTemplate>
                <div id="divSeccionGrillaDomicilios" runat="server" class="">
                    <asp:GridView runat="server" ID="gvDomicilios" AutoGenerateColumns="false"
                        DataKeyNames="Id, CiudadId" CssClass="table table-hover table-responsive"
                        OnRowCommand="OnRowCommandGvDomicilios" AllowPaging="True">
                        <Columns>
                            <asp:BoundField HeaderText="Calle" DataField="Calle" />
                            <asp:BoundField HeaderText="Numero" DataField="Numero" />
                            <asp:BoundField HeaderText="Ciudad" DataField="CiudadStr" />
                            <asp:BoundField HeaderText="Departamento" DataField="DepartamentoStr" />
                            <asp:BoundField HeaderText="Provincia" DataField="ProvinciaStr" />
                            <asp:BoundField HeaderText="Latitud" DataField="Latitud" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:BoundField HeaderText="Longitud" DataField="Longitud" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnQuitar" CssClass="btn btn-danger btn-xs eliminacion" Text="<span class='glyphicon glyphicon-remove'></span>"
                                        CommandArgument="<%# Container.DataItemIndex %>" CommandName="Quitar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</div>

