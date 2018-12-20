<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaEntradasCanaPorPropDualGeralFrente.aspx.vb" Inherits="AspNet5t.cnEntCanaEntradasCanaPorPropDualGeralFrente" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register Src="~/UserControls/ucCapivaraPopUp.ascx" TagPrefix="uc1" TagName="ucCapivaraPopUp" %>


<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style type="text/css">
         /*gauge's titles font styles*/
          .dxg-title text
        {
            fill: rgb(0,120,93)!important;
            font-weight: bold!important;
            font-size: small!important;
            /*background-color: green!important;*/
        }

        /*actual value gauge ao lado do indicador positivo negativo*/
        /*.dx-carditem-default-color
        {
            color: #ffffff!important;
            fill: #ffffff!important;
        }*/

         /*verde triângulo positivo*/
          .dx-carditem-positive-color
        {
            fill: rgb(0,120,93)!important;
           
        }

        /*verde marker no dial do gauge*/        
        .dxg-subvalue-indicator
        {
            fill: rgb(0,120,93)!important;
        }

        .botoes-central
        {
            width: 98%;
            text-align: center;
        }
    </style>

    <script>
        function OnInit(s, e) {
            AdjustSize();
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
        }
        function AdjustSize() {
            var height = document.documentElement.clientHeight;
            dv.SetHeight(height - 48 * 1.5 - 100);
        }
        function OnInit2(s, e) {
            AdjustSize2();
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize2();
            });
        }
        function AdjustSize2() {
            dv2.SetHeight(100);
        }
        function OnMasterFilterSetRange(s, e) {
            //var m = new Date(e.Values[0][0]);
            var dtIni = new Date(e.Values[0][0]);
            var dtFim = new Date(e.Values[0][1]);

            var parameters = dv.GetParameters();
            var parameter1 = parameters.GetParameterByIndex(0);
            var parameter2 = parameters.GetParameterByIndex(1);

            dv.BeginUpdateParameters();
            parameter1.SetValue(e.Values[0][0]);
            parameter2.SetValue(e.Values[0][1]);
            dv.EndUpdateParameters();

            //alert(e.ItemName + ': ' + e.Values[0][0] + ' a ' + e.Values[0][1]);
        }
        function OnMasterFilterSet(s, e) {
            if (e.ItemName == "gridDashboardItem1") {
                btnHistoricoProp.SetText("Histórico " + e.Values[0][1] + ' ( ' + e.Values[0][0] + ' )');
                btnHistoricoProp.SetVisible(true);
            };
        }
        function OnMasterFilterCleared(s, e) {
            if (e.ItemName == "gridDashboardItem1") {
                //hf.Set('COD_PROP', null);
                btnHistoricoProp.SetVisible(false);
            };
        }
        function showPopupProp(s, e) {
            hf.Clear();
            hf.Set("COD_PROP", btnHistoricoProp.GetText());
            pcProp.PerformCallback();
            pcProp.Show();
            datav1.FirstPage();
            datav2.FirstPage();
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
<%--    <div class="botoes-central">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="POR FRENTE" AutoPostBack="False" GroupName="G" Checked="True" Theme="iOS" Width="130px" CausesValidation="False">
            <ClientSideEvents Click="function(s, e) {if (!cbPanel.InCallback()) {cbPanel.PerformCallback(1);}}" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="GERAL" AutoPostBack="False" GroupName="G" Theme="iOS" Width="130px">
            <ClientSideEvents Click="function(s, e) {if (!cbPanel.InCallback()) {cbPanel.PerformCallback(2);}}" />
        </dx:ASPxButton>
    </div>--%>
    <div>
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="cbPanel">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <div class="botao-popcapivara-dash">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" ClientInstanceName="btnHistoricoProp" Text="Histórico Propriedade" AutoPostBack="False" CssClass="icq" EnableTheming="False" ClientVisible="False">
                            <ClientSideEvents Click="showPopupProp" />
                            <Image IconID="chart_previewchart_16x16">
                            </Image>
                            <PressedStyle CssClass="icqPressed">
                            </PressedStyle>
                            <HoverStyle CssClass="icqHovered">
                            </HoverStyle>
                        </dx:ASPxButton>    
                    </div>

                    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaEntradasCanaTonPorViagemPorFrente" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv">
                        <ClientSideEvents Init="OnInit" />
                        <%--<ClientSideEvents MasterFilterSet="function(s, e) {	alert( e.ItemName + ': ' + e.Values[0][1] );}" />--%>
                        <ClientSideEvents MasterFilterSet="OnMasterFilterSet" />
                        <ClientSideEvents MasterFilterCleared="OnMasterFilterCleared" />
                    </dx:ASPxDashboardViewer>
                    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer2" runat="server" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv2" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaEntradasCanaTonPorViagemRangeParam">
<%--                    <ExportOptions>
                            <DocumentContentOptions FilterState="None"></DocumentContentOptions>
                        </ExportOptions>--%>
                        <ClientSideEvents Init="OnInit2" />
                        <%--<ClientSideEvents MasterFilterSet="function(s, e) {	alert( e.ItemName + ': ' + e.Values[0][0] + ' a ' + e.Values[0][1] );}" />--%>
                        <ClientSideEvents MasterFilterSet="OnMasterFilterSetRange" />
                    </dx:ASPxDashboardViewer>

                    <uc1:ucCapivaraPopUp runat="server" ID="ucCapivaraPopUp" />
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
</asp:Content>
