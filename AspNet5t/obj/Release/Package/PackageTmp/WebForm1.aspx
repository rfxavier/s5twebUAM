<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="WebForm1.aspx.vb" Inherits="AspNet5t.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="NRO_ANO_SAFRA" VisibleIndex="0" Visible="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MES" VisibleIndex="1" Visible="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DIA" VisibleIndex="2" Visible="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TONELADA_PLAN" VisibleIndex="3" Visible="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TONELADA_REAL" VisibleIndex="4" Visible="True"></dx:GridViewDataTextColumn>
        </Columns>
        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
    </dx:ASPxGridView>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT A.ID_NEGOCIOS, A.NRO_ANO_SAFRA, TO_CHAR(A.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE') MES, A.DIA, X.TON_PLAN_DIA TONELADA_PLAN, SUM(A.TONELADAS) TONELADA_REAL FROM MOAGEM_CANA_HORA A, (SELECT C.DIA, D.TON_PLAN_DIA FROM (SELECT B.SAFR_INICIO + ROWNUM - 1 DIA FROM DUAL, (SELECT * FROM SISAGRI.SAFRA B WHERE B.SAFR_SAFRA_ATUAL = '*') B CONNECT BY LEVEL <= B.SAFR_FIM - B.SAFR_INICIO + 1) C, (SELECT A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO, ROUND(SUM(TON_PLAN_HORA * 24)) TON_PLAN_DIA FROM SISCOMAG.V_META_COLHEITA A GROUP BY A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO) D WHERE C.DIA BETWEEN D.DATA_INICIO_PERIODO AND D.DATA_FINAL_PERIODO) X WHERE A.DIA = X.DIA GROUP BY A.ID_NEGOCIOS, A.NRO_ANO_SAFRA, TO_CHAR(A.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE'), A.DIA, X.TON_PLAN_DIA ORDER BY A.DIA"></asp:SqlDataSource>
</asp:Content>
