<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCapivaraPopUp.ascx.vb" Inherits="AspNet5t.ucCapivaraPopUp" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

    <script type="text/javascript">
        function OnDateChanged(s, e) {
            var jsDate = dateEditDtRef.GetDate();

            var year = jsDate.getFullYear(); // where getFullYear returns the year (four digits)
            var month = jsDate.getMonth(); // where getMonth returns the month (from 0-11)
            var day = jsDate.getDate();   // where getDate returns the day of the month (from 1-31)

            var dtRef = new Date(year, month, day);
            gvIT.PerformCallback(dtRef);
        }
    </script>


    <dx:ASPxHiddenField ID="ASPxHiddenField" runat="server" ClientInstanceName="hf"></dx:ASPxHiddenField>

    <dx:ASPxPopupControl ID="propriedadePopUp" runat="server" ClientInstanceName="pcProp"
                         HeaderText="Acompanhamento de Produtividade" Width="370px" ShowPageScrollbarWhenModal="True" LoadContentViaCallback="OnPageLoad" PopupElementID="ASPxButton1" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div>
                    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Mapa da Propriedade" NavigateUrl="~/Content/mapas/00338.pdf" Target="_blank" ClientInstanceName="hypMapaProp" ClientVisible="False">
                    </dx:ASPxHyperLink>
                </div>
                <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="1">
                    <TabPages>
                        <dx:TabPage Name="tab1Corte" Text="1º Corte">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <%--<dx:ASPxDataView ID="ASPxDataView1" runat="server" DataSourceID="SqlDataSource1Corte" Theme="Office2003Silver">--%>
                                    <dx:ASPxDataView ID="ASPxDataView1" runat="server" DataSourceID="" Theme="Office2003Silver" ClientInstanceName="datav1">
                                        <SettingsTableLayout ColumnCount="1" RowsPerPage="1" />
                                        <PagerSettings ShowNumericButtons="False" Position="Bottom"></PagerSettings>
                                        <ItemTemplate>
                                            <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" AlignItemCaptionsInAllGroups="True" ColCount="2">
                                                <Items>
                                                    <dx:LayoutItem Caption="Propriedade" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E1" runat="server" Text='<%# Eval("DS_NOME_PROPRIEDADE") & " ( " & Eval("PROP_CODIGO") & " )"%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Área Colhida">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E2" runat="server" Text='<%# Eval("QT_AREA_COLHIDA", "{0:#,#0.00}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Data Plantio">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E5" runat="server" Text='<%# Eval("DT_PLANTIO", "{0:dd/MM/yyyy}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Idade">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E4" runat="server" Text='<%# Eval("IDADE")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tipo Plantio">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E7" runat="server" Text='<%# Eval("TIPO_PLANTIO")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Cana Entregue">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E6" runat="server" Text='<%# Eval("QT_TON_ENTREGUE", "{0:#,#0.00}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Empresa">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E9" runat="server" Text='<%# Eval("EMPRESA_PLANTIO")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Rend. Plan.">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E8" runat="server" Text='<%# Eval("RENDIMENTO_PLAN")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Stand">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E11" runat="server" Text='<%# Eval("STAND")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Rend. Real">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxLabel ID="ASPxFormLayout1_E10" runat="server" Text='<%# Eval("RENDIMENTO_REAL")%>' Font-Bold="True">
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                            <CaptionStyle Font-Bold="True">
                                            </CaptionStyle>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tipo Adubação">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E13" runat="server" Text='<%# Eval("TIPO_ADUBACAO")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Data Dessecação">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E12" runat="server" Text='<%# Eval("DT_DESSECACAO", "{0:dd/MM/yyyy}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Trat. Toletes">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E15" runat="server" Text='<%# Eval("TRAT_TOLETES")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Data Calagem">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E3" runat="server" Text='<%# Eval("DT_CALAGEM", "{0:dd/MM/yyyy}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Data Apl. Herb.">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E14" runat="server" Text='<%# Eval("DT_HERB_CANA_PLANTA", "{0:dd/MM/yyyy}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Semana Encerramento" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout1_E16" runat="server" Text='<%# Eval("SEMANA_ENCERRAMENTO") %>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                                <SettingsItems Width="280px" />
                                                <SettingsItemCaptions Location="Left" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            </dx:ASPxFormLayout>
                                        </ItemTemplate>
                                    </dx:ASPxDataView>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <dx:TabPage Name="tabDCorte" Text="Demais Cortes">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <%--<dx:ASPxDataView ID="ASPxDataView2" runat="server" DataSourceID="SqlDataSourceDCortes" Theme="Office2003Silver">--%>
                                    <dx:ASPxDataView ID="ASPxDataView2" runat="server" DataSourceID="" Theme="Office2003Silver" ClientInstanceName="datav2">
                                        <SettingsTableLayout ColumnCount="1" RowsPerPage="1" />
                                        <PagerSettings ShowNumericButtons="False" Position="Bottom">
                                        </PagerSettings>
                                        <ItemTemplate>
                                            <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" AlignItemCaptionsInAllGroups="True" ColCount="2">
                                                <Items>
                                                    <dx:LayoutItem ColSpan="2" Caption="Propriedade">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E1" runat="server" Text='<%# Eval("DS_NOME_PROPRIEDADE") & " ( " & Eval("PROP_CODIGO") & " )"%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Nº Corte">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E2" runat="server" Text='<%# Eval("NRO_CORTE")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tipo Adubação">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E3" runat="server" Text='<%# Eval("TIPO_ADUBACAO")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Área (ha)">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E4" runat="server" Text='<%# Eval("QT_AREA_COLHIDA", "{0:#,#0.00}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Data Adubação">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E5" runat="server" Text='<%# Eval("DT_ADUBACAO", "{0:dd/MM/yyyy}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Data Colheita Anterior">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E6" runat="server" Text='<%# Eval("DT_COLHEITA_ANTERIOR", "{0:dd/MM/yyyy}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Dif. Adubação (dias)">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E7" runat="server" Text='<%# Eval("DIF_DIAS_ADUB")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Idade (meses)">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E8" runat="server" Text='<%# Eval("IDADE")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Fertirrigação">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E9" runat="server" Text='<%# Eval("DT_FERTIRRIGACAO", "{0:dd/MM/yyyy}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Cana Entregue">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E10" runat="server" Text='<%# Eval("QT_TON_ENTREGUE", "{0:#,#0.00}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tipo Aplic.">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E11" runat="server" Text='<%# Eval("TIPO_HERBICIDA") %>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Prod. Plan.">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E12" runat="server" Text='<%# Eval("RENDIMENTO_PLAN")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Data Herbicida">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E13" runat="server" Text='<%# Eval("DT_HERBICIDA", "{0:dd/MM/yyyy}")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Prod. Real">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxLabel ID="ASPxFormLayout2_E14" runat="server" Text='<%# Eval("RENDIMENTO_REAL")%>' Font-Bold="True">
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                            <CaptionStyle Font-Bold="True">
                                            </CaptionStyle>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Dif. Herbicida (dias)">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E15" runat="server" Text='<%# Eval("DIF_DIAS_HERB")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Produtiv. Desvio (%)">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E16" runat="server" Text='<%# Eval("DESVIO")%>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Semana Encerramento">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxLabel ID="ASPxFormLayout2_E17" runat="server" Text='<%# Eval("SEMANA_ENCERRAMENTO") %>'>
                                                                </dx:ASPxLabel>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                                <SettingsItems Width="280px" />
                                                <SettingsItemCaptions Location="Left" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            </dx:ASPxFormLayout>
                                        </ItemTemplate>
                                    </dx:ASPxDataView>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <dx:TabPage Name="tabProdutividade" Text="Produtividade">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="SqlDataSourceProdutividade" KeyFieldName="ROWNUM" EnableTheming="True" Theme="Office2010Silver" AutoGenerateColumns="False" Width="700px">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PROPRIEDADE" VisibleIndex="1" Caption="Cód." SortIndex="0" SortOrder="Ascending" Visible="False">
                                                <Settings AllowHeaderFilter="True" />
                                                <PropertiesTextEdit DisplayFormatString="{0:#,#0}" DisplayFormatInEditMode="True" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DESCPROP" VisibleIndex="2" Caption="Propriedade" Visible="False">
                                                <Settings AllowHeaderFilter="True" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CORTE" VisibleIndex="3" Caption="N° Corte" SortIndex="1" SortOrder="Ascending" FixedStyle="Left">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TON_HA_6" VisibleIndex="16" Caption="Ton/Ha 2009">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EQUILIBRIO_6" VisibleIndex="17" Caption="Equilíbrio 2009">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TON_HA_5" VisibleIndex="14" Caption="Ton/Ha 2010">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EQUILIBRIO_5" VisibleIndex="15" Caption="Equilíbrio 2010">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TON_HA_4" VisibleIndex="12" Caption="Ton/Ha 2011">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EQUILIBRIO_4" VisibleIndex="13" Caption="Equilíbrio 2011">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TON_HA_3" VisibleIndex="10" Caption="Ton/Ha 2012">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EQUILIBRIO_3" VisibleIndex="11" Caption="Equilíbrio 2012">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TON_HA_2" VisibleIndex="8" Caption="Ton/Ha 2013">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EQUILIBRIO_2" VisibleIndex="9" Caption="Equilíbrio 2013">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TON_HA_1" VisibleIndex="6" Caption="Ton/Ha 2014">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EQUILIBRIO_1" VisibleIndex="7" Caption="Equilíbrio 2014">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TON_HA" VisibleIndex="4" Caption="Ton/Ha 2015">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EQUILIBRIO" VisibleIndex="5" Caption="Equilíbrio 2015">
                                                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                                 <PropertiesTextEdit DisplayFormatString="{0:#,#0}" /> 
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsBehavior AllowDragDrop="False" />
                                        <Settings HorizontalScrollBarMode="Visible" ShowTitlePanel="true"/>
                                        <SettingsText Title="Propriedade" />
                            <Styles>
                                <AlternatingRow Enabled="True">
                                </AlternatingRow>
                            </Styles>
                                    </dx:ASPxGridView>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <dx:TabPage Name="tabIndicesTecnicos" Text="Indices T&#233;cnicos">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server">
                                        <Items>
                                            <dx:LayoutItem Caption="Data Refer&#234;ncia">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" AllowNull="False" AllowUserInput="False" Width="110px" ClientInstanceName="dateEditDtRef">
                                                            <ClientSideEvents DateChanged="OnDateChanged"></ClientSideEvents>
                                                        </dx:ASPxDateEdit>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="" ShowCaption="False">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" DataSourceID="SqlDataSourceIndicesTecnicos" KeyFieldName="ROWNUM" EnableTheming="True" Theme="Office2010Silver" AutoGenerateColumns="False" Width="550px" ClientInstanceName="gvIT">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="ROWNUM" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="DIA" VisibleIndex="1" Caption="Dia" FixedStyle="Left" SortIndex="0" SortOrder="Ascending">
                                                                     <PropertiesTextEdit DisplayFormatString="{0:dd/MM/yyyy}" /> 
                                                         <Settings SortMode="Custom" />
                                                                </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="POL" VisibleIndex="2" Caption="Pol" Width="60px">
                                                                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                                                                </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="FIBRA" VisibleIndex="3" Caption="Fibra" Width="60px">
                                                                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                                                                </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="AR" VisibleIndex="4" Caption="Ar" Width="60px">
                                                                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                                                                </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ATR" VisibleIndex="5" Caption="Atr" Width="60px">
                                                                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                                                                </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="UMIDADE" VisibleIndex="6" Caption="Umidade" Width="60px">
                                                                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                                                                </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="PUREZA" VisibleIndex="7" Caption="Pureza" Width="60px">
                                                                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                                                                </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ART_CALCULADO" VisibleIndex="8" Caption="Art Calc." Width="60px">
                                                                     <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" /> 
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <SettingsBehavior AllowDragDrop="False" />
                                                <Settings ShowTitlePanel="true"/>
                                                            <SettingsText Title="Propriedade" />
                                                <Styles>
                                                    <AlternatingRow Enabled="True">
                                                    </AlternatingRow>
                                                </Styles>
                                                        </dx:ASPxGridView>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>

                                        <SettingsItemCaptions VerticalAlign="Middle"></SettingsItemCaptions>
                                    </dx:ASPxFormLayout>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                    </TabPages>
                </dx:ASPxPageControl>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <asp:SqlDataSource ID="SqlDataSource1Corte" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM, A.* FROM ( SELECT        TRUNC(A.PROP_CODIGO) PROP_CODIGO,        A.DS_NOME_PROPRIEDADE,        TRUNC(A.NRO_CORTE) NRO_CORTE,        ROUND(SUM(A.QT_AREA_COLHIDA), 2) QT_AREA_COLHIDA,        TRUNC(A.IDADE) IDADE,        ROUND(SUM(A.QT_TON_ENTREGUE), 2) QT_TON_ENTREGUE,        ROUND(A.RENDIMENTO_PLAN, 0) RENDIMENTO_PLAN,        ROUND(DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0),                     0,                     0,                     (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA)))) RENDIMENTO_REAL,        MAX(A.DT_DESSECACAO) DT_DESSECACAO,        MAX(A.DT_CALAGEM) DT_CALAGEM,        MAX(A.DT_PLANTIO) DT_PLANTIO,        A.TIPO_PLANTIO,        A.EMPRESA_PLANTIO,        ROUND(AVG(A.STAND)) STAND,        A.TIPO_ADUBACAO,        A.TRAT_TOLETES,        MAX(A.DT_HERB_CANA_PLANTA) DT_HERB_CANA_PLANTA,        A.SEMANA_ENCERRAMENTO   FROM BI4T.V_PRODUTIVIDADE_1CORTE A  WHERE A.PROP_CODIGO = 7 GROUP BY           A.PROP_CODIGO,           A.DS_NOME_PROPRIEDADE,           A.NRO_CORTE,           A.IDADE,           A.RENDIMENTO_PLAN,           A.TIPO_PLANTIO,           A.EMPRESA_PLANTIO,           A.TIPO_ADUBACAO,           A.TRAT_TOLETES,           A.SEMANA_ENCERRAMENTO ) A"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceDCortes" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM, A.*   FROM (SELECT TRUNC(A.PROP_CODIGO) PROP_CODIGO,        A.DS_NOME_PROPRIEDADE,        TRUNC(A.NRO_CORTE) NRO_CORTE,        ROUND(SUM(A.QT_AREA_COLHIDA),2) QT_AREA_COLHIDA,        ROUND(SUM(A.IDADE * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE),2) IDADE,        ROUND(SUM(A.QT_TON_ENTREGUE),2) QT_TON_ENTREGUE,        ROUND(DECODE(NVL(SUM(A.QT_TON_ENTREGUE),0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE))),0) RENDIMENTO_PLAN,        ROUND(DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA)))) RENDIMENTO_REAL,        ROUND(((DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA))) /          DECODE(NVL(SUM(A.QT_TON_ENTREGUE),0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE)))) -1) * 100) DESVIO,        MIN(A.DT_COLHEITA_ANTERIOR) DT_COLHEITA_ANTERIOR,        A.TIPO_ADUBACAO,        MIN(A.DT_ADUBACAO) DT_ADUBACAO,        TRUNC(MIN(A.DT_ADUBACAO) - MIN(A.DT_COLHEITA_ANTERIOR)) DIF_DIAS_ADUB,        A.TIPO_HERBICIDA,        MIN(A.DT_HERBICIDA) DT_HERBICIDA,        TRUNC(MIN(A.DT_HERBICIDA) - MIN(A.DT_COLHEITA_ANTERIOR)) DIF_DIAS_HERB,        A.FERTIRRIGACAO,        MIN(A.DT_FERTIRRIGACAO) DT_FERTIRRIGACAO,        A.SEMANA_ENCERRAMENTO   FROM BI4T.V_PRODUTIVIDADE_DCORTE A WHERE A.PROP_CODIGO = 6 GROUP BY A.PROP_CODIGO,           A.DS_NOME_PROPRIEDADE,           A.NRO_CORTE,                             A.TIPO_ADUBACAO,           A.TIPO_HERBICIDA,           A.FERTIRRIGACAO,                    A.SEMANA_ENCERRAMENTO) A"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceProdutividade" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM, A.*   FROM (SELECT AX.PROPRIEDADE,                AX.DSC_PROPRIEDADE,                AX.CORTE,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-6, AX.TON_HA, 0))) TON_HA_6,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-6, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_6,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-5, AX.TON_HA, 0))) TON_HA_5,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-5, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_5,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-4, AX.TON_HA, 0))) TON_HA_4,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-4, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_4,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-3, AX.TON_HA, 0))) TON_HA_3,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-3, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_3,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-2, AX.TON_HA, 0))) TON_HA_2,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-2, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_2,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-1, AX.TON_HA, 0))) TON_HA_1,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-1, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_1,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)  , AX.TON_HA, 0))) TON_HA,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)  , DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO           FROM (SELECT AB.SAFRA,                        AB.ID_NEGOCIOS_PROP,                        AB.PROPRIEDADE,                        AB.DSC_PROPRIEDADE,                        AB.CORTE,                        DECODE(SUM(AB.TON_COLHIDA), 0, 0, (SUM(AB.IDADE * AB.TON_COLHIDA) / SUM(AB.TON_COLHIDA))) IDADE,                        DECODE(NVL(SUM(AB.AREA_COLHIDA),0), 0, 0, (NVL(SUM(AB.TON_COLHIDA),0) / NVL(SUM(AB.AREA_COLHIDA),0))) TON_HA                   FROM (SELECT A.SAFRA,                                A.ID_NEGOCIOS_PROP,                                A.PROPRIEDADE,                                A.DSC_PROPRIEDADE,                                A.CORTE,                                NVL((A.DT_COLH_ATUAL - A.DT_COLH_ANTERIOR) / 30, 0) IDADE,                                NVL(SUM(A.AREA_COLHIDA),0) AREA_COLHIDA,                                NVL(SUM(A.TON_COLHIDA),0) TON_COLHIDA                           FROM (SELECT TALH.TALH_ID,                                        TALH.ID_NEGOCIOS_PROP,                                        TALH.TALH_CODIGO_PROP PROPRIEDADE,                                        PROP.PROP_DESCRICAO DSC_PROPRIEDADE,                                        TALH.TALH_NCORTE CORTE,                                        LIBE.LIBE_TIPO_CORTE TIPOCORTE,                                        CERC.SAFRA,                                        TALH.TALH_DATA_COLHEITA_ANT DT_COLH_ANTERIOR,                                        MIN(TRUNC(CERC.CERC_DATAENTRADAB)) DT_COLH_ATUAL,                                        NVL((LIBE.LIBE_TOTAL), 0) AREA_COLHIDA,                                        NVL(SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA), 0) / 1000 TON_COLHIDA                                   FROM SISAGRI.TALHAO           TALH,                                        SISAGRI.TALHAO_LIBERACAO LIBE,                                        SISAGRI.CERTIFICADO_CANA CERC,                                        SISAGRI.PROPRIEDADE_AGRICOLA PROP                                                WHERE TALH.TALH_ID = LIBE.LIBE_ID_TALH                                    AND LIBE.LIBE_ID_TALH = CERC.CERC_ID_TALH                                                AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE  IS NULL)                                                  AND TALH.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS                                    AND TALH.TALH_CODIGO_PROP = PROP.PROP_CODIGO                                    AND CERC.CERC_FLAG_ENTRADA IS NULL                                    AND TALH.ID_NEGOCIOS_PROP = 1                                    AND LIBE.LIBE_INDICADOR = '1'                                              AND TALH.TALH_SAFRA BETWEEN (SISAGRI.F_SAFRA_ATUAL(TALH.ID_NEGOCIOS_PROP) - 6) AND SISAGRI.F_SAFRA_ATUAL(TALH.ID_NEGOCIOS_PROP)                                    AND TALH.TALH_CODIGO_PROP = 1234                                  GROUP BY TALH.TALH_ID,                                           TALH.ID_NEGOCIOS_PROP,                                           TALH.TALH_CODIGO_PROP,                                           PROP.PROP_DESCRICAO,                                           TALH.TALH_NCORTE,                                           LIBE.LIBE_TIPO_CORTE,                                           CERC.SAFRA,                                           NVL((LIBE.LIBE_TOTAL), 0),                                           TALH.TALH_DATA_COLHEITA_ANT) A                          GROUP BY A.SAFRA,                                   A.ID_NEGOCIOS_PROP,                                   A.PROPRIEDADE,                                   A.DSC_PROPRIEDADE,                                   A.CORTE,                                   NVL((A.DT_COLH_ATUAL - A.DT_COLH_ANTERIOR) / 30, 0)                                         ) AB                            GROUP BY AB.SAFRA,                           AB.ID_NEGOCIOS_PROP,                           AB.PROPRIEDADE,                           AB.DSC_PROPRIEDADE,                           AB.CORTE                ) AX          GROUP BY AX.PROPRIEDADE,                   AX.DSC_PROPRIEDADE,                   AX.CORTE        ) A"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceIndicesTecnicos" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM, BB.*   FROM (SELECT AA.DIA,                ROUND(SUM(AA.POLPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) POL,                ROUND(SUM(AA.FIBRAPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) FIBRA,                ROUND(SUM(AA.ARPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) AR,                 ROUND(SUM(AA.ATRPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) ATR,                ROUND(SUM(AA.UMIDADEPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) UMIDADE,                ROUND(SUM(AA.PUREZAPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) PUREZA,                ROUND(((SUM(AA.POLPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2)) / 0.95) + (SUM(AA.ARPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2)),2)  ART_CALCULADO           FROM (SELECT TALH.TALH_CODIGO_PROP PROPRIEDADE,                        PROP.PROP_DESCRICAO DESCRICAOPROPRIEDADE,                        TRUNC(CERC.CERC_DATA_REF) DIA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PCC * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) POLPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_FIBRA * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) FIBRAPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PUREZA * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) PUREZAPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_ATR * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) ATRPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_AR * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) ARPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_UMIDADE * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) UMIDADEPRENSA,                        SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA) / 1000 CANAENTREGUE1,                        CASE WHEN ((SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) / 1000) IS NULL) THEN NULL ELSE (SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA) / 1000) END CANAENTREGUE2                   FROM SISAGRI.CERTIFICADO_CANA     CERC,                        SISAGRI.TALHAO_LIBERACAO     LIBE,                        SISAGRI.TALHAO               TALH,                        SISAGRI.PROPRIEDADE_AGRICOLA PROP                  WHERE CERC.CERC_ID_TALH = TALH.TALH_ID                            AND CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH                                AND (CERC.CERC_CODIGO_TIPT = LIBE.LIBE_TIPO_CORTE OR LIBE.LIBE_TIPO_CORTE IS NULL)                                  AND TALH.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS                    AND TALH.TALH_CODIGO_PROP = PROP.PROP_CODIGO                    AND CERC.CERC_FLAG_ENTRADA IS NULL                              AND CERC.ID_NEGOCIOS = 1                    AND CERC.SAFRA >= (SELECT SISAGRI.F_SAFRA_ATUAL(CERC.ID_NEGOCIOS)-1 FROM DUAL)                    AND CERC.CERC_DATA_REF <= (SELECT TRUNC(SYSDATE) + 0.99999 FROM DUAL)                    AND TRUNC(CERC.CERC_DATA_REF)IN ('31/12/2014','31/12/2015','26/04/2014','26/04/2015')                    AND PROP.PROP_CODIGO = 56                 GROUP BY TALH.TALH_CODIGO_PROP,                          PROP.PROP_DESCRICAO,                          TRUNC(CERC.CERC_DATA_REF)                ) AA          GROUP BY AA.DIA          UNION ALL         SELECT AA.SAFRA,                ROUND(SUM(AA.POLPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) POL,                ROUND(SUM(AA.FIBRAPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) FIBRA,                ROUND(SUM(AA.ARPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) AR,                 ROUND(SUM(AA.ATRPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) ATR,                ROUND(SUM(AA.UMIDADEPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) UMIDADE,                ROUND(SUM(AA.PUREZAPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2),2) PUREZA,                ROUND(((SUM(AA.POLPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2)) / 0.95) + (SUM(AA.ARPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2)),2)  ART_CALCULADO           FROM (SELECT TALH.TALH_CODIGO_PROP PROPRIEDADE,                        PROP.PROP_DESCRICAO DESCRICAOPROPRIEDADE,                        TO_DATE('31/12/'||CERC.SAFRA,'DD/MM/YYYY') SAFRA,                        TRUNC(CERC.CERC_DATA_REF) DIA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PCC * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) POLPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_FIBRA * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) FIBRAPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PUREZA * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) PUREZAPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_ATR * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) ATRPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_AR * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) ARPRENSA,                        SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_UMIDADE * CERC.CERC_PESO_ANALISADO )) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO )) UMIDADEPRENSA,                        SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA) / 1000 CANAENTREGUE1,                        CASE WHEN ((SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) / 1000) IS NULL) THEN NULL ELSE (SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA) / 1000) END CANAENTREGUE2                   FROM SISAGRI.CERTIFICADO_CANA     CERC,                        SISAGRI.TALHAO_LIBERACAO     LIBE,                        SISAGRI.TALHAO               TALH,                        SISAGRI.PROPRIEDADE_AGRICOLA PROP                  WHERE CERC.CERC_ID_TALH = TALH.TALH_ID                            AND CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH                                AND (CERC.CERC_CODIGO_TIPT = LIBE.LIBE_TIPO_CORTE OR LIBE.LIBE_TIPO_CORTE IS NULL)                                  AND TALH.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS                    AND TALH.TALH_CODIGO_PROP = PROP.PROP_CODIGO                    AND CERC.CERC_FLAG_ENTRADA IS NULL                              AND CERC.ID_NEGOCIOS = 1                    AND CERC.SAFRA >= (SELECT SISAGRI.F_SAFRA_ATUAL(CERC.ID_NEGOCIOS)-1 FROM DUAL)                    AND CERC.CERC_DATA_REF <= (SELECT TRUNC(SYSDATE) + 0.99999 FROM DUAL)                    AND ((CERC.CERC_DATA_REF BETWEEN '01/01/2015' AND '26/04/2015') OR (CERC.CERC_DATA_REF BETWEEN '01/01/2014' AND '26/04/2014'))                    AND PROP.PROP_CODIGO = 56                 GROUP BY TALH.TALH_CODIGO_PROP,                          PROP.PROP_DESCRICAO,                          CERC.SAFRA,                          TRUNC(CERC.CERC_DATA_REF)                ) AA          GROUP BY AA.SAFRA        ) BB"></asp:SqlDataSource>
