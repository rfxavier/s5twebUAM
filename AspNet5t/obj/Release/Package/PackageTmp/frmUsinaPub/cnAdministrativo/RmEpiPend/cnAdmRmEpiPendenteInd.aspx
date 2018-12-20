<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnAdmRmEpiPendenteInd.aspx.vb" Inherits="AspNet5t.cnAdmRmEpiPendenteInd" %>

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
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DATA_RM" VisibleIndex="20" Caption="Data RM" Width="90px">
                    <PropertiesTextEdit DisplayFormatString="{0:dd/MM/yyyy}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="MATRICULA" VisibleIndex="30" Caption="Matrícula" Width="70px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NOME" VisibleIndex="40" Caption="Nome">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ID_ESTRUTURA" VisibleIndex="50" Caption="ID Estrutura" Width="70px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ESTRUTURA" VisibleIndex="60" Caption="Estrutura">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ITEM" VisibleIndex="70" Caption="Item">
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsPager PageSize="30" AlwaysShowPager="True">
            </SettingsPager>
            <Settings ShowTitlePanel="true" />
            <SettingsText Title="RM EPI Pendente" />
            <SettingsContextMenu Enabled="True">
            </SettingsContextMenu>
            <SettingsBehavior AllowDragDrop="False" AllowSort="False" />
            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            <Styles>
                <Header Wrap="True">
                </Header>
                <TitlePanel Font-Size="Large">
                </TitlePanel>
            </Styles>
        </dx:ASPxGridView>
    </div>
</asp:Content>
