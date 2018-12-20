<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnIndDesempMobIndAgricolasFrenteTipo.aspx.vb" Inherits="AspNet5t.cnIndDesempMobIndAgricolasFrenteTipo" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Linear" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Circular" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.State" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Digital" tagprefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <link href="<%= Page.ResolveUrl("~/Content/4t/css/cnIndDesempMobIndAgricolasFrenteTipo.css")%>?v=<%= DateTime.Now.Ticks %>" rel="stylesheet" />
    <style type="text/css">
        td.dxgvDetailCell { padding: 0px; }
        td.dxgvDetailCell_Office2010Silver { padding: 0px; }
        .dxgvDetailRow_Office2010Silver td.dxgvDetailCell_Office2010Silver { padding: 0px; }
    </style>

    <script type="text/javascript">
        var frenteAux = "";

        function OnClick(s, e, parFrenteTipoFlg, parFrenteTipo, parFrenteTipoTitulo, parPaginaNumero) {
            if (frenteAux !== parFrenteTipo) {
                frenteAux = parFrenteTipo;
                hf.Clear();

                if (parFrenteTipoFlg == "F") {
                    hf.Set("hfFrenteAtual", parFrenteTipo);
                    hf.Set("hfTipoAtual", "");
                }
                else {
                    hf.Set("hfFrenteAtual", "");
                    hf.Set("hfTipoAtual", parFrenteTipo);
                }
                hf.Set("hfFrenteTipoAtual", parFrenteTipo);
                hf.Set("hfFrenteTipoAtualDs", parFrenteTipoTitulo);
                hf.Set("hfPaginaAtual", parPaginaNumero);
                btnResultado.SetText("Resultados % " + parFrenteTipoTitulo);
                btnEquip.SetText("Equipamento " + parFrenteTipoTitulo);

                dvIndicadores.PerformCallback();
            }
            else {
                dvIndicadores.GotoPage(parPaginaNumero - 1);
            }
        }
        function showResultado(s, e) {
            var textBtnResultado = btnResultado.GetText();

            //pcResultado.SetHeaderText("Resultado Frente " + parseInt(frenteAux));
            pcResultado.SetHeaderText("Resultado " + textBtnResultado.substr(10));
            pcResultado.PerformCallback();
            pcResultado.Show();
        }
        function showEquip(s, e) {
            var textBtnEquip = btnEquip.GetText();

            pcEquip.SetHeaderText("");
            pcEquip.PerformCallback();
            pcEquip.Show();
        }
    </script>

