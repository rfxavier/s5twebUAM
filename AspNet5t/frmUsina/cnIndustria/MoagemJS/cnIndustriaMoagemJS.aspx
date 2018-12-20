<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnIndustriaMoagemJS.aspx.vb" Inherits="AspNet5t.cnIndustriaMoagemJS" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <%: Styles.Render("~/Content/dxcss4Tcenindustriamoagem")%>

    <%: Styles.Render("~/Content/csspageindustriamoagem")%>
    
    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
    </script>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>

    <%: Scripts.Render("~/bundles/dx4Tcenindustriamoagem")%>
    
    <%: Scripts.Render("~/bundles/app4Tindustriamoagem") %>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div ng-app="app4T" ng-controller="industriamoagemCtrl as ctrl" ng-cloak>
        <div class="panel panel-default">
            <div data-dx-load-panel="loadOptions"></div>
            
            <div data-dx-popup="popupOptions">
                <div data-options="dxTemplate: { name:'info' }">
                    <div class="dx-fieldset">
                        <div class="dx-field">
                            <div class="dx-field-label">Ligada</div>
                            <div class="dx-field-value">
                                <div data-dx-check-box="checkBoxAutoRefreshOptions"></div>
                            </div>
                        </div>
                        <div class="dx-field">
                            <div class="dx-field-label">Segundos</div>
                            <div class="dx-field-value">
                                <div data-dx-number-box="numberBoxAutoRefreshOptions"></div>
                            </div>
                        </div>
                        <div class="dx-field">
                            <div class="dx-field-label"></div>
                            <div class="dx-field-value">
                                <div data-dx-button="buttonOkAutoRefreshOptions"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>    

            <div class="panel-heading">
                <div class="row">
                    <h3 style="float: left; margin-top: 10px;" class="panel-title">Indústria - Moagem</h3>
                    
                    <div style="float: right;" data-dx-button="buttonHomeOptions"></div>
                    <div style="float: right;" data-dx-button="buttonVisaoGeralOptions"></div>
                    <div style="float: right;" data-dx-date-box="dateBoxOptions"></div>  
                    <span data-ng-show="!(visaoGeralButtonVisible || homeButtonVisible)" style="float: right; margin-top: 10px; font-weight: bold">Dia Referência:&nbsp;</span>
                    <span data-ng-show="visaoGeralButtonVisible || homeButtonVisible" style="float: right; margin-top: 10px; font-weight: bold">Dia Referência:&nbsp;{{visaoGeralDiaDisplay}}&nbsp;&nbsp;</span>
                    <span style="float: right;">&nbsp;&nbsp;</span>
                    <div style="float: right;" data-dx-button="buttonAutoRefreshOptions"></div>
                </div>
            </div>

            <div class="panel-body">
                <div data-ng-show="visaoGeral()">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-chart="chartVisaoGeralDiaOptions">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-chart="chartVisaoGeralSemanaOptions">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-chart="chartVisaoGeralMesOptions">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-chart="chartVisaoGeralSafraOptions">
                            </div>
                        </div>
                    </div>
                </div>
                
                <div data-ng-show="filtroPeriodoDia()">
                    <div data-dx-chart="chartDiaOptions"></div>

                    <div class="row">
                        <div class="col-xs-4 text-center">
                            <div data-dx-button="buttonDiaValoresPontuaisOptions"></div>
                            <div data-dx-button="buttonDiaValoresAcumuladosOptions"></div>
                        </div>
                        <div class="col-xs-2 text-center">
                            <div data-ng-show="visaoGeralHoraAnterior() !== '-1'" class="mediamoagem">Média moagem até {{visaoGeralHoraAnterior()}} hrs:</div>
                            <div data-ng-show="visaoGeralHoraAnterior() !== '-1'" class="mediamoagembold">{{mediaMoagemHoraAnterior}}</div>
                        </div>
                        <div class="col-xs-2 text-center">
                            <div class="mediamoagem">Estoque Pátio</div>
                            <div class="mediamoagembold">{{estoquePatio}}</div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-button="buttonDiaMoendaGeralOptions"></div>
                            <div data-dx-button="buttonDiaMoendaAOptions"></div>
                            <div data-dx-button="buttonDiaMoendaBOptions"></div>
                        </div>
                    </div>
                    <div data-dx-data-grid="gridDiaOptions"></div>
                    <div class="foradogrid">Hora Atual: {{visaoGeralHora}}</div>
                    <div data-dx-data-grid="gridDiaProjecaoOptions"></div>
                    <div class="foradogrid">Passo: {{passoDia}}</div>
                    
                </div>
                
                <div data-ng-show="filtroPeriodoSemana()">
                    <div data-dx-chart="chartSemanaOptions"></div>
                    <div class="row">
                        <div class="col-xs-6 text-center">
                            <div data-dx-button="buttonSemanaValoresPontuaisOptions"></div>
                            <div data-dx-button="buttonSemanaValoresAcumuladosOptions"></div>
                        </div>

                        <div class="col-xs-6 text-center">
                            <div data-dx-button="buttonSemanaMoendaGeralOptions"></div>
                            <div data-dx-button="buttonSemanaMoendaAOptions"></div>
                            <div data-dx-button="buttonSemanaMoendaBOptions"></div>
                        </div>
                    </div>

                    <div data-dx-data-grid="gridSemanaOptions"></div>
                    <%--<div data-dx-data-grid="gridSemanaProjecaoOptions"></div>--%>
                </div>
                
                <div data-ng-show="filtroPeriodoMes()">
                    <div data-dx-chart="chartMesOptions"></div>
                    
                    <div class="row">
                        <div class="col-xs-6 text-center">
                            <div data-dx-button="buttonMesValoresPontuaisOptions"></div>
                            <div data-dx-button="buttonMesValoresAcumuladosOptions"></div>
                        </div>

                        <div class="col-xs-6 text-center">
                            <div data-dx-button="buttonMesMoendaGeralOptions"></div>
                            <div data-dx-button="buttonMesMoendaAOptions"></div>
                            <div data-dx-button="buttonMesMoendaBOptions"></div>
                        </div>
                    </div>

                    <div data-dx-data-grid="gridMesOptions"></div>
                </div>

                <div data-ng-show="filtroPeriodoSafra()">
                    <div data-dx-chart="chartSafraOptions"></div>
                    
                    <div class="row">
                        <div class="col-xs-6 text-center">
                            <div data-dx-button="buttonSafraValoresPontuaisOptions"></div>
                            <div data-dx-button="buttonSafraValoresAcumuladosOptions"></div>
                        </div>

                        <div class="col-xs-6 text-center">
                            <div data-dx-button="buttonSafraMoendaGeralOptions"></div>
                            <div data-dx-button="buttonSafraMoendaAOptions"></div>
                            <div data-dx-button="buttonSafraMoendaBOptions"></div>
                        </div>
                    </div>

                    <div data-dx-data-grid="gridSafraOptions"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
