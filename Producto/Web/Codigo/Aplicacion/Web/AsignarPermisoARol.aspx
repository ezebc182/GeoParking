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
            <asp:DropDownList ID="ddlRol" CssClass="form-control required" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged">
            </asp:DropDownList>

        </div>
        <div class="col-sm-10 col-md-10 col-lg-10">
            <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Permisos</label>
            <div style="position: relative;top: 25px;">
                <asp:CheckBoxList ID="cblPermiso" runat="server">
            </asp:CheckBoxList>
            </div>
        </div>

     </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
