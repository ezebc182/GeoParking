<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarRol.aspx.cs" Inherits="Web.AsignarRol" %>


<asp:Content ID="Content5" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="./Styles/bootstrap-datetimepicker.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
    <div class="form-group">
        <label for="ddlUsuario" class="col-sm-2 col-md-2 col-lg-2 control-label">Usuario</label>
        <div class="col-sm-10 col-md-10 col-lg-10">
            <asp:DropDownList ID="ddlUsuario" CssClass="form-control required" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged"/>
            <asp:DropDownList ID="ddlRol" runat="server">
            </asp:DropDownList>
            <asp:Label ID="lblRol" runat="server" Text="Rol"></asp:Label>
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
        </div>
    </div>
</asp:Content>