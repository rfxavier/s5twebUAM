<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaEntradasCanaMapaPropriedades.aspx.vb" Inherits="AspNet5t.cnEntCanaEntradasCanaMapaPropriedades" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register Src="~/UserControls/ucCapivaraPopUp.ascx" TagPrefix="uc1" TagName="ucCapivaraPopUp" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
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
        function OnLoaded() {
            dv2.MasterFilterSet.AddHandler(OnMasterFilterSetRange);
        }
        function OnItemClick(s, args) {
            if (args.ItemName == "choroplethMapDashboardItem2") {
                var underlyingData = [];
                var dimString = "";
                var dimCOD_PROP = "";
                var dimDSC_PROP = "";
                args.RequestUnderlyingData(function (data) {
                    dataMembers = data.GetDataMembers();
                    //dataMembers[0] = COD_PROP
                    //dataMembers[3] = DSC_PROPRIEDADE
                    //dataMembers[2] = DSC_PROPRIEDADE (second layer) - dataMembers[3] = undefined

                    //dimString0 = data.GetRowValue(0, dataMembers[2]);
                    //alert(dimString0);

                    dimCOD_PROP = data.GetRowValue(0, dataMembers[0]);
                    dimDSC_PROP = data.GetRowValue(0, dataMembers[3]);

                    if (typeof dimDSC_PROP == 'undefined') {
                        dimDSC_PROP = data.GetRowValue(0, dataMembers[2]);
                    }

                    //if (isNaN(data.GetRowValue(0, dataMembers[3]))) {
                    //    dimDSC_PROP = data.GetRowValue(0, dataMembers[3]);
                    //}
                    //else {
                    //    dimDSC_PROP = data.GetRowValue(0, dataMembers[4]);
                    //}

                    btnHistoricoProp.SetText("Histórico " + dimDSC_PROP + " ( " + dimCOD_PROP + " ) ");
                    btnHistoricoProp.SetVisible(true);
                });
            }
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

    <div>
        <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="~/dashXmls/dashCnEntCanaEntradasCanaMapaPropriedades.xml" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv">
            <ClientSideEvents Init="OnInit" />
            <%--<ClientSideEvents Loaded="function() { dv2.MasterFilterSet.AddHandler(OnMasterFilterSetRange); }" />--%>
            <ClientSideEvents Loaded="OnLoaded" />
            <ClientSideEvents ItemClick="OnItemClick" />
        </dx:ASPxDashboardViewer>

        <dx:ASPxDashboardViewer ID="ASPxDashboardViewer2" runat="server" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv2" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaEntradasCanaTonPorViagemRangeParam">
<%--        <ExportOptions>
            <DocumentContentOptions FilterState="None"></DocumentContentOptions>
            </ExportOptions>--%>
            <ClientSideEvents Init="OnInit2" />
            <%--<ClientSideEvents MasterFilterSet="function(s, e) {	alert( e.ItemName + ': ' + e.Values[0][0] + ' a ' + e.Values[0][1] );}" />--%>
        </dx:ASPxDashboardViewer>
    </div>

    <uc1:ucCapivaraPopUp runat="server" ID="ucCapivaraPopUp" />
</asp:Content>
