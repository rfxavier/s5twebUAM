<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnGerencialControleBrocaJS.aspx.vb" Inherits="AspNet5t.cnGerencialControleBrocaJS" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <%: Styles.Render("~/Content/dxcss4Tcengerencial")%>

    <%: Styles.Render("~/Content/csspagectrlbroca")%>

    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
        var tipoPraga = "<%=tipoPraga%>";
    </script>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>

     <%: Scripts.Render("~/bundles/dx4Tcengerencial")%>

     <%: Scripts.Render("~/bundles/app4Tctrlpragas") %>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div ng-app="app4T" ng-controller="controleBrocasCtrl as ctrl" ng-cloak>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Mapa de Controle de {{tipoPragaDisplay}} Safra {{numeroSafraAtual}}</h3>
            </div>
            <div class="panel-body panel-principal">
                <div class="row">
                    <div class="col-xs-3">
                        <div dx-button="propriedadePopOverOptions" ng-show="codigoPropriedade" id="popoverButton"></div>
                        <div dx-button="selecionePropriedadeOptions" ng-show="!codigoPropriedade"></div>
                    </div>
                    <div class="col-xs-1 text-right safra-caption">
                        <span>Safra:</span>
                    </div>
                    <div class="col-xs-2">
                        <div data-dx-select-box="selboxSafraOptions">
                        </div>
                    </div>
                    <div class="col-xs-6 legenda-caption">
                        <div class='my-legend'>
                            <div class='legend-scale'>
                                <ul class='legend-labels'>
                                    <li><span style='background: rgba(252, 255, 0, 0.4);'></span>Propriedade de Fornecedores</li>
                                </ul>
                            </div>
                        </div>
                    </div>

                    <div dx-popover="popOverOptions">
                        <div data-options="dxTemplate: { name:'title' }">
                            <div class="popover-title">
                                <div class="text-center">
                                    <h5 class="popup-titulo">Controle de Infestação de {{tipoPragaDisplay}} Safra {{numeroSafraAtual}} (% de Área Aplicada)</h5>
                                </div>
                                <div class="text-center">
                                    <b>{{percInfestacaoSafraAnteriorTextoDisplay}}<span class="perc-infestacao-numero">{{percInfestacaoSafraAnterior}}</span></b>
                                </div>
                            </div>
                        </div>
                        <div data-options="dxTemplate: { name: 'popoverContent' }">

                            <div class="dx-datagrid dx-datagrid-borders" style="max-width: 720px;">
                                <div class="dx-datagrid-headers dx-datagrid-nowrap" style="padding-right: 0px;">
                                    <div class="dx-datagrid-content dx-datagrid-scroll-container">
                                        <table class="dx-datagrid-table dx-datagrid-table-fixed" role="grid" onclick="void(0)">
                                            <colgroup>
                                                <col style="width: 30px;">
                                                <col style="width: 195px;">
                                                <col style="width: 495px;">
                                                <col style="width: auto;">
                                            </colgroup>
                                            <tbody>
                                                <tr class="dx-row dx-column-lines dx-header-row tratos-header-row" role="row" onclick="void(0)">
                                                    <td role="gridcell" class="dx-command-expand dx-datagrid-group-space dx-cell-focus-disabled" style="text-align: left;">&nbsp;</td>
                                                    <td role="columnheader" aria-label="Tipo Column" aria-sort="none" class="dx-cell-focus-disabled" style="text-align: left;">
                                                        <div class="dx-datagrid-text-content"></div>
                                                    </td>
                                                    <td role="columnheader" aria-label="0 Column" aria-sort="none" class="dx-cell-focus-disabled" style="text-align: center;">
                                                        <div class="dx-datagrid-text-content">Número da Aplicação</div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>


                            <div id="gridBrocasContainer" data-dx-data-grid="gridBrocasOptions"></div>
                            <div ng-show="gridBrocasExpCount"><span class="reforma-legenda">*RC - Reforma Confirmada / RP - Reforma Planejada</span></div>
                        </div>
                    </div>
                </div>
                <div class="row panel-principal">
                    <div id="mapaPropriedadeContainer" data-dx-vector-map="mapaPropriedadeOptions"></div>
                </div>
            </div>
        </div>

        <div class="loadpanel" dx-load-panel="loadOptions"></div>
    </div>
</asp:Content>
