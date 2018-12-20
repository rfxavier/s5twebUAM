<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Root.master" CodeBehind="cnOficinaResumoDualGeralFrente.aspx.vb" Inherits="AspNet5t.cnOficinaResumoDualGeralFrentePub" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderRoot" runat="server">
    <style type="text/css">
         /*gauge's titles font styles*/
          .dxg-title text
        {
            fill: rgb(0,120,93)!important;
            font-weight: bold!important;
            font-size: medium!important;
            /*background-color: green!important;*/
        }

         /*gauge's percent value indicator styles*/
          .dxg-delta-indicator text
        {
            font-size: x-large!important;
            font-weight: bold!important;
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
            dv.SetHeight(height - 100);
        }
        function InverteDashes() {
            if (button1.GetChecked()) {
                //button1.SetChecked(false);
                button2.SetChecked(true);
                cbPanel.PerformCallback(2);
            }
            else {
                button1.SetChecked(true);
                //button2.SetChecked(false);
                cbPanel.PerformCallback(1);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderRoot" runat="server">
    <div class="botoes-central">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="RESUMO" AutoPostBack="False" GroupName="G" Theme="iOS" Width="130px" ClientInstanceName="button1">
            <ClientSideEvents Click="function(s, e) {if (!cbPanel.InCallback()) {cbPanel.PerformCallback(1);}}" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="TRATORES/COLHEDORAS" AutoPostBack="False" GroupName="G" Theme="iOS" Width="130px" ClientInstanceName="button2">
            <ClientSideEvents Click="function(s, e) {if (!cbPanel.InCallback()) {cbPanel.PerformCallback(2);}}" />
        </dx:ASPxButton>
    </div>
    <div>
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="cbPanel">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnOficinaResumoGeralPub" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv">
                        <ClientSideEvents Init="OnInit" />
                    </dx:ASPxDashboardViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>

    <dx:ASPxTimer ID="ASPxTimer1" runat="server" Interval="20000">
        <ClientSideEvents Tick="function(s, e) { InverteDashes(); }" />
    </dx:ASPxTimer>

</asp:Content>
