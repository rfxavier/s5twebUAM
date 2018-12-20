<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaAcompProdutividade1Corte.aspx.vb" Inherits="AspNet5t.cnEntCanaAcompProdutividade1Corte" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/UserControls/ucCapivaraPopUp.ascx" TagPrefix="uc1" TagName="ucCapivaraPopUp" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
        function OnSelectionChanged(s, e) {
            grid1.GetRowValues(e.visibleIndex, "PROP_CODIGO;SEMANA_ENCERRAMENTO;DS_NOME_PROPRIEDADE", onGetValues);
        }
        function onGetValues(data) {
            if (data[0] != null) {
                grid2.ApplyFilter("[PROP_CODIGO] = '" + data[0] + "' and [SEMANA_ENCERRAMENTO] = '" + data[1] + "'");

                btnHistoricoProp.SetText("Histórico " + data[2] + " ( " + data[0] + " ) ");
                btnHistoricoProp.SetVisible(true);

                //hypMapaProp.SetText("Mapa " + data[2] + " ( " + data[0] + " ) ");
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
<%--    <div class="hyperlink-mapa-gridview">
        <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Mapa" NavigateUrl="~/Content/mapas/00338.pdf" Target="_blank" ClientInstanceName="hypMapaProp">
        </dx:ASPxHyperLink>
    </div>--%>
    <div>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1Corte" KeyFieldName="ROWNUM" Width="100%" EnableTheming="True" Theme="Office2010Silver" ClientInstanceName="grid1">
            <TotalSummary>
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_AREA_COLHIDA" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="IDADE" ShowInColumn="Idade" SummaryType="Average" ValueDisplayFormat="{0:#,#0}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_TON_ENTREGUE" ShowInColumn="Cana Entregue" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
            </TotalSummary>
            <GroupSummary>
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_AREA_COLHIDA" ShowInGroupFooterColumn="Área Colhida" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="IDADE" ShowInGroupFooterColumn="Idade" SummaryType="Average" ValueDisplayFormat="{0:#,#0}" />
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
                <dx:GridViewDataTextColumn FieldName="NRO_CORTE" VisibleIndex="24" Caption="No.Corte" Visible="False"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="QT_AREA_COLHIDA" VisibleIndex="4" Caption="Área Colhida">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="IDADE" VisibleIndex="5" Caption="Idade">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_PROPRIEDADE" VisibleIndex="6" Caption="Tipo">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="QT_TON_ENTREGUE" VisibleIndex="7" Caption="Cana Entregue">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RENDIMENTO_PLAN" VisibleIndex="8" Caption="Rend. Plan.">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RENDIMENTO_REAL" VisibleIndex="9" Caption="Rend. Real" SortIndex="1" SortOrder="Ascending">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="INCENDIO" VisibleIndex="13" Caption="Incêndio">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DATA_INCENDIO" VisibleIndex="14" Caption="Data Inc&#234;ndio">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="DT_DESSECACAO" VisibleIndex="15" Caption="Data Dessecação">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="DT_CALAGEM" VisibleIndex="16" Caption="Data Calagem">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="DT_PLANTIO" VisibleIndex="17" Caption="Data Plantio">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_PLANTIO" VisibleIndex="18" Caption="Tipo Plantio">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EMPRESA_PLANTIO" VisibleIndex="19" Caption="Empresa">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="STAND" VisibleIndex="20" Caption="Stand (média pl)">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_ADUBACAO" VisibleIndex="21" Caption="Tipo Adubação">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TRAT_TOLETES" VisibleIndex="22" Caption="Trat. Toletes">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_HERB_CANA_PLANTA" VisibleIndex="23" Caption="Data da Apl. Herbicida C Planta">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="SEMANA_ENCERRAMENTO" VisibleIndex="1" Caption="Semana Encerramento">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DESVIO" VisibleIndex="10" Caption="Produtiv. Desvio (%)">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PORC_BROCA" VisibleIndex="11" Caption="Perc. Broca">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PERDAS" VisibleIndex="12" Caption="Perdas">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                </dx:GridViewDataTextColumn>
            </Columns>
            <ClientSideEvents SelectionChanged="OnSelectionChanged" />
            <SettingsBehavior AllowDragDrop="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
            <SettingsPager Mode="EndlessPaging">
            </SettingsPager>
            <Settings HorizontalScrollBarMode="Visible" ShowTitlePanel="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" VerticalScrollBarStyle="Virtual" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" />
            <SettingsText Title="Acompanhamento de Produtividade 1° Corte" />
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
        <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1CorteTalhao" KeyFieldName="ROWNUM" Width="100%" EnableTheming="True" Theme="Office2010Silver" ClientInstanceName="grid2">
            <TotalSummary>
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_AREA_COLHIDA" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="IDADE" ShowInColumn="Idade" SummaryType="Average" ValueDisplayFormat="{0:#,#0}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_TON_ENTREGUE" ShowInColumn="Cana Entregue" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
            </TotalSummary>
            <GroupSummary>
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.00}" FieldName="QT_AREA_COLHIDA" ShowInGroupFooterColumn="Área Colhida" SummaryType="Sum" ValueDisplayFormat="{0:#,#0.00}" />
                <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="IDADE" ShowInGroupFooterColumn="Idade" SummaryType="Average" ValueDisplayFormat="{0:#,#0}" />
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
                <dx:GridViewDataTextColumn FieldName="NRO_CORTE" VisibleIndex="24" Caption="No.Corte" Visible="False"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="QT_AREA_COLHIDA" VisibleIndex="5" Caption="Área Colhida">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="IDADE" VisibleIndex="6" Caption="Idade">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_PROPRIEDADE" VisibleIndex="7" Caption="Tipo">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="QT_TON_ENTREGUE" VisibleIndex="8" Caption="Cana Entregue">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RENDIMENTO_PLAN" VisibleIndex="9" Caption="Rend. Plan.">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RENDIMENTO_REAL" VisibleIndex="10" Caption="Rend. Real" SortIndex="1" SortOrder="Ascending">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="INCENDIO" VisibleIndex="14" Caption="Incêndio">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DATA_INCENDIO" VisibleIndex="15" Caption="Data Inc&#234;ndio">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="DT_DESSECACAO" VisibleIndex="16" Caption="Data Dessecação">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="DT_CALAGEM" VisibleIndex="17" Caption="Data Calagem">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="DT_PLANTIO" VisibleIndex="18" Caption="Data Plantio">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_PLANTIO" VisibleIndex="19" Caption="Tipo Plantio">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EMPRESA_PLANTIO" VisibleIndex="20" Caption="Empresa">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="STAND" VisibleIndex="21" Caption="Stand (média pl)">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TIPO_ADUBACAO" VisibleIndex="22" Caption="Tipo Adubação">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TRAT_TOLETES" VisibleIndex="23" Caption="Trat. Toletes">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DT_HERB_CANA_PLANTA" VisibleIndex="25" Caption="Data da Apl. Herbicida C Planta">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="SEMANA_ENCERRAMENTO" VisibleIndex="1" Caption="Semana Encerramento">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DESVIO" VisibleIndex="11" Caption="Produtiv. Desvio (%)">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PORC_BROCA" VisibleIndex="12" Caption="Perc. Broca">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PERDAS" VisibleIndex="13" Caption="Perdas">
                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior AllowDragDrop="False" />
            <SettingsPager Mode="EndlessPaging">
            </SettingsPager>
            <Settings HorizontalScrollBarMode="Visible" ShowTitlePanel="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" VerticalScrollBarStyle="Virtual" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" />
            <SettingsText Title="Acompanhamento de Produtividade 1° Corte por Talhão" />
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

    <asp:SqlDataSource ID="SqlDataSource1Corte" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM, A.* FROM (SELECT TRUNC(A.PROP_CODIGO) PROP_CODIGO, A.DS_NOME_PROPRIEDADE, TRUNC(A.NRO_CORTE) NRO_CORTE, ROUND(SUM(A.QT_AREA_COLHIDA), 2) QT_AREA_COLHIDA, TRUNC(A.IDADE) IDADE, A.TIPO_PROPRIEDADE, ROUND(SUM(A.QT_TON_ENTREGUE), 3) QT_TON_ENTREGUE, ROUND(A.RENDIMENTO_PLAN, 0) RENDIMENTO_PLAN, ROUND(DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA)))) RENDIMENTO_REAL, ROUND(((DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA))) / DECODE(NVL(SUM(A.QT_TON_ENTREGUE), 0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE)))) - 1) * 100) DESVIO, ROUND(DECODE(SUM(A.QT_TON_ENTREGUE_BROCA), 0, 0, (SUM(A.PORC_BROCA * A.QT_TON_ENTREGUE_BROCA) / SUM(A.QT_TON_ENTREGUE_BROCA))), 2) PORC_BROCA, ROUND(DECODE(SUM(A.PERDA_AREA), 0, 0, (SUM(PERDA_TOTAL) / SUM(A.PERDA_AREA))), 3) PERDAS, A.INCENDIO, MAX(A.DATA_INCENDIO) DATA_INCENDIO, MAX(A.DT_DESSECACAO) DT_DESSECACAO, MAX(A.DT_CALAGEM) DT_CALAGEM, MAX(A.DT_PLANTIO) DT_PLANTIO, A.TIPO_PLANTIO, A.EMPRESA_PLANTIO, ROUND(AVG(A.STAND)) STAND, A.TIPO_ADUBACAO, A.TRAT_TOLETES, MAX(A.DT_HERB_CANA_PLANTA) DT_HERB_CANA_PLANTA, A.SEMANA_ENCERRAMENTO FROM BI4T.V_PRODUTIVIDADE_1CORTE A GROUP BY A.PROP_CODIGO, A.DS_NOME_PROPRIEDADE, A.NRO_CORTE, A.IDADE, A.TIPO_PROPRIEDADE, A.RENDIMENTO_PLAN, A.INCENDIO, A.TIPO_PLANTIO, A.EMPRESA_PLANTIO, A.TIPO_ADUBACAO, A.TRAT_TOLETES, A.SEMANA_ENCERRAMENTO) A"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1CorteTalhao" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM, TRUNC(A.PROP_CODIGO) PROP_CODIGO, A.DS_NOME_PROPRIEDADE, TRUNC(A.TALHAO) TALHAO, TRUNC(A.NRO_CORTE) NRO_CORTE, ROUND(A.QT_AREA_COLHIDA, 2) QT_AREA_COLHIDA, TRUNC(A.IDADE) IDADE, A.TIPO_PROPRIEDADE, ROUND(A.QT_TON_ENTREGUE, 2) QT_TON_ENTREGUE, ROUND(A.RENDIMENTO_PLAN, 0) RENDIMENTO_PLAN, ROUND(A.RENDIMENTO_REAL, 0) RENDIMENTO_REAL, ROUND(A.DESVIO, 0) DESVIO, ROUND(A.PORC_BROCA, 2) PORC_BROCA, ROUND(A.PERDA, 2) PERDAS, A.INCENDIO, A.DATA_INCENDIO, A.DT_DESSECACAO, A.DT_CALAGEM, A.DT_PLANTIO, A.TIPO_PLANTIO, A.EMPRESA_PLANTIO, ROUND(A.STAND, 0) STAND, A.TIPO_ADUBACAO, A.TRAT_TOLETES, A.DT_HERB_CANA_PLANTA, A.SEMANA_ENCERRAMENTO FROM BI4T.V_PRODUTIVIDADE_1CORTE A"></asp:SqlDataSource>
</asp:Content>
