<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaEscalaColaborador.aspx.vb" Inherits="AspNet5t.cnEntCanaEscalaColaborador" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
        function OnDateChanged(s, e) {
            hf.Set("hfDataRefAtual", cbDataRef.GetValue());
            cbPanel.PerformCallback();
        }
        function OnInit(s, e) {
            AdjustSize();
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
        }
        function OnControlsInitialized(s, e) {
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
        }
        function AdjustSize() {
            var height = Math.max(0, document.documentElement.clientHeight);
            grid.SetHeight(height - 125);
        }
    </script>

</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxCallbackPanel ID="ASPxCbPanel" runat="server" Width="100%" ClientInstanceName="cbPanel">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxHiddenField ID="ASPxHiddenField" runat="server" ClientInstanceName="hf">
                </dx:ASPxHiddenField>

                <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="2">
                    <Items>
                        <dx:LayoutItem Caption="Processo" Width="750px">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox runat="server" ID="ASPxComboProcesso" IncrementalFilteringMode="None" ClientVisible="true" Width="200px" Native="True">
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) { cbPanel.PerformCallback(); }"></ClientSideEvents>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>

                            <CaptionSettings Location="Top"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Data Refer&#234;ncia" Width="100px">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxDateEdit runat="server" ID="ASPxDataRef" Width="100px" AllowNull="False" Date="04/09/2015 00:00:00" AllowUserInput="False" PopupHorizontalAlign="RightSides" ClientInstanceName="cbDataRef">
                                        <ClientSideEvents DateChanged="OnDateChanged"></ClientSideEvents>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>

                            <CaptionSettings Location="Top" HorizontalAlign="Center"></CaptionSettings>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" Theme="Office2010Silver" KeyFieldName="ROWNUM" ClientInstanceName="grid" Width="920px">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="ROWNUM" Visible="False" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ESTRUTURA" VisibleIndex="1" Width="70px" Caption="Estrutura" SortIndex="0" SortOrder="Ascending">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="True" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="MATRICULA" VisibleIndex="2" Width="50px" Caption="Matrícula">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="True" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="NOME" VisibleIndex="3" Width="100px" Caption="Nome" SortIndex="1" SortOrder="Ascending">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="True" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TURNO" VisibleIndex="4" Width="45px" Caption="Turno">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA01" VisibleIndex="5" Width="50px" Caption="Dia 1">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA02" VisibleIndex="6" Width="50px" Caption="Dia 2">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA03" VisibleIndex="7" Width="50px" Caption="Dia 3">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA04" VisibleIndex="8" Width="50px" Caption="Dia 4">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA05" VisibleIndex="9" Width="50px" Caption="Dia 5">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA06" VisibleIndex="10" Width="50px" Caption="Dia 6">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA07" VisibleIndex="11" Width="50px" Caption="Dia 7">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA08" VisibleIndex="12" Width="50px" Caption="Dia 8">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA09" VisibleIndex="13" Width="50px" Caption="Dia 9">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA10" VisibleIndex="14" Width="50px" Caption="Dia 10">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA11" VisibleIndex="15" Width="50px" Caption="Dia 11">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA12" VisibleIndex="16" Width="50px" Caption="Dia 12">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA13" VisibleIndex="17" Width="50px" Caption="Dia 13">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA14" VisibleIndex="18" Width="50px" Caption="Dia 14">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA15" VisibleIndex="19" Width="50px" Caption="Dia 15">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA16" VisibleIndex="20" Width="50px" Caption="Dia 16">
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA17" VisibleIndex="21" Width="50px" Caption="Dia 17">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA18" VisibleIndex="22" Width="50px" Caption="Dia 18">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA19" VisibleIndex="23" Width="50px" Caption="Dia 19">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA20" VisibleIndex="24" Width="50px" Caption="Dia 20">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA21" VisibleIndex="25" Width="50px" Caption="Dia 21">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA22" VisibleIndex="26" Width="50px" Caption="Dia 22">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA23" VisibleIndex="27" Width="50px" Caption="Dia 23">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA24" VisibleIndex="28" Width="50px" Caption="Dia 24">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA25" VisibleIndex="29" Width="50px" Caption="Dia 25">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA26" VisibleIndex="30" Width="50px" Caption="Dia 26">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA27" VisibleIndex="31" Width="50px" Caption="Dia 27">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA28" VisibleIndex="32" Width="50px" Caption="Dia 28">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA29" VisibleIndex="33" Width="50px" Caption="Dia 29">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DIA30" VisibleIndex="34" Width="50px" Caption="Dia 30">
                                                <Settings AllowHeaderFilter="True" AllowAutoFilter="False" />
                                                <CellStyle HorizontalAlign="Center">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataHyperLinkColumn FieldName="CELULAR" ShowInCustomizationForm="True" Width="75px" Caption="Telefone" VisibleIndex="35">
                                                <PropertiesHyperLinkEdit NavigateUrlFormatString="tel:{0}"></PropertiesHyperLinkEdit>
                                            </dx:GridViewDataHyperLinkColumn>
                                        </Columns>
                                        <SettingsPager Visible="False" PageSize="1000"></SettingsPager>
                                        <Settings ShowVerticalScrollBar="true" VerticalScrollableHeight="450" UseFixedTableLayout="True" ShowTitlePanel="true" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" />
                                        <SettingsText Title="Escala de Colaboradores" />

                                        <SettingsBehavior AllowDragDrop="False" AllowGroup="False" />

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
                                        <Templates>
                                            <FooterRow>
                                                <div style="height: 20px;">
                                                    <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="8" Width="920px">
                                                        <Items>
                                                            <dx:LayoutItem ShowCaption="False">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxLabel runat="server" Text="T Trabalhado" ID="ASPxFormLayout2_E1"></dx:ASPxLabel>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem ShowCaption="False">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxLabel runat="server" Text="F Folga" ID="ASPxFormLayout2_E2"></dx:ASPxLabel>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem ShowCaption="False">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxLabel runat="server" Text="C Compensado" ID="ASPxFormLayout2_E3"></dx:ASPxLabel>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem ShowCaption="False">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxLabel runat="server" Text="FR Ferias" ID="ASPxFormLayout2_E4"></dx:ASPxLabel>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem ShowCaption="False">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxLabel runat="server" Text="AT Atestado" ID="ASPxFormLayout2_E5"></dx:ASPxLabel>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem ShowCaption="False">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxLabel runat="server" Text="AF Agenda de Folga" ID="ASPxFormLayout2_E6"></dx:ASPxLabel>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem ShowCaption="False">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxLabel runat="server" Text="NT Não Trabalha" ID="ASPxFormLayout2_E7"></dx:ASPxLabel>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem ShowCaption="False">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxLabel runat="server" Text="A Abonado" ID="ASPxFormLayout2_E8"></dx:ASPxLabel>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                        </Items>
                                                    </dx:ASPxFormLayout>
                                                    <%--T Trabalhado - F Folga - C Compensado - FR Ferias - AT Atestado - AF Agenda de Folfa - NT Não Trabalha - A Abonado--%>
                                                </div>
                                            </FooterRow>
                                        </Templates>

                                        <ClientSideEvents Init="OnInit" />
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

    <asp:SqlDataSource ID="SqlDataSourceRemunVariavel" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM,PROCESSO,ESTRUTURA,MATRICULA,NOME,TURNO,DIA01,DIA02,DIA03,DIA04,DIA05,DIA06,DIA07,DIA08,DIA09,DIA10,DIA11,DIA12,DIA13,DIA14,DIA15,DIA16,DIA17,DIA18,DIA19,DIA20,DIA21,DIA22,DIA23,DIA24,DIA25,DIA26,DIA27,DIA28,DIA29,DIA30,ID_NIVEL,ID_TURMAS FROM BI4T.V_ESCALA_COLAB WHERE ID_NIVEL IN (6,7)"></asp:SqlDataSource>

</asp:Content>
