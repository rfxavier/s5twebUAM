Imports DevExpress.Web
Imports CodeFluent.Runtime
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Owin
Imports S5T

Public Class Usuarios
    Inherits System.Web.UI.Page
    Dim obj As S5T.Usuario = Nothing
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

        '**** RESETA GRID PESQUISA - INÍCIO **
        'MANDA IR PARA PRIMEIRA PÁGINA DO GRID
        gridUsuarios.PageIndex = 0

        'DES-SELECIONA O QUE TIVER SELECIONADO
        RemoveHandler gridUsuarios.SelectionChanged, AddressOf gridUsuarios_SelectionChanged
        gridUsuarios.Selection.UnselectAll()
        AddHandler gridUsuarios.SelectionChanged, AddressOf gridUsuarios_SelectionChanged

        'DESCONECTA E ZERA A DATASOURCE
        RemoveHandler gridUsuarios.DataBinding, AddressOf gridUsuarios_DataBinding
        gridUsuarios.DataSource = Nothing
        gridUsuarios.DataBind()
        AddHandler gridUsuarios.DataBinding, AddressOf gridUsuarios_DataBinding
        '**** RESETA GRID PESQUISA - FIM **


        'RESETA GRID CADASTRO TIPO - FIM **

        'RESETA GRID ROLES USUÁRIO **
        'DES-SELECIONA O QUE TIVER SELECIONADO
        'RemoveHandler gridRolesUsuario.SelectionChanged, AddressOf gridRolesUsuario_SelectionChanged
        gridRolesUsuario.Selection.UnselectAll()
        'AddHandler gridRolesUsuario.SelectionChanged, AddressOf gridRolesUsuario_SelectionChanged
        gridRolesUsuario.DataBind()

        'MANDA IR PARA PRIMEIRA TAB DO ASPxPageControl
        ASPxPageControl1.ActiveTabIndex = 0
    End Sub

#Region "btnPesquisarTratamento"


    Protected Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        gridUsuarios.PageIndex = 0

        gridUsuarios.DataBind()
    End Sub

    Protected Sub gridUsuarios_DataBinding(sender As Object, e As EventArgs) Handles gridUsuarios.DataBinding
        Dim VwGrid As S5T.UsuarioCollection = Nothing

        VwGrid = S5T.UsuarioCollection.LoadAll

        gridUsuarios.DataSource = VwGrid
    End Sub

#End Region

    Protected Sub gridUsuarios_SelectionChanged(sender As Object, e As EventArgs) Handles gridUsuarios.SelectionChanged
        ASPxPageControl1.ActiveTabPage = ASPxPageControl1.TabPages.FindByName("tabUsuario")
        'ASPxPageControl1.ActiveTabIndex = 1
        PreencheFormComId(gridUsuarios.GetSelectedFieldValues("pId")(0).ToString)
    End Sub

    Private Sub PreencheFormComId(ByVal parId As Long)
        'PREENCHE O FORM COM OS DADOS APÓS O EVENTO gridUsuarios.SelectionChanged
        obj = S5T.Usuario.LoadByEntityKey(parId)


        If Not obj Is Nothing Then
            txtLoginUsuario.Text = obj.pLogin

            'NÃO SETA ALTERAÇÃO DE USUÁRIO / SENHA, POR MOTIVOS DE SEGURANÇA
            'PARA NÃO RENDERIZAR O TEXTO DA SENHA NO HTML GERADO

            'txtSenhaUsuario.Text = obj.oUsuario.pSenha
            'txtSenhaConfirmarUsuario.Text = obj.oUsuario.pSenha

            chkHabilitadoUsuario.Checked = obj.sStatus

            'PREENCHE O gridRolesUsuario, EVENTO DataBound DESTE GRID VERIFICA
            'QUAIS OS TIPOS DEVERÃO SER SELECIONADOS E TEREM OS CHECKBOXES MARCADOS
            gridRolesUsuario.DataBind()
        End If
    End Sub

    Protected Sub btnDesistir_Click(sender As Object, e As EventArgs) Handles btnDesistir.Click
        InicializaForm()
    End Sub

#Region "gridRolesUsuario Tratamento"
    Private Sub gridRolesUsuario_CustomUnboundColumnData(sender As Object, e As ASPxGridViewColumnDataEventArgs) Handles gridRolesUsuario.CustomUnboundColumnData
        If e.Column.FieldName = "IdComp" Then
            e.Value = DirectCast(sender, ASPxGridView).Selection.IsRowSelected(e.ListSourceRowIndex)
        End If
    End Sub

    Private Class IdRolegridUsuarios
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
        gridRolesUsuario.DataSource = S5T.IdRoleCollection.LoadAll.ToList.FindAll(Function(x) x.Name <> "AdmMaster")
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
            If obj.oIdUser IsNot Nothing Then
                Dim listRolesIdUser As New List(Of String)

                For Each objRole In obj.oIdUser.Roles
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

    End Sub
#End Region

#Region "tipoOperacaoTratamento"
    Enum tpInsAlt
        Insercao
        Alteracao
    End Enum

    Private Function tipoOperacao() As tpInsAlt
        If gridUsuarios.GetSelectedFieldValues("pId").Count = 0 Then
            tipoOperacao = tpInsAlt.Insercao
        Else
            tipoOperacao = tpInsAlt.Alteracao
        End If
    End Function
