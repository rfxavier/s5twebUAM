<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="Cadastro.aspx.vb" Inherits="AspNet5t.Cadastro" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <style type="text/css">
        .container {
            width: 400px;
        }
        .parentContainer {
            width: 100%;
        }
        .tabbedGroupPageControlCell {
            padding-left: 0px;
            padding-right: 0px;
            padding-bottom: 0px!important;
        }
        .tabbedGroupPageControlCell .dxflPCSys {
            padding-bottom: 0px;
        }
        .radioButtonList .dxe {
            padding:0px!important; 
        }

         /*hide the ASPxComboBox column's headers:*/
          .dxeHLC, .dxeHC, .dxeHFC
        {
            display: none;
        }

          .dxbButton
          {
              background-image: none!important;
          }

          .dxflGroupBox
          {
              padding: 0px 0px 0px;
              margin: 0px 0px;
          }

          .dxtcLite > .dxtc-content
          {
              padding: 0px;
          }

          .dxeRadioButtonList td.dxe, .dxeCheckBoxList td.dxe
          {
              padding: 0px 0px 1px 5px;
          }
          .tabbedGroupPageControlCell 
          {
              vertical-align: top;
          }
          .dxflGroupBox > .dxflGroup tr:first-child > .dxflGroupCell > .dxflItem 
          {
              padding-top: 0px;
          }
    </style>

    <script type="text/javascript">
        var lastValidationResult = false;
        function OnTipoPFPJChanged(s, e) {
            var selectedIndex = s.GetSelectedIndex();
            tabbedGroupPageControl.SetActiveTabIndex(selectedIndex);
        }
        function OnTabbedGroupPageControlInit(s, e) {
            s.SetActiveTabIndex(rbPFPJ.GetSelectedIndex());
        }
        function OnEmailValidation(s, e) {
            var valid = mail.GetText() == retypeEmail.GetText();
            if (s === retypeEmail && mail.GetIsValid())
                e.isValid = valid;
        }
        function OnSubmitButtonClick() {
            if (lastValidationResult)
                alert('Thank you!');
        }
        function OnValidationComplete(s, e) {
            lastValidationResult = e.isValid;
        }
        function SetActiveTab(tabIndexIncrement) {
            var activeTabIndex = PageControl.GetActiveTab().index;
            activeTabIndex += tabIndexIncrement;
            PageControl.SetActiveTab(PageControl.GetTab(activeTabIndex));
        }
        // Submit Button
        function OnSumbitButtonClick(s, e) {
            var tabPageCount = PageControl.GetTabCount();
            for (var i = 1; i < tabPageCount; i++) {
                PageControl.SetActiveTab(PageControl.GetTab(i));
                var editorsContainerId = "ASPxFormLayout" + i;
                //ASPxClientEdit.ClearEditorsInContainerById(editorsContainerId);
                if (!ASPxClientEdit.ValidateEditorsInContainerById(editorsContainerId)) {
                    e.processOnServer = false;
                    break;
                }
            }
        }
        function validaCPF(s, e) {
            var numeros, digitos, soma, i, resultado, digitos_iguais, exp;
            digitos_iguais = 1;
            exp = /\.|\-/g;
            cpf = e.value;
            cpf = cpf.replace(exp, "");
            cpf = cpf.replace(/ /g, "");
            if (cpf === "") {
                e.isValid = false;
                return;
            }
            if (cpf.length < 11) {
                e.isValid = false;
                return;
            }
            for (i = 0; i < cpf.length - 1; i++)
                if (cpf.charAt(i) != cpf.charAt(i + 1)) {
                    digitos_iguais = 0;
                    break;
                }
            if (!digitos_iguais) {
                numeros = cpf.substring(0, 9);
                digitos = cpf.substring(9);
                soma = 0;
                for (i = 10; i > 1; i--)
                    soma += numeros.charAt(10 - i) * i;
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(0)) {
                    e.isValid = false;
                    return;
                }
                numeros = cpf.substring(0, 10);
                soma = 0;
                for (i = 11; i > 1; i--)
                    soma += numeros.charAt(11 - i) * i;
                resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                if (resultado != digitos.charAt(1)) {
                    e.isValid = false;
                    return;
                }
                e.isValid = true;
            }
            else
                e.isValid = false;
        }
        function validaCNPJ(s, e) {
            exp = /[^\d]+/g;
            cnpj = e.value;
            cnpj = cnpj.replace(exp, "");
            cnpj = cnpj.replace(/ /g, "");
            if (cnpj === "") {
                e.isValid = false;
                return;
            }

            if (cnpj.length != 14) {
                e.isValid = false;
                return;
            }

            // Elimina CNPJs invalidos conhecidos
            if (cnpj == "00000000000000" ||
                cnpj == "11111111111111" ||
                cnpj == "22222222222222" ||
                cnpj == "33333333333333" ||
                cnpj == "44444444444444" ||
                cnpj == "55555555555555" ||
                cnpj == "66666666666666" ||
                cnpj == "77777777777777" ||
                cnpj == "88888888888888" ||
                cnpj == "99999999999999") {

                e.isValid = false;
                return;
            }

            // Valida DVs
            tamanho = cnpj.length - 2
            numeros = cnpj.substring(0, tamanho);
            digitos = cnpj.substring(tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(0)) {
                e.isValid = false;
                return;
            }

            tamanho = tamanho + 1;
            numeros = cnpj.substring(0, tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(1)) {
                e.isValid = false;
                return;
            }

            e.isValid = true;
            return;
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div class="buttonsToolbar">
        <dx:ASPxButton ID="btnExcluir" runat="server" Text="Excluir" ImagePosition="Top" BackColor="White">
            <Image IconID="edit_delete_32x32">
            </Image>
            <Border BorderStyle="None" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="btnSalvar" runat="server" Text="Salvar" ImagePosition="Top" BackColor="White" UseSubmitBehavior="False">
            <ClientSideEvents Click="OnSumbitButtonClick" />
            <Image IconID="save_saveto_32x32">
            </Image>
            <Border BorderStyle="None" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="btnDesistir" runat="server" Text="Desistir" ImagePosition="Top" BackColor="White">
            <Image IconID="actions_cancel_32x32">
            </Image>
            <Border BorderStyle="None" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="btnSair" runat="server" Text="Sair" ImagePosition="Top" Theme="Default" BackColor="White">
            <Image IconID="navigation_backward_32x32">
            </Image>
            <Border BorderStyle="None" />
        </dx:ASPxButton>
    </div>

    <div>
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" Width="100%" ClientInstanceName="PageControl">
            <TabPages>
                <dx:TabPage Name="tabPesquisa" Text="Pesquisa">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout0" runat="server" ColCount="3" Width="100%">
                                <Items>
                                    <dx:LayoutItem Caption="Tipo" Width="160px">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="cmbPesqTipo" runat="server" Width="100%" SelectedIndex="0">
                                                    <Items>
                                                        <dx:ListEditItem Selected="True" Text="Todos" Value="" />
                                                        <dx:ListEditItem Text="Usuários" Value="USU" />
                                                    </Items>
                                                </dx:ASPxComboBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Código" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox runat="server" Width="120px" ID="txtPesqCodigo"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem RowSpan="2" Caption="" ShowCaption="False" HorizontalAlign="Right" Width="150px">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxButton runat="server" Text="Pesquisar" ID="btnPesquisar" ImagePosition="Top" BackColor="White">
                                                    <Image IconID="find_findcustomers_32x32">
                                                    </Image>
                                                    <Border BorderStyle="None" />
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btnImprimir" runat="server" BackColor="White" ImagePosition="Top" Text="Imprimir">
                                                    <Image IconID="print_print_32x32">
                                                    </Image>
                                                    <Border BorderStyle="None" />
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="PF/PJ" Width="160px">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="cmbPesqPFPJ" runat="server" SelectedIndex="0" Width="100%">
                                                    <Items>
                                                        <dx:ListEditItem Selected="True" Text="Todos" Value="" />
                                                        <dx:ListEditItem Text="Pessoa Física" Value="F" />
                                                        <dx:ListEditItem Text="Pessoa Jurídica" Value="J" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Nome" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtPesqNome" runat="server" Width="100%">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem ColSpan="3" Caption="" ShowCaption="False">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxGridView ID="gridCadastro" runat="server" AutoGenerateColumns="False" KeyFieldName="pId" Width="100%" EnableCallBacks="False">
                                                    <Columns>
                                                        <dx:GridViewDataHyperLinkColumn FieldName="pId" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="0">
                                                        </dx:GridViewDataHyperLinkColumn>
                                                        <dx:GridViewDataTextColumn Caption="Código" FieldName="pCodigo" ShowInCustomizationForm="True" VisibleIndex="1" Width="80px">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Nome" FieldName="pNome" ShowInCustomizationForm="True" VisibleIndex="2">
                                                            <CellStyle Wrap="False">
                                                            </CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="PF/PJ" FieldName="pPFPJ" ShowInCustomizationForm="True" VisibleIndex="3" Width="20px">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="CPF/CNPJ" FieldName="pCpfCnpj" ShowInCustomizationForm="True" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Cidade" FieldName="pNomeCidade" ShowInCustomizationForm="True" VisibleIndex="5">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="UF" FieldName="pUFCidade" ShowInCustomizationForm="True" VisibleIndex="6" Width="25px">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Tipo" FieldName="pCadastroTipoFlgTipo" ShowInCustomizationForm="True" VisibleIndex="7" Width="90px">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewCommandColumn ShowClearFilterButton="true" ShowApplyFilterButton="true" VisibleIndex="8" />
                                                    </Columns>
                                                    <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" FilterRowMode="OnClick" />
                                                    <SettingsPager EnableAdaptivity="True">
                                                    </SettingsPager>
                                                    <Settings ShowFilterBar="Auto" ShowFilterRow="True" />
                                                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" />
                                                    <SettingsSearchPanel ShowApplyButton="True" Visible="True" AllowTextInputTimer="False" ShowClearButton="True" />
                                                </dx:ASPxGridView>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                </Items>

                                <SettingsItemCaptions HorizontalAlign="Right" VerticalAlign="Middle"></SettingsItemCaptions>
                            </dx:ASPxFormLayout>

                            <asp:ObjectDataSource ID="dsCadastro" runat="server" DataObjectTypeName="S5T.Cadastro" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadByNomeFlgCadastroViewGeral" TypeName="S5T.CadastroCollection" UpdateMethod="Save">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="%" Name="parNome" Type="String" />
                                    <asp:Parameter Name="parFlgCadastro" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Name="tabDados1" Text="Dados">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="3" Width="100%">
                                <Items>
                                    <dx:LayoutItem Caption="Código">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxLabel ID="lbCodigo" runat="server" Text="">
                                                </dx:ASPxLabel>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionSettings VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Tipo">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxRadioButtonList ID="rbPFPJ" runat="server" RepeatDirection="Horizontal" SelectedIndex="0" Width="300px" ClientInstanceName="rbPFPJ">
                                                    <ClientSideEvents SelectedIndexChanged="OnTipoPFPJChanged"></ClientSideEvents>
                                                    <Items>
                                                        <dx:ListEditItem Selected="True" Text="Pessoa Física" Value="F" />
                                                        <dx:ListEditItem Text="Pessoa Jurídica" Value="J" />
                                                    </Items>
                                                    <ValidationSettings ValidationGroup="DadosForm">
                                                    </ValidationSettings>
                                                </dx:ASPxRadioButtonList>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" RowSpan="8" VerticalAlign="Top">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxGridView ID="gridCadastroTipo" runat="server" KeyFieldName="pId" AutoGenerateColumns="False" EnableCallBacks="False">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn Name="colTipoSelecionado" ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0">
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn FieldName="pId" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2" Name="colpId">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="pDescricao" ShowInCustomizationForm="True" VisibleIndex="4" Caption="Tipo Cadastro" Name="colpDescricao">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="pFlgCadastro" ShowInCustomizationForm="True" Visible="False" VisibleIndex="3" Name="colpFlgCadastro">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataCheckColumn FieldName="pFlgCadastroComp" UnboundType="Boolean" Visible="False" VisibleIndex="5" Name="colTipoSelecionadoComp"></dx:GridViewDataCheckColumn>
                                                    </Columns>
                                                    <SettingsBehavior ProcessSelectionChangedOnServer="True" />
                                                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                                </dx:ASPxGridView>
                                                <asp:ObjectDataSource ID="dsCadastroTipo" runat="server" DataObjectTypeName="S5T.CadastroTipo" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAll" TypeName="S5T.CadastroTipoCollection" UpdateMethod="Save"></asp:ObjectDataSource>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:TabbedLayoutGroup ColSpan="2" ClientInstanceName="tabbedGroupPageControl" Width="100%" ShowGroupDecoration="False">
                                        <ParentContainerStyle CssClass="tabbedGroupPageControlCell" />
                                        <ClientSideEvents Init="OnTabbedGroupPageControlInit" />
                                        <Items>
                                            <dx:LayoutGroup ColCount="2" Name="lgPF" Caption="lgPF" GroupBoxDecoration="None">
                                                <Items>
                                                    <dx:LayoutItem Caption="Nome" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtNome" runat="server" Width="100%">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="" SetFocusOnError="True" ValidationGroup="DadosForm">
                                                                        <RequiredField ErrorText="Nome obrigatório" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="CPF" Width="40%">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtCPF" runat="server" Width="120px">
                                                                    <ClientSideEvents Validation="validaCPF" />
                                                                    <MaskSettings ErrorText="Campo Inválido" Mask="999,999,999-99" />
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ValidationGroup="DadosForm" ErrorText="CPF inválido">
                                                                        <RequiredField ErrorText="CPF obrigatório" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Sexo">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxRadioButtonList ID="rbSexo" runat="server" RepeatDirection="Horizontal" SelectedIndex="0" Width="300px">
                                                                    <Items>
                                                                        <dx:ListEditItem Selected="True" Text="Masculino" Value="M" />
                                                                        <dx:ListEditItem Text="Feminino" Value="F" />
                                                                    </Items>
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxRadioButtonList>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Data Nasc.">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxDateEdit ID="txtDataNascimento" runat="server" DateOnError="Null" UseMaskBehavior="True" Width="140px">
                                                                    <CalendarProperties ClearButtonText="Limpar" ShowWeekNumbers="False">
                                                                    </CalendarProperties>
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="RG">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtRG" runat="server" Width="140px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="IE">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtIEPF" runat="server" Width="140px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Email">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtEmailPF" runat="server" Width="100%">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                        <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tel.Fixo">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtTelFixoPF" runat="server" Width="120px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tel.Celular">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtTelCelularPF" runat="server" Width="120px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tel.Alt">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtTelAltPF" runat="server" Width="120px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Fax">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtTelFaxPF" runat="server" Width="120px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>
                                            <dx:LayoutGroup ColCount="2" Name="lgPJ" Caption="lgPJ" GroupBoxDecoration="None">
                                                <Items>
                                                    <dx:LayoutItem Caption="Razão Social" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtRazaoSocial" runat="server" Width="100%">
                                                                    <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                        <RequiredField ErrorText="Razão social obrigatória" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings VerticalAlign="Middle" HorizontalAlign="Right" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Nome Fantasia" ColSpan="2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtNomeFantasia" runat="server" Width="100%">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="CNPJ">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtCNPJ" runat="server" Width="140px">
                                                                    <ClientSideEvents Validation="validaCNPJ" />
                                                                    <MaskSettings ErrorText="Campo Inválido" Mask="99,999,999/9999-99" />
                                                                    <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="ImageWithTooltip" ErrorText="CNPJ inválido" ValidationGroup="DadosForm">
                                                                        <RequiredField ErrorText="CNPJ obrigatório" IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings VerticalAlign="Middle" HorizontalAlign="Right" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="IE">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtIEPJ" runat="server" Width="140px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Email">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtEmailPJ" runat="server" Width="100%">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:EmptyLayoutItem>
                                                    </dx:EmptyLayoutItem>
                                                    <dx:LayoutItem Caption="Tel.Fixo">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtTelFixoPJ" runat="server" Width="120px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tel.Celular">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtTelCelularPJ" runat="server" Width="120px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Tel.Alt">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtTelAltPJ" runat="server" Width="120px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Fax">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtTelFaxPJ" runat="server" Width="120px">
                                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <CaptionSettings HorizontalAlign="Right" VerticalAlign="Middle" />
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>
                                        </Items>
                                    </dx:TabbedLayoutGroup>
                                </Items>
                            </dx:ASPxFormLayout>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Name="tabDados2" Text="Endereços">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="3" Width="100%">
                                <Items>
                                    <dx:LayoutGroup ColCount="3" ColSpan="3" Caption="Residencial" GroupBoxDecoration="HeadingLine">
                                        <Items>
                                            <dx:LayoutItem Caption="Logradouro" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtLogradouro" runat="server" Width="100%">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ValidationGroup="DadosForm">
                                                                <RequiredField ErrorText="Logradouro obrigatório" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="Número">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtNumero" runat="server" Width="140px">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ValidationGroup="DadosForm">
                                                                <RequiredField ErrorText="Número obrigatório" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="Complemento" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtComplemento" runat="server" Width="100%">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="DadosForm">
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:EmptyLayoutItem>
                                            </dx:EmptyLayoutItem>
                                            <dx:LayoutItem Caption="Bairro" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtBairro" runat="server" Width="100%">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ValidationGroup="DadosForm">
                                                                <RequiredField ErrorText="Bairro obrigatório" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:EmptyLayoutItem>
                                            </dx:EmptyLayoutItem>
                                            <dx:LayoutItem Caption="Cidade" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxComboBox ID="cmbCidade" runat="server" Width="100%" CallbackPageSize="10" EnableCallbackMode="True" IncrementalFilteringDelay="200" TextFormatString="{1} ({2})" ValueField="pId" ValueType="System.Int32" NullText="Digite o nome ou código">
                                                            <Columns>
                                                                <dx:ListBoxColumn Caption="Código" FieldName="pCodigoStr" Name="pCodigo" />
                                                                <dx:ListBoxColumn Caption="Cidade" FieldName="pNome" Name="pNome" />
                                                                <dx:ListBoxColumn Caption="UF" FieldName="Sigla" Name="Sigla" />
                                                            </Columns>
                                                            <ClearButton Visibility="True">
                                                            </ClearButton>
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="" SetFocusOnError="True" CausesValidation="True" ValidationGroup="DadosForm">
                                                                <RequiredField IsRequired="True" ErrorText="Cidade obrigatória" />
                                                            </ValidationSettings>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:EmptyLayoutItem>
                                            </dx:EmptyLayoutItem>
                                            <dx:LayoutItem Caption="CEP">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtCEP" runat="server" Width="90px">
                                                            <MaskSettings Mask="00000-000" ErrorText="CEP inválido" />
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ValidationGroup="DadosForm">
                                                                <RequiredField ErrorText="CEP obrigatório" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup Caption="Correspondência / Cobrança" ColCount="3" ColSpan="3" GroupBoxDecoration="HeadingLine">
                                        <Items>
                                            <dx:LayoutItem Caption="Logradouro" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtLogradouroAux" runat="server" Width="100%">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="Número">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtNumeroAux" runat="server" Width="140px">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="Complemento" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtComplementoAux" runat="server" Width="100%">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:EmptyLayoutItem>
                                            </dx:EmptyLayoutItem>
                                            <dx:LayoutItem Caption="Bairro" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtBairroAux" runat="server" Width="100%">
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:EmptyLayoutItem>
                                            </dx:EmptyLayoutItem>
                                            <dx:LayoutItem Caption="Cidade" ColSpan="2">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxComboBox ID="cmbCidadeAux" runat="server" Width="100%" CallbackPageSize="10" EnableCallbackMode="True" IncrementalFilteringDelay="200" TextFormatString="{1} ({2})" ValueField="pId" ValueType="System.Int32" NullText="Digite o nome ou código">
                                                            <Columns>
                                                                <dx:ListBoxColumn Caption="Código" FieldName="pCodigoStr" Name="pCodigoStr" />
                                                                <dx:ListBoxColumn Caption="Cidade" FieldName="pNome" Name="pNome" />
                                                                <dx:ListBoxColumn Caption="UF" FieldName="Sigla" Name="Sigla" />
                                                            </Columns>
                                                            <ClearButton Visibility="True">
                                                            </ClearButton>
                                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                                                            </ValidationSettings>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                            <dx:EmptyLayoutItem>
                                            </dx:EmptyLayoutItem>
                                            <dx:LayoutItem Caption="CEP">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                        <dx:ASPxTextBox ID="txtCEPAux" runat="server" Width="90px">
                                                            <ClientSideEvents Validation="function(s, e) { e.isValid = true }" />
                                                            <MaskSettings Mask="99999-999" />
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                                <CaptionSettings VerticalAlign="Middle" />
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                </Items>
                                <SettingsItemCaptions HorizontalAlign="Right" />
                            </dx:ASPxFormLayout>

                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Name="tabUsuario" Text="Usu&#225;rio" ClientVisible="False">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server" ColCount="3">
                                <Items>
                                    <dx:LayoutItem Caption="Login">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtLoginUsuario" runat="server" Width="170px">
                                                    <ValidationSettings ValidationGroup="DadosForm">
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionSettings VerticalAlign="Middle" />
                                    </dx:LayoutItem>
                                    <dx:LayoutItem ColSpan="2" RowSpan="4" ShowCaption="False" VerticalAlign="Top">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxGridView ID="gridRolesUsuario" runat="server" KeyFieldName="Id" AutoGenerateColumns="False" EnableCallBacks="False">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0">
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" Name="colId" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Permissão" FieldName="Name" Name="colName" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
                                                        <%--<dx:GridViewDataCheckColumn FieldName="IdComp" Name="colIdComp" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="5"></dx:GridViewDataCheckColumn>--%>
                                                        <dx:GridViewDataCheckColumn FieldName="IdComp" UnboundType="Boolean" Visible="False" VisibleIndex="5" Name="colIdComp"></dx:GridViewDataCheckColumn>
                                                    </Columns>
                                                </dx:ASPxGridView>
                                                <asp:ObjectDataSource ID="dsRoles" runat="server" DataObjectTypeName="S5T.IdRole" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAll" TypeName="S5T.IdRoleCollection" UpdateMethod="Save"></asp:ObjectDataSource>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Senha">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtSenhaUsuario" runat="server" Width="170px" ClientInstanceName="txtSenhaUsuario" Password="True">
                                                    <ValidationSettings ValidationGroup="DadosForm">
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionSettings VerticalAlign="Middle" />
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Confirmar Senha">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="txtSenhaConfirmarUsuario" runat="server" Width="170px" ClientInstanceName="txtSenhaConfirmarUsuario" Password="True">
                                                    <ClientSideEvents Validation="function(s, e) {e.isValid = (s.GetText() == txtSenhaUsuario.GetText());}" />
                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="A senha não confere" ValidationGroup="DadosForm">
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionSettings VerticalAlign="Middle" />
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Habilitado">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxCheckBox ID="chkHabilitadoUsuario" runat="server" CheckState="Unchecked">
                                                    <ValidationSettings ValidationGroup="DadosForm">
                                                    </ValidationSettings>
                                                </dx:ASPxCheckBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <CaptionSettings VerticalAlign="Middle" />
                                    </dx:LayoutItem>
                                </Items>
                            </dx:ASPxFormLayout>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
        </dx:ASPxPageControl>
    </div>
    <div class="mensagensValSummary">
        <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" RenderMode="BulletedList" ValidationGroup="DadosForm" HeaderText="Mensagens" ShowErrorsInEditors="True"></dx:ASPxValidationSummary>
    </div>
    <div class="mensagensGenericas">
        <asp:Literal ID="litMsgGenerica" runat="server"></asp:Literal>
    </div>

</asp:Content>
