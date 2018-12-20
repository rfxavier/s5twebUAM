<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnAgricolaColheitaJS.aspx.vb" Inherits="AspNet5t.cnAgricolaColheitaJS" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <%: Styles.Render("~/Content/dxcss4Tcenagricolacolheita")%>

    <%: Styles.Render("~/Content/csspageagricolacolheita")%>
    
    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
    </script>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>

    <%: Scripts.Render("~/bundles/dx4Tcenagricolacolheita")%>
    
    <%: Scripts.Render("~/bundles/app4Tagricolacolheita") %>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div ng-app="app4T" ng-controller="agricolacolheitaCtrl as ctrl" ng-cloak>
        <div class="panel panel-default">
            <div data-dx-load-panel="loadOptions"></div>
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-12">
                        <h3 class="panel-title">Entrega de Cana</h3>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <div id="tabFiltroPeriodo" data-dx-tabs="tabFiltroPeriodoOptions">
                            
                        </div>                        
                    </div>
                </div>

                <div class="row" data-ng-show="filtroPeriodoDia()">
                    <div class="col-xs-6 text-center">
                        <div data-dx-chart="chartEntregaCanaPorDiaOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-6 text-center">
                        <div data-dx-chart="chartDensidadeCargaPorDiaOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-6 text-center">
                        <span>Entrega Acumulada: {{entregaAcumuladaDisplay}} Ton/h</span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <span>Densidade: {{densidadeAtualDisplay}} Ton/viagem</span>
                    </div>
                </div>


                <div class="row" data-ng-show="filtroPeriodoSemana()">
                    <div class="col-xs-6 text-center">
                        <div data-dx-chart="chartEntregaCanaPorSemanaOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-6 text-center">
                        <div data-dx-chart="chartDensidadeCargaPorSemanaOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-6 text-center">
                        <span>Entrega Acumulada: {{entregaAcumuladaDisplay}} Ton/h</span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <span>Densidade: {{densidadeAtualDisplay}} Ton/viagem</span>
                    </div>
                </div>
                
                <div class="row" data-ng-show="filtroPeriodoMes()">
                    <div class="col-xs-6 text-center">
                        <div data-dx-chart="chartEntregaCanaPorMesOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-6 text-center">
                        <div data-dx-chart="chartDensidadeCargaPorMesOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-6 text-center">
                        <span>Entrega Acumulada: {{entregaAcumuladaDisplay}} Ton/h</span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <span>Densidade: {{densidadeAtualDisplay}} Ton/viagem</span>
                    </div>
                </div>

                <div class="row" data-ng-show="filtroPeriodoSafra()">
                    <div class="col-xs-6 text-center">
                        <div data-dx-chart="chartEntregaCanaPorSafraOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-6 text-center">
                        <div data-dx-chart="chartDensidadeCargaPorSafraOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-6 text-center">
                        <span>Entrega Acumulada: {{entregaAcumuladaDisplay}} Ton/h</span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <span>Densidade: {{densidadeAtualDisplay}} Ton/viagem</span>
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <div id="tabFrEntCana" data-dx-tabs="tabFiltroFrentesEntregaCanaOptions">
                        </div>                        
                    </div>

                    <div class="col-xs-6 text-center">
                        <div id="tabFrDensCarga" data-dx-tabs="tabFiltroFrentesDensidadeCargaOptions">
                        </div>
                    </div>
                </div>
                
                <div class="row" data-ng-show="filtroPeriodoDiaFrente()">
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartImpurezaVegetalPorDiaOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartImpurezaMineralPorDiaOptions">
                        </div>                        
                    </div>
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartVelocidadeMediaPorDiaOptions">
                        </div>                        
                    </div>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
