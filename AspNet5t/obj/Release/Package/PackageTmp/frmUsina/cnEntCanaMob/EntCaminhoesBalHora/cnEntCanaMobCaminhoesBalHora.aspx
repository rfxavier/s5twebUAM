<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaMobCaminhoesBalHora.aspx.vb" Inherits="AspNet5t.cnEntCanaMobCaminhoesBalHora" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style type="text/css">
        .dxGridView_gvExpandedButton_Office2010Silver, .dxGridView_gvHeaderSortUp_Office2010Silver, .dxGridView_gvExpandedButton_iOS, .dxGridView_gvHeaderSortUp_iOS
        {
           visibility: hidden;
        }

        .dxflGroupCell {
            padding: 0px 2px;
        }
        .dxflGroup {
            padding: 0px 5px;
        }
        .dxgvDataRow_iOS td.dxgv, .dxgvDataRowAlt_iOS td.dxgv {
            padding: 3px 4px 4px;
        }
    </style>

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script type="text/javascript">
        function OnSelectionChanged(s, e) {
            gridFrentesProp.GetRowValues(e.visibleIndex, "FRENTE;COD_PROP", onGetValues);
        }
        function onGetValues(data) {
            if (data[0] != null) {
                hf.Set("hfFrenteAtual", data[0]);
                hf.Set("hfCodPropAtual", data[1]);
                hf.Set("hfDataRefAtual", cbDataRef.GetValue());
                gridCaminhaoViagens.PerformCallback();
            };
        }
        function OnDateChanged(s, e) {
            //gridFrentesProp.UnselectRows();
            hf.Set("hfDataRefAtual", cbDataRef.GetValue());
            cbPanel.PerformCallback();
        }
        function OnSplitterPaneResized(s, e) {
            if (e.pane.name == 'gridFrentesPropPane')
                gridFrentesProp.SetHeight(e.pane.GetClientHeight());
            else if (e.pane.name == 'gridCaminhaoViagensPane')
                gridCaminhaoViagens.SetHeight(e.pane.GetClientHeight());
        }
        function OnInit(s, e) {
            AdjustSize();
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
            ChangeHeaderStyle();
        }
        function OnEndCallback(s, e) {
            AdjustSize();
            ChangeHeaderStyle();
        }
        function OnControlsInitialized(s, e) {
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
        }
        function AdjustSize() {
            var height = Math.max(0, document.documentElement.clientHeight);
            //implement max height
            if (height - 100 <= 540) {
                gridHorasFrentePrinc.SetHeight(height - 115);
                splitter.SetHeight(height - 115);
            }
            else {
                gridHorasFrentePrinc.SetHeight(540);
                splitter.SetHeight(540);
            }
        }

        function OnInitGrid(s, e) {
            ChangeHeaderStyle();
        }
        function OnEndCallbackGrid(s, e) {
            ChangeHeaderStyle();
        }
        function ChangeHeaderStyle() {
            $(".MyClass").attr("colspan", 2);
            $(".MyClass").parent().children("td:first").css("display", "none");
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
                        <dx:LayoutItem Caption="" ShowCaption="False" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <span style="font-size: 21px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; vertical-align: 20%">Entrada de Caminhões na Balança</span>
                                    <%--<dx:ASPxLabel runat="server" Text="Resumo Entrada Caminhões na Balança" ID="ASPxFormLayout1_E1" style="font-size:21px; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"></dx:ASPxLabel>--%>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem Caption="Data Ref." CaptionStyle-Font-Bold="false" ShowCaption="True">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxDateEdit runat="server" ID="ASPxDataRef" Width="170px" AllowNull="False" Date="10/04/2014 00:00:00" AllowUserInput="False" PopupHorizontalAlign="RightSides" ClientInstanceName="cbDataRef" Theme="iOS">
                                        <ClientSideEvents DateChanged="OnDateChanged"></ClientSideEvents>
                                    </dx:ASPxDateEdit>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionCellStyle>
                                <Paddings PaddingTop="6px"></Paddings>
                            </CaptionCellStyle>

                            <NestedControlCellStyle>
                                <Paddings PaddingTop="6px"></Paddings>
                            </NestedControlCellStyle>

                            <CaptionStyle Font-Names="Segoe UI" Font-Size="21px"></CaptionStyle>
                        </dx:LayoutItem>

                        <dx:LayoutItem ShowCaption="False" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridView ID="ASPxGridViewHorasFrentePrincipal" runat="server" AutoGenerateColumns="False" Theme="Office2010Silver" KeyFieldName="ROWNUM" ClientInstanceName="gridHorasFrentePrinc" Width="520px" DataSourceID="SqlDataSourceHorasFrente">
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F1" ShowInColumn="F1" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F2" ShowInColumn="F2" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F3" ShowInColumn="F3" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F4" ShowInColumn="F4" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F5" ShowInColumn="F5" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F6" ShowInColumn="F6" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F7" ShowInColumn="F7" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F8" ShowInColumn="F8" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F9" ShowInColumn="F9" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="F10" ShowInColumn="F10" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0}" FieldName="TOTALcalc" ShowInColumn="TOTALcalc" SummaryType="Sum" ValueDisplayFormat="{0:#,#0}" />
<%--                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F1" ShowInColumn="F1" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F2" ShowInColumn="F2" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F3" ShowInColumn="F3" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F4" ShowInColumn="F4" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F5" ShowInColumn="F5" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F6" ShowInColumn="F6" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F7" ShowInColumn="F7" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F8" ShowInColumn="F8" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F9" ShowInColumn="F9" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />
                                            <dx:ASPxSummaryItem DisplayFormat="{0:#,#0.0}" FieldName="F10" ShowInColumn="F10" SummaryType="Average" ValueDisplayFormat="{0:#,#0.0}" />--%>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F1" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F1"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F2" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F2"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F3" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F3"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F4" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F4"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F5" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F5"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F6" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F6"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F7" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F7"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F8" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F8"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F9" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F9"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="F10" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="F10"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Custom" FieldName="TOTALcalc" DisplayFormat="{0:#,#0.0}" ValueDisplayFormat="{0:#,#0.0}" ShowInColumn="TOTALcalc"></dx:ASPxSummaryItem>
                                        </TotalSummary>
                                        <GroupSummary>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F1" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F1" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F2" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F2" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F3" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F3" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F4" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F4" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F5" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F5" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F6" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F6" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F7" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F7" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F8" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F8" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F9" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F9" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="F10" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="F10" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="TOTALcalc" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="TOTALcalc" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
                                        </GroupSummary>
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="SUBGRUPOcalc" UnboundType="String" VisibleIndex="0" GroupIndex="0" SortIndex="0" SortOrder="Ascending" Visible="False">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="HORA" VisibleIndex="1" Visible="False" Width="50px" SortIndex="1" SortOrder="Ascending">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="HORAFAIXAcalc" UnboundType="String" VisibleIndex="2" Caption="Horas" SortIndex="2" SortOrder="Ascending" Width="30px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <HeaderStyle CssClass="MyClass" />
                                                <Settings AllowSort="False"></Settings>
                                                <FooterTemplate>
                                                    <span style="font-weight: bold">Total</span><br />
                                                    <span style="font-weight: bold">Média</span>
                                                </FooterTemplate>
                                                <GroupFooterTemplate>
                                                    Subt.
                                                </GroupFooterTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F1" VisibleIndex="3" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F2" VisibleIndex="4" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F3" VisibleIndex="5" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F4" VisibleIndex="6" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F5" VisibleIndex="7" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F6" VisibleIndex="8" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F7" VisibleIndex="9" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F8" VisibleIndex="10" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F9" VisibleIndex="11" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="F10" VisibleIndex="12" Visible="True" Width="50px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TOTALcalc" UnboundType="Integer" VisibleIndex="13" Caption="Total" Width="60px">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsBehavior AllowDragDrop="False" AllowSelectByRowClick="False" AllowSelectSingleRowOnly="False" AllowFixedGroups="False" AllowSort="False" AutoExpandAllGroups="True" />
                                        <SettingsPager Visible="False" PageSize="1000"></SettingsPager>
                                        <Settings ShowGroupPanel="false" HorizontalScrollBarMode="Hidden" ShowVerticalScrollBar="True" VerticalScrollableHeight="500" UseFixedTableLayout="True" ShowTitlePanel="False" ShowFilterRow="False" ShowGroupedColumns="False" ShowFooter="True" ShowStatusBar="Hidden" ShowGroupFooter="VisibleIfExpanded" GroupFormat="" ShowGroupButtons="False" />
                                        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                                        <Styles>
                                            <Cell>
                                                <Paddings PaddingBottom="0px" PaddingTop="0px" />
                                            </Cell>
                                            <Footer Font-Bold="True" HorizontalAlign="Center">
                                            </Footer>
                                            <GroupFooter Font-Bold="True" HorizontalAlign="Center">
                                            </GroupFooter>
                                            <AlternatingRow Enabled="True">
                                            </AlternatingRow>
                                        </Styles>
                                        <%--                            <Templates>
                                            <FooterRow>
                                                teste
                                            </FooterRow>
                                        </Templates>--%>
                                    <ClientSideEvents Init="OnInit" EndCallback="OnEndCallback" />
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Orientation="Vertical" Height="572px" Width="275px" ClientInstanceName="splitter" Theme="iOS">
                                        <Styles>
                                            <Pane>
                                                <Paddings Padding="0px" />
                                            </Pane>
                                        </Styles>
                                        <Panes>
                                            <dx:SplitterPane Name="gridFrentesPropPane" Size="340px">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl runat="server">
                                                        <dx:ASPxGridView ID="ASPxGridViewFrentesProp" runat="server" AutoGenerateColumns="False" Theme="Office2010Silver" KeyFieldName="ROWNUM" ClientInstanceName="gridFrentesProp" Width="270px" DataSourceID="SqlDataSourceFrenteProp">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="FRENTE" VisibleIndex="0" Visible="True" Width="35px" SortIndex="0" SortOrder="Ascending" Caption="Fr.">
                                                                    <CellStyle HorizontalAlign="Center">
                                                                    </CellStyle>
                                                                    <Settings AllowSort="False"></Settings>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="COD_PROP" VisibleIndex="1" Visible="False" Width="50px"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="PROPRIEDADE" VisibleIndex="2" Visible="True" Width="200px" SortIndex="1" SortOrder="Ascending" Caption="Propriedade">
                                                                    <Settings AllowSort="False"></Settings>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="QTD_VIAGENS" VisibleIndex="3" Visible="False" Width="100px"></dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <ClientSideEvents SelectionChanged="OnSelectionChanged" />
                                                            <SettingsPager Mode="EndlessPaging">
                                                            </SettingsPager>
                                                            <SettingsBehavior AllowDragDrop="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowFixedGroups="False" AllowSort="False" />
                                                            <Settings ShowGroupPanel="false" ShowVerticalScrollBar="True" VerticalScrollableHeight="255" UseFixedTableLayout="True" ShowTitlePanel="False" ShowFilterRow="False" ShowGroupedColumns="False" ShowStatusBar="Hidden" />
                                                            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                                                            <Styles>
                                                                <SelectedRow BackColor="#D5FFD5">
                                                                </SelectedRow>
                                                                <Cell>
                                                                    <Paddings PaddingBottom="0px" PaddingTop="0px" />
                                                                </Cell>
                                                                <AlternatingRow Enabled="True">
                                                                </AlternatingRow>
                                                            </Styles>
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                            <dx:SplitterPane Name="gridCaminhaoViagensPane">
                                                <ContentCollection>
                                                    <dx:SplitterContentControl runat="server">
                                                        <dx:ASPxGridView ID="ASPxGridViewCaminhaoViagens" runat="server" AutoGenerateColumns="False" Theme="Office2010Silver" KeyFieldName="ROWNUM" ClientInstanceName="gridCaminhaoViagens" Width="270px" DataSourceID="SqlDataSourceCaminhaoViagens">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="FRENTE" VisibleIndex="0" Visible="False" Width="50px" SortIndex="0" SortOrder="Ascending"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="COD_PROP" VisibleIndex="1" Visible="False" Width="50px"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="CAMINHAO" VisibleIndex="2" Visible="True" Width="50px" SortIndex="1" SortOrder="Ascending" Caption="Caminhão">
                                                                    <CellStyle HorizontalAlign="Center">
                                                                    </CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="QTD_VIAGENS" VisibleIndex="3" Visible="True" Width="50px" Caption="Viagens">
                                                                    <CellStyle HorizontalAlign="Center">
                                                                    </CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>

                                                            <SettingsBehavior AllowDragDrop="False" AllowSelectByRowClick="False" AllowSelectSingleRowOnly="False" AllowFixedGroups="False" AllowSort="False" />
                                                            <SettingsPager Mode="EndlessPaging">
                                                            </SettingsPager>
                                                            <Settings ShowGroupPanel="false" ShowVerticalScrollBar="True" VerticalScrollableHeight="255" UseFixedTableLayout="True" ShowTitlePanel="False" ShowFilterRow="False" ShowGroupedColumns="False" ShowStatusBar="Hidden" />
                                                            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                                                            <Styles>
                                                                <Cell>
                                                                    <Paddings PaddingBottom="0px" PaddingTop="0px" />
                                                                </Cell>
                                                                <AlternatingRow Enabled="True">
                                                                </AlternatingRow>
                                                            </Styles>
                                                        </dx:ASPxGridView>
                                                    </dx:SplitterContentControl>
                                                </ContentCollection>
                                            </dx:SplitterPane>
                                        </Panes>
                                        <ClientSideEvents PaneResized="OnSplitterPaneResized" />
                                    </dx:ASPxSplitter>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                    </Items>

                        <SettingsItems VerticalAlign="Middle"></SettingsItems>

                    <SettingsItemCaptions VerticalAlign="Middle"></SettingsItemCaptions>
                </dx:ASPxFormLayout>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

    <asp:SqlDataSource runat="server" ID="SqlDataSourceHorasFrente" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT AB.HORA, SUM(CASE WHEN (FRENTE = 1) THEN QTD_VIAGENS ELSE 0 END) AS F1, SUM(CASE WHEN (FRENTE = 2) THEN QTD_VIAGENS ELSE 0 END) AS F2, SUM(CASE WHEN (FRENTE = 3) THEN QTD_VIAGENS ELSE 0 END) AS F3, SUM(CASE WHEN (FRENTE = 4) THEN QTD_VIAGENS ELSE 0 END) AS F4, SUM(CASE WHEN (FRENTE = 5) THEN QTD_VIAGENS ELSE 0 END) AS F5, SUM(CASE WHEN (FRENTE = 6) THEN QTD_VIAGENS ELSE 0 END) AS F6, SUM(CASE WHEN (FRENTE = 7) THEN QTD_VIAGENS ELSE 0 END) AS F7, SUM(CASE WHEN (FRENTE = 8) THEN QTD_VIAGENS ELSE 0 END) AS F8, SUM(CASE WHEN (FRENTE = 9) THEN QTD_VIAGENS ELSE 0 END) AS F9, SUM(CASE WHEN (FRENTE = 10) THEN QTD_VIAGENS ELSE 0 END) AS F10, SUM(CASE WHEN (FRENTE BETWEEN 1 AND 10) THEN QTD_VIAGENS ELSE 0 END) AS TOTAL FROM (SELECT CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER) FRENTE, TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))) HORA, COUNT(DISTINCT CERC.CERC_CERTIFICADO) QTD_VIAGENS FROM SISAGRI.CERTIFICADO_CANA CERC, SISAGRI.TALHAO_LIBERACAO LIBE, SISAGRI.PROPRIEDADE_AGRICOLA PROP WHERE CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE IS NULL) AND CERC.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS AND CERC.CERC_CODIGO_PROP = PROP.PROP_CODIGO AND CERC.ID_NEGOCIOS = 1 AND CERC.SAFRA = 2014 AND TRUNC(CERC.CERC_DATAENTRADAB) = TO_DATE('04/10/2014','DD/MM/YYYY') GROUP BY CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER), TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))) ) AB GROUP BY AB.HORA"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceFrenteProp" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT ROWNUM, AX.* FROM ( SELECT AB.FRENTE, AB.COD_PROP, AB.PROPRIEDADE, SUM(QTD_VIAGENS) QTD_VIAGENS FROM (SELECT CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER) FRENTE, TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))) HORA, CERC.CERC_CODIGO_PROP COD_PROP, CERC.CERC_CODIGO_PROP ||' - '|| UPPER(PROP.PROP_DESCRICAO) PROPRIEDADE, CERC.CERC_NEQUIPAMENTO CAMINHAO, COUNT(DISTINCT CERC.CERC_CERTIFICADO) QTD_VIAGENS FROM SISAGRI.CERTIFICADO_CANA CERC, SISAGRI.TALHAO_LIBERACAO LIBE, SISAGRI.PROPRIEDADE_AGRICOLA PROP WHERE CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE IS NULL) AND CERC.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS AND CERC.CERC_CODIGO_PROP = PROP.PROP_CODIGO AND CERC.ID_NEGOCIOS = 1 AND CERC.SAFRA = 2014 AND TRUNC(CERC.CERC_DATAENTRADAB) = TO_DATE('04/10/2014','DD/MM/YYYY') GROUP BY CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER), TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))), CERC.CERC_CODIGO_PROP, CERC.CERC_CODIGO_PROP ||' - '|| UPPER(PROP.PROP_DESCRICAO), CERC.CERC_NEQUIPAMENTO) AB GROUP BY AB.FRENTE, AB.COD_PROP, AB.PROPRIEDADE) AX"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceCaminhaoViagens" ConnectionString='<%$ ConnectionStrings:ConnectionString1Corte %>' ProviderName='<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>' SelectCommand="SELECT ROWNUM, AX.* FROM ( SELECT AB.FRENTE, AB.COD_PROP, AB.CAMINHAO, SUM(QTD_VIAGENS) QTD_VIAGENS FROM (SELECT CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER) FRENTE, TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))) HORA, CERC.CERC_CODIGO_PROP COD_PROP, CERC.CERC_CODIGO_PROP ||' - '|| UPPER(PROP.PROP_DESCRICAO) PROPRIEDADE, CERC.CERC_NEQUIPAMENTO CAMINHAO, COUNT(DISTINCT CERC.CERC_CERTIFICADO) QTD_VIAGENS FROM SISAGRI.CERTIFICADO_CANA CERC, SISAGRI.TALHAO_LIBERACAO LIBE, SISAGRI.PROPRIEDADE_AGRICOLA PROP WHERE CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE IS NULL) AND CERC.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS AND CERC.CERC_CODIGO_PROP = PROP.PROP_CODIGO AND CERC.ID_NEGOCIOS = 1 AND CERC.SAFRA = 2014 AND TRUNC(CERC.CERC_DATAENTRADAB) = TO_DATE('04/10/2014','DD/MM/YYYY') GROUP BY CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER), TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))), CERC.CERC_CODIGO_PROP, CERC.CERC_CODIGO_PROP ||' - '|| UPPER(PROP.PROP_DESCRICAO), CERC.CERC_NEQUIPAMENTO) AB GROUP BY AB.FRENTE, AB.COD_PROP, AB.CAMINHAO) AX"></asp:SqlDataSource>

</asp:Content>
