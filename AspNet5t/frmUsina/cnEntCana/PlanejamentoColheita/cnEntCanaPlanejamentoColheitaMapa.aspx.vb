﻿Imports DevExpress.DataAccess.ConnectionParameters
Imports Microsoft.AspNet.Identity

Public Class cnEntCanaPlanejamentoColheitaMapa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            ASPxDashboardViewer1.DashboardId = AppUtils.dashboardEnumToString(dashboardsList.dashCnEntCanaPlanejamentoColheitaMapa)

            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If
    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

    Private Sub ASPxDashboardViewer1_DashboardLoading(sender As Object, e As DevExpress.DashboardWeb.DashboardLoadingEventArgs) Handles ASPxDashboardViewer1.DashboardLoading
        e.DashboardXml = AppUtils.dashXML(dashboardsList.dashCnEntCanaPlanejamentoColheitaMapa)
    End Sub
End Class