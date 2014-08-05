<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarPermisoARol.aspx.cs" Inherits="Web.AsignarPermisoARol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="position: relative; top: 140px; right: -50%;">Asignar permiso a rol</h3>
     <div class="form-group" style="position:relative; top:160px; right:-40%; height:500px; width:500px" >
        <div class="col-sm-10 col-md-10 col-lg-10">
            <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Rol</label>
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control required" AutoPostBack="True" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged1">
            </asp:DropDownList>

        </div>
        <div class="col-sm-10 col-md-10 col-lg-10">
            <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Permisos</label>
            <div style="position: relative; top: 25px; height:auto">
                <asp:CheckBoxList ID="cblPermiso" runat="server">
            </asp:CheckBoxList>
            </div>
        </div>
            <div class="col-sm-10 col-md-10 col-lg-10">
                <div style="position:relative; top:50px;right: -82%;">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success btn-lg" Text="Guardar" AutoPostBack="True" OnClick="btnGuardar_Click"/>
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-lg" Text="Cancelar" AutoPostBack="True" OnClick="btnCancelar_Click"/>
                </div>
            </div>
     </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
