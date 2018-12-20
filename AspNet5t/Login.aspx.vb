Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports S5T
Imports Owin

Public Class Login1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLoginNow_Click(sender As Object, e As EventArgs) Handles btnLoginNow.Click
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim signinManager = Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)()

        ' This doen't count login failures towards account lockout
        ' To enable password failures to trigger lockout, change to shouldLockout := True
        Dim result = signinManager.PasswordSignIn(txtUsuario.Text, txtPassword.Text, chkLembrar.Checked, shouldLockout:=False)

        Select Case result
            Case SignInStatus.Success
                'Dim ctlhlUserName As DevExpress.Web.ASPxHyperLink = DirectCast(LoginView1.FindControl("hlUserName"), DevExpress.Web.ASPxHyperLink)

                'ctlhlUserName.Text = "teste" 'Parent.Page.User.Identity.GetUserName

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
        'End If

    End Sub

    Protected Sub btnCancelLogin_Click(sender As Object, e As EventArgs) Handles btnCancelLogin.Click
        Response.Redirect("/Default.aspx")
    End Sub
End Class