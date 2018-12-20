Imports DevExpress.DataAccess.ConnectionParameters

Public Class cnOficinaDetalhamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dash As New Win_Dashboards.dashCnOficinaDetalhamento
        ASPxDashboardViewer1.DashboardSource = dash
        ASPxDashboardViewer1.DataBind()

    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

End Class