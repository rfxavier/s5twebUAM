<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="WebFormTmpCanaMoagemMensal.aspx.vb" Inherits="AspNet5t.WebFormTmpCanaMoagemMensal" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" DataSourceID="SqlDataSourceMoagemMensalResumo">
        <Fields>
            <dx:PivotGridField FieldName="TONELADA_REAL" ID="fieldTONELADAREAL" Area="DataArea" AreaIndex="0"></dx:PivotGridField>
            <dx:PivotGridField FieldName="TONELADA_PLAN" ID="fieldTONELADAPLAN" Area="DataArea" AreaIndex="1"></dx:PivotGridField>
            <dx:PivotGridField FieldName="MES" ID="fieldMES" Area="ColumnArea" AreaIndex="0" SortMode="Custom"></dx:PivotGridField>
        </Fields>
        <OptionsView ShowColumnGrandTotals="True" ShowColumnHeaders="False" ShowContextMenus="False" ShowDataHeaders="False" ShowFilterHeaders="False" ShowFilterSeparatorBar="False" />
        <OptionsCustomization AllowCustomizationForm="False" AllowDrag="False" AllowDragInCustomizationForm="False" AllowExpand="False" AllowExpandOnDoubleClick="False" AllowFilter="False" AllowFilterBySummary="False" AllowPrefilter="False" AllowSort="False" AllowSortBySummary="False" />
        <Styles>
            <RowAreaStyle BackColor="White">
            </RowAreaStyle>
        </Styles>
        <EmptyAreaTemplate>
            RESUMO
        </EmptyAreaTemplate>
    </dx:ASPxPivotGrid>
<asp:SqlDataSource runat="server" ID="SqlDataSourceMoagemMensalResumo" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N, SUM(XY.TONELADA_PLAN) TONELADA_PLAN, SUM(XY.TONELADA_REAL) TONELADA_REAL FROM (SELECT A.ID_NEGOCIOS, A.NRO_ANO_SAFRA, TO_CHAR(A.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE') MES, TO_NUMBER(TO_CHAR(A.DIA, 'MM')) MES_N, A.DIA, X.TON_PLAN_DIA TONELADA_PLAN, SUM(A.TONELADAS) TONELADA_REAL FROM MOAGEM_CANA_HORA A, (SELECT C.DIA, D.TON_PLAN_DIA FROM (SELECT B.SAFR_INICIO + ROWNUM - 1 DIA FROM DUAL, (SELECT * FROM SISAGRI.SAFRA B WHERE B.SAFR_SAFRA_ATUAL = '*') B CONNECT BY LEVEL <= B.SAFR_FIM - B.SAFR_INICIO + 1) C, (SELECT A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO, ROUND(SUM(TON_PLAN_HORA * 24)) TON_PLAN_DIA FROM SISCOMAG.V_META_COLHEITA A GROUP BY A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO) D WHERE C.DIA BETWEEN D.DATA_INICIO_PERIODO AND D.DATA_FINAL_PERIODO) X WHERE A.DIA = X.DIA GROUP BY A.ID_NEGOCIOS, A.NRO_ANO_SAFRA, TO_CHAR(A.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE'), TO_NUMBER(TO_CHAR(A.DIA, 'MM')), A.DIA, X.TON_PLAN_DIA ORDER BY A.DIA) XY GROUP BY XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N"></asp:SqlDataSource>
</asp:Content>
