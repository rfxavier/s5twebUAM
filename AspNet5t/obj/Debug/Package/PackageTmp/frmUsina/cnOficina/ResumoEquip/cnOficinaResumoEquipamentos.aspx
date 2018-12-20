<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnOficinaResumoEquipamentos.aspx.vb" Inherits="AspNet5t.cnOficinaResumoEquipamentos" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style type="text/css">
        td.dxgvDetailCell { padding: 0px; }
        td.dxgvDetailCell_Office2010Silver { padding: 0px; }
        .dxgvDetailRow_Office2010Silver td.dxgvDetailCell_Office2010Silver { padding: 0px; }
    </style>

    <script type="text/javascript">
        function OnSelectionChangedCm(s, e) {
            s.GetRowValues(e.visibleIndex, "COD_CLASSE_MECANICA;DSC_CLASSE_MECANICA", onGetValuesCm);
        }
        function onGetValuesCm(data) {
            if (data[1] != null) {
                gvDetalhe.ApplyFilter("[DSC_CLASSE_MECANICA] = '" + data[1] + "'");
                //lbl1.SetText(data[1])
            };
        }

        function OnSelectionChangedCmCo(s, e) {
            s.GetRowValues(e.visibleIndex, "COD_CLASSE_MECANICA;DSC_CLASSE_MECANICA;COD_CLASSE_OPERACIONAL;DSC_CLASSE_OPERACIONAL", onGetValuesCmCo);
        }
        function onGetValuesCmCo(data) {
            if (data[1] != null) {
                gvDetalhe.ApplyFilter("[DSC_CLASSE_MECANICA] = '" + data[1] + "' and [DSC_CLASSE_OPERACIONAL] = '" + data[3] + "'");
                //lbl1.SetText(data[3])
            };
        }

        function OnSelectionChangedCmCoSe(s, e) {
            s.GetRowValues(e.visibleIndex, "COD_CLASSE_MECANICA;DSC_CLASSE_MECANICA;COD_CLASSE_OPERACIONAL;DSC_CLASSE_OPERACIONAL;COD_SETOR;DSC_SETOR", onGetValuesCmCoSe);
        }
        function onGetValuesCmCoSe(data) {
            if (data[1] != null) {
                gvDetalhe.ApplyFilter("[DSC_CLASSE_MECANICA] = '" + data[1] + "' and [DSC_CLASSE_OPERACIONAL] = '" + data[3] + "' and [DSC_SETOR] = '" + data[5] + "'");
                //lbl1.SetText(data[3])
            };
        }
    </script>

