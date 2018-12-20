Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin
Imports DevExpress.Web
Public Class DefaultMain
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


            Dim ctrl2 As Control = AppUtils.FindControlRecursive(Master, "LogonControl")
            If ctrl2 IsNot Nothing Then
                TryCast(ctrl2, ASPxPopupControl).ShowOnPageLoad = True
            End If

        End If

        If Not IsPostBack Then
            ' Render success message
            Dim message = Request.QueryString("m")
            If message IsNot Nothing Then
                ' Strip the query string from action
                Form.Action = ResolveUrl("~/Default")

                SuccessMessage = If(message = "ChangePwdSuccess", "Sua senha foi alterada com sucesso.",
                    If(message = "SetPwdSuccess", "Sua senha foi criada.",
                    If(message = "RemoveLoginSuccess", "The account was removed.",
                    If(message = "AddPhoneNumberSuccess", "Phone number has been added",
                    If(message = "RemovePhoneNumberSuccess", "Phone number was removed", String.Empty)))))
                SuccessMessagePlaceHolder.Visible = Not String.IsNullOrEmpty(SuccessMessage)
            End If
        End If

    End Sub

End Class