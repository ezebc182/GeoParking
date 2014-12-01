<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Ayuda.aspx.cs" Inherits="Web2.Ayuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="width: 100%; height: auto;">
        <div class="page-header">
            <h2>Sección FAQ's</h2>
        </div>
        <div class="col-md-3 col-lg-3 col-xs-3 col-sm-3">
            <div class="well">
                <!-- List group -->
                <div class="list-group">
                    <h3>Lista de contenido</h3>
                    <a href="#" class="list-group-item active">
                        <h5 class="list-group-item-heading"><span class="glyphicon glyphicon-user"></span>&nbsp;Cuentas de usuario</h5>
                        <p class="list-group-item-text">...</p>
                    </a>
                     <a href="#" class="list-group-item ">
                        <h5 class="list-group-item-heading">List group item heading</h5>
                        <p class="list-group-item-text">...</p>
                    </a>
                     <a href="#" class="list-group-item ">
                        <h5 class="list-group-item-heading">List group item heading</h5>
                        <p class="list-group-item-text">...</p>
                    </a>
                </div>
            </div>
          
        </div>
        <div class="col-md-9 col-lg-9 col-xs-9 col-sm-9">
            <div class="panel panel-collapse">
                <div class="panel-heading">
                    <p>TITULO MUNDO</p>
                </div>
                <div class="panel-body">
                    <p>HOLA MUNDO</p>
                </div>
                <div class="panel-footer">
                    <p>HOLA MUNDO</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="helpContent" runat="server">
</asp:Content>
