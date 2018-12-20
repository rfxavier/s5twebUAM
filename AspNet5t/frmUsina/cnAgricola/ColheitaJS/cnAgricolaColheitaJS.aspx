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
                    <h3 style="float: left; margin-top: 10px;" class="panel-title">&nbsp;&nbsp;KPIs Colheita - Produção</h3>

                    <div data-ng-show="seltabFiltroPeriodo == 0" style="float: right;" data-dx-date-box="dateBoxOptions"></div>  
                    <span data-ng-show="seltabFiltroPeriodo == 0" style="float: right; margin-top: 10px; font-weight: bold">Dia Referência:&nbsp;</span>
                    <span data-ng-show="seltabFiltroPeriodo !== 0" style="float: right; margin-top: 10px; font-weight: bold">Dia Referência:&nbsp;{{visaoGeralDiaMaxDisplay}}&nbsp;&nbsp;</span>

                    <span style="float: right;">&nbsp;&nbsp;</span>
                    <div style="float: right;" data-dx-button="buttonAutoRefreshOptions"></div>
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
                    <div class="col-xs-2 text-center">
                        <span class="entregacanatotais">Entrega Planejada Total<br/>{{entregaPlanejadaTotalDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Entrega Planejada<br/>Até {{horaAtual}} h<br/>{{entregaPlanejadaAcumuladaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Entrega Real<br/>Até {{horaAtual}} h<br/>{{entregaAcumuladaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Desvio<br/>{{desvioDisplay}} %</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Média/hora<br/>{{mediaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <span class="entregacanatotais">Densidade média no dia<br/>{{densidadeAtualDisplay}} Ton/viagem</span>
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
                    <div class="col-xs-2 text-center">
                        <span class="entregacanatotais">Entrega Planejada Total<br/>{{entregaPlanejadaTotalDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Entrega Planejada<br/>{{entregaPlanejadaAcumuladaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Entrega Real<br/>{{entregaAcumuladaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Desvio<br/>{{desvioDisplay}} %</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Média/dia<br/>{{mediaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <span class="entregacanatotais">Densidade média na semana<br/>{{densidadeAtualDisplay}} Ton/viagem</span>
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
                    <div class="col-xs-2 text-center">
                        <span class="entregacanatotais">Entrega Planejada Total<br/>{{entregaPlanejadaTotalDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Entrega Planejada<br/>{{entregaPlanejadaAcumuladaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Entrega Real<br/>{{entregaAcumuladaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Desvio<br/>{{desvioDisplay}} %</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Média/semana<br/>{{mediaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <span class="entregacanatotais">Densidade média no mês<br/>{{densidadeAtualDisplay}} Ton/viagem</span>
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
                    <div class="col-xs-2 text-center">
                        <span class="entregacanatotais">Entrega Planejada Total<br/>{{entregaPlanejadaTotalDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Entrega Planejada<br/>{{entregaPlanejadaAcumuladaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Entrega Real<br/>{{entregaAcumuladaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Desvio<br/>{{desvioDisplay}} %</span>
                    </div>
                    <div class="col-xs-1 text-center">
                        <span class="entregacanatotais">Média/mês<br/>{{mediaDisplay}} Ton</span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <span class="entregacanatotais">Densidade média na safra<br/>{{densidadeAtualDisplay}} Ton/viagem</span>
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
                
                <div data-ng-show="filtroPeriodoDiaFrente()">
                    <div class="row">
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
                
                <div data-ng-show="filtroPeriodoSemanaFrente()">
                    <div class="row">
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartImpurezaVegetalPorSemanaOptions">
                            </div>                        
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartImpurezaMineralPorSemanaOptions">
                            </div>                        
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartVelocidadeMediaPorSemanaOptions">
                            </div>                        
                        </div>
                    </div>
                </div>

                <div data-ng-show="filtroPeriodoMesFrente()">
                    <div class="row">
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartImpurezaVegetalPorMesOptions">
                            </div>                        
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartImpurezaMineralPorMesOptions">
                            </div>                        
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartVelocidadeMediaPorMesOptions">
                            </div>                        
                        </div>
                    </div>
                </div>

                <div data-ng-show="filtroPeriodoSafraFrente()">
                    <div class="row">
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartImpurezaVegetalPorSafraOptions">
                            </div>                        
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartImpurezaMineralPorSafraOptions">
                            </div>                        
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartVelocidadeMediaPorSafraOptions">
                            </div>                        
                        </div>
                    </div>
                </div>

                <div data-ng-show="filtroFrente()">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonColhedoraFrenteOptions"></div>
                        </div>
                    </div>
                    <div class="row" data-ng-show="colhedoraFrenteMostrar">
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraVelColheitaOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraEquipProdOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraFaltaTratorOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraTempoAprovOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraAprovDistanciaOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraProdutividadeOptions"></div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonTratorFrenteOptions"></div>
                        </div>
                    </div>
                    <div class="row" data-ng-show="tratorFrenteMostrar">
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipTratorEquipProdOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipTratorFilaCarrOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipTratorFaltaCamOptions"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
