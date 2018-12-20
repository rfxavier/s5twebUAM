<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaColheitaCertificados.aspx.vb" Inherits="AspNet5t.cnEntCanaColheitaCertificados" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

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
            dv.SetHeight(height - 68 * 1.5);
        }

        function OnClick(s, e) {
            switch (e.buttonIndex) {
                case 0:
                    s.SetDate(new Date());
                    cbPanel.PerformCallback();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div class="botoes-direita">
        <div class="botoes-direita-individual">
            Período:
        </div>
        <div class="botoes-direita-individual">
            <dx:ASPxDateEdit ID="dtInicial" runat="server" AllowNull="False" Width="100px" UseMaskBehavior="True">
                <CalendarProperties ShowClearButton="False">
                </CalendarProperties>
            </dx:ASPxDateEdit>
        </div>
        <div class="botoes-direita-individual">
            a
        </div>
        <div class="botoes-direita-individual">
            <dx:ASPxDateEdit ID="dtFinal" runat="server" AllowNull="False" Width="100px" UseMaskBehavior="True">
                <CalendarProperties ShowClearButton="False">
                </CalendarProperties>
                <DateRangeSettings StartDateEditID="dtInicial"></DateRangeSettings>
            </dx:ASPxDateEdit>
        </div>
        <div class="botoes-direita-individual">
            <dx:ASPxButton ID="btnPesquisar" runat="server" Text="Pesquisar" AutoPostBack="False">
                <ClientSideEvents Click="function(s, e) {cbPanel.PerformCallback();}" />
            </dx:ASPxButton>
        </div>
    </div>
    <div class="clear-float">
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="cbPanel">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaColheitaCertificados" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv" AllowExportDashboard="False">
<%--                    <ExportOptions>
                            <DocumentContentOptions FilterState="None"></DocumentContentOptions>
                        </ExportOptions>--%>
                        <ClientSideEvents Init="OnInit" />
                    </dx:ASPxDashboardViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
</asp:Content>
