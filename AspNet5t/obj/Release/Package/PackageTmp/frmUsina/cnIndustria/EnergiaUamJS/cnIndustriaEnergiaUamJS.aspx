<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnIndustriaEnergiaUamJS.aspx.vb" Inherits="AspNet5t.cnIndustriaEnergiaUamJS" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <%: Styles.Render("~/Content/dxcss4Tcenindustriaenergiauam")%>

    <%: Styles.Render("~/Content/csspageindustriaenergiauam")%>
    
    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
    </script>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>

    <%: Scripts.Render("~/bundles/dx4Tcenindustriaenergiauam")%>
    
    <%: Scripts.Render("~/bundles/app4Tindustriaenergiauam") %>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div ng-app="app4T" ng-controller="industriaenergiauamCtrl as ctrl" ng-cloak>
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
                    <h3 style="float: left; margin-top: 10px;" class="panel-title">Indústria - Exportação UAM</h3>
                    
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
                        <div class="col-xs-6 text-center">
                            <div data-dx-button="buttonDiaValoresPontuaisOptions"></div>
                            <div data-dx-button="buttonDiaValoresAcumuladosOptions"></div>
                        </div>
                        <div class="col-xs-6 text-center">
                            <div data-ng-show="visaoGeralHoraAnterior() !== '-1'" class="mediamoagem">Média até {{visaoGeralHoraAnterior()}} hrs:</div>
                            <div data-ng-show="visaoGeralHoraAnterior() !== '-1'" class="mediamoagembold">{{mediaHoraAnterior}}</div>
                        </div>
                    </div>
                    <div data-dx-data-grid="gridDiaOptions"></div>
                    <div class="foradogrid">Hora Atual: {{visaoGeralHora}}</div>
                </div>
                
                <div data-ng-show="filtroPeriodoSemana()">
                    <div data-dx-chart="chartSemanaOptions"></div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonSemanaValoresPontuaisOptions"></div>
                            <div data-dx-button="buttonSemanaValoresAcumuladosOptions"></div>
                        </div>
                    </div>

                    <div data-dx-data-grid="gridSemanaOptions"></div>
                </div>
                
                <div data-ng-show="filtroPeriodoMes()">
                    <div data-dx-chart="chartMesOptions"></div>
                    
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonMesValoresPontuaisOptions"></div>
                            <div data-dx-button="buttonMesValoresAcumuladosOptions"></div>
                        </div>
                    </div>

                    <div data-dx-data-grid="gridMesOptions"></div>
                </div>

                <div data-ng-show="filtroPeriodoSafra()">
                    <div data-dx-chart="chartSafraOptions"></div>
                    
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonSafraValoresPontuaisOptions"></div>
                            <div data-dx-button="buttonSafraValoresAcumuladosOptions"></div>
                        </div>
                    </div>

                    <div data-dx-data-grid="gridSafraOptions"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
