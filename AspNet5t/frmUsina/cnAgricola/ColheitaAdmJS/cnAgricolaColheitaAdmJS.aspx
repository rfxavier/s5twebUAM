<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnAgricolaColheitaAdmJS.aspx.vb" Inherits="AspNet5t.cnAgricolaColheitaAdmJS" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <%: Styles.Render("~/Content/dxcss4Tcenagricolacolheitaadm")%>

    <%: Styles.Render("~/Content/csspageagricolacolheitaadm")%>

    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
    </script>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>

    <%: Scripts.Render("~/bundles/dx4Tcenagricolacolheitaadm")%>
    <%: Scripts.Render("~/bundles/app4Tagricolacolheitaadm") %>
    <script type="text/javascript">
        /* SCRIPT JQUERY PARA FIXAÇÃO DE ELEMENTO AO DAR SCROLL */
        $(window).scroll(function() {
            var panelBodyWidth = $('.panel-body').width();

            if ($(this).scrollTop() > 50) {
                $('.frenteClass').css({ 'position': 'fixed', 'top': '45px', 'z-index': 500, 'width': panelBodyWidth, 'background-color': '#fff' });
                $('.periodoClass').css({ 'position': 'fixed', 'top': '95px', 'z-index': 500, 'width': panelBodyWidth,'background-color': '#fff' });
            } else {
                $('.frenteClass').css({ 'position': 'relative', 'top': '0px', 'z-index': 500, 'width': '100%' });
                $('.periodoClass').css({ 'position': 'relative', 'top': '0px', 'z-index': 500, 'width': '100%' });
            }
        });
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div ng-app="app4T" ng-controller="agricolacolheitaAdmCtrl as ctrl" ng-cloak>
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
                    <h3 style="float: left; margin-top: 10px;" class="panel-title">&nbsp;&nbsp;KPIs Colheita - Administrativo</h3>

                    <div style="float: right;" data-dx-date-box="dateBoxOptions"></div>  
                    <span style="float: right; margin-top: 10px; font-weight: bold">Dia Referência:&nbsp;</span>

                    <span style="float: right;">&nbsp;&nbsp;</span>
                    <div style="float: right;" data-dx-button="buttonAutoRefreshOptions"></div>
                </div>
            </div>
            

            <div class="panel-body">
                <div class="containerFrente">
                    <div class="frenteClass">
                        <div id="tabFrEntCana" data-dx-tabs="tabFiltroFrentesOptions">
                        </div>                        
                    </div>
                </div>

                <div class="containerPeriodo">
                    <div class="periodoClass">
                        <div id="tabFiltroPeriodo" data-dx-tabs="tabFiltroPeriodoOptions">
                            
                        </div>                        
                    </div>
                </div>
                

                <div data-ng-show="frentesColheita">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonColhedoraFrenteOptions"></div>
                        </div>
                    </div>
                    <div class="row" data-ng-show="colhedoraFrenteMostrar">
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraMotorOciosoOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraPilotoAutomaticoOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraConsumoOleoHidraulicoOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraConsumoOleoDieselOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <div data-dx-chart="chartEquipColhedoraColheitabilidadeOptions"></div>
                        </div>
                        <div class="col-xs-4 text-center">
                            <%--<div data-dx-circular-gauge="gaugeEquipColhedoraEquipamentosOnlineOptions"></div>--%>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonTratorFrenteOptions"></div>
                        </div>
                    </div>
                    <div class="row" data-ng-show="tratorFrenteMostrar">
                        <div class="col-xs-6 text-center">
                            <div data-dx-chart="chartEquipTratorMotorOciosoOptions"></div>
                        </div>
                        <div class="col-xs-6 text-center">
                            <div data-dx-chart="chartEquipTratorConsumoOleoDieselOptions"></div>
                        </div>
                    </div>

<%--                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonCaminhaoFrenteOptions"></div>
                        </div>
                    </div>
                    <div class="row" data-ng-show="caminhaoFrenteMostrar">
                        <div class="col-xs-6 text-center">
                            <div data-dx-circular-gauge="gaugeEquipCaminhaoQuantidadeOptions"></div>
                        </div>
                        <div class="col-xs-6 text-center">
                            <div data-dx-circular-gauge="gaugeEquipCaminhaoTempoMedioPermanenciaOptions"></div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonInfoFrenteOptions"></div>
                        </div>
                    </div>
                    <div data-ng-show="infoFrenteMostrar">
                        <div style="width:100%">
                            <table class="tg">
                                <tr>
                                    <th class="tg-5mgg">Colhedoras em propriedade<br />sem talhão liberado</th>
                                    <th class="tg-5mgg">Frotas sem implemento</th>
                                    <th class="tg-5mgg">Propriedade com projeto<br />sem ativação ES</th>
                                </tr>
                                <tr>
                                    <td class="tg-yw4l">{{textoColhedoraI43}}</td>
                                    <td class="tg-yw4l">{{textoColhedoraI44}}</td>
                                    <td class="tg-yw4l">{{textoColhedoraI45}}</td>
                                </tr>
                            </table>
                        </div>
                    </div>--%>
                </div>

                <div data-ng-show="!frentesColheita">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonCanavieiroFrenteOptions"></div>
                        </div>
                    </div>
                    <div class="row" data-ng-show="canavieiroFrenteMostrar">
                        <div class="col-xs-12 text-center">
                            <div data-dx-chart="chartEquipCanavieiroConsumoOleoDieselOptions"></div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div data-dx-button="buttonEscravoFrenteOptions"></div>
                        </div>
                    </div>
                    <div class="row" data-ng-show="escravoFrenteMostrar">
                        <div class="col-xs-12 text-center">
                            <div data-dx-chart="chartEquipEscravoConsumoOleoDieselOptions"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
