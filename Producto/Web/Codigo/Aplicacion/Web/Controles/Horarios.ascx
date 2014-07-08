﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Horarios.ascx.cs" Inherits="Web.Controles.HorarioControl" %>

<div>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:LinkButton ID="btnAgregarHorario" runat="server" CssClass="btn btn-md btn-success pull-right" Text="<span class='glyphicon glyphicon-plus'></span>" OnClientClick="mostrarFormularioHorario()" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Horarios</h3>
        </div>
        <div class="panel-body">
            <div id="divSeccionFormulario" runat="server" class="hidden">
                <asp:UpdatePanel runat="server" ID="upFormulario">
                    <ContentTemplate>
                        <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <label for="ddlDias" class="col-sm-2 col-md-2 col-lg-2 control-label">Dias</label>
                                <div class="col-sm-10 col-md-10 col-lg-10">

                                    <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlDias" />
                                </div>
                            </div>
                            <div class="form-group">

                                <label for="txtDesde" class="col-sm-2 col-md-2 col-lg-2 control-label">Desde</label>
                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <asp:TextBox runat="server" CssClass="form-control required" ID="txtDesde" />
                                </div>


                                <label for="txtHasta" class="col-sm-2 col-md-2 col-lg-2 control-label">Hasta</label>
                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <asp:TextBox runat="server" CssClass="form-control required" ID="txtHasta" />
                                </div>
                                <div class="col-sm-2 col-md-2 col-lg-2">
                                    <asp:CheckBox runat="server" ID="chk24Horas" Text="24 hs" />
                                </div>
                            </div>
                            <div class="form-group pull-right">
                                <asp:LinkButton runat="server" ID="btnGuardar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-ok-circle'></span>" ForeColor="Green" BackColor="Transparent" OnClientClick="mostrarFormularioHorario()" OnClick="btnGuardar_Click" />
                                <asp:LinkButton runat="server" ID="btnCancelar" Text="<span class='glyphicon glyphicon-remove-circle'></span>" CssClass="btn btn-lg" ForeColor="Red" BackColor="Transparent" OnClientClick="mostrarFormularioHorario()" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div id="divSeccionHorarios" runat="server">
        <asp:UpdatePanel runat="server" ID="upGVResultados">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvHorarios" AutoGenerateColumns="false" DataKeyNames="Id, DiaAtencionId"
                    OnRowCommand="OnRowCommandGvHorarios">
                    <Columns>
                        <asp:BoundField HeaderText="Dias" DataField="DiaAtencionStr" />
                        <asp:BoundField HeaderText="Desde" DataField="HoraDesde" />
                        <asp:BoundField HeaderText="Hasta" DataField="HoraHasta" />
                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnQuitar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
<script type="text/javascript">

    function mostrarFormularioHorario() {
        var mostrar = $('#TopContent_ucHorarios_divSeccionFormulario').hasClass("hidden");
        if (mostrar) {
            $('#TopContent_ucHorarios_divSeccionFormulario').removeClass("hidden");
            $('#TopContent_ucHorarios_btnAgregarHorario').addClass("hidden");
        }
        else {
            $('#TopContent_ucHorarios_divSeccionFormulario').addClass("hidden");
            $('#TopContent_ucHorarios_btnAgregarHorario').removeClass("hidden");
        }

    }

</script>
