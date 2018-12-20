<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnAdmRmEpiPendenteIndMenu.aspx.vb" Inherits="AspNet5t.cnAdmRmEpiPendenteIndMenu" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/UserControls/ucCapivaraPopUp.ascx" TagPrefix="uc1" TagName="ucCapivaraPopUp" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
        var timeout;
        var autorefresh;
        var altrefreshgotopage;
        function scheduleGridUpdate(grid) {
            window.clearTimeout(timeout);
            timeout = window.setTimeout(
                function () {
                    //console.log(autorefresh);

                    if (autorefresh) {
                        //console.log(grid.GetPageCount());
                        //console.log(grid.GetPageIndex());

                        if (grid.GetPageCount() == 1) {
                            grid.Refresh();
                        } else {
                            if (grid.GetPageCount() - 1 == grid.GetPageIndex()) {
                                console.log(altrefreshgotopage);
                                if (altrefreshgotopage) {
                                    //location.reload(true);
                                    grid.GotoPage(0);
                                } else {
                                    grid.Refresh();
                                };

                                if (altrefreshgotopage == undefined || altrefreshgotopage == false) {
                                    altrefreshgotopage = true;
                                } else {
                                    altrefreshgotopage = false;
                                };
                            } else {
                                grid.NextPage();
                            };
                        };
                    };
                },
                10000
            );
        }
        function grid_Init(s, e) {
            scheduleGridUpdate(s);
        }
        function grid_BeginCallback(s, e) {
            window.clearTimeout(timeout);
        }
        function grid_EndCallback(s, e) {
            scheduleGridUpdate(s);
        }
        function OnValueChanged(s, e) {
            var checked = cbAutoRef.GetChecked();
            autorefresh = checked;
            if (autorefresh) {
                scheduleGridUpdate(grid);
            };
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
<%--    <dx:ASPxTimer ID="ASPxTimer1" runat="server" Interval="4000">
        <ClientSideEvents Tick="function(s, e) { grid.Refresh(); }" />
    </dx:ASPxTimer>--%>

    <div>
        <dx:ASPxCheckBox ID="ASPxCheckBoxAutoRefresh" runat="server" Text="Atualizar Automaticamente" ClientVisible="true" ClientInstanceName="cbAutoRef" CheckState="Unchecked" Theme="Office2003Silver">
            <ClientSideEvents ValueChanged="OnValueChanged" />
        </dx:ASPxCheckBox>
        <dx:ASPxGridView runat="server"  ID="gridGeral" ClientInstanceName="grid" KeyFieldName="ROWNUM" AutoGenerateColumns="False" Theme="Office2010Silver" Width="100%">
            <ClientSideEvents Init="grid_Init" BeginCallback="grid_BeginCallback" EndCallback="grid_EndCallback" />
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RM" VisibleIndex="10" Caption="RM" Width="70px">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DATA_RM" VisibleIndex="20" Caption="Data RM" Width="120px">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="MATRICULA" VisibleIndex="30" Caption="Matrícula" Width="70px">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NOME" VisibleIndex="40" Caption="Nome">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ID_ESTRUTURA" VisibleIndex="50" Caption="ID Estrutura" Width="70px">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ESTRUTURA" VisibleIndex="60" Caption="Estrutura">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ITEM" VisibleIndex="70" Caption="Item">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsPager PageSize="1000">
            </SettingsPager>
            <Settings ShowTitlePanel="true" ShowFilterRow="True" ShowFooter="True" />
            <SettingsText Title="RM EPI Pendente" />
            <SettingsContextMenu Enabled="True">
            </SettingsContextMenu>
            <SettingsBehavior AllowDragDrop="False" AllowSort="False" />
            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            <SettingsSearchPanel ShowApplyButton="True" Visible="True" AllowTextInputTimer="False" ShowClearButton="True" />
            <TotalSummary>
                <dx:ASPxSummaryItem FieldName="RM" DisplayFormat="TOTAL: {0} itens" SummaryType="Count" />
            </TotalSummary>
            <Styles>
                <Header Wrap="True">
                </Header>
                <TitlePanel Font-Size="Large">
                </TitlePanel>
            </Styles>
        </dx:ASPxGridView>
    </div>
</asp:Content>
