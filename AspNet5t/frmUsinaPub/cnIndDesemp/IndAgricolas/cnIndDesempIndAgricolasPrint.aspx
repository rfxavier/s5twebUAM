<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="cnIndDesempIndAgricolasPrint.aspx.vb" Inherits="AspNet5t.cnIndDesempIndAgricolasPrint" %>
<!DOCTYPE html>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Linear" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Circular" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.State" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Digital" tagprefix="dx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
         <script src="<%# Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>

        <style type="text/css">
            /*gauge's titles font styles*/
            .dxflGroup {
                padding: 0px;
            }

            .contentPane {
                padding: 0px;
            }
            .page-break {
                page-break-after:always;
            }
        </style>

    </head>
    <body>
        <form id="form1" runat="server">
            <dx:ASPxCallbackPanel ID="ASPxCbPanel" runat="server" Width="100%" ClientInstanceName="cbPanel">
                <PanelCollection>
                    <dx:PanelContent runat="server">
                        <dx:ASPxHiddenField ID="ASPxHiddenField" runat="server" ClientInstanceName="hf">
                        </dx:ASPxHiddenField>

                        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="3">
                            <Items>
                                <dx:LayoutItem Caption="Grupo" Width="500px" HorizontalAlign="Left" ShowCaption="True">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox runat="server" ID="ASPxComboGrupo" IncrementalFilteringMode="None" ClientVisible="true" Width="200px" Native="True">
                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { cbPanel.PerformCallback(); }"></ClientSideEvents>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                    <CaptionSettings Location="Top" HorizontalAlign="Left"></CaptionSettings>
                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="Data Fechamento" Width="100px">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="ASPxComboDataFechamento" runat="server" IncrementalFilteringMode="None" ClientVisible="true" Width="100px" ClientInstanceName="cbDataRef" Native="True">
                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { cbPanel.PerformCallback(); }"></ClientSideEvents>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Tempo Aproveit. Industrial" Width="100px" HorizontalAlign="Center">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <div style="width: 100px; text-align: center;">
                                                <dx:ASPxLabel runat="server" Text="N/D" ID="ASPxLabelTempoAprov"></dx:ASPxLabel>
                                            </div>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="False" ColSpan="3">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="SqlDataSourceRemunVariavel" AutoGenerateColumns="False" Theme="Office2010Silver" KeyFieldName="ROWNUM" ClientInstanceName="grid" Width="920px">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="10" Visible="False" Width="50px"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="INDICADOR" VisibleIndex="0" Visible="False" Width="50px">
                                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="METAcalc" UnboundType="String" VisibleIndex="1" Width="120px" Caption="Indicador" SortIndex="0" SortOrder="Ascending">
                                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="DS_FRENTETIPO" VisibleIndex="2" Visible="True" Caption="Frente / Tipo" Width="115px" SortIndex="1" SortOrder="Ascending">
                                                        <%--<Settings AllowHeaderFilter="True" SortMode="Custom" />--%>
                                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="FRENTETIPOcalc" UnboundType="String" Visible="False" VisibleIndex="3" Width="85px" Caption="Frente / Tipo">
                                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="FRENTETIPO" VisibleIndex="21" Visible="False" Caption="Frente/Tipo" Width="85px">
                                                        <%--<Settings AllowHeaderFilter="True" SortMode="Custom" />--%>
                                                        <Settings AutoFilterCondition="Equals" />
                                                        <Settings AllowHeaderFilter="True" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="FRENTETIPOAUX" VisibleIndex="22" Visible="False"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="PLANEJADO" VisibleIndex="4" Caption="Planejado" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="REALIZADO" VisibleIndex="5" Caption="Realizado" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="UNIDADE_MEDIDA" VisibleIndex="8" Width="85px" Caption="Unidade Medida">
                                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="True" AllowSort="False" />
                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NOTA" VisibleIndex="11" Caption="Status" Width="65px">
                                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn VisibleIndex="12" Caption=" " Width="285px">
                                                        <Settings AllowDragDrop="False" AllowAutoFilterTextInputTimer="False" AllowAutoFilter="False" ShowFilterRowMenu="False" ShowFilterRowMenuLikeItem="False" AllowHeaderFilter="False" ShowInFilterControl="False" AllowSort="False" AllowGroup="False" AllowFilterBySearchPanel="False"></Settings>
                                                        <DataItemTemplate>
                                                            <div style="width: 250px; text-align: center;">
                                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Width="250px" Style="font-size: large; font-weight: bold;" OnInit="ASPxLabel1_Init">
                                                                </dx:ASPxLabel>
                                                            </div>

                                                            <dx:ASPxGaugeControl ID="ASPxGaugeControl1" runat="server" BackColor="White" Height="40px" Width="260px" AutoLayout="False" OnInit="ASPxGaugeControl1_Init">
                                                                <Gauges>
                                                                    <dx:LinearGauge Bounds="0, -15, 260, 60" Name="linearGauge11" Orientation="Horizontal">
                                                                        <scales>
                                                                        <dx:LinearScaleComponent AcceptOrder="0" Appearance-Brush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" Appearance-Width="4" AppearanceScale-Brush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" AppearanceScale-Width="4" AppearanceTickmarkText-TextBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" CustomLogarithmicBase="2" EndPoint="62.5, 20" MajorTickCount="8" MajorTickmark-FormatString="{0:#,#0.00}" MajorTickmark-ShapeOffset="-8" MajorTickmark-ShapeType="Circular_Style28_1" MajorTickmark-TextOffset="-18" MajorTickmark-TextOrientation="BottomToTop" MaxValue="140" MinorTickCount="4" MinorTickmark-ShapeScale="0.5,0.5" MinorTickmark-ShapeOffset="-14" MinorTickmark-ShapeType="Circular_Style28_1" MinorTickmark-ShowTick="False" Name="scale2" StartPoint="62.5, 230" Value="1" MajorTickmark-ShowFirst="False" MajorTickmark-ShowLast="False" AppearanceTickmarkText-Font="Tahoma, 6pt">
                                                                            <Labels>
                                                                                <dx:ScaleLabelWeb Name="Label0" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                                <dx:ScaleLabelWeb Name="Label1" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                                <dx:ScaleLabelWeb Name="Label2" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                                <dx:ScaleLabelWeb Name="Label3" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                                <dx:ScaleLabelWeb Name="Label4" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                                <dx:ScaleLabelWeb Name="Label5" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                            </Labels>
                                                                            <ranges>
                                                                                <dx:LinearScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#CE8396&quot;/&gt;" EndThickness="7" EndValue="90" Name="Range0" ShapeOffset="1" StartThickness="7" />
                                                                                <dx:LinearScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#699BC1&quot;/&gt;" EndThickness="7" EndValue="100" Name="Range1" ShapeOffset="1" StartThickness="7" StartValue="90" />
                                                                                <dx:LinearScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#F5E16B&quot;/&gt;" EndThickness="7" EndValue="105" Name="Range2" ShapeOffset="1" StartThickness="7" StartValue="100" />
                                                                                <dx:LinearScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#67DD63&quot;/&gt;" EndThickness="7" EndValue="140" Name="Range3" ShapeOffset="1" StartThickness="7" StartValue="105" />
                                                                            </ranges>
                                                                        </dx:LinearScaleComponent>
                                                                    </scales>
                                                                        <markers>
                                                                        <dx:LinearScaleMarkerComponent AcceptOrder="150" LinearScale="" Name="linearGauge11_Marker1" ScaleID="scale2" ZOrder="-150" />
                                                                    </markers>
                                                                    </dx:LinearGauge>
                                                                </Gauges>
                                                                <LayoutPadding All="0" Bottom="0" Left="0" Right="0" Top="0" />
                                                            </dx:ASPxGaugeControl>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="StatusGauge" VisibleIndex="7" Visible="False" Width="50px">
                                                        <DataItemTemplate>
                                                            <dx:ASPxGaugeControl ID="ASPxGaugeControl2" runat="server" BackColor="White" Height="40px" Value='<%# Eval("NOTACALC") %>' Width="50px">
                                                                <Gauges>
                                                                    <dx:StateIndicatorGauge Bounds="0, 0, 50, 40" Name="Gauge0">
                                                                        <indicators>
                                                                        <dx:StateIndicatorComponent AcceptOrder="0" Center="124, 124" Name="stateIndicatorComponent3" Size="200, 200" StateIndex="0">
                                                                            <states>
                                                                                <dx:IndicatorStateWeb Name="State1" ShapeType="Smile1" />
                                                                                <dx:IndicatorStateWeb Name="State2" ShapeType="Smile2" />
                                                                                <dx:IndicatorStateWeb Name="State3" ShapeType="Smile3" />
                                                                                <dx:IndicatorStateWeb Name="State4" ShapeType="Smile4" />
                                                                                <dx:IndicatorStateWeb Name="State5" ShapeType="Smile5" />
                                                                            </states>
                                                                        </dx:StateIndicatorComponent>
                                                                    </indicators>
                                                                    </dx:StateIndicatorGauge>
                                                                </Gauges>
                                                                <LayoutPadding All="0" Bottom="0" Left="0" Right="0" Top="0" />
                                                            </dx:ASPxGaugeControl>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NOTACALC" Visible="False" VisibleIndex="13" Width="50px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataImageColumn Caption=" " VisibleIndex="9" FieldName="NOTACALC" Width="70px">
                                                        <PropertiesImage ImageUrlFormatString="~/Content/Images/stInd/std{0}.png">
                                                        </PropertiesImage>
                                                        <Settings AllowSort="False" />
                                                    </dx:GridViewDataImageColumn>
                                                </Columns>
                                                <SettingsBehavior AllowDragDrop="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                                                <SettingsPager PageSize="1000">
                                                </SettingsPager>
                                                <Settings ShowTitlePanel="true" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="False" ShowGroupFooter="VisibleIfExpanded" />
                                                <SettingsText Title="Indicadores Agrícolas" />
                                                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>

                                                <Styles>
                                                    <Header Wrap="True">
                                                    </Header>
                                                    <TitlePanel Font-Size="Medium">
                                                    </TitlePanel>
                                                    <Cell>
                                                        <Paddings PaddingBottom="0px" PaddingTop="0px" />
                                                    </Cell>
                                                </Styles>
                                            </dx:ASPxGridView>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="False" ColSpan="3">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" DataSourceID="SqlDataSourceRemunVariavelEquip" AutoGenerateColumns="False" Theme="Office2010Silver" KeyFieldName="ROWNUM" ClientInstanceName="gridequip" Width="920px">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="FRENTETIPO" Visible="False" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="FRENTETIPOAUX" Visible="False" VisibleIndex="21"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="DSC_EQUIPAMENTO" VisibleIndex="0" Caption="Descrição Equipamento" SortIndex="0" SortOrder="Ascending" Width="120px">
                                                        <Settings AllowAutoFilter="False" AllowHeaderFilter="True"></Settings>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NRO_EQUIPAMENTO" VisibleIndex="1" Caption="N° Equip." SortIndex="1" SortOrder="Ascending" Width="55px">
                                                        <Settings AllowAutoFilter="True" AllowHeaderFilter="True"></Settings>
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="DS_FRENTETIPO" VisibleIndex="5" Visible="False" Caption="Frente / Tipo" SortIndex="0" SortOrder="Ascending" Width="85px">
                                                        <Settings AllowAutoFilter="False" AllowHeaderFilter="True"></Settings>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="R_DISP_MECANICA" VisibleIndex="11" Caption="Disponibilidade (%)" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="R_DISP_MECANICA_COLHEDORA" VisibleIndex="9" Visible="false" Caption="Disp. Mec. Colhedora (%)" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="R_DISP_MECANICA_DEMAIS" VisibleIndex="10" Visible="false" Caption="Disp. Mec. Demais Equip. (%)" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="R_CONSUMO_OLEO_DIESELKML" VisibleIndex="12" Caption="Consumo Óleo Diesel (Km/l)" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="R_CONSUMO_OLEO_DIESELLTH" VisibleIndex="13" Caption="Consumo Óleo Diesel (Lt/h)" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="R_CONSUMO_OLEO_DIESELLTTON" VisibleIndex="14" Caption="Consumo Óleo Diesel (Lt/ton)" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="R_CONSUMO_OLEO_HIDRAULICO" VisibleIndex="15" Caption="Consumo Óleo Hidráulico (Lt/ton)" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.0000}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="R_TEMPO_APROVEIT_COLHEDORA" VisibleIndex="16" Caption="Tempo Aprov. Colhedora (%)" Width="80px">
                                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsBehavior AllowDragDrop="False" />
                                                <SettingsPager Visible="False"></SettingsPager>
                                                <Settings ShowVerticalScrollBar="false" UseFixedTableLayout="True" ShowTitlePanel="true" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="False" ShowGroupFooter="VisibleIfExpanded" />
                                                <SettingsText Title="Indicadores Agrícolas Por Equipamento" />
                                                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>

                                                <Styles>
                                                    <Header Wrap="True">
                                                    </Header>
                                                    <TitlePanel Font-Size="Medium">
                                                    </TitlePanel>
                                                    <Cell>
                                                        <Paddings PaddingBottom="0px" PaddingTop="0px" />
                                                    </Cell>
                                                    <AlternatingRow Enabled="True">
                                                    </AlternatingRow>
                                                </Styles>
                                            </dx:ASPxGridView>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>

                            <SettingsItemCaptions Location="Top" HorizontalAlign="Center"></SettingsItemCaptions>
                            <Paddings Padding="0px" />
                        </dx:ASPxFormLayout>

                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>


            <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridView1"></dx:ASPxGridViewExporter>
            <asp:SqlDataSource ID="SqlDataSourceRemunVariavel" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, NVL(A.PLANEJADO, 0) PLANEJADO, NVL(A.REALIZADO, 0) REALIZADO, NVL(A.PERC, 0) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, NVL(A.PERC_ABAIXO_META, 0) PERC_ABAIXO_META, NVL(A.PERC_ACIMA_META, 0) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceRemunVariavelEquip" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="select decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.FRENTE, A.DATA_FECHAMENTO, A.TIPO, A.GRUPO, A.DSC_EQUIPAMENTO, A.NRO_EQUIPAMENTO, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'DISP_MECANICA_COLHEDORA') R_DISP_MECANICA_COLHEDORA, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'DISP_MECANICA_DEMAIS') R_DISP_MECANICA_DEMAIS, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR IN ('DISP_MECANICA_COLHEDORA', 'DISP_MECANICA_DEMAIS')) R_DISP_MECANICA, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_DIESEL' AND B1.UNIDADE_MEDIDA = 'LT/H') R_CONSUMO_OLEO_DIESELLTH, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_DIESEL' AND B1.UNIDADE_MEDIDA = 'KM/L') R_CONSUMO_OLEO_DIESELKML, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_DIESEL' AND B1.UNIDADE_MEDIDA = 'LT/TON') R_CONSUMO_OLEO_DIESELLTTON, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_HIDRAULICO') R_CONSUMO_OLEO_HIDRAULICO, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'TEMPO_APROVEIT_COLHEDORA') R_TEMPO_APROVEIT_COLHEDORA from BI4T.INDICADORES_AGRICOLA_EQUIP A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) = 'CONSERVACAO_GERAL' and A.DATA_FECHAMENTO = TO_DATE('20062015','DDMMYYYY') GROUP BY decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)), B.FRCO_DESCRICAO, C.DSC_REDUZIDA, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO), A.ID_NEGOCIOS, A.FRENTE, A.DATA_FECHAMENTO, A.TIPO, A.GRUPO, A.DSC_EQUIPAMENTO, A.NRO_EQUIPAMENTO"></asp:SqlDataSource>
            <%--<asp:SqlDataSource ID="SqlDataSourceDatasRef" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT TO_CHAR(DATA_FECHAMENTO, 'DD/MM/YYYY') DATA_FECHAMENTO FROM BI4T.INDICADORES_AGRICOLA GROUP BY DATA_FECHAMENTO ORDER BY DATA_FECHAMENTO DESC"></asp:SqlDataSource>--%>
        </form>

        <script type="text/javascript">
            $(function () {
                //dom is ready
                //$('#ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_DXDataRow10').after('<tr><td colspan=8 style="text-align:center;">Indicadores Agricolas</td></tr>').after('<div class="page-break">&nbsp;</div>');
            });
        </script>
    </body>
</html>