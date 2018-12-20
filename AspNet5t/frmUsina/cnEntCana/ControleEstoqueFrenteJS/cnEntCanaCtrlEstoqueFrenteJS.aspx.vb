Imports Microsoft.AspNet.Identity
Public Class cnEntCanaCtrlEstoqueFrenteJS
    Inherits System.Web.UI.Page

    Private _usuarioAtual As String = ""

    Protected ReadOnly Property usuarioAtual() As String
        Get
            Return Me._usuarioAtual
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            _usuarioAtual = User.Identity.GetUserName
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If
    End Sub
End Class