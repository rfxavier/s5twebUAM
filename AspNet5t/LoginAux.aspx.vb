Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports S5T
Imports Owin
Imports Oracle.DataAccess.Client
Imports Microsoft.Owin.Security
Imports DevExpress.Web
Public Class LoginAux
    Inherits System.Web.UI.Page

    Protected Property SuccessMessage() As String
        Get
            Return m_SuccessMessage
        End Get
        Private Set(value As String)
            m_SuccessMessage = value
        End Set
    End Property
    Private m_SuccessMessage As String

    Private Function HasPassword(manager As ApplicationUserManager) As Boolean
        Dim appUser = manager.FindById(User.Identity.GetUserId())
        Return (appUser IsNot Nothing) ' AndAlso appUser.PasswordHash IsNot Nothing)
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim returnUrl = Request.QueryString("ReturnUrl")
        Dim loginpopup = Request.QueryString("loginpopup")

        If loginpopup = "S" Then
            Dim ctrl1 As Control = AppUtils.FindControlRecursive(Master, "ErrorMessage")
            If ctrl1 IsNot Nothing Then
                TryCast(ctrl1, System.Web.UI.WebControls.Literal).Text = "Conteúdo protegido. Faça login para continuar"
            End If


            'Dim ctrl2 As Control = AppUtils.FindControlRecursive(Master, "LogonControl")
            'If ctrl2 IsNot Nothing Then
            '    TryCast(ctrl2, ASPxPopupControl).ShowOnPageLoad = True
            'End If

        End If

        If Not IsPostBack Then
            ' Render success message
            Dim message = Request.QueryString("m")
            If message IsNot Nothing Then
                ' Strip the query string from action
                'Form.Action = ResolveUrl("~/Default")
                Form.Action = ResolveUrl("~/LoginAux")

                SuccessMessage = If(message = "ChangePwdSuccess", "Sua senha foi alterada com sucesso.",
                    If(message = "SetPwdSuccess", "Sua senha foi criada.",
                    If(message = "RemoveLoginSuccess", "The account was removed.",
                    If(message = "AddPhoneNumberSuccess", "Phone number has been added",
                    If(message = "RemovePhoneNumberSuccess", "Phone number was removed", String.Empty)))))
                SuccessMessagePlaceHolder.Visible = Not String.IsNullOrEmpty(SuccessMessage)
            End If
        End If

    End Sub
    Protected Sub btnLoginNow_Click(sender As Object, e As EventArgs) Handles btnLoginNow.Click
        'SE FOR admin@4t.com.br, AUTENTICA COMO RepoLocal
        If txtUsuario.Text.ToLower.Trim <> "admin@4t.com.br" And ConfigurationManager.AppSettings("authMode4T") = "BDCliente" Then
            'BLOCO DE CÓDIGO PARA TRATAR AUTENTICAÇÃO NO BD CLIENTE - ORACLE UAM
            Dim oradbConnMask As String = String.Empty

            If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                If ConfigurationManager.AppSettings("dashDbPointer") = "LocalBI4T" Then
                    oradbConnMask = ConfigurationManager.AppSettings("connOracleConnectionMask_LocalBI4T")
                ElseIf ConfigurationManager.AppSettings("dashDbPointer") = "DbUAMBI4T" Then
                    oradbConnMask = ConfigurationManager.AppSettings("connOracleConnectionMask_DbUAMBI4T")
                End If
            End If

            'TENTA ABRIR CONEXÃO COM O BD USANDO USUÁRIO E SENHA DIGITADOS PELO USUÁRIO, QUE É A AUTENTICAÇÃO authMode4T = BDCliente
            Dim oradb As String = String.Format(oradbConnMask, txtUsuario.Text, txtPassword.Text)
            Try
                Dim conn As OracleConnection = New OracleConnection(oradb)
                conn.Open()

                Dim managerCustom = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
                Dim signinManagerCustom = Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)()

                Dim userCustom = managerCustom.FindByName(txtUsuario.Text.ToLower.Trim)

                If userCustom IsNot Nothing Then
                    'ACHOU USUÁRIO
                    'QUER DIZER: INSERÇÃO DE NOVO TIPO Usuário
                    'CHECA SE JÁ EXISTE USUÁRIO NA ENTIDADE Usuario ANTES, INSERE OU ALTERA S5T.Usuario
                    Dim objUsuario = S5T.Usuario.LoadBypLogin(userCustom.UserName.Trim.ToUpper)

                    If objUsuario Is Nothing Then
                        Dim objNewUsuario As New S5T.Usuario
                        'objNewUsuario.oCadastro = objNew
                        objNewUsuario.pLogin = userCustom.UserName.Trim.ToUpper
                        objNewUsuario.pSenha = " "
                        objNewUsuario.pFlgAdmin = "N"
                        objNewUsuario.sStatus = True
                        objNewUsuario.xLoginReg = "ADMIN"
                        objNewUsuario.oIdUser = userCustom

                        objNewUsuario.Save()
                    Else
                        objUsuario.pSenha = " "
                        objUsuario.pFlgAdmin = "N"
                        objUsuario.sStatus = True
                        objUsuario.xLoginReg = "ADMIN"
                        objUsuario.oIdUser = userCustom

                        objUsuario.Save()
                    End If

                    'REMOVE TODOS OS ROLES
                    While userCustom.Roles.Count > 0
                        userCustom.Roles.Remove(userCustom.Roles(0))
                        userCustom.Save()
                    End While

                    'ADICIONA ROLES PERTINENTES
                    'LENDO A PARTIR DE QUERY EM BD
                    Dim cmd As New OracleCommand("select * from BI4T.V_ACESSO WHERE COD_USUARIO = :p0", conn) With {.CommandType = CommandType.Text}

                    cmd.Parameters.Add(":p0", OracleDbType.Varchar2).Value = userCustom.UserName.ToUpper

                    Dim dr As OracleDataReader = Nothing
                    Try
                        dr = cmd.ExecuteReader()
                        If dr.HasRows Then
                            Do While dr.Read
                                Dim objIdRole = S5T.IdRole.LoadByName(dr.Item("programa"))
                                If objIdRole IsNot Nothing Then
                                    userCustom.Roles.Add(objIdRole)
                                    userCustom.Save()
                                End If
                            Loop

                            dr.Close()
                        Else
                            Throw New Exception("Usuário sem permissão de acesso ao Sistema BI4T")
                        End If
                    Finally
                        conn.Close()
                        If (Not (dr) Is Nothing) Then
                            dr.Dispose()
                        End If
                    End Try

                    'LOGA SEM SENHA ASP.net IDENTITY

                    Session("DummySession") = "DummySession"
                    signinManagerCustom.SignIn(userCustom, True, True)
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
                Else
                    'NÃO ACHOU, CRIA NA HORA
                    Dim user = New IdUser() With {.UserName = txtUsuario.Text.ToLower.Trim, .Email = txtUsuario.Text.ToLower.Trim & "@altamogiana.com.br"} ', .oUsuario = objNewUsuario}

                    Dim resultCustom = managerCustom.Create(user)

                    If resultCustom.Succeeded Then
                        'QUER DIZER: INSERÇÃO DE NOVO TIPO Usuário
                        'CHECA SE JÁ EXISTE USUÁRIO NA ENTIDADE Usuario ANTES, INSERE OU ALTERA S5T.Usuario
                        Dim objUsuario = S5T.Usuario.LoadBypLogin(user.UserName.Trim.ToUpper)

                        If objUsuario Is Nothing Then
                            Dim objNewUsuario As New S5T.Usuario
                            'objNewUsuario.oCadastro = objNew
                            objNewUsuario.pLogin = user.UserName.Trim.ToUpper
                            objNewUsuario.pSenha = " "
                            objNewUsuario.pFlgAdmin = "N"
                            objNewUsuario.sStatus = True
                            objNewUsuario.xLoginReg = "ADMIN"
                            objNewUsuario.oIdUser = user

                            objNewUsuario.Save()
                        Else
                            objUsuario.pSenha = " "
                            objUsuario.pFlgAdmin = "N"
                            objUsuario.sStatus = True
                            objUsuario.xLoginReg = "ADMIN"
                            objUsuario.oIdUser = user

                            objUsuario.Save()
                        End If

                        'ADICIONA ROLES PERTINENTES
                        Dim cmd As New OracleCommand("select * from BI4T.V_ACESSO WHERE COD_USUARIO = :p0", conn) With {.CommandType = CommandType.Text}

                        cmd.Parameters.Add(":p0", OracleDbType.Varchar2).Value = user.UserName.ToUpper

                        Dim dr As OracleDataReader = Nothing
                        Try
                            dr = cmd.ExecuteReader()

                            If dr.HasRows Then
                                Do While dr.Read
                                    Dim objIdRole = S5T.IdRole.LoadByName(dr.Item("programa"))
                                    If objIdRole IsNot Nothing Then
                                        user.Roles.Add(objIdRole)
                                        user.Save()
                                    End If
                                Loop
                                dr.Close()
                            Else
                                Throw New Exception("Usuário sem permissão de acesso ao Sistema BI4T")
                            End If
                        Finally
                            conn.Close()
                            If (Not (dr) Is Nothing) Then
                                dr.Dispose()
                            End If
                        End Try

                        'LOGA SEM SENHA ASP.net IDENTITY
                        Session("DummySession") = "DummySession"

                        signinManagerCustom.SignIn(user, True, True)
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
                    End If
                End If
            Catch ex As Exception
                ErrorMessage.Text = ex.Message
                Exit Sub
            End Try
        Else
            'BLOCO DE CÓDIGO PARA TRATAR AUTENTICAÇÃO ASP.net IDENTITY BI4T AUTENTICAÇÃO authMode4T = RepoLocal

            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim signinManager = Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)()

            ' This doen't count login failures towards account lockout
            ' To enable password failures to trigger lockout, change to shouldLockout := True
            Session("DummySession") = "DummySession"

            Dim result = signinManager.PasswordSignIn(txtUsuario.Text, txtPassword.Text, True, shouldLockout:=False)

            Select Case result
                Case SignInStatus.Success
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)

                    Exit Select
                    'Case SignInStatus.LockedOut
                    '    Response.Redirect("/Account/Lockout")
                    '    Exit Select
                    'Case SignInStatus.RequiresVerification
                    '    Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                    '                                    Request.QueryString("ReturnUrl"),
                    '                                    RememberMe.Checked),
                    '                      True)
                    '    Exit Select
                Case Else
                    ErrorMessage.Text = "Login inválido"
                    'ErrorMessage.Visible = True
                    Exit Select
            End Select
        End If
    End Sub
End Class