<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMRol.aspx.cs" Inherits="Web.ABMRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="position: relative; top: 140px; right: -50%;">Rol</h3>
     
    
    <div class="form-group" style="position:relative; top:160px; right:-40%; height:500px; width:500px" >
        <div class="col-sm-10 col-md-10 col-lg-10">

            </div>
        <div class="col-sm-10 col-md-10 col-lg-10">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" TabIndex="1"></asp:TextBox>
            <div class="col-sm-10 col-md-10 col-lg-10" id="divDescripcion">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" TabIndex="2"></asp:TextBox>
                </div>
        </div>
           <div class="col-sm-10 col-md-10 col-lg-10">
            <div style="position:relative; top:50px;right: -82%;">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success btn-lg" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
          </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>


