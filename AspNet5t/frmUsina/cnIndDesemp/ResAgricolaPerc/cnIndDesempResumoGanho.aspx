<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnIndDesempResumoGanho.aspx.vb" Inherits="AspNet5t.cnIndDesempResumoGanho" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style type="text/css">
       .my-legend .legend-title {
            text-align: left;
            margin-bottom: 8px;
            font-weight: bold;
            font-size: 90%;
        }
        .my-legend .legend-scale ul {
            margin: 0;
            padding: 0;
            float: left;
            list-style: none;
        }
        .my-legend .legend-scale ul li {
            display: block;
            float: left;
            width: 16px;
            margin-bottom: 6px;
            text-align: center;
            font-size: 80%;
            list-style: none;
        }
        .my-legend ul.legend-labels li span {
            display: block;
            float: left;
            height: 15px;
            width: 16px;
        }
        .my-legend ul.legend-labels li  {
            margin-bottom: 0;
        }

        .my-legend .legend-source {
            font-size: 70%;
            color: #999;
            clear: both;
        }
        .my-legend a {
            color: #777;
        }
        .centerBlock {
            display: table;
            margin: 0 auto;
        }

    </style>

    <script type="text/javascript">
        function OnInit(s, e) {
            AdjustSize();
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
        }
        function OnEndCallback(s, e) {
            AdjustSize();
        }
        function OnControlsInitialized(s, e) {
            ASPxClientUtils.AttachEventToElement(window, "resize", function(evt) {
                AdjustSize();
            });
        }
        function AdjustSize() {
            var height = Math.max(0, document.documentElement.clientHeight);
            grid.SetHeight(height - 80 * 1.5);
        }
        function OnSelectionIndexChanged(s, e) {
            if (cmbGrupo.GetValue().toString() == "Todos os Grupos") {
                grid.ClearFilter();
            }
            else {
                grid.ApplyFilter("[GRUPO] = '" + cmbGrupo.GetValue().toString() + "'");

            };
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxCallbackPanel ID="ASPxCbPanel" runat="server" Width="100%" ClientInstanceName="cbPanel">
        <PanelCollection>
            <dx:PanelContent runat="server">

                <dx:ASPxHiddenField ID="ASPxHiddenField" runat="server" ClientInstanceName="hf">
                </dx:ASPxHiddenField>

                <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="3">
                    <Items>
                        <dx:LayoutItem Caption="Grupo" CaptionStyle-Font-Bold="false" Width="50px" HorizontalAlign="Left" ShowCaption="True">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox runat="server" ID="ASPxComboGrupo" IncrementalFilteringMode="None" ClientVisible="true" Width="200px" ClientInstanceName="cmbGrupo">
                                        <%--<ClientSideEvents SelectedIndexChanged="function(s, e) { cbPanel.PerformCallback(); }"></ClientSideEvents>--%>
                                        <ClientSideEvents SelectedIndexChanged="OnSelectionIndexChanged"></ClientSideEvents>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>

                            <CaptionSettings Location="Top" HorizontalAlign="Left"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" Width="650px" HorizontalAlign="Center">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <div class='my-legend centerBlock'>
                                        <div class='legend-scale'>
                                            <ul class='legend-labels'>
                                                <li><span style='background: #CE8396;'></span>RUIM</li>
                                                <li><span style='background: #ffffff;'></span></li>
                                                <li><span style='background: #ffffff;'></span></li>
                                                <li><span style='background: #ffffff;'></span></li>
                                                <li><span style='background: #F5E16B;'></span>REGULAR</li>
                                                <li><span style='background: #ffffff;'></span></li>
                                                <li><span style='background: #ffffff;'></span></li>
                                                <li><span style='background: #ffffff;'></span></li>
                                                <li><span style='background: #699BC1;'></span>BOM</li>
                                                <li><span style='background: #ffffff;'></span></li>
                                                <li><span style='background: #ffffff;'></span></li>
                                                <li><span style='background: #ffffff;'></span></li>
                                                <li><span style='background: #67DD63;'></span>ÓTIMO</li>
                                            </ul>
                                        </div>
                                    </div>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Data Fechamento" CaptionStyle-Font-Bold="false" Width="100px" HorizontalAlign="Right">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <div style="width: 100px; text-align: right;">
                                        <dx:ASPxComboBox runat="server" IncrementalFilteringMode="None" Width="100px" ID="ASPxComboDataFechamento">
                                            <ClientSideEvents SelectedIndexChanged="function(s, e) { cbPanel.PerformCallback(); }"></ClientSideEvents>
                                        </dx:ASPxComboBox>
                                    </div>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceResumoGanho" Theme="Office2010Silver" ClientInstanceName="grid" Width="100%">
                                        <Columns>
                                            <dx:GridViewDataDateColumn FieldName="DATA_FECHAMENTO" VisibleIndex="1" Visible="False"></dx:GridViewDataDateColumn>
                                            <dx:GridViewDataTextColumn FieldName="GRUPO" VisibleIndex="2" Caption="Grupo" Width="100px">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FRENTE" VisibleIndex="4" Caption="Frente" Width="85px" SortIndex="0" SortOrder="Ascending">
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
                                        <Settings ShowVerticalScrollBar="true" VerticalScrollableHeight="930" UseFixedTableLayout="True" ShowTitlePanel="true" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="False" ShowGroupFooter="VisibleIfExpanded" />
                                        <SettingsText Title="Resultado Agrícola em %" />
                                        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>

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

                                        <ClientSideEvents Init="OnInit" EndCallback="OnEndCallback" />

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


    <asp:SqlDataSource runat="server" ID="SqlDataSourceResumoGanho" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="select ID_NEGOCIOS, DATA_FECHAMENTO, ID_PROCESSO, GRUPO, FRENTE, TIPO, PRODUTIVIDADE, IMPUREZA_MINERAL, IMPUREZA_VEGETAL, PERDAS, CONSUMO_OLEO_DIESEL, CONSUMO_OLEO_HIDRAULICO, DISP_MEC_COLHEDORA DISP_MECANICA_COLHEDORA, DISP_MEC_COLHEDORA_SN, DISP_MEC_DEMAIS DISP_MECANICA_DEMAIS, DISP_MEC, TEMPO_APROVEIT_COLHEDORA, GANHO_BONUS, decode(FRENTE, NULL, TIPO, LPAD(FRENTE,3,'0')) FRENTETIPO from v_resumo_ganho_indicadores"></asp:SqlDataSource>
</asp:Content>
