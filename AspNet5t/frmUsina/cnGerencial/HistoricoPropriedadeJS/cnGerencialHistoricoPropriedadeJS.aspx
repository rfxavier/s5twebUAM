<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnGerencialHistoricoPropriedadeJS.aspx.vb" Inherits="AspNet5t.cnGerencialHistoricoPropriedadeJS" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <%: Styles.Render("~/Content/dxcss4Tcengerencial")%>

    <%: Styles.Render("~/Content/csspagehistprop")%>
    
    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
    </script>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>

     <%: Scripts.Render("~/bundles/dx4Tcengerencial")%>
    
     <%: Scripts.Render("~/bundles/app4Thistprop") %>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div ng-app="app4T" ng-controller="historicoProdutivCtrl as ctrl" ng-cloak>
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <h3 class="panel-title historico-safra">Safra {{numeroSafraAtual}}</h3>
                    </div>
                    <div class="col-xs-6 text-center">
                        <h4>{{nomePropriedadeAtualDisplay}}</h4>
                    </div>
                    <div class="col-xs-3">
                        <a ng-href='' class="btn btn-success outra-propriedade-btn btn-sm text-right outra-propriedade" ng-click='resetPropriedade()' ng-if="lookupPropriedadeAtual">Escolher outra propriedade</a>
                    </div>
                </div>
            </div>
            <div class="panel-body">

                <div class="row" data-ng-show="!lookupPropriedadeAtual">
                    <div class="col-xs-12 text-center">
                        <h3>Safra</h3>
                    </div>
                    <div class="col-xs-12 text-center">
                        <div data-dx-select-box="selboxSafraOptions" class="center-widget">
                            <div data-options="dxTemplate: { name: 'item' }">
                                <div style="font-size: 24px;">{{SAFRA}}</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 text-center">
                        <h3>Propriedade</h3>
                    </div>
                    <div class="col-xs-12">
                        <div data-dx-lookup="lookupPropOptions" class="center-widget">
                            <div data-options="dxTemplate: { name: 'item' }" class="propriedade-template">
                                <p>{{COD_PROPRIEDADE}}{{DSC_PROPRIEDADE_DISP}}</p>
                            </div>
                            <div data-options="dxTemplate: { name: 'codigo' }" class="propriedade-template">
                                <p>{{DSC_PROPRIEDADE}} ({{COD_PROPRIEDADE}})</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 text-center">
                        <h6 class="modo-pesquisa">modo de pesquisa</h6>
                    </div>
                    <div class="col-xs-12 text-center">
                        <div data-dx-switch="switchPesquisaOptions"></div>
                    </div>
                    <div class="col-xs-12 text-center">&nbsp;</div>
                    <div class="col-xs-12 text-center">&nbsp;</div>
                </div>
                <div class="row" data-ng-if="lookupPropriedadeAtual">
                    <div class="col-xs-4">
                        <div id="mapaPropriedadeContainer" style="height: 240px; width: 280px;" data-dx-vector-map="mapaPropriedadeOptions"></div>
                    </div>
                    <div class="col-xs-2">
                        <div id="gridAmbientesContainer" data-dx-data-grid="gridAmbientesOptions">
                        </div>
                    </div>
                    <div class="col-xs-2">
                        <div id="gridMaturacoesContainer" data-dx-data-grid="gridMaturacoesOptions">
                        </div>
                    </div>
                    <div class="col-xs-2">
                        <div id="gridVariedadesContainer" data-dx-data-grid="gridVariedadesOptions">
                        </div>
                    </div>
                    <div class="col-xs-2">
                        <div id="gridCortesContainer" data-dx-data-grid="gridCortesOptions">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div data-dx-tab-panel="tabPanelOptions">
                                <div data-options="dxTemplate : { name: 'title' } ">
                                    <h6>{{title}}</h6>
                                </div>
                                <div data-options="dxTemplate : { name: 'tabPlantio' } ">
                                    <div class="dx-widget dx-visibility-change-handler dx-pivotgrid dx-row-lines" style="width: 860px;">
                                        <div>
                                            <table onclick="void(0)" style="width: 100%;">
                                                <tbody>
                                                    <tr>
                                                        <td class="dx-area-description-cell historico-plantio-header">
                                                            <div style="text-align: center;">Histórico de Plantio</div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>

                                    <div data-dx-pivot-grid="pivotPlantiosOptions"></div>
                                </div>
                                <div data-options="dxTemplate : { name: 'tabProducao' } ">
                                    <div class="dx-datagrid dx-datagrid-borders" style="max-width: 855px;">
                                        <div class="dx-datagrid-headers dx-datagrid-nowrap" style="padding-right: 0px;">
                                            <div class="dx-datagrid-content dx-datagrid-scroll-container">
                                                <table class="dx-datagrid-table dx-datagrid-table-fixed" role="grid" onclick="void(0)">
                                                    <colgroup>
                                                        <col style="width: 855px;">
                                                    </colgroup>
                                                    <tbody>
                                                        <tr class="dx-row dx-column-lines dx-header-row historico-produtividade-header" role="row" onclick="void(0)">
                                                            <td role="columnheader" aria-label="Corte Column" aria-sort="none" class="dx-cell-focus-disabled" style="text-align: center;">
                                                                <div class="dx-datagrid-text-content">Histórico de Produtividade</div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div data-dx-data-grid="gridProducaoTonsHaOptions"></div>
                                    <div class="cana-entregue-grid">
                                        <div data-dx-data-grid="gridProducaoCanasEntreguesOptions"></div>
                                    </div>
                                    <div class="resumo-producao-grid">
                                        <div class="dx-datagrid dx-datagrid-borders" style="max-width: 855px;">
                                            <div class="dx-datagrid-headers dx-datagrid-nowrap" style="padding-right: 0px;">
                                                <div class="dx-datagrid-content dx-datagrid-scroll-container">
                                                    <table class="dx-datagrid-table dx-datagrid-table-fixed" role="grid" onclick="void(0)">
                                                        <colgroup>
                                                            <col style="width: 855px;">
                                                        </colgroup>
                                                        <tbody>
                                                            <tr class="dx-row dx-column-lines dx-header-row" role="row" onclick="void(0)">
                                                                <td role="columnheader" aria-label="Ambiente Column" aria-sort="none" class="dx-cell-focus-disabled" style="text-align: center;">
                                                                    <div class="dx-datagrid-text-content">Resumo - Safra {{numeroSafraAtual}}</div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>

                                        <div data-dx-data-grid="gridProducaoResumoAmbientesOptions"></div>
                                    </div>
                                </div>
                                <div data-options="dxTemplate : { name: 'tabTratosCulturais' } ">
                                    <div class="row"></div>
                                    <div class="row">
                                        <div class="col-xs-4">
                                            <div class="form-group subgrupo-agricola">
                                                <label for="subgragr">SubGrupo Agrícola</label>
                                                <div data-dx-select-box="selboxSubGruposAgricolasOptions" id="subgragr"></div>
                                            </div>
                                        </div>
                                        <div class="col-xs-8"></div>
                                    </div>
                                    <div class="dx-datagrid dx-datagrid-borders" style="max-width: 860px;">
                                        <div class="dx-datagrid-headers dx-datagrid-nowrap" style="padding-right: 0px;">
                                            <div class="dx-datagrid-content dx-datagrid-scroll-container">
                                                <table class="dx-datagrid-table dx-datagrid-table-fixed" role="grid" onclick="void(0)">
                                                    <colgroup>
                                                        <col style="width: 860px;">
                                                    </colgroup>
                                                    <tbody>
                                                        <tr class="dx-row dx-column-lines dx-header-row" role="row" onclick="void(0)">
                                                            <td role="columnheader" aria-label="0 Column" aria-sort="none" class="dx-cell-focus-disabled" style="text-align: center;">
                                                                <div class="dx-datagrid-text-content">Histórico de Tratos Culturais (% de Área Aplicada)</div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="dx-datagrid dx-datagrid-borders" style="max-width: 860px;">
                                        <div class="dx-datagrid-headers dx-datagrid-nowrap" style="padding-right: 0px;">
                                            <div class="dx-datagrid-content dx-datagrid-scroll-container">
                                                <table class="dx-datagrid-table dx-datagrid-table-fixed" role="grid" onclick="void(0)">
                                                    <colgroup>
                                                        <col style="width: 30px;">
                                                        <col style="width: 280px;">
                                                        <col style="width: 550px;">
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

                                    <div data-dx-data-grid="gridTratosCulturaisOptions">
                                    </div>
                                </div>

                                <div data-options="dxTemplate : { name: 'tabNaoConformidades' } ">
                                    <div class="dx-datagrid dx-datagrid-borders" style="max-width: 855px;">
                                        <div class="dx-datagrid-headers dx-datagrid-nowrap" style="padding-right: 0px;">
                                            <div class="dx-datagrid-content dx-datagrid-scroll-container">
                                                <table class="dx-datagrid-table dx-datagrid-table-fixed" role="grid" onclick="void(0)">
                                                    <colgroup>
                                                        <col style="width: 855px;">
                                                    </colgroup>
                                                    <tbody>
                                                        <tr class="dx-row dx-column-lines dx-header-row historico-produtividade-header" role="row" onclick="void(0)">
                                                            <td role="columnheader" aria-label="Corte Column" aria-sort="none" class="dx-cell-focus-disabled" style="text-align: center;">
                                                                <div class="dx-datagrid-text-content">Histórico de Não Conformidades</div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div data-dx-data-grid="gridNaoConformidadesOptions"></div>
                                </div>

                                <div data-options="dxTemplate : { name: 'tabDiagnosticoColheita' } ">
                                    <div class="dx-datagrid dx-datagrid-borders" style="max-width: 855px;">
                                        <div class="dx-datagrid-headers dx-datagrid-nowrap" style="padding-right: 0px;">
                                            <div class="dx-datagrid-content dx-datagrid-scroll-container">
                                                <table class="dx-datagrid-table dx-datagrid-table-fixed" role="grid" onclick="void(0)">
                                                    <colgroup>
                                                        <col style="width: 855px;">
                                                    </colgroup>
                                                    <tbody>
                                                        <tr class="dx-row dx-column-lines dx-header-row historico-produtividade-header" role="row" onclick="void(0)">
                                                            <td role="columnheader" aria-label="Corte Column" aria-sort="none" class="dx-cell-focus-disabled" style="text-align: center;">
                                                                <div class="dx-datagrid-text-content">Diagnóstico Colheita</div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div data-dx-data-grid="gridDiagnosticoColheitaOptions"></div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
