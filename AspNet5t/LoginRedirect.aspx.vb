Public Class LoginRedirect
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim logout = Request.QueryString("logout")

        If logout = "S" Then
            Session("DummySession") = "DummySession"

            Context.GetOwinContext().Authentication.SignOut()
            Response.Redirect("~/Default.aspx")
        End If

        Dim returnUrl = Request.QueryString("ReturnUrl")
        Dim redirectUrl As String = String.Empty

        If Not [String].IsNullOrEmpty(returnUrl) Then
            redirectUrl = "~/LoginAux.aspx?loginpopup=S&ReturnUrl=" & returnUrl
        Else
            redirectUrl = "~/LoginAux.aspx"
        End If

        Response.Redirect(redirectUrl)
    End Sub

End Class