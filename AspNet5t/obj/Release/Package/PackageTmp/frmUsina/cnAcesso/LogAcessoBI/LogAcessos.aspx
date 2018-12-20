<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="LogAcessos.aspx.vb" Inherits="AspNet5t.LogAcessos" %>

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
            dv.SetHeight(height + 270 * 1.5);
        }

        function OnClick(s, e) {
            switch (e.buttonIndex) {
                case 0:
                    s.SetDate(new Date());
                    cbPanel.PerformCallback();
            }
        }
        function OnLoaded(s, e) {
            var today = new Date();
            today.setHours(0, 0, 0, 0);
            //dv.SetMasterFilter('chartDashboardItem2', [[new Date().setHours(0, 0, 0, 0)]]);
            dv.SetMasterFilter('chartDashboardItem2', [[today]]);
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div>
        <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashLogUsuarios" Width="100%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv">
            <ClientSideEvents Init="OnInit" />
            <ClientSideEvents Loaded="OnLoaded" />
        </dx:ASPxDashboardViewer>
    </div>
<%--        <dx:ASPxTimer ID="ASPxTimer1" runat="server" Interval="30000">
            <ClientSideEvents Tick="function(s, e) { dv.ReloadData(); }" />
        </dx:ASPxTimer>--%>
</asp:Content>
