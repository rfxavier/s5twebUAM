Imports DevExpress.Web
Imports CodeFluent.Runtime
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Owin
Imports S5T

Public Class Cadastro
    Inherits System.Web.UI.Page
    Dim obj As S5T.Cadastro = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InicializaForm()
        End If
    End Sub

    Private Sub InicializaForm()
        'LIMPA obj
        obj = Nothing

        'APAGA TODOS OS CONTROLES DE EDIÇÃO
        ASPxEdit.ClearEditorsInContainer(ASPxPageControl1)
        litMsgGenerica.Text = ""

        'RESETA O lbCodigo = LABEL (NÃO É CONTROLE DE EDIÇÃO)
        lbCodigo.Text = "NOVO"

        'RESETA COMBOS PESQUISA
        cmbPesqTipo.SelectedIndex = 0

        cmbPesqPFPJ.SelectedIndex = 0

        '**** RESETA GRID PESQUISA - INÍCIO **
        'MANDA IR PARA PRIMEIRA PÁGINA DO GRID
        gridCadastro.PageIndex = 0

        'DES-SELECIONA O QUE TIVER SELECIONADO
        RemoveHandler gridCadastro.SelectionChanged, AddressOf gridCadastro_SelectionChanged
        gridCadastro.Selection.UnselectAll()
        AddHandler gridCadastro.SelectionChanged, AddressOf gridCadastro_SelectionChanged

        'DESCONECTA E ZERA A DATASOURCE
        RemoveHandler gridCadastro.DataBinding, AddressOf gridCadastro_DataBinding
        gridCadastro.DataSource = Nothing
        gridCadastro.DataBind()
        AddHandler gridCadastro.DataBinding, AddressOf gridCadastro_DataBinding
        '**** RESETA GRID PESQUISA - FIM **


        'RESETA GRID CADASTRO TIPO - INÍCIO **
        'DES-SELECIONA O QUE TIVER SELECIONADO
        RemoveHandler gridCadastroTipo.SelectionChanged, AddressOf gridCadastroTipo_SelectionChanged
        gridCadastroTipo.Selection.UnselectAll()
        AddHandler gridCadastroTipo.SelectionChanged, AddressOf gridCadastroTipo_SelectionChanged

        gridCadastroTipo.DataBind()

        'DESCONECTA E ZERA A DATASOURCE
        'RemoveHandler gridCadastroTipo.DataBinding, AddressOf gridCadastroTipo_DataBinding
        'gridCadastroTipo.DataSource = Nothing
        'gridCadastroTipo.DataBind()
        'AddHandler gridCadastroTipo.DataBinding, AddressOf gridCadastroTipo_DataBinding

        'RESETA GRID CADASTRO TIPO - FIM **

        'RESETA GRID ROLES USUÁRIO **
        'DES-SELECIONA O QUE TIVER SELECIONADO
        'RemoveHandler gridRolesUsuario.SelectionChanged, AddressOf gridRolesUsuario_SelectionChanged
        gridRolesUsuario.Selection.UnselectAll()
        'AddHandler gridRolesUsuario.SelectionChanged, AddressOf gridRolesUsuario_SelectionChanged
        gridRolesUsuario.DataBind()

        'DESCONECTA E ZERA A DATASOURCE
        'RemoveHandler gridRolesUsuario.DataBinding, AddressOf gridRolesUsuario_DataBinding
        'gridRolesUsuario.DataSource = Nothing
        'gridRolesUsuario.DataBind()
        'AddHandler gridRolesUsuario.DataBinding, AddressOf gridRolesUsuario_DataBinding

        'RETIRA TABS
        ASPxPageControl1.TabPages(ASPxPageControl1.TabPages.FindByName("tabUsuario").Index).ClientVisible = False

        'RESETA RADIO BUTTONS
        rbPFPJ.SelectedIndex = 0
        rbSexo.SelectedIndex = 0

        'MANDA IR PARA PRIMEIRA TAB DO ASPxPageControl
        ASPxPageControl1.ActiveTabIndex = 0
    End Sub

#Region "btnPesquisarTratamento"


    Protected Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        gridCadastro.PageIndex = 0

        gridCadastro.DataBind()
    End Sub

    Protected Sub gridCadastro_DataBinding(sender As Object, e As EventArgs) Handles gridCadastro.DataBinding
        Dim VwGrid As List(Of S5T.CadastroViewGeralTipo) = Nothing

        VwGrid = S5T.Cadastro.LoadByParametros(IIf(Trim(txtPesqCodigo.Text) = "", Nothing, txtPesqCodigo.Text), _
                                               IIf(Trim(txtPesqNome.Text) = "", Nothing, txtPesqNome.Text & "%"), _
                                               cmbPesqPFPJ.Value, _
                                               Nothing, _
                                               Nothing, _
                                               Nothing, _
                                               cmbPesqTipo.Value)

        gridCadastro.DataSource = VwGrid
    End Sub

