Imports Microsoft.AspNet.Identity
Imports DevExpress.DataAccess.ConnectionParameters

Public Class LogAcessos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If

    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        Dim mysqlpar = New MySqlConnectionParameters

        mysqlpar.ServerName = "localhost"
        mysqlpar.DatabaseName = "s5tuam"
        mysqlpar.UserName = "root"
        mysqlpar.Password = "manager"

        e.ConnectionParameters = mysqlpar
    End Sub

    Private Sub ASPxDashboardViewer1_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashboardViewer1.CustomParameters
        e.Parameters(0).Value = New Date(Today.Year, 1, 1)
        e.Parameters(1).Value = New Date(Today.Year + 1, 1, 1)

    End Sub
End Class