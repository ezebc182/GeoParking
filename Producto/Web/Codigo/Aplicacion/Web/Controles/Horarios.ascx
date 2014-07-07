<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Horarios.ascx.cs" Inherits="Web.Controles.Horario" %>

<div>


    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:Label ID="lblHorarios" runat="server" Text="Horarios"></asp:Label>
            <asp:Button ID="btnAgregarHorario" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClientClick="mostrarFormularioHorario()" />
        </ContentTemplate>
    </asp:UpdatePanel>    
            <div id="divSeccionFormulario" runat="server" class="hidden">
                <asp:UpdatePanel runat="server" ID="upFormulario">
        <ContentTemplate>
                <div class="form-horizontal" role="form">
                    <div class="form-group">
                        <label for="ddlDias" class="col-sm-2 control-label">Dias</label>
                        <div class="col-sm-7">

                            <asp:DropDownList runat="server" CssClass="form-control required" ID="ddlDias" />
                        </div>
                    </div>
                    <div class="form-group">

                        <label for="txtDesde" class="col-sm-2 control-label">Desde</label>
                        <div class="col-sm-7">
                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtDesde" />
                        </div>

                        <label for="txtHasta" class="col-sm-2 control-label">Hasta</label>
                        <div class="col-sm-7">

                            <asp:TextBox runat="server" CssClass="form-control required" ID="txtHasta" />
                        </div>
                        <asp:CheckBox runat="server" ID="chk24Horas" Text="24 Horas" />
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-success" Text="Guardar" OnClientClick="mostrarFormularioHorario()" OnClick="btnGuardar_Click" />
                        <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-danger" Text="Cancelar" OnClientClick="mostrarFormularioHorario()" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="divSeccionHorarios" runat="server">
        <asp:UpdatePanel runat="server" ID="upGVResultados">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvHorarios" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="DiaAtencionId" DataField="DiaAtencionId" Visible="false" />
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
