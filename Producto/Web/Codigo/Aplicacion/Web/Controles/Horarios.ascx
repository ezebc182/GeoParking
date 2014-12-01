<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Horarios.ascx.cs" Inherits="Web2.Controles.HorarioControl" %>

<div id="divPanel">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:LinkButton ID="btnAgregarHorario" runat="server" CssClass="btn btn-md btn-success pull-right"
                Text="<span class='glyphicon glyphicon-plus'></span>" OnClick="btnAgregarHorario_Click"
                OnClientClick="mostrarPanel((this))" />

        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Horarios</h3>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel runat="server" ID="upFormulario">
                <ContentTemplate>
                    <div id="divSeccionFormulario" runat="server" class=" ">
                        <div class="form-horizontal " role="form">
                            <div class="form-group">
                                <label for="ddlDias" class="col-sm-2 col-md-2 col-lg-2 control-label">Dias</label>
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:DropDownList runat="server" CssClass="form-control " data-bv-notempty="true"
                                        data-bv-notempty-message="Seleccione un tipo." ID="ddlDias" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDesde" class="col-sm-2 col-md-2 col-lg-2 control-label">Desde</label>
                                <div class="col-sm-3 col-md-3 col-lg-3 ">
                                <div class="input-group date horarios" id="dtpDesde">
                                    <asp:TextBox type="time" value="09:00" runat="server" CssClass="form-control " ID="txtDesde" data-bv-notempty="true"
                                        data-bv-notempty-message="Ingrese horario hasta" ClientIDMode="Static" disabled="true"/>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                </div>
                                </div>
                                <label for="txtHasta" class="col-sm-2 col-md-2 col-lg-2 control-label">Hasta</label>
                                <div class="col-sm-3 col-md-3 col-lg-3 ">
                                <div class="input-group date horarios" id="dtpHasta">
                                    <asp:TextBox type="time" value="23:59" runat="server" CssClass="form-control " ID="txtHasta" data-bv-notempty="true"
                                        data-bv-notempty-message="Ingrese horario hasta" data-bv-greaterthan-inclusive="false"
                                        data-bv-greaterthan-message="Horario hasta no puede ser inferior a horario desde."
                                        data-bv-greaterthan-value="txtDesde" ClientIDMode="Static" disabled="true" />
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                </div>
                                </div>
                                <div class="col-sm-2 col-md-2 col-lg-2">
                                    <%--24 hs<input type="checkbox" id="chk24Horas" checked />--%>
                                    <asp:CheckBox runat="server" ID="chk24Horas" Checked="true" Text="24 hs" ClientIDMode="Static" CausesValidation="true"/>
                                </div>
                            </div>
                            <div class="form-group pull-right">
                                <asp:LinkButton runat="server" ID="btnGuardar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-ok-circle'></span>"
                                    ForeColor="Green" BackColor="Transparent" OnClientClick="ocultarPanel(this)" OnClick="btnGuardar_Click" />
                               <asp:LinkButton runat="server" ID="btnCancelar" CssClass="btn btn-lg" Text="<span class='glyphicon glyphicon-remove-circle'></span>"
                                    ForeColor="Red" BackColor="Transparent"  OnClientClick="ocultarPanel(this)" OnClick="btnCancelar_Click" />
                                
                            </div>
                        </div>
                    </div>
                    <div id="divSeccionGrillaHorarios" runat="server" class=" ">

                        <asp:GridView runat="server" ID="gvHorarios" AutoGenerateColumns="false" DataKeyNames="Id, DiaAtencionId"
                            OnRowCommand="OnRowCommandGvHorarios" CssClass="table table-hover table-responsive"
                            AllowPaging="True">
                            <Columns>
                                <asp:BoundField HeaderText="Dias" DataField="DiaAtencionStr" />
                                <asp:BoundField HeaderText="Desde" DataField="HoraDesde" />
                                <asp:BoundField HeaderText="Hasta" DataField="HoraHasta" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ToolTip="Eliminar" ID="btnQuitar" CommandName="Quitar"
                                            CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-xs btn-danger eliminacion"
                                            Text="<span class='glyphicon glyphicon-remove'></span>" />
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
    $(document).ready(function () {
        //$(".horarios").datetimepicker({
        //    pickDate: false
        //});
        
        // when unchecked or checked, run the function
        $('[id*=chk24Horas]').first().change(function () {
            if (this.checked) {
                document.getElementById('txtDesde').disabled = false;
                document.getElementById('txtHasta').disabled = false;
            } else {
                document.getElementById('txtDesde').disabled = true;
                document.getElementById('txtHasta').disabled = true;
            }

        });

    });
    pageManager = Sys.WebForms.PageRequestManager.getInstance();
    pageManager.add_endRequest(function () {
        //$(".horarios").datetimepicker({
        //    pickDate: false
        //});
        $('[id*=chk24Horas]').first().change(function () {
            if (this.checked) {
                document.getElementById('txtDesde').disabled = true;
                document.getElementById('txtHasta').disabled = true;
            } else {
                document.getElementById('txtDesde').disabled = false;
                document.getElementById('txtHasta').disabled = false;  
            }

        });


    });


   
   

</script>
<script src="./Scripts/horarios.js"></script>