</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxCallbackPanel ID="ASPxCbPanel" runat="server" Width="100%" ClientInstanceName="cbPanel">
        <PanelCollection>
            <dx:PanelContent runat="server">

                <dx:ASPxHiddenField ID="ASPxHiddenField" runat="server" ClientInstanceName="hf">
                </dx:ASPxHiddenField>

                <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="2">
                    <Items>
                        <dx:LayoutItem>
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxLabel runat="server" CssClass="titulo-indicadores" Text="Indicadores Agrícolas" ID="ASPxFormLayout2_E2"></dx:ASPxLabel>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem HorizontalAlign="Center" Width="500px">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <div style="width: 500px; text-align: center; position: fixed; z-index: 100;">
                                        <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server" ColCount="4" Width="500px">
                                            <Items>
                                                <dx:LayoutItem ShowCaption="False" VerticalAlign="Middle" Width="140px">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxButton runat="server" Text="Resultado Frente" ID="ASPxButtonResultadoFrente" AutoPostBack="False" ClientInstanceName="btnResultado" Height="85px" Style="margin-top: 20px; padding: 0px 0px;" Theme="iOS" Width="140px" Wrap="True" ClientVisible="False">
                                                                <ClientSideEvents Click="showResultado"></ClientSideEvents>
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>

                                                <dx:LayoutItem ShowCaption="False" VerticalAlign="Middle" Width="110px">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxButton runat="server" Text="Exibir Equipamento" ID="ASPxButtonEquip" AutoPostBack="False" ClientInstanceName="btnEquip" Height="85px" Style="margin-top: 20px; margin-left:2px; padding: 0px 0px;" Theme="iOS" Width="110px" Wrap="True" ClientVisible="False">
                                                                <ClientSideEvents Click="showEquip"></ClientSideEvents>
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>

                                                <dx:LayoutItem Caption="Fechamento" Visible="true" Width="120px">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox runat="server" IncrementalFilteringMode="None" Width="150px" Theme="iOS" Style="margin-left: 4px;" ID="ASPxComboDataFechamento">
                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { cbPanel.PerformCallback(); }"></ClientSideEvents>
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionSettings HorizontalAlign="Center"></CaptionSettings>

                                                    <CaptionStyle Font-Bold="True" Font-Size="Small"></CaptionStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Tempo Aprov Total" Width="40px" CssClass="WrapCaption">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <div style="width: 100px; text-align: center; margin-top: 8px;">
                                                                <dx:ASPxLabel runat="server" Text="N/D" Theme="iOS" ID="ASPxLabelTempoAprov" Style="font-size: x-large; font-weight: normal;"></dx:ASPxLabel>

                                                            </div>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>

                                                    <CaptionSettings HorizontalAlign="Center"></CaptionSettings>

                                                    <CaptionStyle Font-Bold="True" Font-Size="Small"></CaptionStyle>
                                                </dx:LayoutItem>
                                            </Items>

                                            <SettingsItems HorizontalAlign="Center" VerticalAlign="Top"></SettingsItems>

                                            <SettingsItemCaptions Location="Top" HorizontalAlign="Left" VerticalAlign="Middle"></SettingsItemCaptions>
                                        </dx:ASPxFormLayout>
                                    </div>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" Width="310px" VerticalAlign="Top" HorizontalAlign="Left">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxNavBar runat="server" AllowSelectItem="True" AutoCollapse="True" ClientInstanceName="frentesNavBar" ExpandButtonPosition="Right" Theme="Office2010Silver" Width="310px" ID="FrentesNavBar" EnableViewState="False">
                                        <GroupHeaderTemplate>
                                            <div style="font-weight: bold; font-size: medium;">
                                                <%#Eval("DataItem.pDsFrenteTipo")%>
                                            </div>

                                        </GroupHeaderTemplate>
                                        <ItemTemplate>
                                            <div style="height: 40px; display: inline-block; vertical-align: top;">
                                                <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" ImageUrl='<%# String.Format("~/Content/Images/stInd/std{0}.png", Eval("DataItem.pNotaCalc"))%>'>
                                                </dx:ASPxImage>
                                            </div>
                                            <div style="height: 30px; display: inline-block;">
                                                <dx:ASPxHyperLink runat="server" ID="ASPxHlMeta" CssClass="aspHyperLink" Text='<%# IndicadoresINDICADORCalcAbrev(Eval("DataItem.pIndicador"))%>' NavigateUrl='javascript:void(0)' ClientInstanceName='hlmeta' OnLoad="ASPxHyperLink1_Load" Style="font-size: 20px; line-height: 35px" Height="35px" Width="250px">
                                                </dx:ASPxHyperLink>
                                            </div>

                                        </ItemTemplate>
                                    </dx:ASPxNavBar>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" Width="500px" VerticalAlign="Top" HorizontalAlign="Left">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxDataView runat="server" ClientInstanceName="dvIndicadores" DataSourceID="SqlDataSourceRemunVariavel" Width="500px" ID="ASPxDataView1"  Style="position:fixed; margin-top: 50px;">
                                        <SettingsTableLayout ColumnCount="1" RowsPerPage="1"></SettingsTableLayout>

                                        <PagerSettings ShowNumericButtons="False" Position="Bottom"></PagerSettings>
                                        <ItemTemplate>
                                            <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" AlignItemCaptionsInAllGroups="True" ColCount="2" Width="500px">
                                                <Items>
                                                    <dx:LayoutItem ColSpan="2" HorizontalAlign="Center" ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <div style="width: 500px; text-align: center;">
                                                                    <dx:ASPxLabel runat="server" ID="ASPxFormLayout1_E1" Style="font-size: medium; font-weight: bold;" Text='<%# Eval("DS_FRENTETIPO")%>'>
                                                                    </dx:ASPxLabel>
                                                                </div>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tipo do Indicador" HorizontalAlign="Center" ColSpan="2" ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <div style="width: 500px; text-align: center;">
                                                                    <dx:ASPxLabel runat="server" ID="ASPxLabel2" Style="font-size: x-large; font-weight: bold;" Text='<%# IndicadoresINDICADORCalc(Eval("INDICADOR"))%>' Width="500px">
                                                                    </dx:ASPxLabel>
                                                                </div>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings Location="Top" HorizontalAlign="Center"></CaptionSettings>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Planejado" HorizontalAlign="Center" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <div style="width: 500px; text-align: center;">
                                                                    <dx:ASPxLabel runat="server" ID="ASPxLabelPlanejado" Style="font-size: x-large;" OnInit="ASPxLabelPlanejado_Init">
                                                                    </dx:ASPxLabel>
                                                                    &nbsp
                                                        <dx:ASPxLabel runat="server" ID="ASPxLabelUnidadeMedida" Style="font-size: x-large;" Text='<%# Eval("UNIDADE_MEDIDA") %>'>
                                                        </dx:ASPxLabel>
                                                                </div>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings Location="Top" HorizontalAlign="Center"></CaptionSettings>
                                                        <CaptionStyle Font-Size="X-Large">
                                                        </CaptionStyle>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Nota" HorizontalAlign="Center" ColSpan="2" ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <div style="width: 500px; text-align: center;">
                                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("NOTA") %>' ID="ASPxFormLayout1_E4" Style="font-size: medium;">
                                                                    </dx:ASPxLabel>
                                                                </div>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings Location="Top" HorizontalAlign="Center"></CaptionSettings>
                                                        <CaptionStyle Font-Size="large">
                                                        </CaptionStyle>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem ColSpan="2" ShowCaption="False" Caption="Status" HorizontalAlign="Center">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <div style="width: 500px; text-align: center;">
                                                                    <dx:ASPxImage runat="server" ImageUrl='<%# String.Format("~/Content/Images/stInd/std{0}.png", Eval("NOTAcalc"))%>' ShowLoadingImage="True" ID="ASPxImage1">
                                                                    </dx:ASPxImage>
                                                                </div>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionStyle Font-Size="Large">
                                                        </CaptionStyle>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem ShowCaption="False" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <div style="width: 500px; text-align: center;">
                                                                    <dx:ASPxLabel runat="server" Width="250px" ID="ASPxLabel1" Style="font-size: xx-large; font-weight: bold;" OnInit="ASPxLabel1_Init">
                                                                    </dx:ASPxLabel>
                                                                </div>
                                                                <dx:ASPxGaugeControl runat="server" Value="1" Width="500px" Height="80px" BackColor="White" ID="ASPxGaugeControl1" OnInit="ASPxGaugeControl1_Init" AutoLayout="False">
                                                                    <Gauges>
                                                                        <dx:LinearGauge Orientation="Horizontal" Name="linearGauge11" Bounds="0, 0, 500, 80">
                                                                            <scales>
                                                                    <dx:LinearScaleComponent AppearanceScale-Brush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" AppearanceScale-Width="4" AppearanceTickmarkText-Font="Tahoma, 6pt" AppearanceTickmarkText-TextBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" CustomLogarithmicBase="2" Appearance-Brush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" Appearance-Width="4" StartPoint="62.5, 230" EndPoint="62.5, 20" Value="1" MaxValue="140" MinorTickmark-ShowTick="False" MinorTickmark-ShapeOffset="-14" MinorTickmark-ShapeType="Circular_Style28_1" MinorTickCount="4" MinorTickmark-ShapeScale="0.5,0.5" MajorTickmark-TextOffset="-18" MajorTickmark-TextOrientation="BottomToTop" MajorTickmark-FormatString="{0:#,#0.00}" MajorTickmark-ShowFirst="False" MajorTickmark-ShowLast="False" MajorTickmark-ShapeOffset="-8" MajorTickmark-ShapeType="Circular_Style28_1" MajorTickCount="8" AcceptOrder="0" Name="scale2">
                                                                        <Labels>
                                                                            <dx:ScaleLabelWeb Name="Label0" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                            <dx:ScaleLabelWeb Name="Label1" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                            <dx:ScaleLabelWeb Name="Label2" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                            <dx:ScaleLabelWeb Name="Label3" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                            <dx:ScaleLabelWeb Name="Label4" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                            <dx:ScaleLabelWeb Name="Label5" Position="50, 90" TextOrientation="Tangent" Text="teste" FormatString="{0}"></dx:ScaleLabelWeb>
                                                                        </Labels>
                                                                        <Ranges>
                                                                            <dx:LinearScaleRangeWeb Name="Range0" AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#CE8396&quot;/&gt;" EndValue="90" StartThickness="7" EndThickness="7" ShapeOffset="1">
                                                                            </dx:LinearScaleRangeWeb>
                                                                            <dx:LinearScaleRangeWeb Name="Range1" AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#699BC1&quot;/&gt;" StartValue="90" EndValue="100" StartThickness="7" EndThickness="7" ShapeOffset="1">
                                                                            </dx:LinearScaleRangeWeb>
                                                                            <dx:LinearScaleRangeWeb Name="Range2" AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#F5E16B&quot;/&gt;" StartValue="100" EndValue="105" StartThickness="7" EndThickness="7" ShapeOffset="1">
                                                                            </dx:LinearScaleRangeWeb>
                                                                            <dx:LinearScaleRangeWeb Name="Range3" AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#67DD63&quot;/&gt;" StartValue="105" EndValue="140" StartThickness="7" EndThickness="7" ShapeOffset="1">
                                                                            </dx:LinearScaleRangeWeb>
                                                                        </Ranges>
                                                                    </dx:LinearScaleComponent>
                                                                </scales>
                                                                            <markers>
                                                                    <dx:LinearScaleMarkerComponent ScaleID="scale2" LinearScale="" ZOrder="-150" AcceptOrder="150" Name="linearGauge11_Marker1">
                                                                    </dx:LinearScaleMarkerComponent>
                                                                </markers>
                                                                        </dx:LinearGauge>
                                                                    </Gauges>
                                                                    <LayoutPadding All="0" Left="0" Top="0" Right="0" Bottom="0"></LayoutPadding>
                                                                </dx:ASPxGaugeControl>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                                <SettingsItemCaptions Location="Left" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            </dx:ASPxFormLayout>

                                        </ItemTemplate>

                                        <Paddings Padding="0px"></Paddings>

                                        <ItemStyle BackColor="White" ForeColor="Black">
                                            <Paddings Padding="0px"></Paddings>

                                            <Border BorderStyle="None"></Border>
                                        </ItemStyle>

                                        <PagerStyle Font-Bold="False"></PagerStyle>
                                    </dx:ASPxDataView>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItems VerticalAlign="Top" HorizontalAlign="Left" ShowCaption="False" Width="100%"></SettingsItems>
                    <SettingsItemCaptions VerticalAlign="Middle"></SettingsItemCaptions>
                </dx:ASPxFormLayout>


            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="pcResultado" PopupElementID="ASPxButtonResultadoFrente" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="Below" CssClass="popupresultado">
        <HeaderStyle Font-Size="Larger" Font-Bold="True" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxGridView ID="gridResumoGanho" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceResumoGanho" KeyFieldName="TIPO;FRENTE_AUX" Theme="Office2010Silver" ClientInstanceName="grid" Width="700px">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="FRENTE" VisibleIndex="4" Caption="Frente" Width="85px" SortIndex="0" SortOrder="Ascending" Visible="False">
                            <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TIPOcalc" VisibleIndex="5" Visible="False" Caption="Tipo" Width="140px" SortIndex="1" SortOrder="Ascending" UnboundType="String">
                            <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DESC_FRENTE_TIPO" VisibleIndex="6" Visible="True" Caption="Tipo" Width="140px" SortIndex="1" SortOrder="Ascending">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TIPO" VisibleIndex="7" Caption="Tipo" Width="100px" Visible="False"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ENTREGA_DE_CANA" VisibleIndex="8" Caption="Entrega Cana" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PRODUTIVIDADE" VisibleIndex="10" Caption="Produt." Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="IMPUREZA_MINERAL" VisibleIndex="11" Caption="Imp. Mineral" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="IMPUREZA_VEGETAL" VisibleIndex="12" Caption="Imp. Vegetal" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PERDAS" VisibleIndex="13" Caption="Perdas" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PISOTEIO_SOQUEIRA" VisibleIndex="14" Caption="Pisoteio Soqueira" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CONSUMO_OLEO_DIESEL" VisibleIndex="16" Caption="Cons. &#211;leo Diesel" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CONSUMO_OLEO_DIESEL_COLHEDORA" VisibleIndex="17" Caption="Cons. &#211;leo Diesel Colh." Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CONSUMO_OLEO_DIESEL_TRATOR" VisibleIndex="18" Caption="Cons. &#211;leo Diesel Trator" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CONSUMO_OLEO_HIDRAULICO" VisibleIndex="19" Caption="Cons. &#211;leo Hidr&#225;ulico" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DISPONIBILIDADE_MECANICA" VisibleIndex="20" Caption="Disp. Mecânica" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DISP_MECANICA_COLHEDORA" VisibleIndex="22" Caption="Disp. Mec. Colh." Width="50px" Visible="True">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DISP_MEC_COLHEDORA_SN" VisibleIndex="23" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DISP_MECANICA_DEMAIS" VisibleIndex="24" Caption="Disp. Mec. Demais" Width="50px" Visible="True">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DISP_MEC" VisibleIndex="25" Caption="Disp. Mec." Visible="False" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TEMPO_APROVEIT_COLHEDORA" VisibleIndex="26" Caption="Tempo Aprov. Colh." Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PREVENTIVA_MECANICA" VisibleIndex="27" Caption="Prevent. Mecânica" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PREVENTIVA_MANUT_BASICA" VisibleIndex="28" Caption="Prevent. Manut. Básica" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TEMPO_ATENDIMENTO" VisibleIndex="29" Caption="Tempo Atend." Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="MAPA_DE_PARADA" VisibleIndex="30" Caption="Mapa Parada" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TOTALcalc" VisibleIndex="34" Caption="Total" UnboundType="Decimal" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>

                            <HeaderStyle Font-Bold="True"></HeaderStyle>

                            <CellStyle Font-Bold="True"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="GANHO_BONUS" VisibleIndex="35" Caption="Ganho B&#244;nus" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="QTDPAGARcalc" VisibleIndex="40" Caption="Qtd. Horas Efet. à Pagar" UnboundType="Decimal" Width="50px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}"></PropertiesTextEdit>

                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior AllowDragDrop="False" />
                    <SettingsPager Visible="False" PageSize="1000"></SettingsPager>
                    <%--<Settings ShowVerticalScrollBar="true" VerticalScrollableHeight="930" UseFixedTableLayout="True" ShowTitlePanel="true" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="False" ShowGroupFooter="VisibleIfExpanded" />--%>
                    <SettingsText Title="Resumo Ganho" />
                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                    <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />

                    <Styles>
                        <Header Wrap="True">
                        </Header>
                        <TitlePanel Font-Size="Medium">
                        </TitlePanel>
                        <Cell>
                            <Paddings PaddingBottom="0px" PaddingTop="0px" />
                        </Cell>
                        <AlternatingRow Enabled="False">
                        </AlternatingRow>
                    </Styles>

                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="gridResumoGanhoColab" runat="server" KeyFieldName="ROWNUM" OnBeforePerformDataSelect="gridResumoGanhoColab_BeforePerformDataSelect" AutoGenerateColumns="False" Theme="Office2010Silver">
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID_NEGOCIOS" VisibleIndex="1" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DATA_HORA" VisibleIndex="2" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID_TIPO" VisibleIndex="3" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="FRENTE_SRV" VisibleIndex="4" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="MATRICULA" VisibleIndex="6" Width="40px" Caption="Matrícula"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="NOME" VisibleIndex="7" Width="120px" Caption="Colaborador"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="CARGO_NA_DATA" VisibleIndex="8" Width="62px" Visible="False"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DS_CARGO" VisibleIndex="9" Width="80px"  Caption="Cargo"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DIAS_PERIODO" VisibleIndex="10" Width="30px" Caption="Dias Período"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DIAS_TRAB_PERIODO" VisibleIndex="11" Width="30px" Caption="Dias Trab. Período"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="VLR_HORA_COLAB" VisibleIndex="12" Width="40px" Caption="Vlr. Hora"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="QTD_TOTAL_TIPO" VisibleIndex="13" Visible="False" Width="30px" Caption="Total Horas Tipo">
                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.0}" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="QTD_TOTAL_COLAB" VisibleIndex="14" Width="30px" Caption="Total Horas Colab">
                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="VLR_TOTAL_TIPO" VisibleIndex="15" Width="40px" Caption="Vlr. Total Tipo">
                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="VLR_TOTAL_COLAB" VisibleIndex="16" Width="40px" Caption="Vlr. Total Colab.">
                                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsPager PageSize="1000">
                                </SettingsPager>
                                <Settings ShowColumnHeaders="True" UseFixedTableLayout="True" />
                                <Styles>
                                    <Header Wrap="True">
                                    </Header>
                                    <AlternatingRow Enabled="True">
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
                </dx:ASPxGridView>

            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>


    <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" ClientInstanceName="pcEquip" PopupElementID="ASPxButtonEquip" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="Below" CssClass="popupresultado">
        <HeaderStyle Font-Size="Larger" Font-Bold="True" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxGridView ID="ASPxGridView2" runat="server" DataSourceID="SqlDataSourceRemunVariavelEquip" AutoGenerateColumns="False" Theme="Office2010Silver" KeyFieldName="ROWNUM" ClientInstanceName="gridequip" Width="920px">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="FRENTETIPO" Visible="False" VisibleIndex="2"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="FRENTETIPOAUX" Visible="False" VisibleIndex="21"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DSC_EQUIPAMENTO" VisibleIndex="0" Caption="Descrição Equipamento" SortIndex="0" SortOrder="Ascending" Width="105px">
                            <Settings AllowAutoFilter="False" AllowHeaderFilter="True"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NRO_EQUIPAMENTO" VisibleIndex="1" Caption="N° Equip." SortIndex="1" SortOrder="Ascending" Width="45px">
                            <Settings AllowAutoFilter="True" AllowHeaderFilter="True"></Settings>
                            <CellStyle HorizontalAlign="Left">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DSC_ULTIMA_OPERACAO" VisibleIndex="2" Caption="Última Operação Realizada" Width="180px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CONSUMO_PADRAO_OPER" VisibleIndex="3" Caption="Consumo Padrão Op." Width="45px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DS_FRENTETIPO" VisibleIndex="8" Visible="False" Caption="Frente / Tipo" SortIndex="0" SortOrder="Ascending" Width="85px">
                            <Settings AllowAutoFilter="False" AllowHeaderFilter="True"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="R_DISP_MECANICA" VisibleIndex="19" Caption="Disp. (%)" Width="40px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="R_DISP_MECANICA_COLHEDORA" VisibleIndex="12" Visible="false" Caption="Disp. Mec. Colhedora (%)" Width="80px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="R_DISP_MECANICA_DEMAIS" VisibleIndex="13" Visible="false" Caption="Disp. Mec. Demais Equip. (%)" Width="80px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewBandColumn Caption="Consumo de Óleo Diesel">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="R_CONSUMO_OLEO_DIESELKML" VisibleIndex="15" Caption="Km/l" Width="40px">
                                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.0000}" />
                                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="R_CONSUMO_OLEO_DIESELLTH" VisibleIndex="16" Caption="Lt/h" Width="40px">
                                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.0000}" />
                                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="R_CONSUMO_OLEO_DIESELLTTON" VisibleIndex="17" Caption="Lt/ton" Width="40px">
                                    <PropertiesTextEdit DisplayFormatString="{0:#,#0.0000}" />
                                    <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:GridViewBandColumn>
                        <dx:GridViewDataTextColumn FieldName="R_CONSUMO_OLEO_HIDRAULICO" VisibleIndex="18" Caption="Consumo Óleo Hidráulico (Lt/ton)" Width="55px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.0000}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="R_TEMPO_APROVEIT_COLHEDORA" VisibleIndex="20" Caption="Tempo Aprov. Colhedora (%)" Width="45px">
                            <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                            <Settings AllowHeaderFilter="False" AllowAutoFilter="False" AllowSort="False" />
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior AllowDragDrop="False" />
                    <SettingsPager Visible="False" PageSize="1000"></SettingsPager>
                    <Settings ShowVerticalScrollBar="true" VerticalScrollableHeight="450" UseFixedTableLayout="True" ShowTitlePanel="true" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="False" ShowGroupFooter="VisibleIfExpanded" />
                    <SettingsText Title="Indicadores Agrícolas Por Equipamento" />
                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>

                    <Styles>
                        <Header Wrap="True" HorizontalAlign="Center">
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

            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <asp:SqlDataSource ID="SqlDataSourceRemunVariavel" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="select DECODE(t.NOTA,'RUIM',4,'REGULAR',3,'BOM',2,'OTIMO',0) NOTAcalc, t.* from BI4T.INDICADORES_AGRICOLA t where t.FRENTE = 1 order by t.frente, t.INDICADOR"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceResumoGanho" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="select ID_NEGOCIOS, DATA_FECHAMENTO, ID_PROCESSO, GRUPO, FRENTE, TIPO, PRODUTIVIDADE, IMP_MINERAL, IMP_VEGETAL, PERDAS, CONSUMO_OLEO_DIESEL, CONSUMO_OLEO_HIDRAULICO, DISP_MEC_COLHEDORA, DISP_MEC_COLHEDORA_SN, DISP_MEC_DEMAIS, DISP_MEC, TEMPO_AP_COLHEDORA, GANHO_BONUS, decode(FRENTE, NULL, TIPO, LPAD(FRENTE,3,'0')) FRENTETIPO from v_resumo_ganho_indicadores"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceRemunVariavelEquip" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="select decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.FRENTE, A.DATA_FECHAMENTO, A.TIPO, A.GRUPO, A.DSC_EQUIPAMENTO, A.NRO_EQUIPAMENTO, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'DISP_MECANICA_COLHEDORA') R_DISP_MECANICA_COLHEDORA, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'DISP_MECANICA_DEMAIS') R_DISP_MECANICA_DEMAIS, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR IN ('DISP_MECANICA_COLHEDORA', 'DISP_MECANICA_DEMAIS')) R_DISP_MECANICA, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_DIESEL' AND B1.UNIDADE_MEDIDA = 'LT/H') R_CONSUMO_OLEO_DIESELLTH, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_DIESEL' AND B1.UNIDADE_MEDIDA = 'KM/L') R_CONSUMO_OLEO_DIESELKML, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_DIESEL' AND B1.UNIDADE_MEDIDA = 'LT/TON') R_CONSUMO_OLEO_DIESELLTTON, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_HIDRAULICO') R_CONSUMO_OLEO_HIDRAULICO, (SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'TEMPO_APROVEIT_COLHEDORA') R_TEMPO_APROVEIT_COLHEDORA from BI4T.INDICADORES_AGRICOLA_EQUIP A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) = 'CONSERVACAO_GERAL' and A.DATA_FECHAMENTO = TO_DATE('20062015','DDMMYYYY') GROUP BY decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)), B.FRCO_DESCRICAO, C.DSC_REDUZIDA, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO), A.ID_NEGOCIOS, A.FRENTE, A.DATA_FECHAMENTO, A.TIPO, A.GRUPO, A.DSC_EQUIPAMENTO, A.NRO_EQUIPAMENTO"></asp:SqlDataSource>
</asp:Content>