#End Region

    Protected Sub gridCadastro_SelectionChanged(sender As Object, e As EventArgs) Handles gridCadastro.SelectionChanged
        ASPxPageControl1.ActiveTabPage = ASPxPageControl1.TabPages.FindByName("tabDados1")
        'ASPxPageControl1.ActiveTabIndex = 1
        PreencheFormComId(gridCadastro.GetSelectedFieldValues("pId")(0).ToString)
    End Sub

    Private Sub PreencheFormComId(ByVal parId As Long)
        'PREENCHE O FORM COM OS DADOS APÓS O EVENTO gridCadastro.SelectionChanged
        obj = S5T.Cadastro.LoadByEntityKey(parId)

        If Not obj Is Nothing Then
            lbCodigo.Text = obj.pCodigo

            If obj.pPFPJ = "F" Then
                'TRATA PESSOA FÍSICA
                rbPFPJ.SelectedIndex = 0

                txtNome.Text = obj.pNome
                txtCPF.Text = obj.pCpfCnpj
                rbSexo.SelectedIndex = IIf(obj.pFlgSexo = "F", 1, 0)
                txtDataNascimento.Text = obj.pDataNascimento
                txtRG.Text = obj.pRgIe
                txtIEPF.Text = ""
                txtEmailPF.Text = obj.pEmail

                txtTelFixoPF.Text = obj.pTelefone
                txtTelCelularPF.Text = obj.pCelular
                txtTelAltPF.Text = obj.pTelefoneAux
                txtTelFaxPF.Text = obj.pFax

            ElseIf obj.pPFPJ = "J" Then
                'TRATA PESSOA JÚRÍDICA
                rbPFPJ.SelectedIndex = 1

                txtRazaoSocial.Text = obj.pNome
                txtNomeFantasia.Text = obj.pNomeFantasia
                txtCNPJ.Text = obj.pCpfCnpj
                txtIEPJ.Text = obj.pRgIe
                txtEmailPJ.Text = obj.pEmail

                txtTelFixoPJ.Text = obj.pTelefone
                txtTelCelularPJ.Text = obj.pCelular
                txtTelAltPJ.Text = obj.pTelefoneAux
                txtTelFaxPJ.Text = obj.pFax

            End If

            txtLogradouro.Text = obj.pEnderLogradouro
            txtNumero.Text = obj.pEnderNumero
            txtComplemento.Text = obj.pEnderComplemento
            txtBairro.Text = obj.pEnderBairro

            Dim objCadastroCidade = obj.oCidade
            If objCadastroCidade IsNot Nothing Then
                Dim objCidade = S5T.CidadeCollection.LoadByNomeViewGrid(objCadastroCidade.pNome)

                cmbCidade.DataSource = objCidade
                cmbCidade.DataBind()
            End If

            cmbCidade.SelectedIndex = 0
            'cmbCidade.Value = obj.oCidadepId
            txtCEP.Text = obj.pCep

            'PREENCHE O gridCadastroTipo, EVENTO DataBound DESTE GRID VERIFICA
            'QUAIS OS TIPOS DEVERÃO SER SELECIONADOS E TEREM OS CHECKBOXES MARCADOS
            gridCadastroTipo.DataBind()


            'FAZ TRATAMENTO DOS TIPOS DERIVADOS - USU / CLI / FOR, etc.
            If obj IsNot Nothing Then
                For i As Integer = 0 To gridCadastroTipo.VisibleRowCount - 1
                    If obj.pcCadastroTipoLista.IndexOf(gridCadastroTipo.GetRowValues(i, "pFlgCadastro").ToString) >= 0 Then
                        If User.IsInRole("AdmMaster") Then
                            If gridCadastroTipo.GetRowValues(i, "pFlgCadastro") = "USU" And gridCadastroTipo.Selection.IsRowSelected(i) Then
                                'txtCodigoUsuario.Text = obj.oUsuario.pCodigo
                                'NÃO SETA ALTERAÇÃO DE USUÁRIO / SENHA, POR MOTIVOS DE SEGURANÇA
                                'PARA NÃO RENDERIZAR O TEXTO DA SENHA NO HTML GERADO
                                txtLoginUsuario.Text = obj.oUsuario.pLogin
                                'txtSenhaUsuario.Text = obj.oUsuario.pSenha
                                'txtSenhaConfirmarUsuario.Text = obj.oUsuario.pSenha

                                chkHabilitadoUsuario.Checked = obj.oUsuario.sStatus

                                'PREENCHE O gridRolesUsuario, EVENTO DataBound DESTE GRID VERIFICA
                                'QUAIS OS TIPOS DEVERÃO SER SELECIONADOS E TEREM OS CHECKBOXES MARCADOS
                                gridRolesUsuario.DataBind()
                            End If
                        End If
                    End If
                Next i
            End If
        End If
    End Sub

    Protected Sub btnDesistir_Click(sender As Object, e As EventArgs) Handles btnDesistir.Click
        InicializaForm()
    End Sub

