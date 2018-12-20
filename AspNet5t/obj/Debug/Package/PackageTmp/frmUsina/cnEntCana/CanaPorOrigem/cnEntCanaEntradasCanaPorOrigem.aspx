<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaEntradasCanaPorOrigem.aspx.vb" Inherits="AspNet5t.cnEntCanaEntradasCanaPorOrigem" %>

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
            dv.SetHeight(height - 48 * 1.5);
        }
        function OnMasterFilterSet(s, e) {
            if (e.ItemName == "gridDashboardItem1") {
                if (e.Values[0][0].indexOf(' ( ') > 0) {
                    btnHistoricoProp.SetText("Histórico " + e.Values[0][0]);
                    btnHistoricoProp.SetVisible(true);
                };
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
        <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaEntradasCanaPorTipo" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv">
            <ClientSideEvents Init="OnInit" />
            <%--<ClientSideEvents MasterFilterSet="function(s, e) {	alert( e.ItemName + ': ' + e.Values[0][0] );}" />--%>
            <ClientSideEvents MasterFilterSet="OnMasterFilterSet" />
            <ClientSideEvents MasterFilterCleared="OnMasterFilterCleared" />
        </dx:ASPxDashboardViewer>

        <uc1:ucCapivaraPopUp runat="server" ID="ucCapivaraPopUp" />
<%--        <dx:ASPxTimer ID="ASPxTimer1" runat="server" Interval="5000">
            <ClientSideEvents Tick="function(s, e) { dv.ReloadData(); }" />
        </dx:ASPxTimer>--%>
    </div>
</asp:Content>
