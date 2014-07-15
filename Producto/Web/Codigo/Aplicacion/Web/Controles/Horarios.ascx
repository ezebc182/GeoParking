<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Horarios.ascx.cs" Inherits="Web.Controles.HorarioControl" %>

<div>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:LinkButton ID="btnAgregarHorario" runat="server" data-toggle="panel" data-target="#upFormulario" OnClick="btnAgregarHorario_Click" CssClass="btn btn-md btn-success pull-right" Text="<span class='glyphicon glyphicon-plus'></span>" OnClientClick="mostrarFormularioHorario()" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Horarios</h3>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel runat="server" ID="upFormulario">
                <ContentTemplate>
                    <div id="divSeccionFormulario" runat="server">
                        <div class="form-horizontal " role="form">
                            <div class="form-group">
                                <label for="ddlDias" class="col-sm-2 col-md-2 col-lg-2 control-label">Dias</label>
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:DropDownList runat="server" CssClass="form-control " data-bv-notempty="true" data-bv-notempty-message="Seleccione un tipo." ID="ddlDias" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDesde" class="col-sm-2 col-md-2 col-lg-2 control-label">Desde</label>
                                <div class="col-sm-3 col-md-3 col-lg-3 input-group date horarios" id="dtpDesde">
                                    <asp:TextBox runat="server" CssClass="form-control "  ID="txtDesde" data-bv-notempty="true" data-bv-notempty-message="Ingrese horario hasta"/>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                </div>

                                <label for="txtHasta" class="col-sm-2 col-md-2 col-lg-2 control-label">Hasta</label>
                                <div class="col-sm-3 col-md-3 col-lg-3 input-group date horarios" id="dtpHasta">
                                    <asp:TextBox runat="server" CssClass="form-control " ID="txtHasta" data-bv-notempty="true" data-bv-notempty-message="Ingrese horario hasta" data-bv-greaterthan-inclusive="false" data-bv-greaterthan-message="Horario hasta no puede ser inferior a horario desde." data-bv-greaterthan-value="txtDesde"/>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                </div>
                                <div class="col-sm-2 col-md-2 col-lg-2">
                                    <asp:CheckBox runat="server" ID="chk24Horas" Checked="true" Text="24 hs" />
                                </div>
                            </div>
                            <div class="form-group pull-right">
                                <asp:LinkButton runat="server" ID="btnGuardar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-ok-circle'></span>" ForeColor="Green" BackColor="Transparent" OnClientClick="mostrarFormularioHorario()" OnClick="btnGuardar_Click" />
                                <asp:LinkButton runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" Text="<span class='glyphicon glyphicon-remove-circle'></span>" CssClass="btn btn-lg" ForeColor="Red" BackColor="Transparent" OnClientClick="mostrarFormularioHorario()" />
                            </div>
                        </div>
                    </div>
                    <div id="divSeccionHorarios" runat="server" class="">

                        <asp:GridView runat="server" ID="gvHorarios" AutoGenerateColumns="false" DataKeyNames="Id, DiaAtencionId"
                            OnRowCommand="OnRowCommandGvHorarios" CssClass="table table-hover table-responsive" AllowPaging="True">
                            <Columns>
                                <asp:BoundField HeaderText="Dias" DataField="DiaAtencionStr" />
                                <asp:BoundField HeaderText="Desde" DataField="HoraDesde" />
                                <asp:BoundField HeaderText="Hasta" DataField="HoraHasta" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ToolTip="Eliminar" ID="btnQuitar" CommandName="Quitar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger eliminacion" Text="&#9747;"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>

</div>
<script type="text/javascript">
    function validarHorarios() { 
        if ($("#TopContent_ucHorarios_txtDesde").text() >= $("#TopContent_ucHorarios_txtHasta").text()) {
        alert("La hora desde no puede ser superior a la hora hasta");
    }
    }

    function mostrarFormularioHorario() {
        //<<<<<<< Updated upstream
        //        var mostrar = $('#TopContent_ucHorarios_divSeccionFormulario').hasClass("hidden");
        //        if (mostrar) {
        //            $('#TopContent_ucHorarios_divSeccionFormulario').removeClass("hidden");
        //            $('#TopContent_ucHorarios_btnAgregarHorario').addClass("hidden");
        //            $('#TopContent_ucHorarios_btnAgregarHorario').addClass("btn btn-danger");
        //            $('#TopContent_ucHorarios_btnAgregarHorario>span').addClass("glyphicon glyphicon-minus");
        //        }
        //        else {
        //            $('#TopContent_ucHorarios_divSeccionFormulario').addClass("hidden");
        //            $('#TopContent_ucHorarios_btnAgregarHorario').removeClass("hidden");
        //            $('#TopContent_ucHorarios_btnAgregarHorario').addClass("btn btn-success");
        //            $('#TopContent_ucHorarios_btnAgregarHorario>span').addClass("glyphicon glyphicon-plus");
        //        }
        //=======
        //var mostrar = $('#TopContent_ucHorarios_divSeccionFormulario').hasClass("hidden");
        //if (mostrar) {
        //    $('#TopContent_ucHorarios_divSeccionFormulario').removeClass("hidden");
        //    $('#TopContent_ucHorarios_btnAgregarHorario').addClass("hidden");
        //}
        //else {
        //    $('#TopContent_ucHorarios_divSeccionFormulario').addClass("hidden");
        //    $('#TopContent_ucHorarios_btnAgregarHorario').removeClass("hidden");
        //}

    }

</script>
<script src="./Scripts/horarios.js"></script>
