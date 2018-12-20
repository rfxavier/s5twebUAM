Public Class LogAdmin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddHandler AppDomain.CurrentDomain.FirstChanceException, AddressOf AppHelper.HandleFirstTimeExceptions

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        RemoveHandler AppDomain.CurrentDomain.FirstChanceException, AddressOf AppHelper.HandleFirstTimeExceptions

    End Sub
End Class