</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="gridCm" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceCM" KeyFieldName="COD_CLASSE_MECANICA" Theme="Office2010Silver" ClientInstanceName="gvCm">
        <TotalSummary>
            <dx:ASPxSummaryItem DisplayFormat="TOTAL GERAL" FieldName="calcDESCRICAO" ShowInColumn="Descri&#231;&#227;o" SummaryType="Count" />
            <dx:ASPxSummaryItem DisplayFormat="{0}" FieldName="BASICA" ShowInColumn="B&#225;sica" SummaryType="Sum" />
            <dx:ASPxSummaryItem DisplayFormat="{0}" FieldName="RAPIDA" ShowInColumn="R&#225;pida" SummaryType="Sum" />
            <dx:ASPxSummaryItem DisplayFormat="{0}" FieldName="OFICINA" ShowInColumn="Oficina" SummaryType="Sum" />
            <dx:ASPxSummaryItem DisplayFormat="{0}" FieldName="VOLANTE" ShowInColumn="Volante" SummaryType="Sum" />
            <dx:ASPxSummaryItem DisplayFormat="{0}" FieldName="EXTERNA" ShowInColumn="Externa" SummaryType="Sum" />
            <dx:ASPxSummaryItem DisplayFormat="{0}" FieldName="EXTERNA_UAM" ShowInColumn="Ext.UAM" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="TOTAL" DisplayFormat="{0}" ShowInColumn="Total" SummaryType="Sum"></dx:ASPxSummaryItem>
            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="DISP" ShowInColumn="Disp" SummaryType="Custom" />
        </TotalSummary>
        <Columns>
            <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="COD_CLASSE_MECANICA" VisibleIndex="1" Visible="False">
                <Settings ShowInFilterControl="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DSC_CLASSE_MECANICA" VisibleIndex="2" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="BASICA" VisibleIndex="4" Caption="B&#225;sica" Width="62px"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RAPIDA" VisibleIndex="5" Caption="R&#225;pida" Width="62px"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="OFICINA" VisibleIndex="6" Caption="Oficina" Width="62px"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="VOLANTE" VisibleIndex="7" Caption="Volante" Width="62px"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EXTERNA" VisibleIndex="8" Caption="Externa" Width="62px"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EXTERNA_UAM" VisibleIndex="9" Caption="Ext.UAM" Width="62px"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TOTAL" VisibleIndex="10" Caption="Total" Width="62px"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DISP" VisibleIndex="11" Caption="Disp" Width="62px">
                <PropertiesTextEdit DisplayFormatString="{0:#,#0.0}" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="calcDESCRICAO" UnboundExpression="[COD_CLASSE_MECANICA] + ' - ' + [DSC_CLASSE_MECANICA]" UnboundType="String" VisibleIndex="3" Caption="Descri&#231;&#227;o">
            </dx:GridViewDataTextColumn>
        </Columns>
        <ClientSideEvents SelectionChanged="OnSelectionChangedCm" />
        <%--<ClientSideEvents SelectionChanged="function(s, e) { if(!isSelection) OnGridSelectionChanged(s, e); }" />--%>
        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
        <SettingsPager PageSize="1000">
        </SettingsPager>
        <Settings UseFixedTableLayout="True" ShowFooter="True" ShowTitlePanel="true" />
        <SettingsText Title="Resumo de Equipamentos por Classe Mecânica, Classe Operacional e Setor" />
        <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
        <Styles>
            <Header Wrap="True">
            </Header>
            <AlternatingRow Enabled="True" BackColor="#CEFFB7">
            </AlternatingRow>
            <TitlePanel Font-Size="Medium">
            </TitlePanel>
        </Styles>
        <Templates>
            <DetailRow>
                <dx:ASPxGridView ID="gridCmCo" runat="server" DataSourceID="SqlDataSourceCMCO" KeyFieldName="COD_CLASSE_MECANICA;COD_CLASSE_OPERACIONAL" OnBeforePerformDataSelect="gridCmCo_BeforePerformDataSelect" AutoGenerateColumns="False" Theme="Office2010Silver" ClientInstanceName="gvCmCo">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="COD_CLASSE_MECANICA" VisibleIndex="1" Visible="False"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DSC_CLASSE_MECANICA" VisibleIndex="2" Visible="False"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="COD_CLASSE_OPERACIONAL" VisibleIndex="3" Visible="False"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DSC_CLASSE_OPERACIONAL" VisibleIndex="4" Visible="False"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="BASICA" VisibleIndex="6" Width="62px"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="RAPIDA" VisibleIndex="7" Width="62px"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="OFICINA" VisibleIndex="8" Width="62px"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="VOLANTE" VisibleIndex="9" Width="62px"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EXTERNA" VisibleIndex="10" Width="62px"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EXTERNA_UAM" VisibleIndex="11" Width="62px"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TOTAL" VisibleIndex="12" Width="62px"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DISP" VisibleIndex="13" Width="62px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.0}" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="calcDESCRICAO" UnboundType="String" UnboundExpression="'     ' + [COD_CLASSE_OPERACIONAL] + ' - ' + [DSC_CLASSE_OPERACIONAL]" Caption="Descri&#231;&#227;o" VisibleIndex="5"></dx:GridViewDataTextColumn>
                    </Columns>
                    <ClientSideEvents SelectionChanged="OnSelectionChangedCmCo" />
                    <%--<ClientSideEvents SelectionChanged="function(s, e) { OnSelectionChangedCmCo(s, e); }" />--%>
                    <%--<ClientSideEvents SelectionChanged="function(s, e) { if(!isSelection) OnGridSelectionChanged(s, e); }" />--%>
                    <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                    <SettingsPager PageSize="1000">
                    </SettingsPager>
                    <Settings ShowColumnHeaders="False" UseFixedTableLayout="True" />
                    <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
                    <Styles>
                        <AlternatingRow Enabled="True" BackColor="#CEFFB7">
                        </AlternatingRow>
                    </Styles>
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="gridCmCoSe" runat="server" DataSourceID="SqlDataSourceCMCOSE" KeyFieldName="COD_CLASSE_MECANICA;COD_CLASSE_OPERACIONAL;COD_SETOR" OnBeforePerformDataSelect="gridCmCoSe_BeforePerformDataSelect" AutoGenerateColumns="False" Theme="Office2010Silver" ClientInstanceName="gvCmCoSe">
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="COD_CLASSE_MECANICA" VisibleIndex="1" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DSC_CLASSE_MECANICA" VisibleIndex="2" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="COD_CLASSE_OPERACIONAL" VisibleIndex="3" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DSC_CLASSE_OPERACIONAL" VisibleIndex="4" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="COD_SETOR" VisibleIndex="6" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DSC_SETOR" VisibleIndex="7" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="BASICA" VisibleIndex="8" Width="62px"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="RAPIDA" VisibleIndex="9" Width="62px"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="OFICINA" VisibleIndex="10" Width="62px"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="VOLANTE" VisibleIndex="11" Width="62px"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="EXTERNA" VisibleIndex="12" Width="62px"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="EXTERNA_UAM" VisibleIndex="13" Width="62px"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="TOTAL" VisibleIndex="14" Width="62px"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DISP" VisibleIndex="15" Width="62px">
                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.0}" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="calcDESCRICAO" UnboundType="String" UnboundExpression="'     ' + [COD_SETOR] + ' - ' + [DSC_SETOR]" Caption="Descri&#231;&#227;o" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                </Columns>
                                <ClientSideEvents SelectionChanged="OnSelectionChangedCmCoSe" />
                                <%--<ClientSideEvents SelectionChanged="function(s, e) { if(!isSelection) OnGridSelectionChanged(s, e); }" />--%>
                                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                                <SettingsPager PageSize="1000">
                                </SettingsPager>
                                <Settings ShowColumnHeaders="False" UseFixedTableLayout="True" />
                                <%--<SettingsDetail ShowDetailRow="True" />--%>
                                <Styles>
                                    <AlternatingRow Enabled="True" BackColor="#CEFFB7">
                                    </AlternatingRow>
                                </Styles>
                                <Border BorderStyle="None" />
                                <Styles>
                                    <DetailCell>
                                        <Border BorderStyle="None" />
                                    </DetailCell>
                                </Styles>
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>

                    <Border BorderStyle="None" />
                    <Styles>
                        <DetailCell>
                            <Border BorderStyle="None" />
                        </DetailCell>
                    </Styles>
                </dx:ASPxGridView>
            </DetailRow>
        </Templates>
    </dx:ASPxGridView>

    <dx:ASPxGridView ID="gridDetalhe" runat="server" ClientInstanceName="gvDetalhe" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDetalhe" KeyFieldName="ROWNUM" Width="100%" EnableTheming="True" Theme="Office2010Silver" >
        <TotalSummary>
            <dx:ASPxSummaryItem SummaryType="Custom" DisplayFormat="Total em Manutenção: {0}" ShowInColumn="Descri&#231;&#227;o Equipamento" FieldName="NUMERO_EQUIPAMENTO_FROTA"></dx:ASPxSummaryItem>
        </TotalSummary>
        <Columns>
            <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="COD_CLASSE_MECANICA" VisibleIndex="1" Visible="False" Caption="C&#243;d.Classe Mec&#226;nica">
                <Settings ShowInFilterControl="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DSC_CLASSE_MECANICA" VisibleIndex="2" Visible="False" Caption="Classe Mec&#226;nica">
                <Settings ShowInFilterControl="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="COD_CLASSE_OPERACIONAL" VisibleIndex="3" Visible="False" Caption="C&#243;d.Classe Operacional">
                <Settings ShowInFilterControl="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DSC_CLASSE_OPERACIONAL" VisibleIndex="4" Visible="False" Caption="Classe Operacional">
                <Settings ShowInFilterControl="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NUMERO_EQUIPAMENTO_FROTA" VisibleIndex="5" Caption="N&#186; Equip.Frota">
                <Settings AllowHeaderFilter="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DSC_EQUIPAMENTO_FROTA" VisibleIndex="6" Caption="Descri&#231;&#227;o Equipamento" Width="200px">
                <Settings AllowHeaderFilter="True" />
                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NUMERO_OS" VisibleIndex="9" Caption="N&#186; OS" Width="70px">
                <Settings AllowHeaderFilter="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DATAHORAABERTURA" VisibleIndex="12" Caption="Data/Hora Abertura" Width="120px">
                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                <PropertiesDateEdit DisplayFormatString="{0:dd/MM/yyyy HH:mm}" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="HORAS_PARADA" VisibleIndex="10" Caption="Horas Parada" Width="60px">
                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                <PropertiesTextEdit DisplayFormatString="{0:#,#0}" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="COD_SETOR" VisibleIndex="15" Visible="False" Caption="C&#243;d.Setor">
                <Settings ShowInFilterControl="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DSC_SETOR" VisibleIndex="16" Visible="False" Caption="Setor">
                <Settings ShowInFilterControl="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DATAHORAFECHAMENTO" VisibleIndex="17" Visible="False"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="PROGNOSTICO" VisibleIndex="14" Caption="Progn&#243;stico" Width="1400px">
                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="COD_FRENTE" VisibleIndex="7" Caption="C&#243;d.Frente">
                <Settings AllowHeaderFilter="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DSC_FRENTE" VisibleIndex="8" Caption="Frente" Width="180px">
                <Settings AllowHeaderFilter="True" />
                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DATAHORAPREVISTA" VisibleIndex="13" Caption="Data/Hora Prevista" Width="120px">
                <Settings AllowHeaderFilter="False" AllowAutoFilter="True" />
                <PropertiesDateEdit DisplayFormatString="{0:dd/MM/yyyy HH:mm}" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="DISP" VisibleIndex="18" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LOCAL" VisibleIndex="11" Caption="Local">
                <Settings AllowHeaderFilter="True" />
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior AllowDragDrop="False" />
<%--        <SettingsPager Mode="EndlessPaging">
        </SettingsPager>--%>
        <SettingsPager PageSize="1000">
        </SettingsPager>
        <Settings HorizontalScrollBarMode="Visible" ShowTitlePanel="true" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" />
        <%--<Settings HorizontalScrollBarMode="Visible" ShowTitlePanel="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" VerticalScrollBarStyle="Virtual" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowGroupFooter="VisibleIfExpanded" />--%>
        <SettingsText Title="Detalhamento de Equipamentos" />
        <SettingsContextMenu Enabled="True">
        </SettingsContextMenu>
        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
        <SettingsSearchPanel ShowApplyButton="True" Visible="True" AllowTextInputTimer="False" ShowClearButton="True" />
        <Styles>
            <Header Wrap="True">
            </Header>
            <TitlePanel Font-Size="Medium">
            </TitlePanel>
        </Styles>
    </dx:ASPxGridView>

    <asp:SqlDataSource runat="server" ID="SqlDataSourceCM" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT ROWNUM, A.* FROM (SELECT R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'BASICA') BASICA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'RAPIDA') RAPIDA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'OFICINA') OFICINA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'VOLANTE') VOLANTE, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'EXTERNA' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.LOCAL IN ('OFICINA'))) EXTERNA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'EXTERNA/UAM' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.LOCAL IN ('OFICINA','EXTERNA'))) EXTERNA_UAM, COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA) TOTAL, ROUND((((SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA) - COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA)) * 100) / (SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA), 1) DISP FROM BI4T.V_RESUMO_OFICINA R GROUP BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA) A"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceCMCO" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT ROWNUM, A.* FROM (SELECT R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'BASICA') BASICA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'RAPIDA') RAPIDA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'OFICINA') OFICINA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'VOLANTE') VOLANTE, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'EXTERNA' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.COD_CLASSE_OPERACIONAL = RB.COD_CLASSE_OPERACIONAL AND RB2.LOCAL IN ('OFICINA'))) EXTERNA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'EXTERNA/UAM' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.COD_CLASSE_OPERACIONAL = RB.COD_CLASSE_OPERACIONAL AND RB2.LOCAL IN ('OFICINA','EXTERNA'))) EXTERNA_UAM, COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA) TOTAL, ROUND((((SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND X.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL) - COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA)) * 100) / (SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND X.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL), 1) DISP FROM BI4T.V_RESUMO_OFICINA R WHERE R.COD_CLASSE_MECANICA = 1 GROUP BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL ORDER BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL) A"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceCMCOSE" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT ROWNUM, A.* FROM (SELECT R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL, R.COD_SETOR, R.DSC_SETOR, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'BASICA') BASICA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'RAPIDA') RAPIDA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'OFICINA') OFICINA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'VOLANTE') VOLANTE, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'EXTERNA' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.LOCAL IN ('OFICINA'))) EXTERNA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'EXTERNA/UAM' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.LOCAL IN ('OFICINA', 'EXTERNA'))) EXTERNA_UAM, COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA) TOTAL, ROUND((((SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND X.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND X.COD_SETOR = R.COD_SETOR) - COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA)) * 100) / (SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND X.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND X.COD_SETOR = R.COD_SETOR), 1) DISP FROM BI4T.V_RESUMO_OFICINA R WHERE R.COD_CLASSE_MECANICA = 1 AND R.COD_CLASSE_OPERACIONAL = 1 GROUP BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL, R.COD_SETOR, R.DSC_SETOR ORDER BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL, R.COD_SETOR, R.DSC_SETOR) A"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceDetalhe" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT ROWNUM, A.* FROM BI4T.V_RESUMO_OFICINA A"></asp:SqlDataSource>
</asp:Content>
