<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnIndustriaHomeJS.aspx.vb" Inherits="AspNet5t.cnIndustriaHomeJS" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <%: Styles.Render("~/Content/dxcss4Tcenindustriahome")%>

    <%: Styles.Render("~/Content/csspageindustriahome")%>
    
    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
    </script>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>

    <%: Scripts.Render("~/bundles/dx4Tcenindustriahome")%>
    
    <%: Scripts.Render("~/bundles/app4Tindustriahome") %>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div ng-app="app4T" ng-controller="industriahomeCtrl as ctrl" ng-cloak>
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
                    <h3 style="float: left; margin-top: 10px;" class="panel-title">Indústria - Home</h3>
                    
                    <div style="float: right;" data-dx-date-box="dateBoxOptions"></div> 
                    <span style="float: right; margin-top: 10px; font-weight: bold">Dia Referência:&nbsp;</span>
                    <span style="float: right;">&nbsp;&nbsp;</span>
                    <div style="float: right;" data-dx-button="buttonAutoRefreshOptions"></div>
                </div>
            </div>

            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-4 text-center">
                        <span class="titulocenario">Moagem</span>
                    </div>
                    <div class="col-xs-4 text-center">
                        <span class="titulocenario">Produção Açúcar</span>
                    </div>
                    <div class="col-xs-4 text-center">
                        <span class="titulocenario">Produção Etanol</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartMoagemVisaoGeralDiaOptions">
                        </div>
                    </div>
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartAcucarVisaoGeralDiaOptions">
                        </div>
                    </div>
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartEtanolVisaoGeralDiaOptions">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartMoagemVisaoGeralSemanaOptions">
                        </div>
                    </div>
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartAcucarVisaoGeralSemanaOptions">
                        </div>
                    </div>
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartEtanolVisaoGeralSemanaOptions">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartMoagemVisaoGeralMesOptions">
                        </div>
                    </div>
                     <div class="col-xs-4 text-center">
                         <div data-dx-chart="chartAcucarVisaoGeralMesOptions">
                         </div>
                     </div>
                     <div class="col-xs-4 text-center">
                         <div data-dx-chart="chartEtanolVisaoGeralMesOptions">
                         </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartMoagemVisaoGeralSafraOptions">
                        </div>
                    </div>
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartAcucarVisaoGeralSafraOptions">
                        </div>
                    </div>
                    <div class="col-xs-4 text-center">
                        <div data-dx-chart="chartEtanolVisaoGeralSafraOptions">
                        </div>
                    </div>
                </div>

                <div class="row" style="height: 50px;">
                </div>
                
                <div class="row">
                    <div class="col-xs-4 text-center">
                        <span class="titulocenario">Eficiência Industrial</span>
                    </div>
                    <div class="col-xs-4 text-center">
                        <span class="titulocenario">Exportação BIO</span>
                    </div>
                    <div class="col-xs-4 text-center">
                        <span class="titulocenario">Exportação UAM</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4 text-center">
                        <div class="row">
                            <div class="col-xs-6 text-center">
                                <div data-dx-circular-gauge="gaugeEficienciaArtOptions"></div>    
                            </div>
                            <div class="col-xs-6 text-center">
                                <div data-dx-circular-gauge="gaugeEficienciaRtcOptions"></div>    
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <div data-dx-circular-gauge="gaugeEficienciaCIOptions"></div>    
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-8 text-center">
                        <div class="row">
                            <div class="col-xs-6 text-center">
                                <div data-dx-chart="chartEnergiaBioVisaoGeralDiaOptions"></div>                                
                            </div>
                            <div class="col-xs-6 text-center">
                                <div data-dx-chart="chartEnergiaUamVisaoGeralDiaOptions"></div>                                
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 text-center">
                                <div data-dx-chart="chartEnergiaBioVisaoGeralSemanaOptions">
                                </div>
                            </div>
                            <div class="col-xs-6 text-center">
                                <div data-dx-chart="chartEnergiaUamVisaoGeralSemanaOptions">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 text-center">
                                <div data-dx-chart="chartEnergiaBioVisaoGeralMesOptions">
                                </div>
                            </div>
                            <div class="col-xs-6 text-center">
                                <div data-dx-chart="chartEnergiaUamVisaoGeralMesOptions">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 text-center">
                                <div data-dx-chart="chartEnergiaBioVisaoGeralSafraOptions">
                                </div>
                            </div>
                            <div class="col-xs-6 text-center">
                                <div data-dx-chart="chartEnergiaUamVisaoGeralSafraOptions">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
