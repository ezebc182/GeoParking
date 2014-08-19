<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarRol.aspx.cs" Inherits="Web.AsignarRol" %>


<asp:Content ID="Content5" ContentPlaceHolderID="head" runat="server">    

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="server">
    <h3 style="position: relative; top: 140px; right: -50%;">Asignar rol a usuario</h3>
    <div class="form-group" style="position:relative; top:160px; right:-40%; height:500px; width:500px" >
        <div class="col-sm-10 col-md-10 col-lg-10">
        <label for="ddlUsuario" class="col-sm-2 col-md-2 col-lg-2 control-label">Usuario</label>
        <asp:DropDownList ID="ddlUsuario" CssClass="form-control required" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged"/>
        </div>
        <div class="col-sm-10 col-md-10 col-lg-10">
            <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Rol</label>
            <asp:DropDownList ID="ddlRol" CssClass="form-control required" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged" />
        </div>
        <div class="col-sm-10 col-md-10 col-lg-10">
            <div style="position:relative; top:50px;right: -82%;">
                <asp:Button ID="btnGuardar" CssClass="btn btn-success btn-lg" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
            </div>
        </div>
    </div>
</asp:Content>