<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="pivotEntradaCana.aspx.vb" Inherits="AspNet5t.pivotEntradaCana" %>

<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register TagPrefix="cc1" Namespace="DevExpress.XtraCharts" Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style type="text/css">
        .dxflGroupBox > .dxflGroup tr:first-child > .dxflGroupCell > .dxflItem {
            padding-top: 0px;
        }

        .dxflWithCaptionSys.dxflHeadingLineGroupBoxSys.dxflGroupBox {
            margin-top: 10px !important;
        }

        .dxflGroupBox {
            padding: 0 0 0px;
            margin: 0px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div>
        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" AlignItemCaptionsInAllGroups="True" ColCount="3" Width="100%">
            <Items>
                <dx:LayoutGroup Caption="Pivot Entrada Cana" ColCount="3" ColSpan="3" GroupBoxDecoration="HeadingLine">
                    <Items>
                        <dx:LayoutItem Caption="Gráfico">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="comboChartType" runat="server" AutoPostBack="True">
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <div class="buttonfloatright">
                                        <dx:ASPxButton ID="buttonSaveAs" runat="server" ClientInstanceName="buttonSaveAs" OnClick="buttonSaveAs_Click" Text="Exportar para Excel" ToolTip="Exportar Excel">
                                        </dx:ASPxButton>
                                    </div>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutItem ShowCaption="False" ColSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" EnableCallBacks="False" Width="100%" Theme="Moderno">
                                <Fields>
                                    <dx:PivotGridField AreaIndex="0" Caption="Ano Safra" FieldName="NR_ANO_SAFRA" Visible="False">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="0" Caption="Núm.Documento" FieldName="NRO_DOCUMENTO" AllowedAreas="RowArea, FilterArea, DataArea" Visible="False">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="0" Caption="Prop.Cód." FieldName="PROP_CODIGO">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="2" Caption="Propriedade" FieldName="DS_NOME_PROPRIEDADE">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="0" Caption="Frente Colheita" FieldName="FRENTE_COLHEITA" Area="ColumnArea" Visible="False">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="5" Caption="Mun.Cód." FieldName="MUNICIPIO" Visible="False" AllowedAreas="RowArea, FilterArea, DataArea">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="0" Caption="Município" FieldName="DESCMUNI" Area="RowArea" AllowedAreas="RowArea, ColumnArea, FilterArea" SortBySummaryInfo-CustomTotalSummaryType="Sum" SortBySummaryInfo-FieldName="QT_TON_ENTREGUE_REAL" SortOrder="Descending">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="6" Caption="Origem.Cód." FieldName="TIPO" Visible="False">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="3" Caption="Origem" FieldName="DESCTIPO" AllowedAreas="RowArea, ColumnArea, FilterArea">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="8" Caption="Equip.Entrada" FieldName="EQUIP_ENTRADA" Visible="False" AllowedAreas="RowArea, FilterArea, DataArea">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="8" Caption="Reboque" FieldName="REBOQUE" Visible="False">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="0" Caption="Toneladas" CellFormat-FormatString="{0:#,#0}" CellFormat-FormatType="Numeric" FieldName="QT_TON_ENTREGUE_REAL" AllowedAreas="DataArea" Area="DataArea">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField AreaIndex="1" Caption="Mês" FieldName="DT_MOAGEM" UnboundFieldName="UnboundColumn0" AllowedAreas="RowArea, ColumnArea, FilterArea" GroupInterval="DateMonth">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField ID="fieldcalcFRENTECOLHEITA" Area="ColumnArea" AreaIndex="0" Caption="Frente" FieldName="calcFRENTE_COLHEITA" UnboundExpression="PadLeft([FRENTE_COLHEITA], 2, '0')" UnboundFieldName="calcFRENTE_COLHEITA" UnboundType="String">
                                    </dx:PivotGridField>
                                </Fields>
                                <OptionsView ShowHorizontalScrollBar="True" />
                                <OptionsChartDataSource DataProvideMode="UseCustomSettings" />
                                <OptionsFilter NativeCheckBoxes="False" />
                            </dx:ASPxPivotGrid>
                            <dx:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ASPxPivotGrid1" Visible="False" />
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False" ColSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" ClientInstanceName="chart" CrosshairEnabled="True" DataSourceID="ASPxPivotGrid1" Height="200px" SeriesDataMember="Series" Width="830px">
                                <borderoptions visibility="False" />
                                <diagramserializable>
                                    <cc1:XYDiagram>
                                        <axisx visibleinpanesserializable="-1">
                                        </axisx>
                                        <axisy visibleinpanesserializable="-1">
                                        </axisy>
                                    </cc1:XYDiagram>
                                </diagramserializable>
                                <legend maxhorizontalpercentage="30"></legend>
                                <seriestemplate argumentdatamember="Arguments" argumentscaletype="Qualitative" valuedatamembersserializable="Values">
                                </seriestemplate>
                            </dxchartsui:WebChartControl>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>

            <SettingsItemCaptions VerticalAlign="Middle"></SettingsItemCaptions>
        </dx:ASPxFormLayout>
    </div>
</asp:Content>
