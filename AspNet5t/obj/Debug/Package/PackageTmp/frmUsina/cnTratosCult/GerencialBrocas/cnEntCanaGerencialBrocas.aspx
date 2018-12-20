<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaGerencialBrocas.aspx.vb" Inherits="AspNet5t.cnEntCanaGerencialBrocas" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style type="text/css">
        .alignright {
            text-align: right;
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
            gridmain.SetHeight(height - 76);
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <span>Safra:</span>
    <asp:DropDownList ID="ASPxComboSafra" runat="server" AutoPostBack="True"></asp:DropDownList>

    <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="SqlDataSourceGerencialBrocas" AutoGenerateColumns="False" Theme="Office2010Silver" KeyFieldName="ROWNUM" ClientInstanceName="gridmain" Width="100%">
        <GroupSummary>
            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="INDICE_SF_ANT" ValueDisplayFormat="{0:#,#0.00}" ShowInGroupFooterColumn="INDICE_SF_ANT" DisplayFormat="{0:#,#0.00}"></dx:ASPxSummaryItem>
            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="AREA_LEVANT_1" ValueDisplayFormat="{0:#,#0.00}" ShowInGroupFooterColumn="AREA_LEVANT_1" DisplayFormat="{0:#,#0.00}"></dx:ASPxSummaryItem>
            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="AREA_LEVANT_2" ValueDisplayFormat="{0:#,#0.00}" ShowInGroupFooterColumn="AREA_LEVANT_2" DisplayFormat="{0:#,#0.00}"></dx:ASPxSummaryItem>
            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="AREA_LEVANT_3" ValueDisplayFormat="{0:#,#0.00}" ShowInGroupFooterColumn="AREA_LEVANT_3" DisplayFormat="{0:#,#0.00}"></dx:ASPxSummaryItem>
            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="AREA_LEVANT_4" ValueDisplayFormat="{0:#,#0.00}" ShowInGroupFooterColumn="AREA_LEVANT_4" DisplayFormat="{0:#,#0.00}"></dx:ASPxSummaryItem>
            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="NRO_INDIV_HA_1" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="NRO_INDIV_HA_1" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="NRO_INDIV_HA_2" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="NRO_INDIV_HA_2" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="NRO_INDIV_HA_3" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="NRO_INDIV_HA_3" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
            <dx:ASPxSummaryItem SummaryType="Sum" FieldName="NRO_INDIV_HA_4" ValueDisplayFormat="{0:#,#0}" ShowInGroupFooterColumn="NRO_INDIV_HA_4" DisplayFormat="{0:#,#0}"></dx:ASPxSummaryItem>
        </GroupSummary>
        <Columns>
            <dx:GridViewDataTextColumn FieldName="TALH_SAFRA" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TALH_CODIGO_PROP" VisibleIndex="1" GroupIndex="0" Visible="True" Caption="Cód. Prop." Width="50px">
                <GroupRowTemplate>
                    Propriedade: 
                    <%--<dx:ASPxLabel runat="server" Text='<%# Eval("TALH_CODIGO_PROP") %>'></dx:ASPxLabel>--%>
                    <dx:ASPxLabel runat="server" Style="font-weight: bold" Text='<%# Eval("PROP_DESCRICAO") %>'></dx:ASPxLabel>
                </GroupRowTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PROP_DESCRICAO" VisibleIndex="2" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TALH_CODIGO" VisibleIndex="3" Caption="Talh&#227;o" Width="50px">
                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

                <GroupFooterTemplate>
                    Subtotal
                </GroupFooterTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TALH_ID" VisibleIndex="4" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TALH_NCORTE" VisibleIndex="5" Caption="Corte" Width="60px">
                <Settings AllowHeaderFilter="True" AllowAutoFilter="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TALH_CODIGO_VARI" VisibleIndex="6" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="VARI_DESCRICAO" VisibleIndex="7" Caption="Variedade">
                <Settings AllowHeaderFilter="True" AllowAutoFilter="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="INDICE_SF_ANT" VisibleIndex="8" Caption="&#205;ndice Infest Sf Ant" Width="60px">
                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
            </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_REFERENCIA" VisibleIndex="9" Visible="True" Caption="Situa&#231;&#227;o Ref&#234;rencia">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="True" />
                        <DataItemTemplate>
                            <div style="text-align: center;">
                                <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" Style="margin-top: 4px;" ImageUrl='<%# String.Format("~/Content/Images/stSit/sit{0}.jpg", Eval("SITREF"))%>' Visible='<%# Eval("SITREF") <> "0"%>'>
                                </dx:ASPxImage>
                            </div>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
            <%--<dx:GridViewDataTextColumn FieldName="CANA_ENT_SF_ANT" VisibleIndex="9" Visible="False"></dx:GridViewDataTextColumn>--%>
            <dx:GridViewBandColumn Caption="1º Levantamento" VisibleIndex="10">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="AREA_LEVANT_1" VisibleIndex="11" Caption="&#193;rea" Width="70px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_LEVANT_1" VisibleIndex="12" Caption="Data Levant." Width="85px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_BIOLOGICO_1_AUX" VisibleIndex="13" Caption="Data Ctrl. Biol&#243;gico" Width="95px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_QUIMICO_1_AUX" VisibleIndex="14" Caption="Data Ctrl. Qu&#237;mico" Width="95px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="IND_MENOR1CM_HA_1" VisibleIndex="15" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="IND_GDE_MEDIA_HA_1" VisibleIndex="16" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NRO_INDIV_HA_1" VisibleIndex="17" Caption="Nro. Ind / ha" Width="70px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn Caption=" " VisibleIndex="18" FieldName="SIT1" Width="70px" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="True" AllowSort="False" />
                        <PropertiesImage ImageUrlFormatString="~/Content/Images/stSit/sit{0}.jpg">
                        </PropertiesImage>
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_1" VisibleIndex="19" Caption="Situa&#231;&#227;o 1º Levantamento" Width="100px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="True" />
                        <DataItemTemplate>
                            <div style="text-align: center">
                                <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" Style="margin-top: 4px;" ImageUrl='<%# String.Format("~/Content/Images/stSit/sit{0}.jpg", Eval("SIT1"))%>' Visible='<%# Eval("SIT1") <> "0"%>'>
                                </dx:ASPxImage>
                            </div>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DIAS_1" VisibleIndex="20" Caption="Dias atraso" Width="55px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:GridViewBandColumn>
            <dx:GridViewBandColumn Caption="2º Levantamento" VisibleIndex="20">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="AREA_LEVANT_2" VisibleIndex="21" Caption="&#193;rea" Width="70px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_LEVANT_2" VisibleIndex="22" Caption="Data Levant." Width="85px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_BIOLOGICO_2_AUX" VisibleIndex="23" Caption="Data Ctrl. Biol&#243;gico" Width="95px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_QUIMICO_2_AUX" VisibleIndex="24" Caption="Data Ctrl. Qu&#237;mico" Width="95px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="IND_MENOR1CM_HA_2" VisibleIndex="25" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="IND_GDE_MEDIA_HA_2" VisibleIndex="26" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NRO_INDIV_HA_2" VisibleIndex="27" Caption="Nro. Ind / ha" Width="70px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn Caption=" " VisibleIndex="28" FieldName="SIT2" Width="70px" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="True" />
                        <PropertiesImage ImageUrlFormatString="~/Content/Images/stSit/sit{0}.jpg">
                        </PropertiesImage>
                        <Settings AllowSort="False" />
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_2" VisibleIndex="29" Caption="Situa&#231;&#227;o 2º Levantamento">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="True" />
                        <DataItemTemplate>
                            <div style="text-align: center">
                                <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" Style="margin-top: 4px;" ImageUrl='<%# String.Format("~/Content/Images/stSit/sit{0}.jpg", Eval("SIT2"))%>' Visible='<%# Eval("SIT2") <> "0"%>'>
                                </dx:ASPxImage>
                            </div>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DIAS_2" VisibleIndex="30" Caption="Dias atraso" Width="55px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:GridViewBandColumn>
            <dx:GridViewBandColumn Caption="3º Levantamento" VisibleIndex="30">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="AREA_LEVANT_3" VisibleIndex="31" Caption="&#193;rea" Width="70px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_LEVANT_3" VisibleIndex="32" Caption="Data Levant." Width="85px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_BIOLOGICO_3_AUX" VisibleIndex="33" Caption="Data Ctrl. Biol&#243;gico" Width="95px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_QUIMICO_3_AUX" VisibleIndex="34" Caption="Data Ctrl. Qu&#237;mico" Width="95px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="IND_MENOR1CM_HA_3" VisibleIndex="35" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="IND_GDE_MEDIA_HA_3" VisibleIndex="36" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NRO_INDIV_HA_3" VisibleIndex="37" Caption="Nro. Ind / ha" Width="70px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn Caption=" " VisibleIndex="38" FieldName="SIT3" Width="70px" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="True" />
                        <PropertiesImage ImageUrlFormatString="~/Content/Images/stSit/sit{0}.jpg">
                        </PropertiesImage>
                        <Settings AllowSort="False" />
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_3" VisibleIndex="39" Caption="Situa&#231;&#227;o 3º Levantamento">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="True" />
                        <DataItemTemplate>
                            <div style="text-align: center;">
                                <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" Style="margin-top: 4px;" ImageUrl='<%# String.Format("~/Content/Images/stSit/sit{0}.jpg", Eval("SIT3"))%>' Visible='<%# Eval("SIT3") <> "0"%>'>
                                </dx:ASPxImage>
                            </div>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DIAS_3" VisibleIndex="40" Caption="Dias atraso" Width="55px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_REFERENCIA" VisibleIndex="41" Visible="False">

                    </dx:GridViewDataDateColumn>
                </Columns>
            </dx:GridViewBandColumn>
            <dx:GridViewBandColumn Caption="4º Levantamento" VisibleIndex="50">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="AREA_LEVANT_4" VisibleIndex="51" Caption="&#193;rea" Width="70px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_LEVANT_4" VisibleIndex="52" Caption="Data Levant." Width="85px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_BIOLOGICO_4_AUX" VisibleIndex="53" Caption="Data Ctrl. Biol&#243;gico" Width="95px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_QUIMICO_4_AUX" VisibleIndex="54" Caption="Data Ctrl. Qu&#237;mico" Width="95px">


                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="IND_MENOR1CM_HA_4" VisibleIndex="55" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="IND_GDE_MEDIA_HA_4" VisibleIndex="56" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NRO_INDIV_HA_4" VisibleIndex="57" Caption="Nro. Ind / ha" Width="70px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn Caption=" " VisibleIndex="58" FieldName="SIT4" Width="70px" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="True" />
                        <PropertiesImage ImageUrlFormatString="~/Content/Images/stSit/sit{0}.jpg">
                        </PropertiesImage>
                        <Settings AllowSort="False" />
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_4" VisibleIndex="59" Caption="Situa&#231;&#227;o 4º Levantamento">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="True" />
                        <DataItemTemplate>
                            <div style="text-align: center;">
                                <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" Style="margin-top: 4px;" ImageUrl='<%# String.Format("~/Content/Images/stSit/sit{0}.jpg", Eval("SIT4"))%>' Visible='<%# Eval("SIT4") <> "0"%>'>
                                </dx:ASPxImage>
                            </div>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DIAS_4" VisibleIndex="60" Caption="Dias atraso" Width="55px">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="DATA_REFERENCIA" VisibleIndex="41" Visible="False">

                    </dx:GridViewDataDateColumn>
                </Columns>
            </dx:GridViewBandColumn>
        </Columns>
        <SettingsBehavior AllowDragDrop="False" AllowSelectByRowClick="False" AllowSelectSingleRowOnly="False" AllowFixedGroups="False" AutoExpandAllGroups="True"/>
        <SettingsPager Mode="EndlessPaging">
        </SettingsPager>
        <Settings ShowGroupPanel="false" HorizontalScrollBarMode="Visible" ShowVerticalScrollBar="true" VerticalScrollableHeight="450" UseFixedTableLayout="True" ShowTitlePanel="true" ShowFilterBar="Auto" ShowFilterRow="True" ShowGroupedColumns="True" ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" />
        <SettingsText Title="Controle Gerencial de Brocas" />
        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
        <Styles>
            <Header Wrap="True">
            </Header>
            <GroupFooter Font-Bold="True">
            </GroupFooter>
            <TitlePanel Font-Size="Medium">
            </TitlePanel>
            <Cell>
                <Paddings PaddingBottom="0px" PaddingTop="0px" />
            </Cell>
            <GroupRow Font-Bold="True">
            </GroupRow>
            <AlternatingRow Enabled="True">
            </AlternatingRow>
        </Styles>
        <Templates>
            <FooterRow>
                <div>
                    <span style="">Legenda:&nbsp;</span>
                    <img src="<%= Page.ResolveUrl("~/Content/Images/stSit/sit1.jpg")%>" style="vertical-align: -34%">
                    <span style="font-style: italic">Infestação Controlada&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <img src="<%= Page.ResolveUrl("~/Content/Images/stSit/sit2.jpg")%>" style="vertical-align: -34%">
                    <span style="font-style: italic">Ctrl. Químico Prazo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <img src="<%= Page.ResolveUrl("~/Content/Images/stSit/sit3.jpg")%>" style="vertical-align: -34%">
                    <span style="font-style: italic">Ctrl. Químico Atraso&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <img src="<%= Page.ResolveUrl("~/Content/Images/stSit/sit4.jpg")%>" style="vertical-align: -34%">
                    <span style="font-style: italic">Ctrl. Biológico Prazo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <img src="<%= Page.ResolveUrl("~/Content/Images/stSit/sit5.jpg")%>" style="vertical-align: -34%">
                    <span style="font-style: italic">Ctrl. Biológico Atraso&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                </div>
           </FooterRow>
        </Templates>

        <ClientSideEvents Init="OnInit" EndCallback="OnEndCallback" />
    </dx:ASPxGridView>
                 <dx:ASPxCheckBox ID="ASPxChkSemControle" runat="server" Text="Somente talhões s/ controle (Quimico/Biológico) sobre o mesmo" ClientInstanceName="chksemcontrole" CheckState="Unchecked">
                    <ClientSideEvents CheckedChanged="function(s, e) { gridmain.PerformCallback(); }"></ClientSideEvents>
                </dx:ASPxCheckBox>

    <dx:ASPxGridView ID="ASPxGridView2" runat="server" DataSourceID="SqlDataSourceGerencialBrocasResumo" AutoGenerateColumns="False" Theme="Office2010Silver" KeyFieldName="ROWPK" ClientInstanceName="gridresumo" Width="100%">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="TOTAL_LEVANT" VisibleIndex="0" Caption="Total Levant." Visible="False">
                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                <PropertiesTextEdit DisplayFormatString="{0:#,#0}" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewBandColumn Caption="1º Levantamento" VisibleIndex="1">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="TOTAL_LEVANT_1" VisibleIndex="2" Caption="Total Levant.">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_IC_1" VisibleIndex="3" Caption="I. C. &lt; 1500">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CBP_1" VisibleIndex="6" Caption="C. B. Prazo">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CBA_1" VisibleIndex="7" Caption="C. B. Atraso">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CQP_1" VisibleIndex="4" Caption="C. Q. Prazo">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CQA_1" VisibleIndex="5" Caption="C. Q. Atraso">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CTRL_QUIM_BIO_1" VisibleIndex="8" Caption="Ctrl. Q + B">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NAO_FEZ_INTERV_MENOR_1" VisibleIndex="9" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NAO_FEZ_INTERV_MAIOR_1" VisibleIndex="10" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:GridViewBandColumn>

            <dx:GridViewBandColumn Caption="2º Levantamento" VisibleIndex="11">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="TOTAL_LEVANT_2" VisibleIndex="12" Caption="Total Levant.">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_IC_2" VisibleIndex="13" Caption="I. C. &lt; 1500">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CBP_2" VisibleIndex="16" Caption="C. B. Prazo">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CBA_2" VisibleIndex="17" Caption="C. B. Atraso">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CQP_2" VisibleIndex="14" Caption="C. Q. Prazo">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CQA_2" VisibleIndex="15" Caption="C. Q. Atraso">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CTRL_QUIM_BIO_2" VisibleIndex="18" Caption="Ctrl. Q + B">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NAO_FEZ_INTERV_MENOR_2" VisibleIndex="19" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NAO_FEZ_INTERV_MAIOR_2" VisibleIndex="20" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:GridViewBandColumn>

            <dx:GridViewBandColumn Caption="3º Levantamento" VisibleIndex="21">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="TOTAL_LEVANT_3" VisibleIndex="22" Caption="Total Levant.">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_IC_3" VisibleIndex="23" Caption="I. C. &lt; 1500">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CBP_3" VisibleIndex="26" Caption="C. B. Prazo">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CBA_3" VisibleIndex="27" Caption="C. B. Atraso">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CQP_3" VisibleIndex="24" Caption="C. Q. Prazo">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CQA_3" VisibleIndex="25" Caption="C. Q. Atraso">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CTRL_QUIM_BIO_3" VisibleIndex="28" Caption="Ctrl. Q + B">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NAO_FEZ_INTERV_MENOR_3" VisibleIndex="29" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NAO_FEZ_INTERV_MAIOR_3" VisibleIndex="30" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:GridViewBandColumn>

            <dx:GridViewBandColumn Caption="4º Levantamento" VisibleIndex="31">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="TOTAL_LEVANT_4" VisibleIndex="32" Caption="Total Levant.">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_IC_4" VisibleIndex="33" Caption="I. C. &lt; 1500">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CBP_4" VisibleIndex="36" Caption="C. B. Prazo">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CBA_4" VisibleIndex="37" Caption="C. B. Atraso">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CQP_4" VisibleIndex="34" Caption="C. Q. Prazo">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SITUACAO_CQA_4" VisibleIndex="35" Caption="C. Q. Atraso">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CTRL_QUIM_BIO_4" VisibleIndex="38" Caption="Ctrl. Q + B">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NAO_FEZ_INTERV_MENOR_4" VisibleIndex="39" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NAO_FEZ_INTERV_MAIOR_4" VisibleIndex="40" Visible="False">
                        <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:GridViewBandColumn>

            <dx:GridViewDataTextColumn FieldName="AREA_CTRL_Q_SEM_LEVANT" VisibleIndex="31" Visible="False">
                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AREA_CTRL_B_SEM_LEVANT" VisibleIndex="32" Visible="False">
                <Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                <PropertiesTextEdit DisplayFormatString="{0:#,#0.00}" />
            </dx:GridViewDataTextColumn>
        </Columns>
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="TOTAL_LEVANT" SummaryType="Sum" Tag="TOTAL_LEVANT" />
            <dx:ASPxSummaryItem FieldName="TOTAL_LEVANT_1" SummaryType="Sum" Tag="TOTAL_LEVANT_1" />
            <dx:ASPxSummaryItem FieldName="TOTAL_LEVANT_2" SummaryType="Sum" Tag="TOTAL_LEVANT_2" />
            <dx:ASPxSummaryItem FieldName="TOTAL_LEVANT_3" SummaryType="Sum" Tag="TOTAL_LEVANT_3" />
            <dx:ASPxSummaryItem FieldName="TOTAL_LEVANT_4" SummaryType="Sum" Tag="TOTAL_LEVANT_4" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CQP_1" SummaryType="Sum" Tag="SITUACAO_CQP_1" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CQP_2" SummaryType="Sum" Tag="SITUACAO_CQP_2" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CQP_3" SummaryType="Sum" Tag="SITUACAO_CQP_3" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CQP_4" SummaryType="Sum" Tag="SITUACAO_CQP_4" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CQA_1" SummaryType="Sum" Tag="SITUACAO_CQA_1" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CQA_2" SummaryType="Sum" Tag="SITUACAO_CQA_2" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CQA_3" SummaryType="Sum" Tag="SITUACAO_CQA_3" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CQA_4" SummaryType="Sum" Tag="SITUACAO_CQA_4" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CBP_1" SummaryType="Sum" Tag="SITUACAO_CBP_1" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CBP_2" SummaryType="Sum" Tag="SITUACAO_CBP_2" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CBP_3" SummaryType="Sum" Tag="SITUACAO_CBP_3" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CBP_4" SummaryType="Sum" Tag="SITUACAO_CBP_4" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CBA_1" SummaryType="Sum" Tag="SITUACAO_CBA_1" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CBA_2" SummaryType="Sum" Tag="SITUACAO_CBA_2" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CBA_3" SummaryType="Sum" Tag="SITUACAO_CBA_3" />
            <dx:ASPxSummaryItem FieldName="SITUACAO_CBA_4" SummaryType="Sum" Tag="SITUACAO_CBA_4" />
            <dx:ASPxSummaryItem FieldName="NAO_FEZ_INTERV_MAIOR_1" SummaryType="Sum" Tag="NAO_FEZ_INTERV_MAIOR_1" />
            <dx:ASPxSummaryItem FieldName="NAO_FEZ_INTERV_MAIOR_2" SummaryType="Sum" Tag="NAO_FEZ_INTERV_MAIOR_2" />
            <dx:ASPxSummaryItem FieldName="NAO_FEZ_INTERV_MAIOR_3" SummaryType="Sum" Tag="NAO_FEZ_INTERV_MAIOR_3" />
            <dx:ASPxSummaryItem FieldName="NAO_FEZ_INTERV_MAIOR_4" SummaryType="Sum" Tag="NAO_FEZ_INTERV_MAIOR_4" />
            <dx:ASPxSummaryItem FieldName="NAO_FEZ_INTERV_MENOR_1" SummaryType="Sum" Tag="NAO_FEZ_INTERV_MENOR_1" />
            <dx:ASPxSummaryItem FieldName="NAO_FEZ_INTERV_MENOR_2" SummaryType="Sum" Tag="NAO_FEZ_INTERV_MENOR_2" />
            <dx:ASPxSummaryItem FieldName="NAO_FEZ_INTERV_MENOR_3" SummaryType="Sum" Tag="NAO_FEZ_INTERV_MENOR_3" />
            <dx:ASPxSummaryItem FieldName="NAO_FEZ_INTERV_MENOR_4" SummaryType="Sum" Tag="NAO_FEZ_INTERV_MENOR_4" />
            <dx:ASPxSummaryItem FieldName="AREA_CTRL_Q_SEM_LEVANT" SummaryType="Sum" Tag="AREA_CTRL_Q_SEM_LEVANT" />
            <dx:ASPxSummaryItem FieldName="AREA_CTRL_B_SEM_LEVANT" SummaryType="Sum" Tag="AREA_CTRL_B_SEM_LEVANT" />
        </TotalSummary>

        <SettingsBehavior AllowDragDrop="False" AllowSelectByRowClick="False" AllowSelectSingleRowOnly="False" AllowFixedGroups="False" AllowSort="False"/>
        <Settings ShowGroupPanel="false" HorizontalScrollBarMode="Visible" ShowVerticalScrollBar="false" VerticalScrollableHeight="35" UseFixedTableLayout="True" ShowTitlePanel="true" ShowFilterRow="False" ShowGroupedColumns="False" ShowFooter="True" ShowStatusBar="Hidden" />
        <SettingsText Title="Controle Gerencial de Brocas - Resumo por Áreas" />
        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
        <Styles>
            <Header Wrap="True">
            </Header>
            <GroupFooter Font-Bold="True">
            </GroupFooter>
            <TitlePanel Font-Size="Medium">
            </TitlePanel>
            <Cell>
                <Paddings PaddingBottom="0px" PaddingTop="0px" />
            </Cell>
            <GroupRow Font-Bold="True">
            </GroupRow>
        </Styles>
        <Templates>
            <FooterRow>
                <div style="height: 140px;">
                    <span style="font-weight: bold; text-decoration: underline;">Resumo:</span>

                    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="3" SettingsItemCaptions-HorizontalAlign="Right">
                        <Items>
                            <dx:LayoutItem Caption="Total Levant. (1&#186; + 2&#186; + 3&#186; + 4&#186;)" Width="425px" CssClass="alignright">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <%# String.Format("{0:#,#0.00}", GetTotalSummaryValue("TOTAL_LEVANT_1") + GetTotalSummaryValue("TOTAL_LEVANT_2") + GetTotalSummaryValue("TOTAL_LEVANT_3") + GetTotalSummaryValue("TOTAL_LEVANT_4"))%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <CaptionStyle Font-Bold="True"></CaptionStyle>
                            </dx:LayoutItem>
                            <dx:EmptyLayoutItem Width="175px"></dx:EmptyLayoutItem>
                            <dx:LayoutItem Caption="" Width="250px" ShowCaption="False">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxLabel runat="server" Text="Total s/ Levantamento" ID="ASPxFormLayout1_E1" Style="font-weight: bold;"></dx:ASPxLabel>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem CssClass="alignright" Caption="Total c/ Interven&#231;&#227;o Qu&#237;m. (1&#186; + 2&#186; + 3&#186; + 4&#186;)" Width="425px">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <%# String.Format("{0:#,#0.00}", GetTotalSummaryValue("SITUACAO_CQP_1") + GetTotalSummaryValue("SITUACAO_CQP_2") + GetTotalSummaryValue("SITUACAO_CQP_3") + GetTotalSummaryValue("SITUACAO_CQA_1") + GetTotalSummaryValue("SITUACAO_CQA_2") + GetTotalSummaryValue("SITUACAO_CQA_3") + GetTotalSummaryValue("SITUACAO_CQA_4"))%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                                <CaptionStyle Font-Bold="True"></CaptionStyle>
                            </dx:LayoutItem>
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                            <dx:LayoutItem Caption="c/ Controle Qu&#237;mico" CssClass="alignright" Width="250px">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <%# String.Format("{0:#,#0.00}", GetTotalSummaryValue("AREA_CTRL_Q_SEM_LEVANT"))%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="Total c/ Interven&#231;&#227;o Biol. (1&#186; + 2&#186; + 3&#186; + 4&#186;)" Width="425px" CssClass="alignright">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <%# String.Format("{0:#,#0.00}", GetTotalSummaryValue("SITUACAO_CBP_1") + GetTotalSummaryValue("SITUACAO_CBP_2") + GetTotalSummaryValue("SITUACAO_CBP_3") + GetTotalSummaryValue("SITUACAO_CBA_1") + GetTotalSummaryValue("SITUACAO_CBA_2") + GetTotalSummaryValue("SITUACAO_CBA_3") + GetTotalSummaryValue("SITUACAO_CBA_4"))%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <CaptionStyle Font-Bold="True"></CaptionStyle>
                            </dx:LayoutItem>
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                            <dx:LayoutItem Caption="c/ Controle Biol&#243;gico" CssClass="alignright" Width="250px">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <%# String.Format("{0:#,#0.00}", GetTotalSummaryValue("AREA_CTRL_B_SEM_LEVANT"))%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="Total c/ Interven&#231;&#227;o Qu&#237;m. + Biol. (1&#186; + 2&#186; + 3&#186; + 4&#186;)" Width="425px" CssClass="alignright">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <%# String.Format("{0:#,#0.00}", GetTotalSummaryValue("SITUACAO_CQP_1") + GetTotalSummaryValue("SITUACAO_CQP_2") + GetTotalSummaryValue("SITUACAO_CQP_3") + GetTotalSummaryValue("SITUACAO_CQA_1") + GetTotalSummaryValue("SITUACAO_CQA_2") + GetTotalSummaryValue("SITUACAO_CQA_3") + GetTotalSummaryValue("SITUACAO_CBP_1") + GetTotalSummaryValue("SITUACAO_CBP_2") + GetTotalSummaryValue("SITUACAO_CBP_3") + GetTotalSummaryValue("SITUACAO_CBA_1") + GetTotalSummaryValue("SITUACAO_CBA_2") + GetTotalSummaryValue("SITUACAO_CBA_3") + GetTotalSummaryValue("SITUACAO_CBA_4"))%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <CaptionStyle Font-Bold="True"></CaptionStyle>
                            </dx:LayoutItem>
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                            <dx:LayoutItem Caption="Total s/ Interven&#231;&#227;o c/ &#205;nd. &gt; 1500 (1&#186; + 2&#186; + 3&#186; + 4&#186;)" Width="425px" CssClass="alignright">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <%# String.Format("{0:#,#0.00}", GetTotalSummaryValue("NAO_FEZ_INTERV_MAIOR_1") + GetTotalSummaryValue("NAO_FEZ_INTERV_MAIOR_2") + GetTotalSummaryValue("NAO_FEZ_INTERV_MAIOR_3") + GetTotalSummaryValue("NAO_FEZ_INTERV_MAIOR_4"))%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <CaptionStyle Font-Bold="True"></CaptionStyle>
                            </dx:LayoutItem>
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                            <dx:LayoutItem Caption="Total s/ Interven&#231;&#227;o c/ &#205;nd. &lt; 1500 (1&#186; + 2&#186; + 3&#186; + 4&#186;)" Width="425px" CssClass="alignright">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <%# String.Format("{0:#,#0.00}", GetTotalSummaryValue("NAO_FEZ_INTERV_MENOR_1") + GetTotalSummaryValue("NAO_FEZ_INTERV_MENOR_2") + GetTotalSummaryValue("NAO_FEZ_INTERV_MENOR_3") + GetTotalSummaryValue("NAO_FEZ_INTERV_MENOR_4"))%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <CaptionStyle Font-Bold="True"></CaptionStyle>
                            </dx:LayoutItem>
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                            <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                        </Items>

                        <SettingsItems HorizontalAlign="Right"></SettingsItems>

                        <SettingsItemCaptions VerticalAlign="Middle"></SettingsItemCaptions>
                    </dx:ASPxFormLayout>
                </div>
            </FooterRow>
        </Templates>
    </dx:ASPxGridView>

    <asp:SqlDataSource ID="SqlDataSourceGerencialBrocas" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT ROWNUM, ID_NEGOCIOS, TALH_SAFRA, TALH_CODIGO_PROP, PROP_DESCRICAO, TALH_CODIGO, TALH_ID, TALH_NCORTE, TALH_CODIGO_VARI, VARI_DESCRICAO, INDICE_SF_ANT, CANA_ENT_SF_ANT, AREA_LEVANT_1, DATA_LEVANT_1, DATA_BIOLOGICO_1, DATA_QUIMICO_1, IND_MENOR1CM_HA_1, IND_GDE_MEDIA_HA_1, NRO_INDIV_HA_1, DECODE(SITUACAO_1, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT1, SITUACAO_1, DIAS_1, AREA_LEVANT_2, DATA_LEVANT_2, DATA_BIOLOGICO_2, DATA_QUIMICO_2, IND_MENOR1CM_HA_2, IND_GDE_MEDIA_HA_2, NRO_INDIV_HA_2, DECODE(SITUACAO_2, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT2, SITUACAO_2, DIAS_2, AREA_LEVANT_3, DATA_LEVANT_3, DATA_BIOLOGICO_3, DATA_QUIMICO_3, IND_MENOR1CM_HA_3, IND_GDE_MEDIA_HA_3, NRO_INDIV_HA_3, DECODE(SITUACAO_3, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT3, SITUACAO_3, DIAS_3, DATA_REFERENCIA, SITUACAO_REFERENCIA, DECODE(SITUACAO_REFERENCIA, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SITREF FROM BI4T.GERENCIAL_BROCA"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGerencialBrocasResumo" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="SELECT 1 ROWPK, NVL(SUM(AA.AREA_LEVANT_1), 0) TOTAL_LEVANT, NVL(SUM(CASE WHEN (AA.DATA_LEVANT_1 IS NULL) THEN NULL ELSE AA.AREA_LEVANT_1 END), 0) AS TOTAL_LEVANT_1, NVL(SUM(CASE WHEN (AA.NRO_INDIV_HA_1 < 1500) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_IC_1, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_1 IS NULL) AND (AA.DATA_BIOLOGICO_1 IS NOT NULL) AND (AA.DATA_BIOLOGICO_1 <= (AA.DATA_LEVANT_1 + 5))) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_CBP_1, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_1 IS NULL) AND (AA.DATA_BIOLOGICO_1 IS NOT NULL) AND (AA.DATA_BIOLOGICO_1 > (AA.DATA_LEVANT_1 + 5))) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_CBA_1, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_1 IS NULL) AND (AA.DATA_QUIMICO_1 IS NOT NULL) AND (AA.DATA_QUIMICO_1 <= (AA.DATA_LEVANT_1 + 3))) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_CQP_1, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_1 IS NULL) AND (AA.DATA_QUIMICO_1 IS NOT NULL) AND (AA.DATA_QUIMICO_1 > (AA.DATA_LEVANT_1 + 3))) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_CQA_1, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_1 IS NOT NULL) AND (AA.DATA_QUIMICO_1 IS NOT NULL)) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS CTRL_QUIM_BIO_1, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_1 IS NOT NULL) AND (AA.NRO_INDIV_HA_1 < 1500) AND (AA.DATA_QUIMICO_1 IS NULL) AND (AA.DATA_BIOLOGICO_1 IS NULL)) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MENOR_1, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_1 IS NOT NULL) AND (AA.NRO_INDIV_HA_1 >= 1500) AND (AA.DATA_QUIMICO_1 IS NULL) AND (AA.DATA_BIOLOGICO_1 IS NULL)) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MAIOR_1, NVL(SUM(CASE WHEN (AA.DATA_LEVANT_2 IS NULL) THEN NULL ELSE AA.AREA_LEVANT_2 END), 0) AS TOTAL_LEVANT_2, NVL(SUM(CASE WHEN (AA.NRO_INDIV_HA_2 < 1500) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_IC_2, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_2 IS NULL) AND (AA.DATA_BIOLOGICO_2 IS NOT NULL) AND (AA.DATA_BIOLOGICO_2 <= (AA.DATA_LEVANT_2 + 5))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CBP_2, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_2 IS NULL) AND (AA.DATA_BIOLOGICO_2 IS NOT NULL) AND (AA.DATA_BIOLOGICO_2 > (AA.DATA_LEVANT_2 + 5))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CBA_2, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_2 IS NULL) AND (AA.DATA_QUIMICO_2 IS NOT NULL) AND (AA.DATA_QUIMICO_2 <= (AA.DATA_LEVANT_2 + 3))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CQP_2, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_2 IS NULL) AND (AA.DATA_QUIMICO_2 IS NOT NULL) AND (AA.DATA_QUIMICO_2 > (AA.DATA_LEVANT_2 + 3))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CQA_2, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_2 IS NOT NULL) AND (AA.DATA_QUIMICO_2 IS NOT NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS CTRL_QUIM_BIO_2, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_2 IS NOT NULL) AND (AA.NRO_INDIV_HA_2 < 1500) AND (AA.DATA_QUIMICO_2 IS NULL) AND (AA.DATA_BIOLOGICO_2 IS NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MENOR_2, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_2 IS NOT NULL) AND (AA.NRO_INDIV_HA_2 >= 1500) AND (AA.DATA_QUIMICO_2 IS NULL) AND (AA.DATA_BIOLOGICO_2 IS NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MAIOR_2, NVL(SUM(CASE WHEN (AA.DATA_LEVANT_3 IS NULL) THEN NULL ELSE AA.AREA_LEVANT_2 END), 0) AS TOTAL_LEVANT_3, NVL(SUM(CASE WHEN (AA.NRO_INDIV_HA_3 < 1500) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_IC_3, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_3 IS NULL) AND (AA.DATA_BIOLOGICO_3 IS NOT NULL) AND (AA.DATA_BIOLOGICO_3 <= (AA.DATA_LEVANT_3 + 5))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CBP_3, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_3 IS NULL) AND (AA.DATA_BIOLOGICO_3 IS NOT NULL) AND (AA.DATA_BIOLOGICO_3 > (AA.DATA_LEVANT_3 + 5))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CBA_3, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_3 IS NULL) AND (AA.DATA_QUIMICO_3 IS NOT NULL) AND (AA.DATA_QUIMICO_3 <= (AA.DATA_LEVANT_3 + 3))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CQP_3, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_3 IS NULL) AND (AA.DATA_QUIMICO_3 IS NOT NULL) AND (AA.DATA_QUIMICO_3 > (AA.DATA_LEVANT_3 + 3))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CQA_3, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_3 IS NOT NULL) AND (AA.DATA_QUIMICO_3 IS NOT NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS CTRL_QUIM_BIO_3, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_3 IS NOT NULL) AND (AA.NRO_INDIV_HA_3 < 1500) AND (AA.DATA_QUIMICO_3 IS NULL) AND (AA.DATA_BIOLOGICO_3 IS NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MENOR_3, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_3 IS NOT NULL) AND (AA.NRO_INDIV_HA_3 >= 1500) AND (AA.DATA_QUIMICO_3 IS NULL) AND (AA.DATA_BIOLOGICO_3 IS NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MAIOR_3, (SELECT SUM(NVL(AB.AREA_CTRL_QUIMICO,0)) FROM BI4T.GERENCIAL_BROCA_SEM_LEVANT AB WHERE AB.ID_NEGOCIOS = AA.ID_NEGOCIOS AND AB.DT_ATUALIZACAO = AA.DT_ATUALIZACAO) AREA_CTRL_Q_SEM_LEVANT, (SELECT SUM(NVL(AB.AREA_CTRL_BIOLOGICO,0)) FROM BI4T.GERENCIAL_BROCA_SEM_LEVANT AB WHERE AB.ID_NEGOCIOS = AA.ID_NEGOCIOS AND AB.DT_ATUALIZACAO = AA.DT_ATUALIZACAO) AREA_CTRL_B_SEM_LEVANT FROM BI4T.GERENCIAL_BROCA AA GROUP BY AA.ID_NEGOCIOS, AA.DT_ATUALIZACAO"></asp:SqlDataSource>
</asp:Content>