#End Region

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim signInManager = Context.GetOwinContext().Get(Of ApplicationSignInManager)()

        Try
            If tipoOperacao() = tpInsAlt.Insercao Then
                'É INSERÇÃO

                'NOVO REGISTRO, NOVO USUÁRIO

                'ASP.NET Identity 2.1 - CRIAÇÃO DE NOVO USUÁRIO
                Dim userName As String = txtLoginUsuario.Text

                Dim user = New IdUser() With {.UserName = userName, .Email = userName & "@altamogiana.com.br"} ', .oUsuario = objNewUsuario}

                Dim result = manager.Create(user, txtSenhaUsuario.Text)

                If result.Succeeded Then
                    'QUER DIZER: INSERÇÃO DE NOVO TIPO Usuário
                    Dim objNewUsuario As New S5T.Usuario
                    'objNewUsuario.oCadastro = objNew
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


            ElseIf tipoOperacao() = tpInsAlt.Alteracao Then
                'É ALTERAÇÃO

                'QUER DIZER: ALTERAÇÃO DE TIPO JÁ EXISTENTE Usuário
                Dim objUsuario As S5T.Usuario = S5T.Usuario.LoadByEntityKey(gridUsuarios.GetSelectedFieldValues("pId")(0))

                If objUsuario IsNot Nothing Then

                    'SÓ ALTERA A SENHA SE TIVEREM PREENCHIDOS OS DEVIDOS CAMPOS
                    If objUsuario.oIdUser IsNot Nothing And txtSenhaUsuario.Text.Trim <> "" Then
                        'ASP.NET Identity 2.1 - ALTERAÇÃO DE SENHA DE USUÁRIO

                        'Dim result As IdentityResult = manager.ChangePassword(objUsuario.oIdUser.Id.ToString, objUsuario.pSenha, txtSenhaUsuario.Text)
                        If manager.HasPassword(objUsuario.oIdUser.Id.ToString) Then
                            Dim result As IdentityResult = manager.RemovePassword(objUsuario.oIdUser.Id.ToString)
                            If result.Succeeded Then
                                Dim result2 As IdentityResult = manager.AddPassword(objUsuario.oIdUser.Id.ToString, txtSenhaUsuario.Text)

                                If result2.Succeeded Then
                                    objUsuario.pSenha = txtSenhaUsuario.Text
                                Else
                                    Throw New CodeFluentValidationException("Alteração Usuário: " & result2.Errors.FirstOrDefault())
                                End If
                            Else
                                Throw New CodeFluentValidationException("Alteração Usuário: " & result.Errors.FirstOrDefault())
                            End If
                        Else
                            Dim result3 As IdentityResult = manager.AddPassword(objUsuario.oIdUser.Id.ToString, txtSenhaUsuario.Text)

                            If result3.Succeeded Then
                                objUsuario.pSenha = txtSenhaUsuario.Text
                            Else
                                Throw New CodeFluentValidationException("Alteração Usuário: " & result3.Errors.FirstOrDefault())
                            End If
                        End If
                    End If

                    objUsuario.pFlgAdmin = "N"
                    objUsuario.sStatus = chkHabilitadoUsuario.Checked
                    objUsuario.xLoginReg = "ADMIN"

                    objUsuario.Save()

                    'INICIALIZA user COM S5T.Usuario RECARREGADO, PARA REFLETIR CASO ACONTECEU ALTERAÇÃO DE SENHA
                    Dim user As IdUser = S5T.Usuario.LoadByEntityKey(gridUsuarios.GetSelectedFieldValues("pId")(0)).oIdUser

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

            InicializaForm()

        Catch ex As CodeFluentValidationException
            Dim msgEx As String = ex.MessageWithoutCode

            If AppUtils.exMsgHasTag(msgEx) Then
                'ACHOU TAG DELIMITADA COM [] ?
                'VAI PROCURAR O CONTROLE COM NOME EQUIVALENTE PARA SETAR ERRO E MENSAGEM ESPECÍFICA A ESTE CONTROLE

                'PRÉ-REQUISITO NOMENCLATURA DOS CONTROLES:
                'ASPxPageControl1 - nome fixo
                'ASPxFormLayoutN - nome dos ASPxFormLayout dentro de cada tab page do ASPxPageControl1, onde N = tab index de sua respectiva tab

                Dim nomeControle = parseExMsg(msgEx, "name")
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
        End Try
    End Sub

    Protected Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()

        Try
            If gridUsuarios.GetSelectedFieldValues("pId").Count = 1 Then
                'DELETA USUÁRIO
                Dim objUsuario As S5T.Usuario = S5T.Usuario.LoadByEntityKey(gridUsuarios.GetSelectedFieldValues("pId")(0))

                If objUsuario IsNot Nothing Then
                    If objUsuario.oIdUser IsNot Nothing Then
                        Dim result As IdentityResult = manager.Delete(objUsuario.oIdUser)
                        If result.Succeeded Then
                            objUsuario.Delete()
                        End If
                    Else
                        objUsuario.Delete()
                    End If
                End If
            End If

            InicializaForm()
        Catch ex As CodeFluentValidationException
            Dim msgEx As String = ex.MessageWithoutCode

            If AppUtils.exMsgHasTag(msgEx) Then
                'ACHOU TAG DELIMITADA COM [] ?
                'VAI PROCURAR O CONTROLE COM NOME EQUIVALENTE PARA SETAR ERRO E MENSAGEM ESPECÍFICA A ESTE CONTROLE

                'PRÉ-REQUISITO NOMENCLATURA DOS CONTROLES:
                'ASPxPageControl1 - nome fixo
                'ASPxFormLayoutN - nome dos ASPxFormLayout dentro de cada tab page do ASPxPageControl1, onde N = tab index de sua respectiva tab

                Dim nomeControle = parseExMsg(msgEx, "name")
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
        End Try

    End Sub
End Class

