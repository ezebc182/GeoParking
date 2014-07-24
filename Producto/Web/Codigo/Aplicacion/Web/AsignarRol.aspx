<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarRol.aspx.cs" Inherits="Web.AsignarRol" %>


<asp:Content ID="Content5" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="./Styles/bootstrap-datetimepicker.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
    <h3 style="position: relative; top: 200px; right: -50%;">Asignar rol a usuario</h3>
    <div class="form-group" style="position:relative; top:200px; right:-40%; height:500px; width:500px" >
        <label for="ddlUsuario" class="col-sm-2 col-md-2 col-lg-2 control-label">Usuario</label>
        <asp:DropDownList ID="ddlUsuario" CssClass="form-control required" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged"/>
        <div class="col-sm-10 col-md-10 col-lg-10">    
        </div>
        <asp:Label ID="lblRol" for="ddlRol" runat="server" Text="Rol"></asp:Label>
        <div class="col-sm-10 col-md-10 col-lg-10">
            <asp:DropDownList ID="ddlRol" CssClass="form-control required" runat="server" AutoPostBack="True" />
        </div>
        <div style="position:relative; top:50px;">
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
        </div>
    </div>
</asp:Content>