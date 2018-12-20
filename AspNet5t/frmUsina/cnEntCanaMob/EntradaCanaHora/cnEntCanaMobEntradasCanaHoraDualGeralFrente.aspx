<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaMobEntradasCanaHoraDualGeralFrente.aspx.vb" Inherits="AspNet5t.cnEntCanaMobEntradasCanaHoraDualGeralFrente" %>

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
            dv.SetHeight(height - 104 * 1.5);
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

            //alert(nowHourMin.substr(0, 12));
            //alert(dateTimeBtn());
            //alert(dateTimeNow());
            if (dateTimeBtn !== dateTimeNow) {
                btnData.SetDate(new Date());
                cbPanelTop.PerformCallback();
                cbPanel.PerformCallback();
            }
            else
            {
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
        function OnSelectedIndexChanged(s, e) {
            cbPanelTop.PerformCallback();
            cbPanel.PerformCallback();
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel2" runat="server" Width="100%" ClientInstanceName="cbPanelTop">
        <SettingsLoadingPanel Enabled="False" />
        <PanelCollection>
            <dx:PanelContent runat="server">

                <div style="float: left; margin-top: 8px;">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Entrada de Cana / Hora" Style="font-size: 18px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
                    </dx:ASPxLabel>
                </div>
                <div id="divTonHoraMedia" style="float: left; text-align: center; margin-left: 10px; margin-top: 8px; border: thin solid black;">
                    <dx:ASPxLabel ID="ASPxLabelTonHoraMedia" runat="server" Text=" " ClientVisible="true" ClientInstanceName="lbTonHoraMedia" EncodeHtml="False" Style="font-size: 18px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" Width="220px">
                    </dx:ASPxLabel>
                    <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" ImageUrl="~/Content/Images/upArrowGreen.jpg"></dx:ASPxImage>
                </div>
                <div style="float: left; margin-top: 8px;">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Média Viagens:" Style="margin-left: 120px; font-size: 18px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
                    </dx:ASPxLabel>
                </div>
                <div id="divViagemMedia" style="float: left; text-align: center; margin-left: 2px; margin-top: 8px;">
                    <dx:ASPxLabel ID="ASPxLabelViagemMedia" runat="server" Text=" " ClientVisible="true" ClientInstanceName="lbViagemMedia" EncodeHtml="False" Style="font-size: 18px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" Width="30px">
                    </dx:ASPxLabel>
                </div>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

    <div class="botoes-direita">
        <dx:ASPxDateEdit ID="dataReferencia" runat="server" EditFormat="DateTime" AllowNull="False" Date="03/08/2015 18:00:00" Width="346px" BackColor="#97FF97" AllowUserInput="False" Theme="iOS" ClientInstanceName="btnData">
            <Buttons>
                <dx:EditButton Position="Left" Text="-12h">
                </dx:EditButton>
                <dx:EditButton Text="Hoje" Position="Left">
                </dx:EditButton>
                <dx:EditButton Text="+12h">
                </dx:EditButton>
            </Buttons>
            <ClientSideEvents ButtonClick="OnClick" />
            <CalendarProperties ShowClearButton="False" ShowWeekNumbers="False" ShowTodayButton="False">
            </CalendarProperties>
            <TimeSectionProperties Visible="True">
            </TimeSectionProperties>
            <ClientSideEvents DateChanged="OnDateChanged" />
        </dx:ASPxDateEdit>
    </div>
    <div class="combofrente">
        <dx:ASPxComboBox ID="cmbFrente" runat="server" Theme="iOS" Width="100%" IncrementalFilteringMode="None">
            <ClientSideEvents SelectedIndexChanged="OnSelectedIndexChanged" />
            <Columns>
                <dx:ListBoxColumn Caption="Código" FieldName="pCodFrente" Name="CodFrente" Visible="False" />
                <dx:ListBoxColumn Caption="Frente" FieldName="pDescFrente" Name="DescFrente" />
            </Columns>
        </dx:ASPxComboBox>
    </div>
    <div class="clear-float">
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="cbPanel">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaMobEntradaCanaHoraGeral" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv" AllowExportDashboard="False">
                        <ClientSideEvents Init="OnInit" />
                    </dx:ASPxDashboardViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>

    <dx:ASPxTimer ID="ASPxTimer1" runat="server" Interval="60000">
        <%--<ClientSideEvents Tick="function(s, e) { dv.ReloadData(); }" />--%>
        <ClientSideEvents Tick="OnTick" />
    </dx:ASPxTimer>
</asp:Content>
