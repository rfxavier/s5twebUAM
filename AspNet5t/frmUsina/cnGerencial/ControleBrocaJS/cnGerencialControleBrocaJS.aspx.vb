Imports Microsoft.AspNet.Identity
Public Class cnGerencialControleBrocaJS
    Inherits System.Web.UI.Page

    Private _tipoPraga As String = ""

    Protected ReadOnly Property tipoPraga() As String
        Get
            Return Me._tipoPraga
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            _tipoPraga = Request.QueryString("tipo")
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If

    End Sub

End Class