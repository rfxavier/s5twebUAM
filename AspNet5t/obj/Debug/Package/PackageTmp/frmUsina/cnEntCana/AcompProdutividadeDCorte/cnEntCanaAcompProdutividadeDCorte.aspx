<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaAcompProdutividadeDCorte.aspx.vb" Inherits="AspNet5t.cnEntCanaAcompProdutividadeDCorte" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/UserControls/ucCapivaraPopUp.ascx" TagPrefix="uc1" TagName="ucCapivaraPopUp" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
        function OnSelectionChanged(s, e) {
            grid1.GetRowValues(e.visibleIndex, "PROP_CODIGO;SEMANA_ENCERRAMENTO;NRO_CORTE;DS_NOME_PROPRIEDADE", onGetValues);
        }
        function onGetValues(data) {
            if (data[0] != null) {
                grid2.ApplyFilter("[PROP_CODIGO] = '" + data[0] + "' and [SEMANA_ENCERRAMENTO] = '" + data[1] + "' and [NRO_CORTE] = '" + data[2] + "'");

                //isFiltered = true;
                btnHistoricoProp.SetText("Histórico " + data[3] + " ( " + data[0] + " ) ");
                btnHistoricoProp.SetVisible(true);
            };
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
    <div class="botao-popcapivara-gridview">
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
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDCorte" KeyFieldName="ROWNUM" Width="100%" EnableTheming="True" Theme="Office2010Silver" ClientInstanceName="grid1">
            <TotalSummary>
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_AREA_COLHIDA" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="IDADE" ShowInColumn="Idade (meses)" SummaryType="Average" ValueDisplayFormat="{0:#,#0}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_TON_ENTREGUE" ShowInColumn="Cana Entregue" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
            </TotalSummary>
            <GroupSummary>
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_AREA_COLHIDA" ShowInGroupFooterColumn="Área Colhida" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="IDADE" ShowInGroupFooterColumn="Idade (meses)" SummaryType="Average" ValueDisplayFormat="{0:#,#0}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_TON_ENTREGUE" ShowInGroupFooterColumn="Cana Entregue" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
            </GroupSummary>
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PROP_CODIGO" VisibleIndex="2" Caption="Cód." SortIndex="0" SortOrder="Ascending">
                    <Settings AllowHeaderFilter="True" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0}" DisplayFormatInEditMode="True" /> 
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DS_NOME_PROPRIEDADE" VisibleIndex="3" Caption="Propriedade">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NRO_CORTE" VisibleIndex="4" Caption="N° Corte" SortIndex="1" SortOrder="Ascending">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="QT_AREA_COLHIDA" VisibleIndex="5" Caption="Área (Ha)">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Idade (meses)" FieldName="IDADE" VisibleIndex="7">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_PROPRIEDADE" VisibleIndex="8" Caption="Tipo">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_COLHEITA_ATUAL" VisibleIndex="26" Visible="False">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="QT_TON_ENTREGUE" VisibleIndex="9" Caption="Cana Entregue">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RENDIMENTO_PLAN" VisibleIndex="10" Caption="Prod. Plan.">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RENDIMENTO_REAL" VisibleIndex="11" Caption="Prod. Real">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DESVIO" VisibleIndex="12" Caption="Produtiv. Desvio (%)">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_COLHEITA_ANTERIOR" VisibleIndex="6" Caption="Data Colheita Anterior">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_ADUBACAO" VisibleIndex="15" Caption="Tipo Adubação">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_ADUBACAO" VisibleIndex="16" Caption="Data Adubação">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="DIF_DIAS_ADUB" VisibleIndex="17" Caption="Dif. Adubação (dias)">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_HERBICIDA" VisibleIndex="21" Caption="Tipo Aplic.">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_HERBICIDA" VisibleIndex="22" Caption="Data Herbicida">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="DIF_DIAS_HERB" VisibleIndex="23" Caption="Dif. Herbicida (dias)">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="INCENDIO" VisibleIndex="18" Caption="Incêndio">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DATA_INCENDIO" VisibleIndex="19" Caption="Data Inc&#234;ndio">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="FERTIRRIGACAO" VisibleIndex="20" Caption="Fertirrigação">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_FERTIRRIGACAO" VisibleIndex="25" Visible="False">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="SEMANA_ENCERRAMENTO" VisibleIndex="1" Caption="Semana Encerramento">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PORC_BROCA" VisibleIndex="13" Caption="Perc. Broca">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PERDAS" VisibleIndex="14" Caption="Perdas">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                </dx:GridViewDataTextColumn>
            </Columns>
            <ClientSideEvents SelectionChanged="OnSelectionChanged" />
            <SettingsBehavior AllowDragDrop="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
            <SettingsPager Mode="EndlessPaging">
            </SettingsPager>
            <Settings HorizontalScrollBarMode="Visible" ShowTitlePanel="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" VerticalScrollBarStyle="Virtual" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" />
            <SettingsText Title="Acompanhamento de Produtividade Demais Cortes" />
            <SettingsContextMenu Enabled="True">
            </SettingsContextMenu>
            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            <SettingsSearchPanel ShowApplyButton="True" Visible="True" AllowTextInputTimer="False" ShowClearButton="True" />
            <Styles>
                <Header Wrap="True">
                </Header>
                <TitlePanel Font-Size="Large">
                </TitlePanel>
            </Styles>
        </dx:ASPxGridView>
        <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDCorte" KeyFieldName="ROWNUM" Width="100%" EnableTheming="True" Theme="Office2010Silver" ClientInstanceName="grid2">
            <TotalSummary>
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_AREA_COLHIDA" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="IDADE" ShowInColumn="Idade (meses)" SummaryType="Average" ValueDisplayFormat="{0:#,#0}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_TON_ENTREGUE" ShowInColumn="Cana Entregue" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
            </TotalSummary>
            <GroupSummary>
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_AREA_COLHIDA" ShowInGroupFooterColumn="Área Colhida" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="IDADE" ShowInGroupFooterColumn="Idade (meses)" SummaryType="Average" ValueDisplayFormat="{0:#,#0}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_TON_ENTREGUE" ShowInGroupFooterColumn="Cana Entregue" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
            </GroupSummary>
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PROP_CODIGO" VisibleIndex="2" Caption="Cód." SortIndex="0" SortOrder="Ascending">
                    <Settings AllowHeaderFilter="True" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0}" DisplayFormatInEditMode="True" /> 
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DS_NOME_PROPRIEDADE" VisibleIndex="3" Caption="Propriedade">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TALHAO" VisibleIndex="4" Caption="Talhão">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NRO_CORTE" VisibleIndex="5" Caption="N° Corte" SortIndex="1" SortOrder="Ascending">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="QT_AREA_COLHIDA" VisibleIndex="6" Caption="Área (Ha)">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Idade (meses)" FieldName="IDADE" VisibleIndex="8">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_PROPRIEDADE" VisibleIndex="9" Caption="Tipo">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_COLHEITA_ATUAL" VisibleIndex="26" Visible="False">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="QT_TON_ENTREGUE" VisibleIndex="10" Caption="Cana Entregue">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RENDIMENTO_PLAN" VisibleIndex="11" Caption="Prod. Plan.">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RENDIMENTO_REAL" VisibleIndex="12" Caption="Prod. Real">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DESVIO" VisibleIndex="13" Caption="Produtiv. Desvio (%)">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_COLHEITA_ANTERIOR" VisibleIndex="7" Caption="Data Colheita Anterior">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_ADUBACAO" VisibleIndex="16" Caption="Tipo Adubação">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_ADUBACAO" VisibleIndex="17" Caption="Data Adubação">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="DIF_DIAS_ADUB" VisibleIndex="18" Caption="Dif. Adubação (dias)">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_HERBICIDA" VisibleIndex="22" Caption="Tipo Aplic.">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_HERBICIDA" VisibleIndex="23" Caption="Data Herbicida">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="DIF_DIAS_HERB" VisibleIndex="24" Caption="Dif. Herbicida (dias)">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="INCENDIO" VisibleIndex="19" Caption="Incêndio">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DATA_INCENDIO" VisibleIndex="20" Caption="Data Inc&#234;ndio">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="FERTIRRIGACAO" VisibleIndex="21" Caption="Fertirrigação">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_FERTIRRIGACAO" VisibleIndex="25" Visible="False">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="SEMANA_ENCERRAMENTO" VisibleIndex="1" Caption="Semana Encerramento">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PORC_BROCA" VisibleIndex="14" Caption="Perc. Broca">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PERDAS" VisibleIndex="15" Caption="Perdas">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior AllowDragDrop="False" />
            <SettingsPager Mode="EndlessPaging">
            </SettingsPager>
            <Settings HorizontalScrollBarMode="Visible" ShowTitlePanel="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" VerticalScrollBarStyle="Virtual" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" />
            <SettingsText Title="Acompanhamento de Produtividade Demais Cortes por Talhão" />
            <SettingsContextMenu Enabled="True">
            </SettingsContextMenu>
            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            <SettingsSearchPanel ShowApplyButton="True" Visible="True" AllowTextInputTimer="False" ShowClearButton="True" />
            <Styles>
                <Header Wrap="True">
                </Header>
                <TitlePanel Font-Size="Large">
                </TitlePanel>
            </Styles>
        </dx:ASPxGridView>
    </div>

    <uc1:ucCapivaraPopUp runat="server" ID="ucCapivaraPopUp" />

    <asp:SqlDataSource ID="SqlDataSourceDCorte" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM, A.* FROM (SELECT TRUNC(A.PROP_CODIGO) PROP_CODIGO, A.DS_NOME_PROPRIEDADE, TRUNC(A.NRO_CORTE) NRO_CORTE, ROUND(SUM(A.QT_AREA_COLHIDA), 2) QT_AREA_COLHIDA, ROUND(SUM(A.IDADE * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE), 2) IDADE, A.TIPO_PROPRIEDADE, ROUND(SUM(A.QT_TON_ENTREGUE), 2) QT_TON_ENTREGUE, ROUND(DECODE(NVL(SUM(A.QT_TON_ENTREGUE), 0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE))), 0) RENDIMENTO_PLAN, ROUND(DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA)))) RENDIMENTO_REAL, ROUND(((DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA))) / DECODE(NVL(SUM(A.QT_TON_ENTREGUE), 0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE)))) - 1) * 100) DESVIO, ROUND(DECODE(SUM(A.QT_TON_ENTREGUE_BROCA), 0, 0, (SUM(A.PORC_BROCA * A.QT_TON_ENTREGUE_BROCA) / SUM(A.QT_TON_ENTREGUE_BROCA))), 2) PORC_BROCA, ROUND(DECODE(SUM(A.PERDA_AREA), 0, 0, (SUM(PERDA_TOTAL) / SUM(A.PERDA_AREA))), 3) PERDAS, MIN(A.DT_COLHEITA_ANTERIOR) DT_COLHEITA_ANTERIOR, A.TIPO_ADUBACAO, MIN(A.DT_ADUBACAO) DT_ADUBACAO, TRUNC(MIN(A.DT_ADUBACAO) - MIN(A.DT_COLHEITA_ANTERIOR)) DIF_DIAS_ADUB, A.TIPO_HERBICIDA, MIN(A.DT_HERBICIDA) DT_HERBICIDA, TRUNC(MIN(A.DT_HERBICIDA) - MIN(A.DT_COLHEITA_ANTERIOR)) DIF_DIAS_HERB, A.INCENDIO, MIN(A.DATA_INCENDIO) DATA_INCENDIO, A.FERTIRRIGACAO, MIN(A.DT_FERTIRRIGACAO) DT_FERTIRRIGACAO, A.SEMANA_ENCERRAMENTO FROM BI4T.V_PRODUTIVIDADE_DCORTE A GROUP BY A.PROP_CODIGO, A.DS_NOME_PROPRIEDADE, A.NRO_CORTE, A.TIPO_PROPRIEDADE, A.TIPO_ADUBACAO, A.TIPO_HERBICIDA, A.INCENDIO, A.FERTIRRIGACAO, A.SEMANA_ENCERRAMENTO) A"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceDCorteTalhao" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM, TRUNC(PROP_CODIGO) PROP_CODIGO, DS_NOME_PROPRIEDADE, TRUNC(TALHAO) TALHAO, TRUNC(NRO_CORTE) NRO_CORTE, ROUND(QT_AREA_COLHIDA, 2) QT_AREA_COLHIDA, TRUNC(IDADE) IDADE, TIPO_PROPRIEDADE, DT_COLHEITA_ATUAL, ROUND(QT_TON_ENTREGUE, 2) QT_TON_ENTREGUE, ROUND(RENDIMENTO_PLAN, 0) RENDIMENTO_PLAN, ROUND(RENDIMENTO_REAL, 0) RENDIMENTO_REAL, ROUND(DESVIO, 0) DESVIO, ROUND(PORC_BROCA, 2) PORC_BROCA, ROUND(PERDA, 2) PERDAS, DT_COLHEITA_ANTERIOR, TIPO_ADUBACAO, DT_ADUBACAO, TRUNC(DIF_DIAS_ADUB) DIF_DIAS_ADUB, TIPO_HERBICIDA, DT_HERBICIDA, TRUNC(DIF_DIAS_HERB) DIF_DIAS_HERB, INCENDIO, DATA_INCENDIO, FERTIRRIGACAO, DT_FERTIRRIGACAO, SEMANA_ENCERRAMENTO FROM BI4T.V_PRODUTIVIDADE_DCORTE"></asp:SqlDataSource>
</asp:Content>