#Region "gridCadastroTipo Tratamento"
    Private Sub gridCadastroTipo_CustomUnboundColumnData(sender As Object, e As ASPxGridViewColumnDataEventArgs) Handles gridCadastroTipo.CustomUnboundColumnData
        If e.Column.FieldName = "pFlgCadastroComp" Then
            e.Value = DirectCast(sender, ASPxGridView).Selection.IsRowSelected(e.ListSourceRowIndex)
        End If

    End Sub

    Private Sub gridCadastroTipo_DataBinding(sender As Object, e As EventArgs) Handles gridCadastroTipo.DataBinding
        gridCadastroTipo.DataSource = S5T.CadastroTipoCollection.LoadAllViewGrid
    End Sub

    Private Sub gridCadastroTipo_DataBound(sender As Object, e As EventArgs) Handles gridCadastroTipo.DataBound
        Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
        If obj IsNot Nothing Then
            For i As Integer = 0 To grid.VisibleRowCount - 1
                If obj.pcCadastroTipoLista.IndexOf(gridCadastroTipo.GetRowValues(i, "pFlgCadastro").ToString) >= 0 Then
                    grid.Selection.SelectRow(i)
                Else
                    grid.Selection.UnselectRow(i)
                End If
            Next i
        End If
    End Sub

    Protected Sub gridCadastroTipo_SelectionChanged(sender As Object, e As EventArgs) Handles gridCadastroTipo.SelectionChanged
        Dim FlgCadastrosObj As List(Of Object) = gridCadastroTipo.GetSelectedFieldValues("pFlgCadastro")

        Dim FlgCadastros As New List(Of String)

        For i = 0 To FlgCadastrosObj.Count - 1
            FlgCadastros.Add(FlgCadastrosObj(i).ToString)
        Next

        If FlgCadastros.Contains("USU") And User.IsInRole("AdmMaster") Then
            ASPxPageControl1.TabPages(ASPxPageControl1.TabPages.FindByName("tabUsuario").Index).ClientVisible = True
            gridRolesUsuario.DataBind()
        Else
            ASPxPageControl1.TabPages(ASPxPageControl1.TabPages.FindByName("tabUsuario").Index).ClientVisible = False
        End If
    End Sub
#End Region

#Region "gridRolesUsuario Tratamento"
    Private Sub gridRolesUsuario_CustomUnboundColumnData(sender As Object, e As ASPxGridViewColumnDataEventArgs) Handles gridRolesUsuario.CustomUnboundColumnData
        If e.Column.FieldName = "IdComp" Then
            e.Value = DirectCast(sender, ASPxGridView).Selection.IsRowSelected(e.ListSourceRowIndex)
        End If
    End Sub

    Private Class IdRoleGridCadastro
        Private _Id As Long
        Public Property Id() As Long
            Get
                Return _Id
            End Get
            Set(ByVal value As Long)
                _Id = value
            End Set
        End Property

        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Private _IdComp As Boolean
        Public Property IdComp() As Boolean
            Get
                Return _IdComp
            End Get
            Set(ByVal value As Boolean)
                _IdComp = value
            End Set
        End Property
    End Class


    Protected Sub gridRolesUsuario_DataBinding(sender As Object, e As EventArgs) Handles gridRolesUsuario.DataBinding
        'Dim dsRolesLoadAll = S5T.IdRoleCollection.LoadAll
        'Dim dsRoles As New List(Of IdRoleGridCadastro)

        'For Each objRolesLoadAll In dsRolesLoadAll
        '    Dim objRoleGridCadastro = New IdRoleGridCadastro

        '    objRoleGridCadastro.Id = objRolesLoadAll.Id
        '    objRoleGridCadastro.Name = objRolesLoadAll.Name
        '    objRoleGridCadastro.IdComp = False

        '    If obj IsNot Nothing Then
        '        If obj.oUsuario IsNot Nothing Then
        '            Dim objIdUser = obj.oUsuario.oIdUser
        '            If objIdUser IsNot Nothing Then
        '                Dim listRolesIdUser As New List(Of String)

        '                For Each objRole In objIdUser.Roles
        '                    listRolesIdUser.Add(objRole.Id.ToString)
        '                Next

        '                If listRolesIdUser.Contains(objRoleGridCadastro.Id) Then
        '                    objRoleGridCadastro.IdComp = True
        '                Else
        '                    objRoleGridCadastro.IdComp = False
        '                End If
        '            End If
        '        End If
        '    End If

        '    dsRoles.Add(objRoleGridCadastro)
        'Next

        gridRolesUsuario.DataSource = S5T.IdRoleCollection.LoadAll
    End Sub

    Protected Sub gridRolesUsuario_DataBound(sender As Object, e As EventArgs) Handles gridRolesUsuario.DataBound
        Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)

        'For i As Integer = 0 To grid.VisibleRowCount - 1
        '    If gridRolesUsuario.GetRowValues(i, "IdComp") Then
        '        grid.Selection.SelectRow(i)
        '    Else
        '        grid.Selection.UnselectRow(i)
        '    End If
        'Next

        If obj IsNot Nothing Then
            If obj.oUsuario IsNot Nothing Then
                If obj.oUsuario.oIdUser IsNot Nothing Then
                    Dim listRolesIdUser As New List(Of String)

                    For Each objRole In obj.oUsuario.oIdUser.Roles
                        listRolesIdUser.Add(objRole.Id.ToString)
                    Next

                    For i As Integer = 0 To grid.VisibleRowCount - 1
                        If listRolesIdUser.Contains(gridRolesUsuario.GetRowValues(i, "Id").ToString) Then
                            grid.Selection.SelectRow(i)
                        Else
                            grid.Selection.UnselectRow(i)
                        End If
                    Next i
                End If
            End If
        End If
    End Sub
