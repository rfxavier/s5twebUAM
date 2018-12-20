<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="WebFormTmpChoropleth.aspx.vb" Inherits="AspNet5t.WebFormTmpChoropleth" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register Src="~/UserControls/ucCapivaraPopUp.ascx" TagPrefix="uc1" TagName="ucCapivaraPopUp" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <script src="Scripts/jquery-1.10.2.js"></script>
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
        function OnItemClick(s, args) {
            if (args.ItemName == "choroplethMapDashboardItem2") {
                var underlyingData = [];
                var dimString = "";
                var dimCOD_PROP = "";
                var dimDSC_PROP = "";
                args.RequestUnderlyingData(function (data) {
                    dataMembers = data.GetDataMembers();
                    //$.each(dataMembers, function (_, dataMember) {
                    //    dimString = dimString + " " + data.GetRowValue(0, dataMember);
                    //});

                    //dataMembers[1] = COD_PROP
                    //dataMembers[3] = DSC_PROPRIEDADE

                    //dimString = data.GetRowValue(0, dataMembers[3]);
                    //alert(dimString);

                    dimCOD_PROP = data.GetRowValue(0, dataMembers[1]);
                    dimDSC_PROP = data.GetRowValue(0, dataMembers[3]);

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
        <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaEntradasCanaMapaPropriedades" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv">
            <ClientSideEvents Init="OnInit" />
            <ClientSideEvents ItemClick="OnItemClick" />
        </dx:ASPxDashboardViewer>
    </div>

    <uc1:ucCapivaraPopUp runat="server" ID="ucCapivaraPopUp" />
</asp:Content>
