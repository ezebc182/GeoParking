<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMRol.aspx.cs" Inherits="Web.ABMRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="position: relative; top: 140px; right: -50%;">Nuevo Rol</h3>
     
    
    <div class="form-group" style="position:relative; top:160px; right:-40%; height:500px; width:500px" >
        <div class="col-sm-10 col-md-10 col-lg-10">

            </div>
        <div id="divNombre"  class="form-group col-sm-10 col-md-10 col-lg-10" style="position:relative;">
            <label for="txtNombre" class="col-sm-2 col-md-2 col-lg-2 control-label">Nombre</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" TabIndex="1" data-bv-notempty="true" data-bv-notempty-message="El nombre es requerido."></asp:TextBox>
        </div>

        <div id="divDescripcion" class="form-group col-sm-10 col-md-10 col-lg-10" style="position:relative; top:10px;">
            <label for="txtNombre" class="col-sm-2 col-md-2 col-lg-2 control-label">Descripcion</label>
            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" TabIndex="2" data-bv-notempty="true" data-bv-notempty-message="El nombre es requerido."></asp:TextBox>
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


