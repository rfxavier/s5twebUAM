Imports DevExpress.DataAccess.ConnectionParameters
Imports Microsoft.AspNet.Identity

Public Class cnEntCanaColheitaCertificados
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) And (Not IsCallback) Then
            ASPxDashboardViewer1.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaColheitaCertificados)
            ASPxDashboardViewer1.DataBind()

            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

            dtInicial.Date = New DateTime(Now.Date.Year, Now.Date.Month, Now.Date.Day, 0, 0, 0) 'New DateTime(2015, 10, 1, 0, 0, 0) 'Now
            dtFinal.Date = New DateTime(Now.Date.Year, Now.Date.Month, Now.Date.Day, 23, 59, 59) 'New DateTime(2015, 10, 1, 23, 59, 59)
        End If
    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        'MsgBox(dataReferencia.Date)
    End Sub

    Private Sub ASPxDashboardViewer1_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashboardViewer1.CustomParameters

        e.Parameters(0).Value = dtInicial.Date.ToString("yyyyMMddHH:mm")
        e.Parameters(1).Value = New DateTime(dtFinal.Date.Year, dtFinal.Date.Month, dtFinal.Date.Day, 23, 59, 59).ToString("yyyyMMddHH:mm")

    End Sub

End Class