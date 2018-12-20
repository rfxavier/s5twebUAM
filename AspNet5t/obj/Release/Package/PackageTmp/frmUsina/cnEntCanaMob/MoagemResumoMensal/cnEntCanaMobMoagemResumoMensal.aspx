<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaMobMoagemResumoMensal.aspx.vb" Inherits="AspNet5t.cnEntCanaMobMoagemResumoMensal" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
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
            cbPanel.PerformCallback();
            cbPanelLabel.PerformCallback();
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    
     <div class="clear-float">
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel4" runat="server" Width="100%" ClientInstanceName="cbPanelLabel">
            <SettingsLoadingPanel Enabled="false" />
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <div style="float:left; margin-top:8px;" >
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Resumo de Moagem" style="font-size:18px; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
                        </dx:ASPxLabel>
                    </div>
                    <div id="divTonHoraMedia" style="float: left; text-align: center; margin-left: 10px; margin-top:8px; border: thin solid black;">
                        <dx:ASPxLabel ID="ASPxLabelSafraMes" runat="server" Text="Safra 2015 - " ClientVisible="true" ClientInstanceName="lbSafraMes" EncodeHtml="False" Style="font-size: 18px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" Width="220px">
                        </dx:ASPxLabel>
                    </div>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>

    

    <div class="botoes-direita">
        <dx:ASPxDateEdit ID="dataReferencia" runat="server" EditFormat="Date" AllowNull="False" Date="03/08/2015 18:00:00" Width="150px" BackColor="#97FF97" AllowUserInput="False" Theme="iOS" ClientInstanceName="btnData">
            <ClientSideEvents DateChanged="OnDateChanged" />
            <CalendarProperties ShowClearButton="False" ShowWeekNumbers="False" ShowTodayButton="True">
            </CalendarProperties>
            <ButtonStyle>
                <Border BorderStyle="None" />
            </ButtonStyle>
        </dx:ASPxDateEdit>
    </div>


    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="cbPanel">
        <PanelCollection>
            <dx:PanelContent runat="server">

                <div class="clear-float">
                    <dx:ASPxDashboardViewer ID="ASPxDashMoagemMensalDiaria" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaMoagemMensalDiaria" Width="98%" Height="490px" UseDataAccessApi="True" ClientInstanceName="dvdiaria">
                    </dx:ASPxDashboardViewer>
                </div>

                <div class="clear-float">
                    <dx:ASPxDashboardViewer ID="ASPxDashMoagemMensalAcumulada" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaMoagemMensalAcumulada" Width="98%" Height="490px" UseDataAccessApi="True" ClientInstanceName="dvmensal">
                    </dx:ASPxDashboardViewer>
                </div>

                <div class="clear-float">
                    <dx:ASPxDashboardViewer ID="ASPxDashMoagemMensalSafra" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaMoagemMensalSafra" Width="98%" Height="490px" UseDataAccessApi="True" ClientInstanceName="dvmensal">
                    </dx:ASPxDashboardViewer>
                </div>

                <div class="clear-float">
                    <dx:ASPxDashboardViewer ID="ASPxDashMoagemMensalSafraAcumulada" runat="server" DashboardSource="AspNet5t.Win_Dashboards.dashCnEntCanaMoagemMensalSafraAcumulada" Width="98%" Height="490px" UseDataAccessApi="True" ClientInstanceName="dvmensal">
                    </dx:ASPxDashboardViewer>
                </div>

                <div class="clear-float">
                    <span style="font-weight: bold">RESUMO</span>
                    <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" DataSourceID="SqlDataSourceMoagemMensalResumo" EnableTheming="True" Theme="Office2010Silver">
                        <Fields>
                            <dx:PivotGridField FieldName="TONELADA" ID="fieldTONELADA" Area="DataArea" AreaIndex="0" CellFormat-FormatString="{0:#,#0}" CellFormat-FormatType="Numeric"></dx:PivotGridField>
                            <dx:PivotGridField FieldName="MES" ID="fieldMES" Area="ColumnArea" AreaIndex="0" SortMode="Custom"></dx:PivotGridField>
                            <dx:PivotGridField FieldName="TIPO" ID="fieldTIPO" Area="RowArea" AreaIndex="0" Caption=" " SortOrder="Descending"></dx:PivotGridField>
                        </Fields>
                        <OptionsView ShowColumnGrandTotals="True" ShowRowGrandTotals="False" ShowColumnHeaders="False" ShowContextMenus="False" ShowDataHeaders="False" ShowFilterHeaders="False" ShowFilterSeparatorBar="False" />
                        <OptionsCustomization AllowCustomizationForm="False" AllowDrag="False" AllowDragInCustomizationForm="False" AllowExpand="False" AllowExpandOnDoubleClick="False" AllowFilter="False" AllowFilterBySummary="False" AllowPrefilter="False" AllowSort="False" AllowSortBySummary="False" />
                        <Styles>
                            <RowAreaStyle BackColor="White">
                            </RowAreaStyle>
                        </Styles>
                        <EmptyAreaTemplate>
                            RESUMO
                        </EmptyAreaTemplate>
                    </dx:ASPxPivotGrid>
                </div>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

    <asp:SqlDataSource runat="server" ID="SqlDataSourceMoagemMensalResumo" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N, 'REAL' TIPO, SUM(XY.TONELADA_REAL) TONELADA_REAL FROM (SELECT X.ID_NEGOCIOS, X.NRO_ANO_SAFRA, TO_CHAR(X.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE') MES, TO_NUMBER(TO_CHAR(X.DIA, 'MM')) MES_N, X.DIA, X.TON_PLAN_DIA TONELADA_PLAN, SUM(A.TONELADAS) TONELADA_REAL FROM MOAGEM_CANA_HORA A, (SELECT C.ID_NEGOCIOS, C.NRO_ANO_SAFRA, C.DIA, D.TON_PLAN_DIA FROM (SELECT B.ID_NEGOCIOS, B.SAFR_ANO NRO_ANO_SAFRA, B.SAFR_INICIO + ROWNUM - 1 DIA FROM DUAL, (SELECT * FROM SISAGRI.SAFRA B WHERE B.SAFR_SAFRA_ATUAL = '*') B CONNECT BY LEVEL <= B.SAFR_FIM - B.SAFR_INICIO + 1) C, (SELECT A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO, ROUND(SUM(TON_PLAN_HORA * 24)) TON_PLAN_DIA FROM SISCOMAG.V_META_COLHEITA A GROUP BY A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO) D WHERE C.DIA BETWEEN D.DATA_INICIO_PERIODO AND D.DATA_FINAL_PERIODO) X WHERE A.ID_NEGOCIOS(+) = X.ID_NEGOCIOS AND A.NRO_ANO_SAFRA(+) = X.NRO_ANO_SAFRA AND A.DIA (+) = X.DIA GROUP BY X.ID_NEGOCIOS, X.NRO_ANO_SAFRA, TO_CHAR(X.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE'), TO_NUMBER(TO_CHAR(X.DIA, 'MM')), X.DIA, X.TON_PLAN_DIA ORDER BY A.DIA) XY GROUP BY XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N UNION ALL SELECT XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N, 'PLANEJADA' TIPO, SUM(XY.TONELADA_PLAN) TONELADA_PLAN FROM (SELECT X.ID_NEGOCIOS, X.NRO_ANO_SAFRA, TO_CHAR(X.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE') MES, TO_NUMBER(TO_CHAR(X.DIA, 'MM')) MES_N, X.DIA, X.TON_PLAN_DIA TONELADA_PLAN, SUM(A.TONELADAS) TONELADA_REAL FROM MOAGEM_CANA_HORA A, (SELECT C.ID_NEGOCIOS, C.NRO_ANO_SAFRA, C.DIA, D.TON_PLAN_DIA FROM (SELECT B.ID_NEGOCIOS, B.SAFR_ANO NRO_ANO_SAFRA, B.SAFR_INICIO + ROWNUM - 1 DIA FROM DUAL, (SELECT * FROM SISAGRI.SAFRA B WHERE B.SAFR_SAFRA_ATUAL = '*') B CONNECT BY LEVEL <= B.SAFR_FIM - B.SAFR_INICIO + 1) C, (SELECT A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO, ROUND(SUM(TON_PLAN_HORA * 24)) TON_PLAN_DIA FROM SISCOMAG.V_META_COLHEITA A GROUP BY A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO) D WHERE C.DIA BETWEEN D.DATA_INICIO_PERIODO AND D.DATA_FINAL_PERIODO) X WHERE A.ID_NEGOCIOS(+) = X.ID_NEGOCIOS AND A.NRO_ANO_SAFRA(+) = X.NRO_ANO_SAFRA AND A.DIA (+) = X.DIA GROUP BY X.ID_NEGOCIOS, X.NRO_ANO_SAFRA, TO_CHAR(X.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE'), TO_NUMBER(TO_CHAR(X.DIA, 'MM')), X.DIA, X.TON_PLAN_DIA ORDER BY A.DIA) XY GROUP BY XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N"></asp:SqlDataSource>

</asp:Content>