#End Region

#Region "combosTratamento"

    Private Sub cmbCidade_ItemRequestedByValue(source As Object, e As DevExpress.Web.ListEditItemRequestedByValueEventArgs) Handles cmbCidade.ItemRequestedByValue
        Dim value As Long = 0
        If e.Value Is Nothing OrElse (Not Int64.TryParse(e.Value.ToString(), value)) Then
            Return
        End If
        Dim comboBox As ASPxComboBox = CType(source, ASPxComboBox)

        If comboBox.Text = "" Then Return

        Dim objCidade = S5T.Cidade.LoadByEntityKey(e.Value.ToString())

        comboBox.DataSource = objCidade
        comboBox.DataBind()
    End Sub

    Protected Sub cmbCidade_ItemsRequestedByFilterCondition(source As Object, e As DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs) Handles cmbCidade.ItemsRequestedByFilterCondition
        Dim strFilterToSearch As String = String.Empty
        If Regex.IsMatch(e.Filter, "^[0-9]+$") Then
            strFilterToSearch = String.Format("%{0}%", e.Filter.PadLeft(4, "0"))
        Else
            strFilterToSearch = String.Format("%{0}%", e.Filter)
        End If

        Dim CidadesPesquisa = S5T.Cidade.LoadByFilterCodigoNome(strFilterToSearch, e.BeginIndex + 1, e.EndIndex + 1)
        cmbCidade.DataSource = CidadesPesquisa
        cmbCidade.DataBind()
    End Sub

    Protected Sub cmbCidadeAux_ItemsRequestedByFilterCondition(source As Object, e As ListEditItemsRequestedByFilterConditionEventArgs) Handles cmbCidadeAux.ItemsRequestedByFilterCondition
        Dim strFilterToSearch As String = String.Empty
        If Regex.IsMatch(e.Filter, "^[0-9]+$") Then
            strFilterToSearch = String.Format("%{0}%", e.Filter.PadLeft(4, "0"))
        Else
            strFilterToSearch = String.Format("%{0}%", e.Filter)
        End If

        Dim CidadesPesquisa = S5T.Cidade.LoadByFilterCodigoNome(strFilterToSearch, e.BeginIndex + 1, e.EndIndex + 1)
        cmbCidadeAux.DataSource = CidadesPesquisa
        cmbCidadeAux.DataBind()
    End Sub

    Protected Sub cmbCidadeAux_ItemRequestedByValue(source As Object, e As ListEditItemRequestedByValueEventArgs) Handles cmbCidadeAux.ItemRequestedByValue
        Dim value As Long = 0
        If e.Value Is Nothing OrElse (Not Int64.TryParse(e.Value.ToString(), value)) Then
            Return
        End If
        Dim comboBox As ASPxComboBox = CType(source, ASPxComboBox)

        If comboBox.Text = "" Then Return

        Dim objCidade = S5T.Cidade.LoadByEntityKey(e.Value.ToString())

        comboBox.DataSource = objCidade
        comboBox.DataBind()
    End Sub

#End Region

#Region "tipoOperacaoTratamento"
    Enum tpInsAlt
        Insercao
        Alteracao
    End Enum

    Private Function tipoOperacao() As tpInsAlt
        If gridCadastro.GetSelectedFieldValues("pId").Count = 0 Then
            tipoOperacao = tpInsAlt.Insercao
        Else
            tipoOperacao = tpInsAlt.Alteracao
        End If
    End Function
