<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="WebFormTmp2.aspx.vb" Inherits="AspNet5t.WebFormTmp2" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Xpo.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Xpo" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" DataSourceID="LinqServerModeDataSource1">
        <Fields>
            <dx:PivotGridField AreaIndex="0" FieldName="NR_ANO_SAFRA">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="1" FieldName="NRO_DOCUMENTO">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="2" FieldName="PROP_CODIGO">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="3" FieldName="DS_NOME_PROPRIEDADE">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="4" FieldName="FRENTE_COLHEITA">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="5" FieldName="DESCMUNI">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="6" FieldName="COD_IBGE">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="7" FieldName="TIPO">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="8" FieldName="DESCTIPO">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="9" FieldName="DT_ENTRADA">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="10" FieldName="EQUIP_ENTRADA">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="11" FieldName="REBOQUE">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="12" FieldName="DT_MOAGEM">
            </dx:PivotGridField>
            <dx:PivotGridField AreaIndex="13" FieldName="QT_TON">
            </dx:PivotGridField>
        </Fields>
    </dx:ASPxPivotGrid>
    <dx:LinqServerModeDataSource ID="LinqServerModeDataSource1" runat="server">
    </dx:LinqServerModeDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connOracleXE %>" ProviderName="<%$ ConnectionStrings:connOracleXE.ProviderName %>" SelectCommand="SELECT &quot;PID&quot;, &quot;NR_ANO_SAFRA&quot;, &quot;NRO_DOCUMENTO&quot;, &quot;PROP_CODIGO&quot;, &quot;DS_NOME_PROPRIEDADE&quot;, &quot;FRENTE_COLHEITA&quot;, &quot;MUNICIPIO&quot;, &quot;DESCMUNI&quot;, &quot;COD_IBGE&quot;, &quot;COORD_LAT&quot;, &quot;COORD_LONG&quot;, &quot;TIPO&quot;, &quot;DESCTIPO&quot;, &quot;DT_ENTRADA&quot;, &quot;EQUIP_ENTRADA&quot;, &quot;REBOQUE&quot;, &quot;DT_MOAGEM&quot;, &quot;QT_TON&quot; FROM &quot;ENTRADASANALITICAS&quot;"></asp:SqlDataSource>
</asp:Content>
