<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEnRenovColetaPalha.aspx.vb" Inherits="AspNet5t.cnEnRenovColetaPalha" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style type="text/css">
        .dxeBase {
            vertical-align: top!important;
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
            var width = document.documentElement.clientWidth;
            dv.SetHeight(height - 80 * 1.5);
        }

        function OnClick(s, e) {
            switch (e.buttonIndex) {
                case 0:
                    var date = s.GetDate();
                    date.setMonth(date.getMonth() - 1);
                    s.SetDate(date);
                    cbPanelTop.PerformCallback();
                    cbPanel.PerformCallback();
                    break;
                case 1:
                    s.SetDate(new Date());
                    cbPanelTop.PerformCallback();
                    cbPanel.PerformCallback();
                    break;
                case 2:
                    var date = s.GetDate();
                    date.setMonth(date.getMonth() + 1);
                    s.SetDate(date);
                    cbPanelTop.PerformCallback();
                    cbPanel.PerformCallback();
                    break;
            }
        }
        function OnDateChanged(s, e) {
            cbPanelTop.PerformCallback();
            cbPanel.PerformCallback();
            //dv.ReloadData();
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel2" runat="server" Width="100%" ClientInstanceName="cbPanelTop">
            <SettingsLoadingPanel Enabled="False" />
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <div style="float: left; margin-top:8px;">
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Coleta Palha - Período:" Style="font-size: 16px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
                        </dx:ASPxLabel>
                    </div>
                    <div id="divcoletaPalha" style="float: left; text-align: right; margin-left: 10px; margin-top:8px; border: thin solid black; display:inline-block; white-space:nowrap;">
                        <dx:ASPxLabel ID="ASPxLabelPalhaMes" runat="server" Text=" " ClientVisible="true" ClientInstanceName="lbPalhaMes" EncodeHtml="False" Style="font-size: 16px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin-right: 10px;" Width="90px">
                        </dx:ASPxLabel>
                        <dx:ASPxImage ID="ASPxImagePeriodo" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/upArrowGreen.jpg"></dx:ASPxImage>
                    </div>

                    <div style="float: left; margin-left: 10px; margin-top:8px;">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Safra:" Style="font-size: 16px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin-top:8px;">
                        </dx:ASPxLabel>
                    </div>
                    <div id="divcoletaPalhaSAFRA" style="float: left; text-align: right; margin-left: 10px; margin-top:8px; border: thin solid black; display:inline-block; white-space:nowrap;">
                        <dx:ASPxLabel ID="ASPxLabelPalhaSafra" runat="server" Text=" " ClientVisible="true" ClientInstanceName="lbPalhaSafra" EncodeHtml="False" Style="font-size: 16px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" Width="100px">
                        </dx:ASPxLabel>&nbsp;
                        <dx:ASPxImage ID="ASPxImageSafra" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/upArrowGreen.jpg"></dx:ASPxImage>
                    </div>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>

    <div class="botoes-direita">
        <dx:ASPxDateEdit ID="dataReferencia" runat="server" AllowNull="False" Date="03/06/2015" Width="310px" BackColor="#97FF97" AllowUserInput="False" Theme="iOS" ClientInstanceName="btnData">
            <ClientSideEvents DateChanged="OnDateChanged" />
            <CalendarProperties ShowClearButton="False" ShowWeekNumbers="False" ShowTodayButton="False">
            </CalendarProperties>
            <ClientSideEvents ButtonClick="OnClick" />
            <Buttons>
                <dx:EditButton Position="Left" Text="-Mês">
                </dx:EditButton>
                <dx:EditButton Text="Hoje" Position="Left">
                </dx:EditButton>
                <dx:EditButton Text="+Mês">
                </dx:EditButton>
            </Buttons>
            <ButtonStyle>
                <Border BorderStyle="None" />
            </ButtonStyle>
        </dx:ASPxDateEdit>
    </div>


    <div class="clear-float">
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="cbPanel">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaPalhaPorDia" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv" AllowExportDashboard="False">
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
