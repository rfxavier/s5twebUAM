Imports DevExpress.DataAccess.ConnectionParameters
Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity
Public Class cnEntCanaEntradasCana
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            ASPxDashboardViewer1.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaEntradasCana)
            ASPxDashboardViewer1.DataBind()

            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If
    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub
End Class