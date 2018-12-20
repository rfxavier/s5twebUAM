<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaCtrlEstoqueFrenteJS.aspx.vb" Inherits="AspNet5t.cnEntCanaCtrlEstoqueFrenteJS" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <%: Styles.Render("~/Content/dxcss4Tcencolheitacana")%>

    <%: Styles.Render("~/Content/csspagectrlestfrente")%>

    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
        var usuarioAtual = "<%=usuarioAtual%>";
    </script>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>

     <%: Scripts.Render("~/bundles/dx4Tcencolheitacana")%>

     <%: Scripts.Render("~/bundles/app4Tctrlestcolheita") %>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div style="height: 0">
        <svg>
            <pattern id="fc01p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#ffc0cb"></path>
            </pattern>
            <pattern id="fc01p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#ffc0cb"></path>
            </pattern>
            <pattern id="fc01p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#ffc0cb"></path>
            </pattern>

            <pattern id="fc02p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#ffa500"></path>
            </pattern>
            <pattern id="fc02p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#ffa500"></path>
            </pattern>
            <pattern id="fc02p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#ffa500"></path>
            </pattern>

            <pattern id="fc03p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#800080"></path>
            </pattern>
            <pattern id="fc03p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#800080"></path>
            </pattern>
            <pattern id="fc03p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#800080"></path>
            </pattern>

            <pattern id="fc04p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#00ff00"></path>
            </pattern>
            <pattern id="fc04p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#00ff00"></path>
            </pattern>
            <pattern id="fc04p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#00ff00"></path>
            </pattern>

            <pattern id="fc05p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#00ffff"></path>
            </pattern>
            <pattern id="fc05p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#00ffff"></path>
            </pattern>
            <pattern id="fc05p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#00ffff"></path>
            </pattern>

            <pattern id="fc06p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#4169e1"></path>
            </pattern>
            <pattern id="fc06p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#4169e1"></path>
            </pattern>
            <pattern id="fc06p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#4169e1"></path>
            </pattern>

            <pattern id="fc07p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#ff00ff"></path>
            </pattern>
            <pattern id="fc07p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#ff00ff"></path>
            </pattern>
            <pattern id="fc07p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#ff00ff"></path>
            </pattern>

            <pattern id="fc08p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#ff0000"></path>
            </pattern>
            <pattern id="fc08p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#ff0000"></path>
            </pattern>
            <pattern id="fc08p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#ff0000"></path>
            </pattern>

            <pattern id="fc09p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#00c000"></path>
            </pattern>
            <pattern id="fc09p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#00c000"></path>
            </pattern>
            <pattern id="fc09p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#00c000"></path>
            </pattern>

            <pattern id="fc10p2" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6" stroke-width="6" stroke="#ffff00"></path>
            </pattern>
            <pattern id="fc10p3" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="3" stroke="#ffff00"></path>
            </pattern>
            <pattern id="fc10p4" width="6" height="6" patternUnits="userSpaceOnUse">
                <path d="M 0 0 L 6 6 M -3 3 L 3 9 M 3 -3 L 9 3" stroke-width="1" stroke="#ffff00"></path>
            </pattern>
        </svg>
    </div>
    <div ng-app="app4T" ng-controller="controleEstColheitaCtrl as ctrl" ng-cloak>
        <span class="centerBlock dx-dashboard-title">Mapa de Colheita - Safra {{numeroSafraAtual}}</span>
        <div class="panel panel-default" id="panelPrincipal">
            <div class="panel-heading">
                <h3 class="panel-title pull-left">Controle de Estoque de Colheita</h3>
                <a href="#" class="icon" ng-click="toggleGrid()"><span ng-class="!showDiv ? 'dx-icon-chevronleft' : 'dx-icon-chevronright'"></span> {{msgShowDiv}}</a>

                <a id="updateNow" href="#" class="pull-right icon"><span class="dx-icon-revert"></span> Atualizar Agora</a>
                <div id="clockdiv" class="panel-title pull-right">
                    <div class="divatualiza"><span class="spanatualiza">Atualiza em</span></div>
                    <div>
                        <span class="hours"></span>
                        <div>h</div>
                    </div>
                    <div>
                        <span class="minutes"></span>
                        <div>m</div>
                    </div>
                    <div>
                        <span class="seconds"></span>
                        <div>s</div>
                    </div>
                </div>


                <div class="clearfix"></div>
            </div>
            <div class="panel-body panel-principal">
                <div class="col-fixed" ng-show="!showDiv">
                    <div class="dx-datagrid dx-datagrid-borders centerBlock" style="max-width: 374px;">
                        <div class="dx-datagrid-headers" style="padding-right: 0px;">
                            <div class="dx-datagrid-content dx-datagrid-scroll-container">
                                <table class="dx-datagrid-table dx-datagrid-table-fixed" role="grid" onclick="void(0)">
                                <colgroup>
                                    <col style="width: 374px;">
                                </colgroup>
                                <tbody>
                                    <tr class="dx-row dx-column-lines dx-header-row ctrlest-header-row" role="row" onclick="void(0)" style="background: rgba(0, 38, 255, 0.168627);">
                                        <td role="columnheader" aria-label="Estoque Column" aria-sort="none" class="dx-cell-focus-disabled" style="text-align: center;">
                                            <div class="dx-datagrid-text-content">Resumo - Estoque de Campo</div>
                                        </td>
                                    </tr>
                                </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div id="gridTotaisContainer" class="centerBlock" data-dx-data-grid="gridTotaisOptions"></div>                
                    <div class="dx-datagrid dx-datagrid-borders centerBlock" style="max-width: 374px;">
                        <div class="dx-datagrid-headers" style="padding-right: 0px;">
                            <div class="dx-datagrid-content dx-datagrid-scroll-container">
                                <table class="dx-datagrid-table dx-datagrid-table-fixed" role="grid" onclick="void(0)">
                                <colgroup>
                                    <col style="width: 374px;">
                                </colgroup>
                                <tbody>
                                    <tr class="dx-row dx-column-lines dx-header-row ctrlest-header-row" role="row" onclick="void(0)" style="background: rgba(0, 38, 255, 0.168627);">
                                        <td role="columnheader" aria-label="Estoque Column" aria-sort="none" class="dx-cell-focus-disabled" style="text-align: center;">
                                            <div class="dx-datagrid-text-content">Resumo - Estoque de Campo</div>
                                        </td>
                                    </tr>
                                </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div id="gridFrentesContainer" class="centerBlock" data-dx-data-grid="gridFrentesOptions"></div>
                    <div id="botaoEncerrarContainer" class="centerBlock" data-dx-button="botaoEncerrarOptions"></div>
                </div>

                <div class="row1">
                    <div class="col-xs-12">
                        <div class='my-legend centerBlock'>
                            <div class='legend-scale'>
                                <ul class='legend-labels'>
                                    <li><span style='background: #ffc0cb;'></span>1</li>
                                    <li><span style='background: #ffffff;'></span></li>
                                    <li><span style='background: #ffa500;'></span>2</li>
                                    <li><span style='background: #ffffff;'></span></li>
                                    <li><span style='background: #800080;'></span>3</li>
                                    <li><span style='background: #ffffff;'></span></li>
                                    <li><span style='background: #00ff00;'></span>4</li>
                                    <li><span style='background: #ffffff;'></span></li>
                                    <li><span style='background: #00ffff;'></span>5</li>
                                    <li><span style='background: #ffffff;'></span></li>
                                    <li><span style='background: #4169e1;'></span>6</li>
                                    <li><span style='background: #ffffff;'></span></li>
                                    <li><span style='background: #ff00ff;'></span>7</li>
                                    <li><span style='background: #ffffff;'></span></li>
                                    <li><span style='background: #ff0000;'></span>8</li>
                                    <li><span style='background: #ffffff;'></span></li>
                                    <li><span style='background: #00c000;'></span>9</li>
                                    <li><span style='background: #ffffff;'></span></li>
                                    <li><span style='background: #ffff00;'></span>10</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row1 panel-principal">
                    <div id="mapaPropriedadeContainer" data-dx-vector-map="mapaPropriedadeOptions"></div>
                </div>
            </div>
        </div>

        <div class="loadpanel" dx-load-panel="loadOptions"></div>
   </div>
</asp:Content>
