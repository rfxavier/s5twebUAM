<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnOficinaDetalhamento.aspx.vb" Inherits="AspNet5t.cnOficinaDetalhamento" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style type="text/css">
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
            dv.SetHeight(height + 420 * 1.5);
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div>
        <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnOficinaDetalhamento" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv">
            <ClientSideEvents Init="OnInit" />
        </dx:ASPxDashboardViewer>
    </div>
</asp:Content>
