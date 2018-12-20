﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnOficinaResumoDualGeralFrente.aspx.vb" Inherits="AspNet5t.cnOficinaResumoDualGeralFrente" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
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
            dv.SetHeight(height + 360 * 1.5);
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div class="botoes-central">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="GERAL" AutoPostBack="False" GroupName="G" Checked="True" Theme="iOS" Width="130px">
            <ClientSideEvents Click="function(s, e) {if (!cbPanel.InCallback()) {cbPanel.PerformCallback(1);}}" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="POR FRENTE" AutoPostBack="False" GroupName="G" Theme="iOS" Width="130px">
            <ClientSideEvents Click="function(s, e) {if (!cbPanel.InCallback()) {cbPanel.PerformCallback(2);}}" />
        </dx:ASPxButton>
    </div>
    <div>
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="cbPanel">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnOficinaResumoGeral" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv">
                        <ClientSideEvents Init="OnInit" />
                    </dx:ASPxDashboardViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
</asp:Content>
