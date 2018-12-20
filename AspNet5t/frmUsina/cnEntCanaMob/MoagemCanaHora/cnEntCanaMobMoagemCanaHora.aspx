<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaMobMoagemCanaHora.aspx.vb" Inherits="AspNet5t.cnEntCanaMobMoagemCanaHora" %>

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
            dv.SetHeight(height - 68 * 1.5);
        }

        function OnClick(s, e) {
            switch (e.buttonIndex) {
                case 0:
                    var date = s.GetDate();
                    date.setHours(date.getHours() - 12);
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
                    date.setHours(date.getHours() + 12);
                    s.SetDate(date);
                    cbPanelTop.PerformCallback();
                    cbPanel.PerformCallback();
                    break;
            }
        }
        function OnTick(s, e) {
            var now = new Date();
            var nowHour = now.getHours();
            now.setHours(nowHour, 0, 0, 0);
            var nowHourMin = now.ddmmyyyyhhmm();
            var timeBtn = btnData.GetText();
            var dateTimeBtn = timeBtn.substr(0, 13).toString();
            var dateTimeNow = nowHourMin.substr(0, 13).toString();

            if (dateTimeBtn !== dateTimeNow) {
                btnData.SetDate(new Date());
                cbPanelTop.PerformCallback();
                cbPanel.PerformCallback();
            }
            else {
                cbPanelTop.PerformCallback();
                dv.ReloadData();
            }
        }
        Date.prototype.ddmmyyyyhhmm = function () {
            var yyyy = this.getFullYear().toString();
            var mm = (this.getMonth() + 1).toString(); // getMonth() is zero-based
            var dd = this.getDate().toString();
            var hh = this.getHours().toString();
            var mmm = this.getMinutes().toString();
            return (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy + ' ' + (hh[1] ? hh : "0" + hh[0]) + ':' + (mmm[1] ? mmm : "0" + mmm[0]); // padding
        };
        function OnDateChanged(s, e) {
            cbPanelTop.PerformCallback();
            dv.ReloadData();
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">


   <%-- <div class="texto-esquerda">
        Moagem de Cana / Hora
    </div>--%>
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel2" runat="server" Width="100%" ClientInstanceName="cbPanelTop">
            <SettingsLoadingPanel Enabled="False" />
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <div style="float:left; width: 130px; margin-top: 12px;" >
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Moagem / Hora" style="font-size:18px;  font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
                        </dx:ASPxLabel>
                    </div>
                    <div id="divTonHoraMedia" style="float:left; text-align:center; margin-left:10px; border: thin solid black; width: 190px;">
                        <dx:ASPxLabel ID="ASPxLabelMedia" runat="server" Text="Média:" ClientVisible="true" EncodeHtml="False" style="font-size:18px; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" width="190px">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabelTonHoraMedia" runat="server" Text=" " ClientVisible="true" ClientInstanceName="lbTonHoraMedia" EncodeHtml="False" style="font-size:18px; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" width="140px">
                        </dx:ASPxLabel>
                        <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/upArrowGreen.jpg"></dx:ASPxImage>
                    </div>
                    <div id="divTonDia" style="float:left; text-align:center; margin-left:10px; border: thin solid black; width: 110px;">
                        <dx:ASPxLabel ID="ASPxLabelTon" runat="server" Text="Dia:" ClientVisible="true" EncodeHtml="False" style="font-size:18px; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" width="110px">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabelTonDia" runat="server" Text=" " ClientVisible="true" ClientInstanceName="lbTonDia" EncodeHtml="False" style="font-size:18px; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" width="110px">
                        </dx:ASPxLabel>
                    </div>
                    <div style="float: left; margin-top: 12px;">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Média Viagens:" Style="margin-left: 120px; font-size: 18px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
                        </dx:ASPxLabel>
                    </div>
                    <div id="divViagemMedia" style="float: left; text-align: center; margin-left: 2px; margin-top: 12px;">
                        <dx:ASPxLabel ID="ASPxLabelViagemMedia" runat="server" Text=" " ClientVisible="true" ClientInstanceName="lbViagemMedia" EncodeHtml="False" Style="font-size: 18px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" Width="30px">
                        </dx:ASPxLabel>
                    </div>

                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>

    <div class="botoes-direita">
        <dx:ASPxDateEdit ID="dataReferencia" runat="server" EditFormat="DateTime" AllowNull="False" Date="03/08/2015 18:00:00" Width="346px" BackColor="#97FF97" AllowUserInput="False" Theme="iOS" ClientInstanceName="btnData">
            <ClientSideEvents DateChanged="OnDateChanged" />
            <CalendarProperties ShowClearButton="False" ShowWeekNumbers="False" ShowTodayButton="False">
            </CalendarProperties>
            <TimeSectionProperties Visible="True">
            </TimeSectionProperties>
            <ClientSideEvents ButtonClick="OnClick" />
            <Buttons>
                <dx:EditButton Position="Left" Text="-12h">
                </dx:EditButton>
                <dx:EditButton Text="Hoje" Position="Left">
                </dx:EditButton>
                <dx:EditButton Text="+12h">
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
                    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaMobMoagemCanaHora" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv" AllowExportDashboard="False">
<%--                    <ExportOptions>
                            <DocumentContentOptions FilterState="None"></DocumentContentOptions>
                        </ExportOptions>--%>
                        <ClientSideEvents Init="OnInit" />
                    </dx:ASPxDashboardViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>

<%--    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" CloseAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowHeader="False" ShowOnPageLoad="True">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="ASPxLabel">
                </dx:ASPxLabel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>--%>

    <dx:ASPxTimer ID="ASPxTimer1" runat="server" Interval="60000">
        <%--<ClientSideEvents Tick="function(s, e) { dv.ReloadData(); }" />--%>
        <ClientSideEvents Tick="OnTick" />
    </dx:ASPxTimer>
</asp:Content>