#End Region

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim scope As System.Transactions.TransactionScope = Nothing
        Try
            Dim options As System.Transactions.TransactionOptions = New System.Transactions.TransactionOptions()
            scope = New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, options)

            'For i = 0 To gridCadastroTipo.VisibleRowCount - 1

            '    MsgBox(gridCadastroTipo.GetRowValues(i, "pFlgCadastro") & "=" & IIf(gridCadastroTipo.Selection.IsRowSelected(i), "SEL", "NÃO SEL") & " e pFlgCadastroComp=" & IIf(gridCadastroTipo.GetRowValues(i, "pFlgCadastroComp"), "sel", "não sel"))
            'Next


            If tipoOperacao() = tpInsAlt.Insercao Then
                'É INSERÇÃO

                Dim objNew As New S5T.Cadastro

                objNew.oEmpresas.Add(S5T.Empresa.LoadBypCodigo(1)) 'OFICIALIZAR PARA NÃO PASSAR FIXO = 1

                objNew.pPFPJ = IIf(rbPFPJ.SelectedIndex = 0, "F", "J")

                If objNew.pPFPJ = "F" Then
                    'PESSOA FÍSICA

                    'SETA COMO VÁLIDOS OS CAMPOS "ESCONDIDOS" DA PESSOA JURÍDICA
                    'PARA NÃO DISPARAR VALIDAÇÃO NELES
                    txtRazaoSocial.IsValid = True

                    objNew.pNome = txtNome.Text
                    objNew.pFlgSexo = IIf(rbSexo.SelectedIndex = 0, "M", "F")
                    objNew.pCpfCnpj = txtCPF.Text
                    objNew.pDataNascimento = IIf(txtDataNascimento.Text = "", Nothing, txtDataNascimento.Text)
                    objNew.pEmail = txtEmailPF.Text
                    objNew.pTelefone = txtTelFixoPF.Text
                    objNew.pTelefoneAux = txtTelAltPF.Text
                    objNew.pCelular = txtTelCelularPF.Text
                    objNew.pFax = txtTelFaxPF.Text
                ElseIf objNew.pPFPJ = "J" Then
                    'PESSOA JURÍDICA

                    'SETA COMO VÁLIDOS OS CAMPOS "ESCONDIDOS" DA PESSOA FÍSICA
                    'PARA NÃO DISPARAR VALIDAÇÃO NELES
                    txtNome.IsValid = True

                    objNew.pNome = txtRazaoSocial.Text
                    objNew.pNomeFantasia = txtNomeFantasia.Text
                    objNew.pCpfCnpj = txtCNPJ.Text
                    objNew.pEmail = txtEmailPJ.Text
                    objNew.pTelefone = txtTelFixoPJ.Text
                    objNew.pTelefoneAux = txtTelAltPJ.Text
                    objNew.pCelular = txtTelCelularPJ.Text
                    objNew.pFax = txtTelFaxPJ.Text
                End If

                objNew.pEnderLogradouro = txtLogradouro.Text
                objNew.pEnderNumero = txtNumero.Text
                objNew.pEnderComplemento = txtComplemento.Text
                objNew.pEnderBairro = txtBairro.Text
                objNew.oCidadepId = cmbCidade.Value
                objNew.pCep = txtCEP.Text
                objNew.pEnderAuxLogradouro = txtLogradouroAux.Text
                objNew.pEnderAuxNumero = txtNumeroAux.Text
                objNew.pEnderAuxComplemento = txtComplementoAux.Text
                objNew.pEnderAuxBairro = txtBairroAux.Text
                objNew.oCidadeAuxpId = cmbCidadeAux.Value
                objNew.pCepAux = txtCEPAux.Text

                objNew.xLoginReg = "ADMIN"
                objNew.Save()

                'PERCORRE O gridCadastroTipo, PARA AVALIAR SE HÁ DADOS EM ABAS DOS TIPOS DERIVADOS (USU, CLI, FOR, etc)
                For i = 0 To gridCadastroTipo.VisibleRowCount - 1
                    If User.IsInRole("AdmMaster") Then
                        If gridCadastroTipo.GetRowValues(i, "pFlgCadastro") = "USU" And gridCadastroTipo.Selection.IsRowSelected(i) Then
                            'NOVO REGISTRO, NOVO USUÁRIO

                            'ASP.NET Identity 2.1 - CRIAÇÃO DE NOVO USUÁRIO
                            Dim userName As String = txtLoginUsuario.Text
                            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
                            Dim signInManager = Context.GetOwinContext().Get(Of ApplicationSignInManager)()
                            Dim user = New IdUser() With {.UserName = userName, .Email = IIf(rbPFPJ.SelectedIndex = 0, txtEmailPF.Text, txtEmailPJ.Text)} ', .oUsuario = objNewUsuario}
                            Dim result = manager.Create(user, txtSenhaUsuario.Text)
                            If result.Succeeded Then
                                ' For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                                ' Dim code = manager.GenerateEmailConfirmationToken(user.Id)
                                ' Dim callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request)
                                ' manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=""" & callbackUrl & """>here</a>.")

                                'signInManager.SignIn(user, isPersistent:=False, rememberBrowser:=False)
                                'IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)

                                'QUER DIZER: INSERÇÃO DE NOVO TIPO Usuário
                                Dim objNewUsuario As New S5T.Usuario
                                objNewUsuario.oCadastro = objNew
                                objNewUsuario.pLogin = txtLoginUsuario.Text
                                objNewUsuario.pSenha = txtSenhaUsuario.Text
                                objNewUsuario.pFlgAdmin = "N"
                                objNewUsuario.sStatus = chkHabilitadoUsuario.Checked
                                objNewUsuario.xLoginReg = "ADMIN"
                                objNewUsuario.oIdUser = user

                                objNewUsuario.Save()

                                'TRATA ALTERAÇÃO DOS UserRoles
                                For j = 0 To gridRolesUsuario.VisibleRowCount - 1
                                    If gridRolesUsuario.Selection.IsRowSelected(j) Then
                                        'QUER DIZER: INSERÇÃO DE NOVA UserRole
                                        Dim objRoleUsuario = S5T.IdRole.LoadByEntityKey(gridRolesUsuario.GetRowValues(j, "Id").ToString)

                                        user.Roles.Add(objRoleUsuario)
                                        user.Save()
                                    End If
                                Next
                            Else
                                'ErrorMessage.Text = result.Errors.FirstOrDefault()
                                Throw New CodeFluentValidationException("Criação Usuário: " & result.Errors.FirstOrDefault())
                            End If
                        End If
                    End If
                Next
            ElseIf tipoOperacao() = tpInsAlt.Alteracao Then
                'É ALTERAÇÃO

                Dim obj As S5T.Cadastro = S5T.Cadastro.LoadByEntityKey(gridCadastro.GetSelectedFieldValues("pId")(0))

                obj.pPFPJ = IIf(rbPFPJ.SelectedIndex = 0, "F", "J")

                If obj.pPFPJ = "F" Then
                    'PESSOA FÍSICA

                    'SETA COMO VÁLIDOS OS CAMPOS "ESCONDIDOS" DA PESSOA JURÍDICA
                    'PARA NÃO DISPARAR VALIDAÇÃO NELES
                    txtRazaoSocial.IsValid = True

                    obj.pNome = txtNome.Text
                    obj.pFlgSexo = IIf(rbSexo.SelectedIndex = 0, "M", "F")
                    obj.pCpfCnpj = txtCPF.Text
                    obj.pDataNascimento = IIf(txtDataNascimento.Text = "", Nothing, txtDataNascimento.Text)
                    obj.pEmail = txtEmailPF.Text
                    obj.pTelefone = txtTelFixoPF.Text
                    obj.pTelefoneAux = txtTelAltPF.Text
                    obj.pCelular = txtTelCelularPF.Text
                    obj.pFax = txtTelFaxPF.Text
                ElseIf obj.pPFPJ = "J" Then
                    'PESSOA JURÍDICA

                    'SETA COMO VÁLIDOS OS CAMPOS "ESCONDIDOS" DA PESSOA FÍSICA
                    'PARA NÃO DISPARAR VALIDAÇÃO NELES
                    txtNome.IsValid = True

                    obj.pNome = txtRazaoSocial.Text
                    obj.pNomeFantasia = txtNomeFantasia.Text
                    obj.pCpfCnpj = txtCNPJ.Text
                    obj.pEmail = txtEmailPJ.Text
                    obj.pTelefone = txtTelFixoPJ.Text
                    obj.pTelefoneAux = txtTelAltPJ.Text
                    obj.pCelular = txtTelCelularPJ.Text
                    obj.pFax = txtTelFaxPJ.Text
                End If

                obj.pEnderLogradouro = txtLogradouro.Text
                obj.pEnderNumero = txtNumero.Text
                obj.pEnderComplemento = txtComplemento.Text
                obj.pEnderBairro = txtBairro.Text
                obj.oCidadepId = cmbCidade.Value
                obj.pCep = txtCEP.Text
                obj.pEnderAuxLogradouro = txtLogradouroAux.Text
                obj.pEnderAuxNumero = txtNumeroAux.Text
                obj.pEnderAuxComplemento = txtComplementoAux.Text
                obj.pEnderAuxBairro = txtBairroAux.Text
                obj.oCidadeAuxpId = cmbCidadeAux.Value
                obj.pCepAux = txtCEPAux.Text

                obj.xLoginReg = "ADMIN"
                obj.Save()

                'PERCORRE O gridCadastroTipo, PARA AVALIAR SE HÁ DADOS EM ABAS DOS TIPOS DERIVADOS (USU, CLI, FOR, etc)
                For i = 0 To gridCadastroTipo.VisibleRowCount - 1
                    If User.IsInRole("AdmMaster") Then
                        'MsgBox(gridCadastroTipo.GetRowValues(i, "pFlgCadastro") & "=" & IIf(gridCadastroTipo.Selection.IsRowSelected(i), "SEL", "NÃO SEL") & " e pFlgCadastroComp=" & IIf(gridCadastroTipo.GetRowValues(i, "pFlgCadastroComp"), "sel", "não sel"))

                        If gridCadastroTipo.GetRowValues(i, "pFlgCadastro") = "USU" And gridCadastroTipo.Selection.IsRowSelected(i) And Not gridCadastroTipo.GetRowValues(i, "pFlgCadastroComp") Then
                            'REGISTRO NO CADASTRO JÁ EXISTENTE, NOVO USUÁRIO

                            'ASP.NET Identity 2.1 - CRIAÇÃO DE NOVO USUÁRIO
                            Dim userName As String = txtLoginUsuario.Text
                            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
                            Dim signInManager = Context.GetOwinContext().Get(Of ApplicationSignInManager)()
                            Dim user = New IdUser() With {.UserName = userName, .Email = IIf(rbPFPJ.SelectedIndex = 0, txtEmailPF.Text, txtEmailPJ.Text)} ', .oUsuario = objNewUsuario}
                            Dim result = manager.Create(user, txtSenhaUsuario.Text)
                            If result.Succeeded Then
                                'signInManager.SignIn(user, isPersistent:=False, rememberBrowser:=False)
                                'IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)

                                'ADICIONA Roles
                                For j = 0 To gridRolesUsuario.VisibleRowCount - 1
                                    If gridRolesUsuario.Selection.IsRowSelected(j) Then
                                        Dim objRoleUsuario = S5T.IdRole.LoadByEntityKey(gridRolesUsuario.GetRowValues(j, "Id").ToString)

                                        user.Roles.Add(objRoleUsuario)
                                        user.Save()
                                    End If
                                Next

                                'QUER DIZER: INSERÇÃO DE NOVO TIPO Usuário
                                Dim objNewUsuario As New S5T.Usuario
                                objNewUsuario.oCadastro = obj
                                objNewUsuario.pLogin = txtLoginUsuario.Text
                                objNewUsuario.pSenha = txtSenhaUsuario.Text
                                objNewUsuario.pFlgAdmin = "N"
                                objNewUsuario.sStatus = chkHabilitadoUsuario.Checked
                                objNewUsuario.xLoginReg = "ADMIN"
                                objNewUsuario.oIdUser = user

                                objNewUsuario.Save()
                            Else
                                Throw New CodeFluentValidationException("Criação Usuário: " & result.Errors.FirstOrDefault())
                            End If
                        ElseIf gridCadastroTipo.GetRowValues(i, "pFlgCadastro") = "USU" And gridCadastroTipo.Selection.IsRowSelected(i) And gridCadastroTipo.GetRowValues(i, "pFlgCadastroComp") Then
                            'REGISTRO NO CADASTRO JÁ EXISTENTE, USUÁRIO JÁ EXISTENTE
                            If User.IsInRole("AdmMaster") Then

                                'QUER DIZER: ALTERAÇÃO DE TIPO JÁ EXISTENTE Usuário
                                Dim objUsuario = S5T.Usuario.LoadByoCadastro(obj.pId)

                                If objUsuario IsNot Nothing Then
                                    Dim user As IdUser = objUsuario.oIdUser

                                    'SÓ ALTERA A SENHA SE TIVEREM PREENCHIDOS OS DEVIDOS CAMPOS
                                    If txtSenhaUsuario.Text <> "" And user IsNot Nothing Then
                                        'ASP.NET Identity 2.1 - ALTERAÇÃO DE SENHA DE USUÁRIO

                                        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
                                        Dim signInManager = Context.GetOwinContext().Get(Of ApplicationSignInManager)()
                                        Dim result As IdentityResult = manager.ChangePassword(objUsuario.oIdUser.Id, objUsuario.pSenha, txtSenhaUsuario.Text)
                                        If result.Succeeded Then
                                            'Dim userInfo = manager.FindById(User.Identity.GetUserId())
                                            'signInManager.SignIn(userInfo, isPersistent:=False, rememberBrowser:=False)
                                            'Response.Redirect("~/Account/Manage?m=ChangePwdSuccess")

                                            objUsuario.pSenha = txtSenhaUsuario.Text
                                        Else
                                            Throw New CodeFluentValidationException("Alteração Usuário: " & result.Errors.FirstOrDefault())
                                        End If
                                    End If

                                    objUsuario.pFlgAdmin = "N"
                                    objUsuario.sStatus = chkHabilitadoUsuario.Checked
                                    objUsuario.xLoginReg = "ADMIN"

                                    objUsuario.Save()

                                    'TRATA ALTERAÇÃO DOS UserRoles
                                    For j = 0 To gridRolesUsuario.VisibleRowCount - 1
                                        If gridRolesUsuario.Selection.IsRowSelected(j) And Not gridRolesUsuario.GetRowValues(j, "IdComp") Then
                                            'QUER DIZER: INSERÇÃO DE NOVA UserRole
                                            Dim objRoleUsuario = S5T.IdRole.LoadByEntityKey(gridRolesUsuario.GetRowValues(j, "Id").ToString)

                                            user.Roles.Add(objRoleUsuario)
                                            user.Save()
                                        ElseIf Not gridRolesUsuario.Selection.IsRowSelected(j) And gridRolesUsuario.GetRowValues(j, "IdComp") Then
                                            'QUER DIZER: ELIMINAÇÃO DE UserRole
                                            Dim objRoleUsuario = S5T.IdRole.LoadByEntityKey(gridRolesUsuario.GetRowValues(j, "Id").ToString)

                                            user.Roles.Remove(objRoleUsuario)
                                            user.Save()
                                        End If
                                    Next
                                End If
                            End If

                        ElseIf gridCadastroTipo.GetRowValues(i, "pFlgCadastro") = "USU" And Not gridCadastroTipo.Selection.IsRowSelected(i) And gridCadastroTipo.GetRowValues(i, "pFlgCadastroComp") Then
                            If User.IsInRole("AdmMaster") Then
                                'QUER DIZER: ELIMINAÇÃO DE TIPO JÁ EXISTENTE Usuário
                                If obj.oUsuario IsNot Nothing Then
                                    Dim user As IdUser = obj.oUsuario.oIdUser
                                    If user IsNot Nothing Then
                                        user.Delete()
                                    End If

                                    S5T.Usuario.DeleteLinkCadastro(S5T.Usuario.LoadByoCadastro(obj.pId))
                                End If
                            End If
                        End If
                    End If
                Next
            End If

            InicializaForm()

            scope.Complete()
        Catch ex As CodeFluentValidationException
            Dim msgEx As String = ex.MessageWithoutCode

            If AppUtils.exMsgHasTag(msgEx) Then
                'ACHOU TAG DELIMITADA COM [] ?
                'VAI PROCURAR O CONTROLE COM NOME EQUIVALENTE PARA SETAR ERRO E MENSAGEM ESPECÍFICA A ESTE CONTROLE

                'PRÉ-REQUISITO NOMENCLATURA DOS CONTROLES:
                'ASPxPageControl1 - nome fixo
                'ASPxFormLayoutN - nome dos ASPxFormLayout dentro de cada tab page do ASPxPageControl1, onde N = tab index de sua respectiva tab

                Dim nomeControle = resolveNomeControleCadastro(parseExMsg(msgEx, "name"), IIf(rbPFPJ.SelectedIndex = 0, "F", "J"))
                Dim boolAchouControle As Boolean = False

                For i = 1 To ASPxPageControl1.TabPages.Count - 1
                    ASPxPageControl1.ActiveTabIndex = i

                    Dim ctrl As Control = AppUtils.FindControlRecursive(AppUtils.FindControlRecursive(Me, "ASPxFormLayout" & i.ToString), nomeControle)
                    If ctrl IsNot Nothing Then
                        DirectCast(ctrl, DevExpress.Web.ASPxEdit).IsValid = False
                        DirectCast(ctrl, DevExpress.Web.ASPxEdit).ErrorText = AppUtils.parseExMsg(msgEx)
                        boolAchouControle = True
                        Exit For
                    End If
                Next

                If Not boolAchouControle Then
                    ASPxPageControl1.ActiveTabIndex = 1
                    litMsgGenerica.Text = msgEx
                End If
            Else
                litMsgGenerica.Text = msgEx
            End If
        Finally
            If (Not (scope) Is Nothing) Then
                scope.Dispose()
            End If
        End Try
    End Sub

    Private Function resolveNomeControleCadastro(tagControleFromPartial As String, tipoPFPJ As String) As String
        '"TRADUÇÃO" DOS NOMES DE CONTROLES PF PJ ESPECÍFICOS
        Dim dictControles As New Dictionary(Of String, String)

        dictControles.Add("F" & "TxtCpfCnpj", "txtCPF")
        dictControles.Add("J" & "TxtCpfCnpj", "txtCNPJ")
        dictControles.Add("F" & "TxtNome", "TxtNome")
        dictControles.Add("J" & "TxtNome", "txtRazaoSocial")
        dictControles.Add("F" & "MskDtNasc", "txtDataNascimento")
        dictControles.Add("F" & "MskCep", "txtCEP")
        dictControles.Add("F" & "TxtFoneFixo1", "txtTelFixoPF")
        dictControles.Add("J" & "TxtFoneFixo1", "txtTelFixoPJ")
        dictControles.Add("F" & "TxtFoneAlt1", "txtTelAltPF")
        dictControles.Add("J" & "TxtFoneAlt1", "txtTelAltPJ")
        dictControles.Add("F" & "TxtFoneCel1", "txtTelCelPF")
        dictControles.Add("J" & "TxtFoneCel1", "txtTelCelPJ")
        dictControles.Add("F" & "TxtFoneFax1", "txtTelFaxPF")
        dictControles.Add("J" & "TxtFoneFax1", "txtTelFaxPJ")

        If dictControles.ContainsKey(tipoPFPJ & tagControleFromPartial) Then
            resolveNomeControleCadastro = dictControles.Item(tipoPFPJ & tagControleFromPartial)
        Else
            resolveNomeControleCadastro = tagControleFromPartial
        End If
    End Function
End Class

