<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnAgricolaColheitaOperJS.aspx.vb" Inherits="AspNet5t.cnAgricolaColheitaOperJS" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <%: Styles.Render("~/Content/dxcss4Tcenagricolacolheitaoper")%>

    <%: Styles.Render("~/Content/csspageagricolacolheitaoper")%>

    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
    </script>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>

    <%: Scripts.Render("~/bundles/dx4Tcenagricolacolheitaoper")%>
    <%: Scripts.Render("~/bundles/app4Tagricolacolheitaoper") %>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div ng-app="app4T" ng-controller="agricolacolheitaOperCtrl as ctrl" ng-cloak>
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
                    <h3 style="float: left; margin-top: 10px;" class="panel-title">&nbsp;&nbsp;KPIs Colheita - Operacional</h3>

                    <span style="float: right; margin-top: 10px; font-weight: bold">Dia Referência:&nbsp;{{visaoGeralDiaMaxDisplay}}&nbsp;&nbsp;</span>

                    <span style="float: right;">&nbsp;&nbsp;</span>
                    <div style="float: right;" data-dx-button="buttonAutoRefreshOptions"></div>
                </div>
            </div>
            

            <div class="panel-body">
                <div style="width:100%">
                    <table class="tg">
                        <tr>
                            <th class="tg-5mgg">Frente</th>
                            <th class="tg-5mgg">Equipamentos Online</th>
                            <th class="tg-5mgg">Caminhão Quantidade</th>
                            <th class="tg-5mgg">Caminhão Tempo Permanência</th>
                            <th class="tg-5mgg">Colhedoras em propriedade<br />sem talhão liberado</th>
                            <th class="tg-5mgg">Frotas sem implemento</th>
                            <th class="tg-5mgg">Propriedade com projeto<br />sem ativação do<br />Piloto Automático</th>
                        </tr>
                        <tr data-ng-repeat="data in infoFrentes">
                            <td class="tg-yw4l">{{data.frenteDescricao}}</td>
                            <td class="tg-yw4l"><div data-dx-circular-gauge="gaugeEquipColhedoraEquipamentosOnlineDynOptions(data)"></div></td>
                            <td class="tg-yw4l"><div data-dx-circular-gauge="gaugeEquipCaminhaoQuantidadeDynOptions(data)"></div></td>
                            <td class="tg-yw4l"><div data-dx-circular-gauge="gaugeEquipCaminhaoTempoMedioPermanenciaDynOptions(data)"></div></td>
                            <td class="tg-yw42" data-ng-bind-html="replacePipeWithBr(data.textoColhedoraI43)"></td>
                            <td class="tg-yw42">{{data.textoColhedoraI45}}</td>
                            <td class="tg-yw42">{{data.textoColhedoraI44}}</td>
                        </tr>
                    </table>
                </div>
                
            </div>
        </div>
    </div>    

</asp:Content>
