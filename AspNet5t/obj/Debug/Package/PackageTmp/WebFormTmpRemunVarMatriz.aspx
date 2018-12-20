<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="WebFormTmpRemunVarMatriz.aspx.vb" Inherits="AspNet5t.WebFormTmpRemunVarMatriz" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" DataSourceID="SqlDataSource1">
        <Fields>
            <dx:PivotGridField FieldName="CATEGORIA" Area="ColumnArea" AreaIndex="0" AllowedAreas="ColumnArea" Caption="Categoria">
                <CellStyle Wrap="True">
                </CellStyle>
                <HeaderStyle Wrap="True" />
                <ValueStyle Wrap="True">
                </ValueStyle>
            </dx:PivotGridField>
            <dx:PivotGridField FieldName="INDICADOR" Area="RowArea" AreaIndex="0" AllowedAreas="RowArea" Caption="Indicador"></dx:PivotGridField>
            <dx:PivotGridField FieldName="NOTA_CALC" Area="RowArea" AreaIndex="1" AllowedAreas="RowArea" Caption="Nota"></dx:PivotGridField>
            <dx:PivotGridField FieldName="PESO_CALC" Area="DataArea" AreaIndex="0" AllowedAreas="DataArea" CellFormat-FormatString="{0:#,#0.0} %" CellFormat-FormatType="Custom"></dx:PivotGridField>
        </Fields>
        <OptionsView ShowColumnGrandTotals="False" ShowColumnHeaders="False" ShowContextMenus="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
        <OptionsCustomization AllowCustomizationForm="False" AllowDrag="False" AllowDragInCustomizationForm="False" AllowExpand="False" AllowExpandOnDoubleClick="False" AllowFilter="False" AllowFilterBySummary="False" AllowPrefilter="False" AllowSort="False" AllowSortBySummary="False" />
        <Styles>
            <HeaderStyle Wrap="True" />
            <ColumnAreaStyle Wrap="True">
            </ColumnAreaStyle>
            <FieldValueStyle Wrap="True">
            </FieldValueStyle>
        </Styles>
        <StylesFilterControl>
            <Value Wrap="True">
            </Value>
        </StylesFilterControl>
    </dx:ASPxPivotGrid>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="select t2.id_negocios, t2.indicador, t2.frente, 'OTIMO' nota_calc, 'CATEG' categoria, 0 peso, 0 coef_calc, 0 peso_calc from INDICADORES_AGRICOLA t2 where t2.frente = 8"></asp:SqlDataSource>
</asp:Content>
