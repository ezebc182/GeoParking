<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Web2.Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/bootstrapformhelpers/css/bootstrap-formhelpers.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Estadisticas</h3>
        </div>
        <div class="panel-body">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-lg-2">
                            <h3 class="panel-title">Historico</h3>
                        </div>
                        <div class="col-lg-2">

                            <select id="ddlBuscarPor"></select>
                        </div>
                        <div class="col-lg-4">
                            <div class="col-lg-3">
                                <label class="control-label">Desde:</label>
                            </div>
                            <div class="col-lg-7 pul-left">
                                <div class="bfh-datepicker" data-placeholder="Fecha Desde" data-min="01/15/2013" data-max="today"></div>
                            </div>

                        </div>
                        <div class="col-lg-4">
                            <div class="col-lg-3">
                                <label class="control-label">Hasta:</label>
                            </div>
                            <div class="col-lg-7 pull-left">
                                <div class="bfh-datepicker" data-placeholder="Fecha Hasta" data-min="01/15/2013" data-max="today"></div>
                            </div>
                            <div class="pull-right"><i id="minMax" class="fa fa-minus-square-o fa-lg"></i></div>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    algo 2
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="js/bootstrapformhelpers/js/bootstrap-formhelpers.js"></script>
    <script>
        $(document).ready(function () {
            $('#minMax').on('click', function () {
                var $heading = $(this).parents('.panel-heading');
                var $content = $heading.next();

                $content.slideToggle(500, function () {
                    if ($content.is(":visible")) {
                        $heading.find('#minMax').removeClass('fa-square-o').addClass('fa-minus-square-o');
                    }
                    else {
                        $heading.find('#minMax').removeClass('fa-minus-square-o').addClass('fa-square-o');
                    }
                    });
            });
        });

    </script>
</asp:Content>
