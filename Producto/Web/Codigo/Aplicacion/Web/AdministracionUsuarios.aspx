<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AdministracionUsuarios.aspx.cs" Inherits="Web.AdministracionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="jumbotron" style="margin-top: 5%;">
            <div class="row">
                <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
                    data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
                    <asp:Panel ID="panelNuevoRol" runat="server">
                        <div class="col-md-4" id="divNuevoRol">


                            <%--ABMC ROL--%>

                            <h3><span class="glyphicon glyphicon-user"></span>&nbsp;Nuevo Rol</h3>
                            <div class="form-group">
                                <!--ABM Rol -->
                                <label for="txtNombre" class="col-sm-2 col-md-2 col-lg-2 control-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" TabIndex="1" data-bv-notempty="true"
                                    data-bv-notempty-message="El nombre es requerido." data-bv-regexp-regexp="^[a-zA-Z0-9_\.]+$"
                                    data-bv-regexp-message="El nombre de usuario sólo puede consistir en alfabético, número, puntos o subrayados"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtNombre" class="col-sm-2 col-md-2 col-lg-2 control-label">Descripcion</label>
                                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" TabIndex="2"                                    
                                    data-bv-stringlength="true"
                                    data-bv-stringlength-message="Introduzca un valor entre 5 y 100 caracteres."
                                    data-bv-stringlength-min="5"
                                    data-bv-stringlength-max="100" TextMode="MultiLine"></asp:TextBox>
                            </div>


                            <%--FIN ABMC ROL--%>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelAsignarRol" runat="server">
                        <div class="col-md-4" id="divAsignarRolAUsuario">
                            <%--ASIGNAR ROL--%>

                            <h3><span class="glyphicon glyphicon-eye-open"></span>&nbsp;Asignar rol a usuario
                            </h3>
                            <div class="form-group">

                                <label for="ddlUsuario" class="col-sm-2 col-md-2 col-lg-2 control-label">Usuario</label>
                                <asp:DropDownList ID="ddlUsuario" CssClass="form-control required" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged" />
                            </div>
                            <div class="form-group">
                                <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Rol</label>
                                <asp:DropDownList ID="ddlRol" CssClass="form-control required" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlRol_SelectedIndexChanged" />
                            </div>

                        </div>
                    </asp:Panel>

                    <%--FIN ASIGNAR ROL--%>
                    <asp:Panel ID="panelAsignarPermiso" runat="server">
                        <div class="col-md-4" id="divAsignarPermisoARol">
                            <%--ASIGNARPERMISOAROL--%>

                            <h3><span class="glyphicon glyphicon-check"></span>&nbsp;Asignar permiso a rol</h3>
                            <div class="form-group">
                                <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Rol</label>
                                <asp:DropDownList ID="ddlRolPermisos" runat="server" CssClass="form-control required"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged1">
                                </asp:DropDownList>

                            </div>
                            <div class="form-group">
                                <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Permisos</label>
                                <br />
                                <div>
                                    <asp:CheckBoxList ID="cblPermiso" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cblPermiso_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>




                </div>
            </div>
            <asp:Panel ID="panelBotones" runat="server" CssClass="pull-right">
                <div id="divBotones" class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success btn-lg" Text="Guardar"
                        OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-lg" Text="Cancelar"
                        AutoPostBack="True" OnClick="btnCancelar_Click" />
                </div>
            </asp:Panel>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">

    <script>
        $(document).ready(function () {

            $('.formulario').bootstrapValidator();

            $("#admUsuarios").removeClass("hidden");
            $("#admPlayas").removeClass("hidden");
            $("#admPOI").removeClass("hidden");
            $("#admUsuarios").addClass("active");

        });
        pageManager = Sys.WebForms.PageRequestManager.getInstance();
        pageManager.add_endRequest(function () {
            $(".formulario").bootstrapValidator();

        });
    </script>
</asp:Content>
