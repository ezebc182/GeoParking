<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AdministracionUsuarios.aspx.cs" Inherits="Web.AdministracionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function dibujar(cb) {
            //var cbChecked = cb.id;
            switch (cb.id) {
                case 'cbNuevoRol':
                    var elemento1 = document.getElementById("divAsignarRolAUsuario");
                    var elemento2 = document.getElementById("divAsignarPermisoARol");
                    elemento1.addClass("hidden");
                    elemento2.addClass("hidden");

                    break;
                case 'cbAsignarRol':
                    var elemento = document.getElementById("divAsignarRolAUsuario");
                    break;
                case 'cbAsignarPermiso':
                    var elemento = document.getElementById("divAsignarPermisoARol");
                    break;
                default:
                    alert("NADA");

            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="jumbotron" style="margin-top: 5%;">
            <div class="row">
                <asp:Panel ID="panelNuevoRol" runat="server">
                    <div class="col-md-4" id="divNuevoRol">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" id="cbNuevoRol" onclick="javascript: dibujar(this)" />Habilitar
                            </label>
                        </div>

                        <%--ABMC ROL--%>

                        <h3><span class="glyphicon glyphicon-user"></span>&nbsp;Nuevo Rol</h3>
                        <div class="form-group">
                            <!--ABM Rol -->
                            <label for="txtNombre" class="col-sm-2 col-md-2 col-lg-2 control-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" TabIndex="1" data-bv-notempty="true"
                                data-bv-notempty-message="El nombre es requerido."></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtNombre" class="col-sm-2 col-md-2 col-lg-2 control-label">Descripcion</label>
                            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" TabIndex="2"
                                data-bv-notempty="true" data-bv-notempty-message="El nombre es requerido."></asp:TextBox>
                        </div>
                    

                        <%--FIN ABMC ROL--%>
                    </div>
                </asp:Panel>
                <asp:Panel ID="panelAsignarRol" runat="server">
                    <div class="col-md-4" id="divAsignarRolAUsuario">
                        <%--ASIGNAR ROL--%>
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" id="cbAsignarRol" onclick="javascript: dibujar(this)" />Habilitar
                            </label>
                        </div>
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
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" id="cbAsignarPermiso" onclick="javascript: dibujar(this)" />Habilitar
                        
                        
                            </label>
                        </div>
                        <h3><span class="glyphicon glyphicon-check"></span>&nbsp;Asignar permiso a rol</h3>
                        <div class="form-group">
                            <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Rol</label>
                            <asp:DropDownList ID="ddlRolPermisos" runat="server" CssClass="form-control required"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged1">
                            </asp:DropDownList>

                        </div>
                        <div class="form-group">
                            <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Permisos</label>
                            <div>
                                <asp:CheckBoxList ID="cblPermiso" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cblPermiso_SelectedIndexChanged">
                                    <asp:ListItem>Permiso1</asp:ListItem>
                                    <asp:ListItem>Permiso2</asp:ListItem>
                            </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
            </asp:Panel>
            <asp:Panel ID="panelBotones" runat="server">
                <div id="divBotones" class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success btn-lg" Text="Guardar"
                        OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-lg" Text="Cancelar"
                            AutoPostBack="True" OnClick="btnCancelar_Click" />
                </div>
             </asp:Panel>
            </div>
        </div>
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
